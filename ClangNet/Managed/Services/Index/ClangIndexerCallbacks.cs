using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Indexer Callbacks
    /// </summary>
    public class ClangIndexerCallbacks
    {
        /// <summary>
        /// Abort Query Event
        /// </summary>
        public event Func<IntPtr, bool> AbortQuery;
        /// <summary>
        /// Diagnostic Event
        /// </summary>
        public event Action<IntPtr, ClangDiagnosticSet> Diagnostic;
        /// <summary>
        /// Entered Main File Event
        /// </summary>
        public event Func<IntPtr, ClangFile, ClangIndexClientFile> EnteredMainFile;
        /// <summary>
        /// Preprocess Included File Event
        /// </summary>
        public event Func<IntPtr, ClangIndexIncludedFileInfo, ClangIndexClientFile> PreprocessIncludedFile;
        /// <summary>
        /// Imported AST File Event
        /// </summary>
        public event Func<IntPtr, ClangIndexImportedASTFileInfo, ClangIndexClientASTFile> ImportedASTFile;
        /// <summary>
        /// Started Translation Unit Event
        /// </summary>
        public event Func<IntPtr, ClangIndexClientContainer> StartedTranslationUnit;
        /// <summary>
        /// Index Declaration Event
        /// </summary>
        public event Action<IntPtr, ClangIndexDeclarationInfo> IndexDeclaration;
        /// <summary>
        /// Index Entity Reference Event
        /// </summary>
        public event Action<IntPtr, ClangIndexEntityReferenceInfo> IndexEntityReference;

        /// <summary>
        /// Convert to Native Clang Indexer Calbacks
        /// </summary>
        /// <returns>Native Clang Indexer Calbacks</returns>
        internal IndexerCallbacks ToNative()
        {
            var native_callbacks = new IndexerCallbacks();

            if (this.AbortQuery != null)
                native_callbacks.AbortQuery =
                    (client_data, reserved) => this.AbortQuery(client_data).ToInt();

            if (this.Diagnostic != null)
                native_callbacks.Diagnostic =
                    (client_data, diagnostics, reserved) => this.Diagnostic(client_data, new ClangDiagnosticSet(diagnostics));

            if (this.EnteredMainFile != null)
                native_callbacks.EnteredMainFile =
                    (client_data, file, reserved) => this.EnteredMainFile(client_data, new ClangFile(file)).Address;

            if (this.PreprocessIncludedFile != null)
                native_callbacks.PpIncludedFile =
                    (client_data, included_file) => this.PreprocessIncludedFile(client_data, new ClangIndexIncludedFileInfo(included_file)).Address;

            if (this.ImportedASTFile != null)
                native_callbacks.ImportedASTFile =
                    (client_data, imported_ast_file) => this.ImportedASTFile(client_data, new ClangIndexImportedASTFileInfo(imported_ast_file)).Address;

            if (this.StartedTranslationUnit != null)
                native_callbacks.StartedTranslationUnit =
                    (client_data, reserved) => this.StartedTranslationUnit(client_data).Address;

            if (this.IndexDeclaration != null)
                native_callbacks.IndexDeclaration =
                    (client_data, decl_info) => this.IndexDeclaration(client_data, new ClangIndexDeclarationInfo(decl_info));

            if (this.IndexEntityReference != null)
                native_callbacks.IndexEntityReference =
                    (client_data, entity_ref_info) => this.IndexEntityReference(client_data, new ClangIndexEntityReferenceInfo(entity_ref_info));

            return native_callbacks;
        }
    }
}
