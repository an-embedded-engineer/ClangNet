using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Translation Unit Parse Setting
    /// </summary>
    public class TranslationUnitParseSetting
    {
        /// <summary>
        /// Source Path List
        /// </summary>
        public List<string> Sources { get; set; } = new List<string>();

        /// <summary>
        /// Command Line Arguments
        /// </summary>
        public List<string> CommandLineArgs { get; set; } = new List<string>();

        /// <summary>
        /// Translation Unit Parse Options
        /// </summary>
        public TranslationUnitFlags ParseOptions { get; set; } = TranslationUnitFlags.None;

        /// <summary>
        /// Display Diagnostics Flag
        /// </summary>
        public bool DisplayDiag { get; set; } = true;

        /// <summary>
        /// Dump AST Flag
        /// </summary>
        public bool DumpAST { get; set; } = true;
    }
}
