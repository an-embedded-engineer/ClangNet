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

    /// <summary>
    /// Libclang P/Invoke : Index
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Provides a shared context for creating translation units.
        ///
        /// It provides two options:
        /// - exclude_declarations_from_pch: When non-zero, allows enumeration of "local"
        /// declarations(when loading any new translation units). A "local" declaration
        /// is one that belongs in the translation unit itself and not in a precompiled
        /// header that was used by the translation unit.If zero, all declarations
        /// will be enumerated.
        ///
        /// This process of creating the 'pch', loading it separately, and using it
        /// (via -include-pch) allows 'exclude_declarations_from_pch' to remove redundant callbacks
        /// (which gives the indexer the same performance benefit as the compiler).
        ///
        /// <code>
        ///   // exclude_declarations_from_pch = 1, display_diagnostics=1
        ///   Idx = clang_createIndex(1, 1);
        ///
        ///   // IndexTest.pch was produced with the following command:
        ///   // "clang -x c IndexTest.h -emit-ast -o IndexTest.pch"
        ///   TU = clang_createTranslationUnit(Idx, "IndexTest.pch");
        ///
        ///   // This will load all the symbols from 'IndexTest.pch'
        ///   clang_visitChildren(clang_getTranslationUnitCursor(TU), TranslationUnitVisitor, 0);
        ///
        ///   clang_disposeTranslationUnit(TU);
        ///
        ///   // This will load all the symbols from 'IndexTest.c', excluding symbols from 'IndexTest.pch'.
        ///   char* args[] = { "-Xclang", "-include-pch=IndexTest.pch" };
        ///
        ///   TU = clang_createTranslationUnitFromSourceFile(Idx, "IndexTest.c", 2, args, 0, 0);
        ///
        ///   clang_visitChildren(clang_getTranslationUnitCursor(TU), TranslationUnitVisitor, 0);
        ///   clang_disposeTranslationUnit(TU);
        /// </code>
        /// </summary>
        /// <param name="exclude_declarations_from_pch">Exclude Declarations from PCH Flag</param>
        /// <param name="display_diagnostics">Display Diagnostics Flag</param>
        /// <returns>CXIndex Object</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXIndex clang_createIndex(int exclude_declarations_from_pch, int display_diagnostics);

        /// <summary>
        /// Destroy the given index.
        /// </summary>
        /// <remarks>
        /// The index must not be destroyed until all of the translation units created
        /// within that index have been destroyed.
        /// </remarks>
        /// <param name="index">CXIndex Object</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeIndex(CXIndex index);

        /// <summary>
        /// Sets general options associated with a CXIndex.
        /// <code>
        ///   CXIndex idx = ...;
        ///   clang_CXIndex_setGlobalOptions(idx,
        ///     clang_CXIndex_getGlobalOptions(idx) |
        ///       CXGlobalOpt_ThreadBackgroundPriorityForIndexing);
        /// </code>
        /// </summary>
        /// <param name="index">CXIndex Object</param>
        /// <param name="options">A bitmask of options, a bitwise OR of GlobalOptionFlags.</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_CXIndex_setGlobalOptions(CXIndex index, GlobalOptionFlags options);

        /// <summary>
        /// Gets the general options associated with a CXIndex.
        /// </summary>
        /// <param name="index">CXIndex Object</param>
        /// <returns>
        /// A bitmask of options, a bitwise OR of GlobalOptionFlags flags that
        /// are associated with the given CXIndex object.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern GlobalOptionFlags clang_CXIndex_getGlobalOptions(CXIndex index);

        /// <summary>
        /// Sets the invocation emission path option in a CXIndex.
        ///
        /// The invocation emission path specifies a path which will contain log
        /// files for certain libclang invocations.A null value(default) implies that
        /// libclang invocations are not logged..
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="path">Invocation Emission Path Option</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_CXIndex_setInvocationEmissionPathOption(CXIndex index, string path);
    }
}
