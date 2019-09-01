#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // A single diagnostic, containing the diagnostic's severity,
    // location, text, source ranges, and fix-it hints.
    // void*
    using CXDiagnostic = IntPtr;

    // A semantic string that describes a code-completion result.
    //
    // A semantic string that describes the formatting of a code-completion
    // result as a single "template" of text that should be inserted into the
    // source buffer when a particular code-completion result is selected.
    // Each semantic string is made up of some number of "chunks", each of which
    // contains some text along with a description of what that text means, e.g.,
    // the name of the entity being referenced, whether the text chunk is part of
    // the template, or whether it is a "placeholder" that the user should replace
    // with actual code, of a specific kind. See <c>CXCompletionChunkKind</c> for a
    // description of the different kinds of chunks.
    // void*
    using CXCompletionString = IntPtr;

    // CXCompletionResult*
    using CXCompletionResultPtr = IntPtr;

    // CXCompletionResults*
    using CXCodeCompleteResultsPtr = IntPtr;

    // enum CXCursorkind*
    using CXCursorKindPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Code Completion
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Determine the kind of a particular chunk within a completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <param name="chunk_number">the 0-based index of the chunk in the completion string.</param>
        /// <returns>the kind of the chunk at the index <c>chunk_number</c>.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CompletionChunkKind clang_getCompletionChunkKind(CXCompletionString completion_string, uint chunk_number);

        /// <summary>
        /// Retrieve the text associated with a particular chunk within a completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <param name="chunk_number">the 0-based index of the chunk in the completion string.</param>
        /// <returns>the text associated with the chunk at index <c>chunk_number</c>.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCompletionChunkText(CXCompletionString completion_string, uint chunk_number);

        /// <summary>
        /// Retrieve the completion string associated with a particular chunk within a completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <param name="chunk_number">the 0-based index of the chunk in the completion string.</param>
        /// <returns>the completion string associated with the chunk at index <c>chunk_number</c>.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompletionString clang_getCompletionChunkCompletionString(CXCompletionString completion_string, uint chunk_number);

        /// <summary>
        /// Retrieve the number of chunks in the given code-completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <returns>the number of chunks</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getNumCompletionChunks(CXCompletionString completion_string);

        /// <summary>
        /// Determine the priority of this code completion.
        ///
        /// The priority of a code completion indicates how likely it is that this
        /// particular completion is the completion that the user will select.
        /// The priority is selected by various internal heuristics.
        /// </summary>
        /// <param name="completion_string">The completion string to query.</param>
        /// <returns>
        /// The priority of this completion string. Smaller values indicate
        /// higher-priority (more likely) completions.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getCompletionPriority(CXCompletionString completion_string);

        /// <summary>
        /// Determine the availability of the entity that this code-completion
        /// string refers to.
        /// </summary>
        /// <param name="completion_string">The completion string to query.</param>
        /// <returns>The availability of the completion string.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern AvailabilityKind clang_getCompletionAvailability(CXCompletionString completion_string);

        /// <summary>
        /// Retrieve the number of annotations associated with the given completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <returns>the number of annotations associated with the given completion string.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getCompletionNumAnnotations(CXCompletionString completion_string);

        /// <summary>
        /// Retrieve the annotation associated with the given completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <param name="annotation_number">the 0-based index of the annotation of the completion string.</param>
        /// <returns>
        /// annotation string associated with the completion at index
        /// <c>annotation_number</c>, or a NULL string if that annotation is not available.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCompletionAnnotation(CXCompletionString completion_string, uint annotation_number);

        /// <summary>
        /// Retrieve the parent context of the given completion string.
        /// The parent context of a completion string is the semantic parent of
        /// the declaration(if any) that the code completion represents.For example,
        /// a code completion for an Objective-C method would have the method's class
        /// or protocol as its context.
        /// </summary>
        /// <param name="completion_string">The code completion string whose parent is being queried.</param>
        /// <param name="kind">DEPRECATED: always set to CXCursor_NotImplemented if non-NULL.</param>
        /// <returns>
        /// The name of the completion parent, e.g., "NSObject" if
        /// the completion string represents a method in the NSObject class.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCompletionParent(CXCompletionString completion_string, CXCursorKindPtr kind);

        /// <summary>
        /// Retrieve the brief documentation comment attached to the declaration
        /// that corresponds to the given completion string.
        /// </summary>
        /// <param name="completion_string">the completion string to query.</param>
        /// <returns>the brief documentation comment attached to the declaration</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCompletionBriefComment(CXCompletionString completion_string);

        /// <summary>
        /// Retrieve a completion string for an arbitrary declaration or macro definition cursor.
        /// </summary>
        /// <param name="cursor">The cursor to query.</param>
        /// <returns>
        /// A non-context-sensitive completion string for declaration and macro
        /// definition cursors, or NULL for other kinds of cursors.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompletionString clang_getCursorCompletionString(CXCursor cursor);

        /// <summary>
        /// Retrieve the number of fix-its for the given completion index.
        ///
        /// Calling this makes sense only if CXCodeComplete_IncludeCompletionsWithFixIts
        /// option was set.
        /// </summary>
        /// <param name="results">The structure keeping all completion results</param>
        /// <param name="completion_index">The index of the completion</param>
        /// <returns>
        /// The number of fix-its which must be applied before the completion at
        /// <c>ompletion_index</c>c can be applied
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getCompletionNumFixIts(CXCodeCompleteResultsPtr results, uint completion_index);

        /// <summary>
        /// Fix-its that *must* be applied before inserting the text for the
        /// corresponding completion.
        ///
        /// By default, <c>clang_codeCompleteAt()</c> only returns completions with empty
        /// fix-its.Extra completions with non-empty fix-its should be explicitly
        /// requested by setting CXCodeComplete_IncludeCompletionsWithFixIts.
        ///
        /// For the clients to be able to compute position of the cursor after applying
        /// fix-its, the following conditions are guaranteed to hold for
        /// replacement_range of the stored fix-its:
        ///  - Ranges in the fix-its are guaranteed to never contain the completion
        ///  point (or identifier under completion point, if any) inside them, except
        ///  at the start or at the end of the range.
        ///  - If a fix-it range starts or ends with completion point (or starts or
        ///  ends after the identifier under completion point), it will contain at
        ///  least one character.It allows to unambiguously recompute completion
        ///  point after applying the fix-it.
        ///
        /// The intuition is that provided fix-its change code around the identifier we
        /// complete, but are not allowed to touch the identifier itself or the
        /// completion point.One example of completions with corrections are the ones
        /// replacing '.' with '->' and vice versa:
        ///
        /// std::unique_ptr&lt;std::vector&lt;int&gt;&gt; vec_ptr;
        /// In 'vec_ptr.^', one of the completions is 'push_back', it requires
        /// replacing '.' with '-&gt;'.
        /// In 'vec_ptr-&gt;^', one of the completions is 'release', it requires
        /// replacing '-&gt;' with '.'.
        /// </summary>
        /// <param name="results">The structure keeping all completion results</param>
        /// <param name="completion_index">The index of the completion</param>
        /// <param name="fixit_index">The index of the fix-it for the completion at <c>completion_index</c></param>
        /// <param name="replacement_range">The fix-it range that must be replaced before the completion at <c>completion_index</c> can be applied</param>
        /// <returns>
        /// The fix-it string that must replace the code at replacement_range
        /// before the completion at <c>completion_index</c> can be applied
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCompletionFixIt(CXCodeCompleteResultsPtr results, uint completion_index, uint fixit_index, ref CXSourceRange replacement_range);

        /// <summary>
        /// Returns a default set of code-completion options that can be
        /// passed to <c>clang_codeCompleteAt()</c>.
        /// </summary>
        /// <returns>a default set of code-completion options</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CodeCompleteFlags clang_defaultCodeCompleteOptions();

        /// <summary>
        /// Perform code completion at a given location in a translation unit.
        ///
        /// This function performs code completion at a particular file, line, and
        /// column within source code, providing results that suggest potential
        /// code snippets based on the context of the completion.The basic model
        /// for code completion is that Clang will parse a complete source file,
        /// performing syntax checking up to the location where code-completion has
        /// been requested. At that point, a special code-completion token is passed
        /// to the parser, which recognizes this token and determines, based on the
        /// current location in the C/Objective-C/C++ grammar and the state of
        /// semantic analysis, what completions to provide. These completions are
        /// returned via a new <c>CXCodeCompleteResults</c> structure.
        ///
        /// Code completion itself is meant to be triggered by the client when the
        /// user types punctuation characters or whitespace, at which point the
        /// code-completion location will coincide with the cursor.For example, if <c></c> p
        /// is a pointer, code-completion might be triggered after the "-" and then
        /// after the ">" in <c>p-></c>. When the code-completion location is after the ">",
        /// the completion results will provide, e.g., the members of the struct that
        /// "p" points to.The client is responsible for placing the cursor at the
        /// beginning of the token currently being typed, then filtering the results
        /// based on the contents of the token.For example, when code-completing for
        /// the expression <c>p->get</c>, the client should provide the location just after
        /// the ">" (e.g., pointing at the "g") to this code-completion hook. Then, the
        /// client can filter the results based on the current token text ("get"), only
        /// showing those results that start with "get". The intent of this interface
        /// is to separate the relatively high-latency acquisition of code-completion
        /// results from the filtering of results on a per-character basis, which must
        /// have a lower latency.
        /// </summary>
        /// <param name="tu">
        /// The translation unit in which code-completion should
        /// occur.The source files for this translation unit need not be
        /// completely up-to-date(and the contents of those source files may
        /// be overridden via unsaved_files). Cursors referring into the
        /// translation unit may be invalidated by this invocation.
        /// </param>
        /// <param name="complete_filename">
        /// The name of the source file where code
        /// completion should be performed.This filename may be any file
        /// included in the translation unit.
        /// </param>
        /// <param name="complete_line">The line at which code-completion should occur.</param>
        /// <param name="complete_column">
        /// complete_column The column at which code-completion should occur.
        /// Note that the column should point just after the syntactic construct that
        /// initiated code completion, and not in the middle of a lexical token.
        /// </param>
        /// <param name="unsaved_files">
        /// the Files that have not yet been saved to disk
        /// but may be required for parsing or code completion, including the
        /// contents of those files.The contents and name of these files(as
        /// specified by CXUnsavedFile) are copied when necessary, so the
        /// client only needs to guarantee their validity until the call to
        /// this function returns.
        /// </param>
        /// <param name="num_unsaved_files">The number of unsaved file entries in unsaved_files.</param>
        /// <param name="options">
        /// Extra options that control the behavior of code
        /// completion, expressed as a bitwise OR of the enumerators of the
        /// CXCodeComplete_Flags enumeration.The
        /// <c>clang_defaultCodeCompleteOptions()</c> function returns a default set
        /// of code-completion options.
        /// </param>
        /// <returns>
        /// If successful, a new <c>CXCodeCompleteResults</c> structure
        /// containing code-completion results, which should eventually be
        /// freed with <c>clang_disposeCodeCompleteResults()</c>. If code
        /// completion fails, returns NULL.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCodeCompleteResultsPtr clang_codeCompleteAt(CXTranslationUnit tu,
                                                                             string complete_filename, uint complete_line, uint complete_column,
                                                                             [MarshalAs(UnmanagedType.LPArray)] CXUnsavedFile[] unsaved_files,
                                                                             uint num_unsaved_files, CodeCompleteFlags options);

        /// <summary>
        /// Sort the code-completion results in case-insensitive alphabetical order.
        ///
        /// </summary>
        /// <param name="results">The set of results to sort.</param>
        /// <param name="num_results">The number of results in results.</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_sortCodeCompletionResults(CXCompletionResultPtr results, uint num_results);

        /// <summary>
        /// Free the given set of code-completion results.
        /// </summary>
        /// <param name="results">the code completion results to query.</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeCodeCompleteResults(CXCodeCompleteResultsPtr results);

        /// <summary>
        /// Determine the number of diagnostics produced prior to the
        /// location where code completion was performed.
        /// </summary>
        /// <param name="results">the code completion results to query.</param>
        /// <returns>the number of diagnostics produced priority</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_codeCompleteGetNumDiagnostics(CXCodeCompleteResultsPtr results);

        /// <summary>
        /// Retrieve a diagnostic associated with the given code completion.
        /// </summary>
        /// <param name="results">the code completion results to query.</param>
        /// <param name="index">the zero-based diagnostic number to retrieve.</param>
        /// <returns>
        /// the requested diagnostic. This diagnostic must be freed
        /// via a call to <c>clang_disposeDiagnostic()</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnostic clang_codeCompleteGetDiagnostic(CXCodeCompleteResultsPtr results, uint index);

        /// <summary>
        /// Determines what completions are appropriate for the context
        /// the given code completion.
        /// </summary>
        /// <param name="results">the code completion results to query</param>
        /// <returns>
        /// the kinds of completions that are appropriate for use
        /// long with the given code completion results.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CompletionContext clang_codeCompleteGetContexts(CXCodeCompleteResultsPtr results);

        /// <summary>
        /// Returns the cursor kind for the container for the current code
        /// completion context.The container is only guaranteed to be set for
        /// contexts where a container exists (i.e.member accesses or Objective-C
        /// message sends); if there is not a container, this function will return
        /// CXCursor_InvalidCode.
        /// </summary>
        /// <param name="results">the code completion results to query</param>
        /// <param name="is_incomplete">
        /// on return, this value will be false if Clang has complete
        /// information about the container.If Clang does not have complete
        /// information, this value will be true.
        /// </param>
        /// <returns>the container kind, or CXCursor_InvalidCode if there is not a container</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CursorKind clang_codeCompleteGetContainerKind(CXCodeCompleteResultsPtr results, out uint is_incomplete);

        /// <summary>
        /// Returns the USR for the container for the current code completion
        /// context.If there is not a container for the current context, this
        /// function will return the empty string.
        /// </summary>
        /// <param name="results">the code completion results to query</param>
        /// <returns>the USR for the container</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_codeCompleteGetContainerUSR(CXCodeCompleteResultsPtr results);

        /// <summary>
        /// Returns the currently-entered selector for an Objective-C message
        /// send, formatted like "initWithFoo:bar:". Only guaranteed to return a
        /// non-empty string for CXCompletionContext_ObjCInstanceMessage and
        /// CXCompletionContext_ObjCClassMessage.
        /// </summary>
        /// <param name="results">the code completion results to query</param>
        /// <returns>
        /// the selector (or partial selector) that has been entered thus far
        /// for an Objective-C message send.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_codeCompleteGetObjCSelector(CXCodeCompleteResultsPtr results);
    }
}
