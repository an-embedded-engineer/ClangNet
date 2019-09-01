using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    // Opaque pointer representing client data that will be passed through
    // to various callbacks and visitors.
    // void*
    using CXClientData = IntPtr;

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // A group of CXDiagnostics.
    // void*
    using CXDiagnosticSet = IntPtr;

    // The client's data object that is associated with a CXFile.
    // void*
    using CXIdxClientFile = IntPtr;

    // The client's data object that is associated with an AST file (PCH or module).
    // void*
    using CXIdxClientASTFile = IntPtr;

    // The client's data object that is associated with a semantic container of entities.
    // void*
    using CXIdxClientContainer = IntPtr;

    // const CXIdxDeclInfo*
    using ConstCXIdxDeclInfoPtr = IntPtr;

    // const CXIdxIncludedFileInfo*
    using ConstCXIdxIncludedFileInfoPtr = IntPtr;

    // const CXIdxImportedASTFileInfo*
    using ConstCXIdxImportedASTFileInfoPtr = IntPtr;

    // const CXIdxEntityRefInfo*
    using ConstCXIdxEntityRefInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Abort Query Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="reserved">Reserved</param>
    /// <returns>0 to continue, and non-zero to abort.</returns>
    /// <remarks>
    /// Called periodically to check whether indexing should be aborted.
    /// Should return 0 to continue, and non-zero to abort.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate int AbortQueryHandler(CXClientData client_data, VoidPtr reserved);

    /// <summary>
    /// Native Clang Diagnostic Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="diagnostic_set">Diagnostic Set</param>
    /// <param name="reserved">Reserved</param>
    /// <remarks>
    /// Called at the end of indexing; passes the complete diagnostic set.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate void DiagnosticHandler(CXClientData client_data, CXDiagnosticSet diagnostic_set, VoidPtr reserved);

    /// <summary>
    /// Native Clang Entered Main File Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="main_file">Main File</param>
    /// <param name="reserved">Reserved</param>
    /// <returns>Index Client File</returns>
    /// <remarks>
    /// Called to Entered Main File
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate CXIdxClientFile EnteredMainFileHandler(CXClientData client_data, CXFile main_file, VoidPtr reserved);

    /// <summary>
    /// Native Clang Preprocess Included File Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="index_include_file_info">Index Included File Info</param>
    /// <returns>Index Client File</returns>
    /// <remarks>
    /// Called when a file gets #included/#imported.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate CXIdxClientFile PpIncludedFileHandler(CXClientData client_data, ConstCXIdxIncludedFileInfoPtr index_include_file_info);

    /// <summary>
    /// Native Clang Imported AST File Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="index_imported_ast_file_info">Index Imported AST File Info</param>
    /// <returns>Index Client AST File</returns>
    /// <remarks>
    /// Called when a AST file (PCH or module) gets imported.
    ///
    /// AST files will not get indexed(there will not be callbacks to index all
    /// the entities in an AST file). The recommended action is that, if the AST
    /// file is not already indexed, to initiate a new indexing job specific to
    /// the AST file.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate CXIdxClientASTFile ImportedASTFileHandler(CXClientData client_data, ConstCXIdxImportedASTFileInfoPtr index_imported_ast_file_info);

    /// <summary>
    /// Native Clang Started Translation Unit Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="reserved">Reserved</param>
    /// <returns>Index Client Container</returns>
    /// <remarks>
    /// Called at the beginning of indexing a translation unit.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate CXIdxClientContainer StartedTranslationUnitHandler(CXClientData client_data, VoidPtr reserved);

    /// <summary>
    /// Native Clang Index Declaration Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="index_decl_info">Index Declaration Info</param>
    /// <remarks>
    /// Called to Index a Declaration
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate void IndexDeclarationHandler(CXClientData client_data, ConstCXIdxDeclInfoPtr index_decl_info);

    /// <summary>
    /// Native Clang Index Entity Reference Handler
    /// </summary>
    /// <param name="client_data">Client Data</param>
    /// <param name="index_entity_ref_info">Index Entity Reference Info</param>
    /// <remarks>
    /// Called to index a reference of an entity.
    /// </remarks>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate void IndexEntityReferenceHandler(CXClientData client_data, ConstCXIdxEntityRefInfoPtr index_entity_ref_info);

    /// <summary>
    /// Native Clang Indexer Callbacks
    /// </summary>
    /// <remarks>
    /// A group of callbacks used by <c>clang_indexSourceFile()</c> and
    /// <c>clang_indexTranslationUnit()</c>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct IndexerCallbacks
    {
        /// <summary>
        /// Clang Abort Query Handler
        /// </summary>
        /// <remarks>
        /// Called periodically to check whether indexing should be aborted.
        /// Should return 0 to continue, and non-zero to abort.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public AbortQueryHandler AbortQuery;

        /// <summary>
        /// Clang Diagnostic Handler
        /// </summary>
        /// <remarks>
        /// Called at the end of indexing; passes the complete diagnostic set.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public DiagnosticHandler Diagnostic;

        /// <summary>
        /// Clang Entered Main File Handler
        /// </summary>
        /// <remarks>
        /// Called to Entered Main File
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public EnteredMainFileHandler EnteredMainFile;

        /// <summary>
        /// Clang Preprocess Included File Handler
        /// </summary>
        /// <remarks>
        /// Called when a file gets #included/#imported.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public PpIncludedFileHandler PpIncludedFile;

        /// <summary>
        /// Clang Imported AST File Handler
        /// </summary>
        /// <remarks>
        /// Called when a AST file (PCH or module) gets imported.
        ///
        /// AST files will not get indexed(there will not be callbacks to index all
        /// the entities in an AST file). The recommended action is that, if the AST
        /// file is not already indexed, to initiate a new indexing job specific to
        /// the AST file.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public ImportedASTFileHandler ImportedASTFile;

        /// <summary>
        /// Clang Started Translation Unit Handler
        /// </summary>
        /// <remarks>
        /// Called at the beginning of indexing a translation unit.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public StartedTranslationUnitHandler StartedTranslationUnit;

        /// <summary>
        /// Clang Index Declaration Handler
        /// </summary>
        /// <remarks>
        /// Called to Index a Declaration
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public IndexDeclarationHandler IndexDeclaration;

        /// <summary>
        /// Clang Index Entity Referene Handler
        /// </summary>
        /// <remarks>
        /// Called to index a reference of an entity.
        /// </remarks>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public IndexEntityReferenceHandler IndexEntityReference;
    }
}
