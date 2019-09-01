using System;

namespace ClangNet
{
    /// <summary>
    /// Code Completion Flags
    /// </summary>
    /// <remarks>
    /// Flags that can be passed to <c>clang_codeCompleteAt()</c> to
    /// modify its behavior.
    ///
    /// The enumerators in this enumeration can be bitwise-OR'd together to
    /// provide multiple options to <c>clang_codeCompleteAt()</c>.
    /// </remarks>
    [Flags]
    public enum CodeCompleteFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Include Macros
        /// </summary>
        /// <remarks>
        /// Whether to include macros within the set of code
        /// completions returned.
        /// </remarks>
        IncludeMacros = 0x01,

        /// <summary>
        /// Include Code Patterns
        /// </summary>
        /// <remarks>
        /// Whether to include code patterns for language constructs
        /// within the set of code completions, e.g., for loops.
        /// </remarks>
        IncludeCodePatterns = 0x02,

        /// <summary>
        /// Include Brief Comments
        /// </summary>
        /// <remarks>
        /// Whether to include brief documentation within the set of code
        /// completions returned.
        /// </remarks>
        IncludeBriefComments = 0x04,

        /// <summary>
        /// Skip Reamble
        /// </summary>
        /// <remarks>
        /// Whether to speed up completion by omitting top- or namespace-level entities
        /// defined in the preamble. There's no guarantee any particular entity is
        /// omitted. This may be useful if the headers are indexed externally.
        /// </remarks>
        SkipPreamble = 0x08,

        /// <summary>
        /// Include Completion With Fix Its
        /// </summary>
        /// <remarks>
        /// Whether to include completions with small
        /// fix-its, e.g. change '.' to '-&gt;' on member access, etc.
        /// </remarks>
        IncludeCompletionsWithFixIts = 0x10,
    }
}
