using System;
using System.IO;

namespace ClangNet.Samples
{
    /// <summary>
    /// Translation Units Parser
    /// </summary>
    public static class TranslationUnitsParser
    {
        /// <summary>
        /// Parse Translation Units
        /// </summary>
        /// <param name="setting">Translation Unit Parse Setting</param>
        /// <returns>Translation Unit Map</returns>
        public static TranslationUnitMap Parse(TranslationUnitParseSetting setting)
        {
            var impl = new TranslationUnitsParserImpl();

            var map = impl.Execute(setting);

            return map;
        }

        /// <summary>
        /// Translation Units Parser Implementation
        /// </summary>
        public class TranslationUnitsParserImpl : AMessageable
        {
            /// <summary>
            /// Translation Unit Parse Setting
            /// </summary>
            private TranslationUnitParseSetting Setting { get; set; }

            /// <summary>
            /// Current Translation Unit
            /// </summary>
            private TranslationUnitInfo CurrentTranslationUnit { get; set; }

            /// <summary>
            /// Current Behavior
            /// </summary>
            private BehaviorInfo CurrentBehavior { get; set; }

            /// <summary>
            /// Translation Unit Map
            /// </summary>
            private TranslationUnitMap TranslationUnitMap { get; set; } = new TranslationUnitMap();

            /// <summary>
            /// Execute
            /// </summary>
            /// <param name="setting">Translation Unit Parse Setting</param>
            /// <returns>Translation Unit Map</returns>
            public TranslationUnitMap Execute(TranslationUnitParseSetting setting)
            {
                this.Setting = setting;

                var display_diag = setting.DisplayDiag;

                var src_path_list = setting.Sources;

                var command_line_args = setting.CommandLineArgs.ToArray();

                var options = setting.ParseOptions;

                using (var index = Clang.CreateIndex(false, display_diag))
                {
                    foreach (var src_path in src_path_list)
                    {
                        if (File.Exists(src_path))
                        {
                            using (var tu = index.ParseTranslationUnit(src_path, command_line_args, new ClangUnsavedFile[0], options))
                            {
                                this.ExecuteCore(index, tu);
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException($"Source File Not Found :{src_path}");
                        }
                    }
                }

                return this.TranslationUnitMap;
            }

            /// <summary>
            /// Execute Translation Unit Handler Core
            /// </summary>
            /// <param name="index">Clang Index</param>
            /// <param name="tu">Clang Translation Unit</param>
            private void ExecuteCore(ClangIndex index, ClangTranslationUnit tu)
            {
                if (this.Setting.DumpAST)
                {
                    this.SendMessage($"AST Dump:");
                }

                this.VisitChild(tu.Cursor, 0);
            }

            /// <summary>
            /// Cursor Visitor
            /// </summary>
            /// <param name="cursor">Clang Cursor</param>
            /// <param name="parent">Parent Clang Cursor</param>
            /// <param name="depth">Depth</param>
            /// <returns>Child Visit Result</returns>
            private ChildVisitResult Visitor(ClangCursor cursor, ClangCursor parent, int depth)
            {
                var loc = cursor.Location;

                if (loc.IsFromMainFile == true)
                {
                    this.VisitChild(cursor, depth);
                }
                else
                {
                    if (loc.IsInSystemHeader == true)
                    {
                        /* Nothing to do */
                    }
                    else
                    {
                        this.VisitChild(cursor, depth);
                    }
                }

                return ChildVisitResult.Continue;
            }

            /// <summary>
            /// Visit Child Clang Cursor
            /// </summary>
            /// <param name="cursor">Clang Cursor</param>
            /// <param name="depth">Depth</param>
            private void VisitChild(ClangCursor cursor, int depth)
            {
                if (this.Setting.DumpAST)
                {
                    this.DumpAstInfo(cursor, depth);
                }

                this.AnalyseInvokationInfo(cursor);

                cursor.VisitChildren(this.Visitor, depth + 1);
            }

            /// <summary>
            /// Dump AST Information
            /// </summary>
            /// <param name="cursor">Clang Cursor</param>
            /// <param name="depth">Depth</param>
            private void DumpAstInfo(ClangCursor cursor, int depth)
            {
                var indent = new string(' ', depth * 2);

                var kind = cursor.Kind;

                var name = cursor.Spelling;

                var loc = cursor.Location.ToStringEx();

                this.SendMessage($"{indent}[{kind}] {name} @ {loc}");
            }

            /// <summary>
            /// Analyse Invokation Info
            /// </summary>
            /// <param name="cursor">Clang Cursor</param>
            private void AnalyseInvokationInfo(ClangCursor cursor)
            {
                switch (cursor.Kind)
                {
                    case CursorKind.TranslationUnit:
                        this.CurrentTranslationUnit = new TranslationUnitInfo(cursor);
                        this.TranslationUnitMap.Add(this.CurrentTranslationUnit);
                        break;
                    case CursorKind.Constructor:
                        this.CurrentBehavior = BehaviorInfoFactory.Create(cursor);
                        this.CurrentTranslationUnit.AddBehavior(this.CurrentBehavior);
                        break;
                    case CursorKind.Destructor:
                        this.CurrentBehavior = BehaviorInfoFactory.Create(cursor);
                        this.CurrentTranslationUnit.AddBehavior(this.CurrentBehavior);
                        break;
                    case CursorKind.FunctionDeclaration:
                        this.CurrentBehavior = BehaviorInfoFactory.Create(cursor);
                        this.CurrentTranslationUnit.AddBehavior(this.CurrentBehavior);
                        break;
                    case CursorKind.CXXMethod:
                        this.CurrentBehavior = BehaviorInfoFactory.Create(cursor);
                        this.CurrentTranslationUnit.AddBehavior(this.CurrentBehavior);
                        break;
                    case CursorKind.CallExpression:
                        var invokation_info = new InvokationInfo(cursor);
                        this.CurrentBehavior.AddInvokation(invokation_info);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
