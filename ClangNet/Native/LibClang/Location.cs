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

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // CXSourceRangeList*
    using CXSourceRangeListPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Physical Source Locations
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve a NULL (invalid) source location.
        /// </summary>
        /// <returns>Null Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getNullLocation();

        /// <summary>
        /// Determine whether two source locations, which must refer into
        /// the same translation unit, refer to exactly the same point in the
        /// source code.
        /// </summary>
        /// <param name="loc1">Source Location1</param>
        /// <param name="loc2">Source Location2</param>
        /// <returns>
        /// non-zero if the source locations refer to the same location, zero
        /// if they refer to different locations.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_equalLocations(CXSourceLocation loc1, CXSourceLocation loc2);

        /// <summary>
        /// Retrieves the source location associated with a given file/line/column
        /// in a particular translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="file">File</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        /// <returns>Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getLocation(CXTranslationUnit tu, CXFile file, uint line, uint column);

        /// <summary>
        /// Retrieves the source location associated with a given character offset
        /// in a particular translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="file">File</param>
        /// <param name="offset">Offset</param>
        /// <returns>Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getLocationForOffset(CXTranslationUnit tu, CXFile file, uint offset);

        /// <summary>
        ///  Returns non-zero if the given source location is in a system header.
        /// </summary>
        /// <param name="location">Source Location</param>
        /// <returns>
        /// 0 : Not In System Header
        /// Other : In System Header
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Location_isInSystemHeader(CXSourceLocation location);

        /// <summary>
        /// Returns non-zero if the given source location is in the main file of
        /// the corresponding translation unit.
        /// </summary>
        /// <param name="location">Source Location</param>
        /// <returns>
        /// 0 : Not From Main File
        /// Other : From Main File
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Location_isFromMainFile(CXSourceLocation location);

        /// <summary>
        /// Retrieve a NULL (invalid) source range.
        /// </summary>
        /// <returns>Null Source Range</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getNullRange();

        /// <summary>
        /// Retrieve a source range given the beginning and ending source locations.
        /// </summary>
        /// <param name="begin">Beginning Source Location</param>
        /// <param name="end">Ending Source Location</param>
        /// <returns>Source Range</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getRange(CXSourceLocation begin, CXSourceLocation end);

        /// <summary>
        /// Determine whether two ranges are equivalent.
        /// </summary>
        /// <param name="range1">Source Range1</param>
        /// <param name="range2">Source Range2</param>
        /// <returns>non-zero if the ranges are the same, zero if they differ.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_equalRanges(CXSourceRange range1, CXSourceRange range2);

        /// <summary>
        /// Returns non-zero if <paramref name="range"/> is null.
        /// </summary>
        /// <param name="range">Source Range</param>
        /// <returns>
        /// 0 : Not Null Source Range
        /// Other : Null Source Range
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Range_isNull(CXSourceRange range);

        /// <summary>
        /// Retrieve the file, line, column, and offset represented by
        /// the given source location.
        ///
        /// If the location refers into a macro expansion, retrieves the
        /// location of the macro expansion.
        /// </summary>
        /// <param name="location">
        /// the location within a source file that will be decomposed
        /// into its parts.
        /// </param>
        /// <param name="file">
        /// if non-NULL, will be set to the file to which the given
        /// source location points.
        /// </param>
        /// <param name="line">
        /// if non-NULL, will be set to the line to which the given
        /// source location points.
        /// </param>
        /// <param name="column">
        /// if non-NULL, will be set to the column to which the given
        /// source location points.
        /// </param>
        /// <param name="offset">
        /// if non-NULL, will be set to the offset into the
        /// buffer to which the given source location points.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getExpansionLocation(CXSourceLocation location, out CXFile file, out uint line, out uint column, out uint offset);

        /// <summary>
        /// Retrieve the file, line and column represented by the given source
        /// location, as specified in a #line directive.
        ///
        /// Example: given the following source code in a file somefile.c
        ///
        /// <code>
        /// #123 "dummy.c" 1
        ///
        /// static int func(void)
        /// {
        ///  return 0;
        /// }
        /// </code>
        ///
        /// the location information returned by this function would be
        ///
        /// File: dummy.c Line: 124 Column: 12
        ///
        /// whereas <c>clang_getExpansionLocation()</c> would have returned
        ///
        /// File: somefile.c Line: 3 Column: 12
        /// </summary>
        /// <param name="location">
        /// location the location within a source file that will be decomposed
        /// into its parts.
        /// </param>
        /// <param name="filename">
        /// if non-NULL, will be set to the filename of the
        /// source location.Note that filenames returned will be for "virtual" files,
        /// which don't necessarily exist on the machine running clang - e.g. when
        /// parsing preprocessed output obtained from a different environment. If
        /// a non-NULL value is passed in, remember to dispose of the returned value
        /// using <c>clang_disposeString()</c> once you've finished with it. For an invalid
        /// source location, an empty string is returned.
        /// </param>
        /// <param name="line">
        /// if non-NULL, will be set to the line number of the
        /// source location.For an invalid source location, zero is returned.
        /// </param>
        /// <param name="column">
        /// if non-NULL, will be set to the column number of the
        /// source location.For an invalid source location, zero is returned.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getPresumedLocation(CXSourceLocation location, out CXString filename, out uint line, out uint column);

        /// <summary>
        /// Legacy API to retrieve the file, line, column, and offset represented
        /// by the given source location.
        ///
        /// This interface has been replaced by the newer interface
        /// <c>clang_getExpansionLocation()</c>.
        /// See that interface's documentation for details.
        /// </summary>
        /// <param name="location">
        /// the location within a source file that will be decomposed
        /// into its parts.
        /// </param>
        /// <param name="file">
        /// if non-NULL, will be set to the file to which the given
        /// source location points.
        /// </param>
        /// <param name="line">
        /// if non-NULL, will be set to the line to which the given
        /// source location points.
        /// </param>
        /// <param name="column">
        /// if non-NULL, will be set to the column to which the given
        /// source location points.
        /// </param>
        /// <param name="offset">
        /// if non-NULL, will be set to the offset into the
        /// buffer to which the given source location points.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getInstantiationLocation(CXSourceLocation location, out CXFile file, out uint line, out uint column, out uint offset);

        /// <summary>
        /// Retrieve the file, line, column, and offset represented by
        /// the given source location.
        ///
        /// If the location refers into a macro instantiation, return where the
        /// location was originally spelled in the source file.
        /// </summary>
        /// <param name="location">
        /// the location within a source file that will be decomposed
        /// into its parts.
        /// </param>
        /// <param name="file">
        /// if non-NULL, will be set to the file to which the given
        /// source location points.
        /// </param>
        /// <param name="line">
        /// if non-NULL, will be set to the line to which the given
        /// source location points.
        /// </param>
        /// <param name="column">
        /// if non-NULL, will be set to the column to which the given
        /// source location points.
        /// </param>
        /// <param name="offset">
        /// if non-NULL, will be set to the offset into the
        /// buffer to which the given source location points.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getSpellingLocation(CXSourceLocation location, out CXFile file, out uint line, out uint column, out uint offset);

        /// <summary>
        /// Retrieve the file, line, column, and offset represented by
        /// the given source location.
        ///
        /// If the location refers into a macro expansion, return where the macro was
        /// expanded or where the macro argument was written, if the location points at
        /// a macro argument.
        /// </summary>
        /// <param name="location">
        /// the location within a source file that will be decomposed
        /// into its parts.
        /// </param>
        /// <param name="file">
        /// if non-NULL, will be set to the file to which the given
        /// source location points.
        /// </param>
        /// <param name="line">
        /// if non-NULL, will be set to the line to which the given
        /// source location points.
        /// </param>
        /// <param name="column">
        /// if non-NULL, will be set to the column to which the given
        /// source location points.
        /// </param>
        /// <param name="offset">
        /// if non-NULL, will be set to the offset into the
        /// buffer to which the given source location points.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getFileLocation(CXSourceLocation location, out CXFile file, out uint line, out uint column, out uint offset);

        /// <summary>
        /// Retrieve a source location representing the first character within a
        /// source range.
        /// </summary>
        /// <param name="range">Source Range</param>
        /// <returns>Start Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getRangeStart(CXSourceRange range);

        /// <summary>
        /// Retrieve a source location representing the last character within a
        /// source range.
        /// </summary>
        /// <param name="range">Source Range</param>
        /// <returns>End Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getRangeEnd(CXSourceRange range);

        /// <summary>
        /// Retrieve all ranges that were skipped by the preprocessor.
        ///
        /// The preprocessor will skip lines when they are surrounded by an
        /// if/ifdef/ifndef directive whose condition does not evaluate to true.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="file">File</param>
        /// <returns>Skipped Source Range List</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRangeListPtr clang_getSkippedRanges(CXTranslationUnit tu, CXFile file);

        /// <summary>
        /// Retrieve all ranges from all files that were skipped by the
        /// preprocessor.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Skipped Source Range List</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRangeListPtr clang_getAllSkippedRanges(CXTranslationUnit tu);

        /// <summary>
        /// Destroy the given <c>CXSourceRangeList</c>.
        /// </summary>
        /// <param name="ranges">Source Range List</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeSourceRangeList(CXSourceRangeListPtr ranges);
    }
}
