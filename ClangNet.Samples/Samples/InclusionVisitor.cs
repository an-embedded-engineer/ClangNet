using System;
using System.Collections.Generic;
using System.Text;

namespace ClangNet.Samples
{
    /// <summary>
    /// Inclusion Visitor Sample
    /// </summary>
    public class InclusionVisitor
    {
        /// <summary>
        /// Execute Inclusion Visitor Sample
        /// </summary>
        /// <param name="src_path">Source Path</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="options">Translation Unit Parse Options</param>
        /// <param name="display_diag">Display Diagnostics</param>
        public static void Execute(string src_path, string[] command_line_args, TranslationUnitFlags options = TranslationUnitFlags.None, bool display_diag = false)
        {
            var impl = new InclusionVisitorImpl();

            impl.Execute(src_path, command_line_args, options, display_diag);
        }

        /// <summary>
        /// Inclusion Visitor Implementation
        /// </summary>
        internal class InclusionVisitorImpl : ATranslationUnitHandler
        {
            /// <summary>
            /// Execute Core Logic
            /// </summary>
            /// <param name="index">Clang Index</param>
            /// <param name="tu">Clang Translation Unit</param>
            protected override void ExecuteCore(ClangIndex index, ClangTranslationUnit tu)
            {
                var cursor = tu.Cursor;

                this.SendMessage($"Inclusion Tree Dump:");

                tu.GetInclusions(this.Visitor, IntPtr.Zero);
            }

            /// <summary>
            /// Inclusion Visitor
            /// </summary>
            /// <param name="file">Clang File</param>
            /// <param name="location_stack">Clang Source Location Stack</param>
            /// <param name="client_data">Native Client Data Pointer</param>
            private void Visitor(ClangFile file, ClangSourceLocation[] location_stack, IntPtr client_data)
            {
                var depth = location_stack.Length;

                var indent = new string(' ', depth * 2);

                var filename = file.ToFullPath();

                this.SendMessage($"{indent}{filename}");
            }
        }
    }
}
