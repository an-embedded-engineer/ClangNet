#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // An "index" that consists of a set of translation units that would
    // typically be linked together into an executable or library.
    // void*
    using CXIndex = IntPtr;

    // An opaque type representing target information for a given translation unit.
    // struct CXTargetInfoImpl*
    using CXTargetInfo = IntPtr;

    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // Opaque pointer representing client data that will be passed through
    // to various callbacks and visitors.
    // void*
    using CXClientData = IntPtr;

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // The client's data object that is associated with a CXFile.
    // void*
    using CXIdxClientFile = IntPtr;

    // The client's data object that is associated with a semantic entity.
    // void*
    using CXIdxClientEntity = IntPtr;

    // The client's data object that is associated with a semantic container or entities.
    // void*
    using CXIdxClientContainer = IntPtr;

    // An indexing action/session, to be applied to one or multiple translation units.
    // void*
    using CXIndexAction = IntPtr;

    // const CXIdxAttrInfo*
    using ConstCXIdxAttrInfoPtr = IntPtr;

    // const CXIdxDeclInfo*
    using ConstCXIdxDeclInfoPtr = IntPtr;

    // const CXIdxObjCContainerDeclInfo*
    using ConstCXIdxObjCContainerDeclInfoPtr = IntPtr;

    // const CXIdxObjCProtocolRefListInfo*
    using ConstCXIdxObjCProtocolRefListInfoPtr = IntPtr;

    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    // const CXIdxObjCInterfaceDeclInfo*
    using ConstCXIdxObjCInterfaceDeclInfoPtr = IntPtr;

    // const CXIdxObjCCategoryDeclInfo*
    using ConstCXIdxObjCCategoryDeclInfoPtr = IntPtr;

    // const CXIdxObjCPropertyDeclInfo*
    using ConstCXIdxObjCPropertyDeclInfoPtr = IntPtr;

    // const CXIdxIBOutletCollectionAttrInfo*
    using ConstCXIdxIBOutletCollectionAttrInfoPtr = IntPtr;

    // const CXIdxCXXClassDeclInfo*
    using ConstCXIdxCXXClassDeclInfoPtr = IntPtr;

    // const CXIdxContainerInfo*
    using ConstCXIdxContainerInfoPtr = IntPtr;

    /// <summary>
    /// Visitor invoked for each field found by a traversal.
    ///
    /// This visitor function will be invoked for each field found by
    /// <c>clang_Type_visitFields</c>. Its first argument is the cursor being
    /// visited, its second argument is the client data provided to
    /// <c>clang_Type_visitFields</c>.
    ///
    /// The visitor should return one of the <c>CXVisitorResult</c> values
    /// to direct <c>clang_Type_visitFields</c>.
    /// </summary>
    /// <param name="cursor">Cursor</param>
    /// <param name="client_data">Client Data</param>
    /// <returns>Visitor Result</returns>
    internal delegate VisitorResult CXFieldVisitor(CXCursor cursor, CXClientData client_data);

    /// <summary>
    /// Libclang P/Invoke : Higher Level API
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Find references of a declaration in a specific file.
        /// </summary>
        /// <param name="cursor">pointing to a declaration or a reference of one.</param>
        /// <param name="file">to search for references.</param>
        /// <param name="visitor">
        /// callback that will receive pairs of CXCursor/CXSourceRange for each reference found.
        /// The CXSourceRange will point inside the file; if the reference is inside
        /// a macro(and not a macro argument) the CXSourceRange will be invalid.
        /// </param>
        /// <returns>one of the CXResult enumerators.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern FindResult clang_findReferencesInFile(CXCursor cursor, CXFile file, CXCursorAndRangeVisitor visitor);

        /// <summary>
        /// Find #import/#include directives in a specific file.
        /// </summary>
        /// <param name="tu">translation unit containing the file to query.</param>
        /// <param name="file">to search for #import/#include directives.</param>
        /// <param name="visitor">callback that will receive pairs of CXCursor/CXSourceRange for each directive found.</param>
        /// <returns>one of the CXResult enumerators.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern FindResult clang_findIncludesInFile(CXTranslationUnit tu, CXFile file, CXCursorAndRangeVisitor visitor);

        /// <summary>
        /// Check specified Index Entity Kind is Entity Objective-C Container Kind
        /// </summary>
        /// <param name="index_entity_kind">Index Entity Kind</param>
        /// <returns>
        /// 0 : Not Entity Objective-C Container Kind
        /// Other : Entity Objective-C Container Kind
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_index_isEntityObjCContainerKind(IndexEntityKind index_entity_kind);

        /// <summary>
        /// Get Objective-C Container Declaration Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>Objective-C Container Declaration Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxObjCContainerDeclInfoPtr clang_index_getObjCContainerDeclInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// Get Objective-C Interface Declaration Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>Objective-C Interface Declaration Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxObjCInterfaceDeclInfoPtr clang_index_getObjCInterfaceDeclInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// Get Objective-C Category Declaration Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>Objective-C Category Declaration Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxObjCCategoryDeclInfoPtr clang_index_getObjCCategoryDeclInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// Get Objective-C Protocol Reference List Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>Objective-C Protocol Reference List Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxObjCProtocolRefListInfoPtr clang_index_getObjCProtocolRefListInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// Get Objective-C Property Declaration Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>Objective-C Property Declaration Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxObjCPropertyDeclInfoPtr clang_index_getObjCPropertyDeclInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// Get IBOutlet Collection AttributeInfo
        /// </summary>
        /// <param name="index_attr_info">Index Attribute Info</param>
        /// <returns>IBOutlet Collection AttributeInfo</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxIBOutletCollectionAttrInfoPtr clang_index_getIBOutletCollectionAttrInfo(ConstCXIdxAttrInfoPtr index_attr_info);

        /// <summary>
        /// Get C++ Class Declaration Info
        /// </summary>
        /// <param name="index_decl_info">Index Declaration Info</param>
        /// <returns>C++ Class Declaration Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCXIdxCXXClassDeclInfoPtr clang_index_getCXXClassDeclInfo(ConstCXIdxDeclInfoPtr index_decl_info);

        /// <summary>
        /// For retrieving a custom CXIdxClientContainer attached to a container.
        /// </summary>
        /// <param name="index_container_info">Index Container Info</param>
        /// <returns>Index Client Container</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXIdxClientContainer clang_index_getClientContainer(ConstCXIdxContainerInfoPtr index_container_info);

        /// <summary>
        /// For setting a custom CXIdxClientContainer attached to a container.
        /// </summary>
        /// <param name="index_container_info">Index Container Info</param>
        /// <param name="index_client_container">Index Client Container</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_index_setClientContainer(ConstCXIdxContainerInfoPtr index_container_info, CXIdxClientContainer index_client_container);

        /// <summary>
        /// For retrieving a custom CXIdxClientEntity attached to an entity.
        /// </summary>
        /// <param name="index_entity_info">Index Entity Info</param>
        /// <returns>Index Client Entity</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXIdxClientEntity clang_index_getClientEntity(ConstCXIdxEntityInfoPtr index_entity_info);

        /// <summary>
        /// For setting a custom CXIdxClientEntity attached to an entity.
        /// </summary>
        /// <param name="index_entity_info">Index Entity Info</param>
        /// <param name="index_client_entity">Index Client Entity</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_index_setClientEntity(ConstCXIdxEntityInfoPtr index_entity_info, CXIdxClientEntity index_client_entity);

        /// <summary>
        /// An indexing action/session, to be applied to one or multiple
        /// translation units.
        /// </summary>
        /// <param name="index">The index object with which the index action will be associated.</param>
        /// <returns>Index Action</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXIndexAction clang_IndexAction_create(CXIndex index);

        /// <summary>
        /// Destroy the given index action.
        ///
        /// The index action must not be destroyed until all of the translation units
        /// created within that index action have been destroyed.
        /// </summary>
        /// <param name="index_action">Index Action</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_IndexAction_dispose(CXIndexAction index_action);

        /// <summary>
        /// Index the given source file and the translation unit corresponding
        /// to that file via callbacks implemented through #IndexerCallbacks.
        /// </summary>
        /// <param name="index_action">Index Action</param>
        /// <param name="client_data">
        /// pointer data supplied by the client, which will
        /// be passed to the invoked callbacks.
        /// </param>
        /// <param name="index_callbacks">
        /// Pointer to indexing callbacks that the client
        /// implements.
        /// </param>
        /// <param name="index_callbacks_size">
        /// Size of <c>IndexerCallbacks</c> structure that gets
        /// passed in <paramref name="index_callbacks"/>.</param>
        /// <param name="index_options">
        /// A bitmask of options that affects how indexing is
        /// performed.This should be a bitwise OR of the CXIndexOpt_XXX flags.
        /// </param>
        /// <param name="source_filename">
        /// The name of the source file to load, or NULL if the
        /// source file is included in <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="command_line_args">
        /// The command-line arguments that would be
        /// passed to the <c>clang</c> executable if it were being invoked out-of-process.
        /// These command-line options will be parsed and will affect how the translation
        /// unit is parsed.Note that the following options are ignored: '-c',
        /// '-emit-ast', '-fsyntax-only' (which is the default), and '-o &lt;output file&gt;'.
        /// </param>
        /// <param name="num_command_line_args">
        /// The number of command-line arguments in
        /// <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="unsaved_files">
        /// the files that have not yet been saved to disk
        /// but may be required for code completion, including the contents of
        /// those files.
        /// The contents and name of these files(as specified by CXUnsavedFile)
        /// are copied when necessary, so the client only needs to
        /// guarantee their validity until the call to this function returns.
        /// </param>
        /// <param name="num_unsaved_files">
        /// the number of unsaved file entries in <paramref name="unsaved_files"/>.
        /// </param>
        /// <param name="out_tu">
        /// pointer to store a \c CXTranslationUnit that can be
        /// reused after indexing is finished.Set to \c NULL if you do not require it.
        /// </param>
        /// <param name="tu_options">
        /// A bitmask of options that affects how the translation unit
        /// is managed but not its compilation.This should be a bitwise OR of the
        /// CXTranslationUnit_XXX flags.
        /// </param>
        /// <returns>
        /// 0 on success or if there were errors from which the compiler could
        /// recover.If there is a failure from which there is no recovery, returns
        /// a non-zero <c>CXErrorCode</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_indexSourceFile(CXIndexAction index_action, CXClientData client_data,
                                                              [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
                                                              IndexerCallbacks[] index_callbacks,
                                                              uint index_callbacks_size,
                                                              IndexOptionFlags index_options,
                                                              string source_filename,
                                                              [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)]
                                                              string[] command_line_args,
                                                              int num_command_line_args,
                                                              [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)]
                                                              CXUnsavedFile[] unsaved_files,
                                                              uint num_unsaved_files,
                                                              out CXTranslationUnit out_tu,
                                                              TranslationUnitFlags tu_options);

        /// <summary>
        /// Same as clang_indexSourceFile but requires a full command line
        /// for <c>command_line_args</c> including argv[0]. This is useful if the standard
        /// library paths are relative to the binary.
        /// </summary>
        /// <param name="index_action">Index Action</param>
        /// <param name="client_data">
        /// pointer data supplied by the client, which will
        /// be passed to the invoked callbacks.
        /// </param>
        /// <param name="index_callbacks">
        /// Pointer to indexing callbacks that the client
        /// implements.
        /// </param>
        /// <param name="index_callbacks_size">
        /// Size of <c>IndexerCallbacks</c> structure that gets
        /// passed in <paramref name="index_callbacks"/>.</param>
        /// <param name="index_options">
        /// A bitmask of options that affects how indexing is
        /// performed.This should be a bitwise OR of the CXIndexOpt_XXX flags.
        /// </param>
        /// <param name="source_filename">
        /// The name of the source file to load, or NULL if the
        /// source file is included in <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="command_line_args">
        /// The command-line arguments that would be
        /// passed to the <c>clang</c> executable if it were being invoked out-of-process.
        /// These command-line options will be parsed and will affect how the translation
        /// unit is parsed.Note that the following options are ignored: '-c',
        /// '-emit-ast', '-fsyntax-only' (which is the default), and '-o &lt;output file&gt;'.
        /// </param>
        /// <param name="num_command_line_args">
        /// The number of command-line arguments in
        /// <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="unsaved_files">
        /// the files that have not yet been saved to disk
        /// but may be required for code completion, including the contents of
        /// those files.
        /// The contents and name of these files(as specified by CXUnsavedFile)
        /// are copied when necessary, so the client only needs to
        /// guarantee their validity until the call to this function returns.
        /// </param>
        /// <param name="num_unsaved_files">
        /// the number of unsaved file entries in <paramref name="unsaved_files"/>.
        /// </param>
        /// <param name="out_tu">
        /// pointer to store a \c CXTranslationUnit that can be
        /// reused after indexing is finished.Set to \c NULL if you do not require it.
        /// </param>
        /// <param name="tu_options">
        /// A bitmask of options that affects how the translation unit
        /// is managed but not its compilation.This should be a bitwise OR of the
        /// CXTranslationUnit_XXX flags.
        /// </param>
        /// <returns>
        /// 0 on success or if there were errors from which the compiler could
        /// recover.If there is a failure from which there is no recovery, returns
        /// a non-zero <c>CXErrorCode</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_indexSourceFileFullArgv(CXIndexAction index_action, CXClientData client_data,
                                                                       [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
                                                                       IndexerCallbacks[] index_callbacks,
                                                                       uint index_callbacks_size,
                                                                       IndexOptionFlags index_options,
                                                                       string source_filename,
                                                                       [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)]
                                                                       string[] command_line_args,
                                                                       int num_command_line_args,
                                                                       [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)]
                                                                       CXUnsavedFile[] unsaved_files,
                                                                       uint num_unsaved_files,
                                                                       out CXTranslationUnit out_tu,
                                                                       TranslationUnitFlags tu_options);

        /// <summary>
        /// Index the given translation unit via callbacks implemented through
        /// <c>IndexerCallbacks</c>.
        ///
        /// The order of callback invocations is not guaranteed to be the same as
        /// when indexing a source file.The high level order will be:
        ///
        /// -Preprocessor callbacks invocations
        /// -Declaration/reference callbacks invocations
        /// -Diagnostic callback invocations
        /// </summary>
        /// <param name="index_action">Index Action</param>
        /// <param name="client_data">
        /// pointer data supplied by the client, which will
        /// be passed to the invoked callbacks.
        /// </param>
        /// <param name="index_callbacks">
        /// Pointer to indexing callbacks that the client
        /// implements.
        /// </param>
        /// <param name="index_callbacks_size">
        /// Size of <c>IndexerCallbacks</c> structure that gets
        /// passed in <paramref name="index_callbacks"/>.</param>
        /// <param name="index_options">
        /// A bitmask of options that affects how indexing is
        /// performed.This should be a bitwise OR of the CXIndexOpt_XXX flags.
        /// </param>
        /// <param name="tu">Translation Unit</param>
        /// <returns>
        /// If there is a failure from which there is no recovery, returns
        /// non-zero, otherwise returns 0.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_indexTranslationUnit(CXIndexAction index_action,
                                                                    CXClientData client_data,
                                                                    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
                                                                    IndexerCallbacks[] index_callbacks,
                                                                    uint index_callbacks_size,
                                                                    IndexOptionFlags index_options,
                                                                    CXTranslationUnit tu);

        /// <summary>
        /// Retrieve the CXIdxFile, file, line, column, and offset represented by
        /// the given <c>CXIdxLoc</c>.
        ///
        /// If the location refers into a macro expansion, retrieves the
        /// location of the macro expansion and if it refers into a macro argument
        /// retrieves the location of the argument.
        /// </summary>
        /// <param name="loc">Index Location</param>
        /// <param name="indexFile">Index Client File</param>
        /// <param name="file">File</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        /// <param name="offset">Offset</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_indexLoc_getFileLocation(CXIdxLoc loc,
                                                                   out CXIdxClientFile indexFile, out CXFile file,
                                                                   out uint line, out uint column, out uint offset);

        /// <summary>
        /// Retrieve the CXSourceLocation represented by the given CXIdxLoc.
        /// </summary>
        /// <param name="loc">Index Location</param>
        /// <returns>Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_indexLoc_getCXSourceLocation(CXIdxLoc loc);

        /// <summary>
        /// Visit the fields of a particular type.
        ///
        /// This function visits all the direct fields of the given cursor,
        /// invoking the given <paramref name="visitor"/> function with the cursors of each
        /// visited field.The traversal may be ended prematurely, if
        /// the visitor returns <c>CXFieldVisit_Break</c>.
        /// </summary>
        /// <param name="type">the record type whose field may be visited.</param>
        /// <param name="visitor">
        /// the visitor function that will be invoked for each
        /// field of <paramref name="type"/>.
        /// </param>
        /// <param name="client_data">
        /// pointer data supplied by the client, which will
        /// be passed to the visitor each time it is invoked.
        /// </param>
        /// <returns>
        /// a non-zero value if the traversal was terminated
        /// prematurely by the visitor returning <c>CXFieldVisit_Break</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Type_visitFields(CXType type, CXFieldVisitor visitor, CXClientData client_data);
    }
}
