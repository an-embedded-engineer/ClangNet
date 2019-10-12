using System;
using System.Collections.Generic;
using System.IO;
using ClangNet;

namespace ClangNet.Samples
{
    /// <summary>
    /// Cursor Visitor Sample
    /// </summary>
    public class CursorVisitor
    {
        /// <summary>
        /// Execute Cursor Visitor Sample
        /// </summary>
        /// <param name="src_path">Source Path</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="options">Translation Unit Parse Options</param>
        /// <param name="display_diag">Display Diagnostics</param>
        public static void Execute(string src_path, string[] command_line_args, TranslationUnitFlags options = TranslationUnitFlags.None, bool display_diag = false)
        {
            var impl = new CursorVisitorImpl();

            impl.Execute(src_path, command_line_args, options, display_diag);
        }

        /// <summary>
        /// Cursor Visitor Implementation
        /// </summary>
        internal class CursorVisitorImpl : ATranslationUnitHandler
        {
            /// <summary>
            /// System Include Header Paths
            /// </summary>
            private SortedSet<string> SystemIncludes { get; } = new SortedSet<string>();

            /// <summary>
            /// User Include Header Paths
            /// </summary>
            private SortedSet<string> UserIncludes { get; } = new SortedSet<string>();

            /// <summary>
            /// Execute Core Logic
            /// </summary>
            /// <param name="index">Clang Index</param>
            /// <param name="tu">Clang Translation Unit</param>
            protected override void ExecuteCore(ClangIndex index, ClangTranslationUnit tu)
            {
                var cursor = tu.Cursor;

                this.SendMessage($"AST Dump:");

                cursor.VisitChildren(this.Visitor, 0);

                this.DumpIncludes("System", this.SystemIncludes);

                this.DumpIncludes("User", this.UserIncludes);
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
                    var file_path = loc.GetFilePath(true);

                    if (loc.IsInSystemHeader == true)
                    {
                        this.SystemIncludes.Add(file_path);
                    }
                    else
                    {
                        this.UserIncludes.Add(file_path);

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
                var indent = new string(' ', depth * 2);

                var kind = cursor.Kind;

                var name = cursor.Spelling;

                var loc = cursor.Location.ToStringEx();

                this.SendMessage($"{indent}[{kind}] {name} @ {loc}");

                cursor.VisitChildren(this.Visitor, depth + 1);
            }

            /// <summary>
            /// Dump Include File Paths
            /// </summary>
            /// <param name="type">Include File Type</param>
            /// <param name="includes">Include File Paths</param>
            private void DumpIncludes(string type, ISet<string> includes)
            {
                this.SendMessage();

                this.SendMessage($"{type} Include Files:");

                foreach (var inc in includes)
                {
                    this.SendMessage($"{inc}");
                }
            }
        }
    }
}
