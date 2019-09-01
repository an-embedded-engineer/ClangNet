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

    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // An opaque type representing target information for a given translation unit.
    // struct CXTargetInfoImpl*
    using CXTargetInfo = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Translation Unit
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Get the original translation unit source file name.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Translation Unit Source File Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getTranslationUnitSpelling(CXTranslationUnit tu);

        /// <summary>
        /// Return the CXTranslationUnit for a given source file and the provided
        /// command line arguments one would pass to the compiler.
        ///
        /// Note: The 'source_filename' argument is optional.
        /// If the caller provides a NULL pointer,
        /// the name of the source file is expected to reside in the
        /// specified command line arguments.
        ///
        /// Note: When encountered in 'clang_command_line_args', the following options
        /// are ignored:
        ///
        /// '-c'
        /// '-emit-ast'
        /// '-fsyntax-only'
        /// '-o &lt;output file&gt;'  (both '-o' and '&lt;output file&gt;' are ignored)
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
        /// <param name="source_filename">
        /// The name of the source file to load, or NULL if the
        /// source file is included in <paramref name="clang_command_line_ags"/>.
        /// </param>
        /// <param name="num_clang_command_line_args">
        /// The number of command-line arguments in
        /// <paramref name="clang_command_line_ags"/>.
        /// </param>
        /// <param name="clang_command_line_ags">
        /// The command-line arguments that would be
        /// passed to the <c>clang</c> executable if it were being invoked out-of-process.
        /// These command-line options will be parsed and will affect how the translation
        /// unit is parsed.Note that the following options are ignored: '-c',
        /// '-emit-ast', '-fsyntax-only' (which is the default), and '-o &lt;output file&gt;'.
        /// </param>
        /// <param name="num_unsaved_files">
        /// the number of unsaved file entries in <paramref name="unsaved_files"/>.
        /// </param>
        /// <param name="unsaved_files">
        /// the files that have not yet been saved to disk
        /// but may be required for code completion, including the contents of
        /// those files.
        /// The contents and name of these files(as specified by CXUnsavedFile)
        /// are copied when necessary, so the client only needs to
        /// guarantee their validity until the call to this function returns.
        /// </param>
        /// <returns>Translation Unit</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTranslationUnit clang_createTranslationUnitFromSourceFile(CXIndex index, string source_filename,
                                                                                           int num_clang_command_line_args,
                                                                                           [MarshalAs(UnmanagedType.LPArray)] string[] clang_command_line_ags,
                                                                                           uint num_unsaved_files,
                                                                                           [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files);

        /// <summary>
        /// Same as <c>clang_createTranslationUnit2()</c>, but returns
        /// the <c>CXTranslationUnit</c> instead of an error code.
        /// In case of an error this routine returns a <c>NULL</c> <c>CXTranslationUnit</c>,
        /// without further detailed error codes.
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
        /// <param name="ast_filename">AST File Name</param>
        /// <returns>Translation Unit</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTranslationUnit clang_createTranslationUnit(CXIndex index, string ast_filename);

        /// <summary>
        /// Create a translation unit from an AST file (\c -emit-ast).
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
        /// <param name="ast_filename">AST File Name</param>
        /// <param name="out_tu">A non-NULL pointer to store the created
        /// <c>CXTranslationUnit</c>.</param>
        /// <returns>Zero on success, otherwise returns an error code.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_createTranslationUnit2(CXIndex index, string ast_filename, out CXTranslationUnit out_tu);

        /// <summary>
        /// Returns the set of flags that is suitable for parsing a translation
        /// unit that is being edited.
        ///
        /// The set of flags returned provide options for <c>clang_parseTranslationUnit()</c>
        /// to indicate that the translation unit is likely to be reparsed many times,
        /// either explicitly (via <c>clang_reparseTranslationUnit()</c>) or implicitly
        /// (e.g., by code completion(<c>clang_codeCompletionAt()</c>)).
        /// The returned flag set contains an unspecified set of optimizations
        /// (e.g., the precompiled preamble) geared toward improving the performance of these routines.
        /// The set of optimizations enabled may change from one version to the next.
        /// </summary>
        /// <returns>Default Translation Unit Flags</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TranslationUnitFlags clang_defaultEditingTranslationUnitOptions();

        /// <summary>
        /// Same as <c>clang_parseTranslationUnit2()</c>, but returns
        /// the <c>CXTranslationUnit</c> instead of an error code.
        /// In case of an error this routine returns a <c>NULL</c> <c>CXTranslationUnit</c>,
        /// without further detailed error codes.
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
        /// <param name="source_filename">Source File Name</param>
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
        /// <param name="options">
        /// A bitmask of options that affects how the translation unit
        /// is managed but not its compilation.This should be a bitwise OR of the
        /// CXTranslationUnit_XXX flags.
        /// </param>
        /// <returns>Translation Unit</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTranslationUnit clang_parseTranslationUnit(CXIndex index, string source_filename,
                                                                            [MarshalAs(UnmanagedType.LPArray)] string[] command_line_args,
                                                                            int num_command_line_args,
                                                                            [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files,
                                                                            uint num_unsaved_files,
                                                                            TranslationUnitFlags options);

        /// <summary>
        /// Parse the given source file and the translation unit corresponding
        /// to that file.
        ///
        /// This routine is the main entry point for the Clang C API, providing the
        /// ability to parse a source file into a translation unit that can then be
        /// queried by other functions in the API.This routine accepts a set of
        /// command-line arguments so that the compilation can be configured in the same
        /// way that the compiler is configured on the command line.
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
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
        /// The number of command-line arguments in <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="unsaved_files">
        /// the files that have not yet been saved to disk
        /// but may be required for parsing, including the contents of
        /// those files.The contents and name of these files (as specified by
        /// CXUnsavedFile) are copied when necessary, so the client only needs to
        /// guarantee their validity until the call to this function returns.
        /// </param>
        /// <param name="num_unsaved_files">
        /// the number of unsaved file entries in <paramref name="unsaved_files"/>.
        /// </param>
        /// <param name="options">
        /// A bitmask of options that affects how the translation unit
        /// is managed but not its compilation.This should be a bitwise OR of the
        /// CXTranslationUnit_XXX flags.
        /// </param>
        /// <param name="out_tu">
        /// A non-NULL pointer to store the created
        /// <c>CXTranslationUnit</c>, describing the parsed code and containing any
        /// diagnostics produced by the compiler.
        /// </param>
        /// <returns>Zero on success, otherwise returns an error code.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_parseTranslationUnit2(CXIndex index, string source_filename,
                                                                     [MarshalAs(UnmanagedType.LPArray)] string[] command_line_args,
                                                                     int num_command_line_args,
                                                                     [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files,
                                                                     uint num_unsaved_files,
                                                                     TranslationUnitFlags options,
                                                                     out CXTranslationUnit out_tu);

        /// <summary>
        /// Same as clang_parseTranslationUnit2 but requires a full command line
        /// for <paramref name="command_line_args"/> including argv[0]. This is useful if the standard
        /// library paths are relative to the binary.
        /// </summary>
        /// <param name="index">The index object with which the translation unit will be associated.</param>
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
        /// The number of command-line arguments in <paramref name="command_line_args"/>.
        /// </param>
        /// <param name="unsaved_files">
        /// the files that have not yet been saved to disk
        /// but may be required for parsing, including the contents of
        /// those files.The contents and name of these files (as specified by
        /// CXUnsavedFile) are copied when necessary, so the client only needs to
        /// guarantee their validity until the call to this function returns.
        /// </param>
        /// <param name="num_unsaved_files">
        /// the number of unsaved file entries in <paramref name="unsaved_files"/>.
        /// </param>
        /// <param name="options">
        /// A bitmask of options that affects how the translation unit
        /// is managed but not its compilation.This should be a bitwise OR of the
        /// CXTranslationUnit_XXX flags.
        /// </param>
        /// <param name="out_tu">
        /// A non-NULL pointer to store the created
        /// <c>CXTranslationUnit</c>, describing the parsed code and containing any
        /// diagnostics produced by the compiler.
        /// </param>
        /// <returns>Zero on success, otherwise returns an error code.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_parseTranslationUnit2FullArgv(CXIndex index, string source_filename,
                                                                            [MarshalAs(UnmanagedType.LPArray)] string[] command_line_args,
                                                                            int num_command_line_args,
                                                                            [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files,
                                                                            uint num_unsaved_files,
                                                                            TranslationUnitFlags options,
                                                                            out CXTranslationUnit out_tu);

        /// <summary>
        /// Returns the set of flags that is suitable for saving a translation
        /// unit.
        ///
        /// The set of flags returned provide options for
        /// <c>clang_saveTranslationUnit()</c> by default. The returned flag
        /// set contains an unspecified set of options that save translation units with
        /// the most commonly-requested data.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Default Save Translation Unit Flags</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern SaveTranslationUnitFlags clang_defaultSaveOptions(CXTranslationUnit tu);

        /// <summary>
        /// Saves a translation unit into a serialized representation of
        /// that translation unit on disk.
        ///
        /// Any translation unit that was parsed without error can be saved
        /// into a file.The translation unit can then be deserialized into a
        /// new <c>CXTranslationUnit</c> with <c>clang_createTranslationUnit()</c> or,
        /// if it is an incomplete translation unit that corresponds to a
        /// header, used as a precompiled header when parsing other translation
        /// units.
        /// </summary>
        /// <param name="tu">The translation unit to save.</param>
        /// <param name="filename">The file to which the translation unit will be saved.</param>
        /// <param name="options">
        /// A bitmask of options that affects how the translation unit
        /// is saved.This should be a bitwise OR of the
        /// CXSaveTranslationUnit_XXX flags.
        /// </param>
        /// <returns>
        /// A value that will match one of the enumerators of the CXSaveError
        /// enumeration.Zero(CXSaveError_None) indicates that the translation unit was
        /// saved successfully, while a non-zero value indicates that a problem occurred.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern SaveError clang_saveTranslationUnit(CXTranslationUnit tu, string filename, SaveTranslationUnitFlags options);

        /// <summary>
        /// Suspend a translation unit in order to free memory associated with it.
        ///
        /// A suspended translation unit uses significantly less memory but on the other
        /// side does not support any other calls than <c>clang_reparseTranslationUnit()</c>
        /// to resume it or <c>clang_disposeTranslationUnit()</c> to dispose it completely.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>???</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_suspendTranslationUnit(CXTranslationUnit tu);

        /// <summary>
        /// Destroy the specified CXTranslationUnit object.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeTranslationUnit(CXTranslationUnit tu);

        /// <summary>
        /// Returns the set of flags that is suitable for reparsing a translation
        /// unit.
        ///
        /// The set of flags returned provide options for
        /// <c>clang_reparseTranslationUnit()</c> by default. The returned flag
        /// set contains an unspecified set of optimizations geared toward common uses
        /// of reparsing.The set of optimizations enabled may change from one version
        /// to the next.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Default Reparse Translation Unit Flags</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ReparseTranslationUnitFlags clang_defaultReparseOptions(CXTranslationUnit tu);

        /// <summary>
        /// Reparse the source files that produced this translation unit.
        ///
        /// This routine can be used to re-parse the source files that originally
        /// created the given translation unit, for example because those source files
        /// have changed(either on disk or as passed via <paramref name="unsaved_files"/>).
        /// The source code will be reparsed with the same command-line options as it
        /// was originally parsed.
        ///
        /// Reparsing a translation unit invalidates all cursors and source locations
        /// that refer into that translation unit. This makes reparsing a translation
        /// unit semantically equivalent to destroying the translation unit and then
        /// creating a new translation unit with the same command-line arguments.
        /// However, it may be more efficient to reparse a translation
        /// unit using this routine.
        /// </summary>
        /// <param name="tu">
        /// The translation unit whose contents will be re-parsed. The
        /// translation unit must originally have been built with
        /// <c>clang_createTranslationUnitFromSourceFile()</c>.
        /// </param>
        /// <param name="num_unsaved_files">
        /// The number of unsaved file entries in <paramref name="num_unsaved_files"/>
        /// </param>
        /// <param name="unsaved_files">
        /// The files that have not yet been saved to disk
        /// Tbut may be required for parsing, including the contents of
        /// Tthose files.The contents and name of these files (as specified by
        /// TCXUnsavedFile) are copied when necessary, so the client only needs to
        /// Tguarantee their validity until the call to this function returns.
        /// </param>
        /// <param name="options">
        /// A bitset of options composed of the flags in CXReparse_Flags.
        /// The function <c>clang_defaultReparseOptions()</c> produces a default set of
        /// options recommended for most uses, based on the translation unit.
        /// </param>
        /// <returns>
        /// 0 if the sources could be reparsed.  A non-zero error code will be
        /// returned if reparsing was impossible, such that the translation unit is
        /// invalid.In such cases, the only valid call for <paramref name="tu"/> is
        /// <c>clang_disposeTranslationUnit(tu)</c>.  The error codes returned by this
        /// routine are described by the <c>CXErrorCode</c> enum.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_reparseTranslationUnit(CXTranslationUnit tu,
                                                                      uint num_unsaved_files,
                                                                      [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files,
                                                                      ReparseTranslationUnitFlags options);

        /// <summary>
        /// Returns the human-readable null-terminated C string that represents
        /// the name of the memory category.This string should never be freed.
        /// </summary>
        /// <param name="kind">Resource Usage Kind</param>
        /// <returns>Resource Usage Kind Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern string clang_getTUResourceUsageName(ResourceUsageKind kind);

        /// <summary>
        /// Return the memory usage of a translation unit.  This object
        /// should be released with <c>clang_disposeCXTUResourceUsage()</c>.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Translation Unit Resource Usage</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTUResourceUsage clang_getCXTUResourceUsage(CXTranslationUnit tu);

        /// <summary>
        /// Dispose Translation Unit Resource Usage object.
        /// </summary>
        /// <param name="usage">Translation Unit Resource Usage</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeCXTUResourceUsage(CXTUResourceUsage usage);

        /// <summary>
        /// Get target information for this translation unit.
        ///
        /// The CXTargetInfo object cannot outlive the CXTranslationUnit object.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Target Info</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTargetInfo clang_getTranslationUnitTargetInfo(CXTranslationUnit tu);

        /// <summary>
        /// Destroy the CXTargetInfo object.
        /// </summary>
        /// <param name="target_info">Target Info</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_TargetInfo_dispose(CXTargetInfo target_info);

        /// <summary>
        /// Get the normalized target triple as a string.
        ///
        /// Returns the empty string in case of any error.
        /// </summary>
        /// <param name="target_info">Target Info</param>
        /// <returns>Normalized Target Triple String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_TargetInfo_getTriple(CXTargetInfo target_info);

        /// <summary>
        /// Get the pointer width of the target in bits.
        ///
        /// Returns -1 in case of error.
        /// </summary>
        /// <param name="target_info">Target Info</param>
        /// <returns>Pointer Width</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_TargetInfo_getPointerWidth(CXTargetInfo target_info);
    }
}
