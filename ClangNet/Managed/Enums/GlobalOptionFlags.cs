using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Global Option Flags
    /// </summary>
    [Flags]
    public enum GlobalOptionFlags
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Used to indicate that no special <c>CXIndex</c> options are needed.
        /// </remarks>
        None = 0x0,

        /// <summary>
        /// Thread Background Priority For Indexing
        /// </summary>
        /// <remarks>
        /// Used to indicate that threads that libclang creates for indexing
        /// purposes should use background priority.
        /// Affects <c>clang_indexSourceFile()</c>, <c>clang_indexTranslationUnit()</c>,
        /// <c>clang_parseTranslationUnit()</c>, <c>clang_saveTranslationUnit()</c>.
        /// </remarks>
        ThreadBackgroundPriorityForIndexing = 0x1,

        /// <summary>
        /// Thread Background Priority For Editing
        /// </summary>
        /// <remarks>
        /// Used to indicate that threads that libclang creates for editing
        /// purposes should use background priority.
        /// Affects <c>clang_reparseTranslationUnit</c>, <c>clang_codeCompleteAt</c>,
        /// <c>clang_annotateTokens</c>
        /// </remarks>
        ThreadBackgroundPriorityForEditing = 0x2,

        /// <summary>
        /// Thread Background Priority For All
        /// </summary>
        /// <remarks>
        /// Used to indicate that all threads that libclang creates should use
        /// background priority.
        /// </remarks>
        ThreadBackgroundPriorityForAll = ThreadBackgroundPriorityForIndexing | ThreadBackgroundPriorityForEditing,
    }
}
