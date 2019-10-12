namespace ClangNet.Samples
{
    /// <summary>
    /// Abstract Translation Unit Handler
    /// </summary>
    internal abstract class ATranslationUnitHandler : AMessageable
    {
        /// <summary>
        /// Source Path
        /// </summary>
        public string SourcePath { get; private set; }

        /// <summary>
        /// Command Line Arguments
        /// </summary>
        public string[] CommandLineArgs { get; private set; }

        /// <summary>
        /// Translation Unit Parse Options
        /// </summary>
        public TranslationUnitFlags ParseOptions { get; private set; }

        /// <summary>
        /// Display Diagnostics Flag
        /// </summary>
        public bool DisplayDiagnostic { get; private set; }

        /// <summary>
        /// Execute Translation Unit Handler Core
        /// </summary>
        /// <param name="index">Clang Index</param>
        /// <param name="tu">Clang Translation Unit</param>
        protected abstract void ExecuteCore(ClangIndex index, ClangTranslationUnit tu);

        /// <summary>
        /// Execute Translation Unit Handler
        /// </summary>
        /// <param name="src_path">Source Path</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="options">Parse Options</param>
        /// <param name="display_diag">Display Diagnostics Flag</param>
        public void Execute(string src_path, string[] command_line_args, TranslationUnitFlags options = TranslationUnitFlags.None, bool display_diag = false)
        {
            this.SourcePath = src_path;

            this.CommandLineArgs = command_line_args;

            this.ParseOptions = options;

            this.DisplayDiagnostic = display_diag;

            using (var index = Clang.CreateIndex(false, display_diag))
            {
                using (var tu = index.ParseTranslationUnit(src_path, command_line_args, new ClangUnsavedFile[0], options))
                {
                    this.ExecuteCore(index, tu);
                }
            }
        }
    }
}
