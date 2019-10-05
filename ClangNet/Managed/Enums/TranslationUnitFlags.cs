using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Translation Unit Flags
    /// </summary>
    /// <remarks>
    /// Flags that control the creation of translation units.
    ///
    /// The enumerators in this enumeration type are meant to be bitwise
    /// ORed together to specify which options should be used when
    /// constructing the translation unit.
    /// </remarks>
    [Flags]
    public enum TranslationUnitFlags
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Used to indicate that no special translation-unit options are needed.
        /// </remarks>
        None = 0x0,

        /// <summary>
        /// Detailed Preprocessing Record
        /// </summary>
        /// <remarks>
        /// Used to indicate that the parser should construct a "detailed"
        /// preprocessing record, including all macro definitions and instantiations.
        ///
        /// Constructing a detailed preprocessing record requires more memory
        /// and time to parse, since the information contained in the record
        /// is usually not retained. However, it can be useful for
        /// applications that require more detailed information about the
        /// behavior of the preprocessor.
        /// </remarks>
        DetailedPreprocessingRecord = 0x01,

        /// <summary>
        /// Incomplete
        /// </summary>
        /// <remarks>
        /// Used to indicate that the translation unit is incomplete.
        ///
        /// When a translation unit is considered "incomplete", semantic
        /// analysis that is typically performed at the end of the
        /// translation unit will be suppressed. For example, this suppresses
        /// the completion of tentative declarations in C and of
        /// instantiation of implicitly-instantiation function templates in
        /// C++. This option is typically used when parsing a header with the
        /// intent of producing a precompiled header.
        /// </remarks>
        Incomplete = 0x02,

        /// <summary>
        /// Precompiled Preamble
        /// </summary>
        /// <remarks>
        /// Used to indicate that the translation unit should be built with an
        /// implicit precompiled header for the preamble.
        ///
        /// An implicit precompiled header is used as an optimization when a
        /// particular translation unit is likely to be reparsed many times
        /// when the sources aren't changing that often. In this case, an
        /// implicit precompiled header will be built containing all of the
        /// initial includes at the top of the main file (what we refer to as
        /// the "preamble" of the file). In subsequent parses, if the
        /// preamble or the files in it have not changed,
        /// <c>clang_reparseTranslationUnit()</c> will re-use the implicit
        /// precompiled header to improve parsing performance.
        /// </remarks>
        PrecompiledPreamble = 0x04,

        /// <summary>
        /// Cache Completion Results
        /// </summary>
        /// <remarks>
        /// Used to indicate that the translation unit should cache some
        /// code-completion results with each reparse of the source file.
        ///
        /// Caching of code-completion results is a performance optimization that
        /// introduces some overhead to reparsing but improves the performance of
        /// code-completion operations.
        /// </remarks>
        CacheCompletionResults = 0x08,

        /// <summary>
        /// For Serialization
        /// </summary>
        /// <remarks>
        /// Used to indicate that the translation unit will be serialized with
        /// <c>clang_saveTranslationUnit()</c>.
        ///
        /// This option is typically used when parsing a header with the intent of
        /// producing a precompiled header.
        /// </remarks>
        ForSerialization = 0x10,

        /// <summary>
        /// C++ Chained PCH
        /// </summary>
        /// <remarks>
        /// Enabled chained precompiled preambles in C++.
        ///
        /// Note: this is a *temporary* option that is available only while
        /// we are testing C++ precompiled preamble support. It is deprecated.
        /// </remarks>
        [Obsolete]
        CXXChainedPCH = 0x20,

        /// <summary>
        /// Skip Function Bodies
        /// </summary>
        /// <remarks>
        /// Used to indicate that function/method bodies should be skipped while parsing.
        ///
        /// This option can be used to search for declarations/definitions while
        /// ignoring the usages.
        /// </remarks>
        SkipFunctionBodies = 0x40,

        /// <summary>
        /// Include Brief Comments In Code Completion
        /// </summary>
        /// <remarks>
        /// Used to indicate that brief documentation comments should be
        /// included into the set of code completions returned from this translation unit.
        /// </remarks>
        IncludeBriefCommentsInCodeCompletion = 0x80,

        /// <summary>
        /// Create Preamble On First Parse
        /// </summary>
        /// <remarks>
        /// Used to indicate that the precompiled preamble should be created on
        /// the first parse. Otherwise it will be created on the first reparse. This
        /// trades runtime on the first parse (serializing the preamble takes time) for
        /// reduced runtime on the second parse (can now reuse the preamble).
        /// </remarks>
        CreatePreambleOnFirstParse = 0x100,


        /// <summary>
        /// Keep Going
        /// </summary>
        /// <remarks>
        /// Do not stop processing when fatal errors are encountered.
        ///
        /// When fatal errors are encountered while parsing a translation unit,
        /// semantic analysis is typically stopped early when compiling code. A common
        /// source for fatal errors are unresolvable include files. For the
        /// purposes of an IDE, this is undesirable behavior and as much information
        /// as possible should be reported. Use this flag to enable this behavior.
        /// </remarks>
        KeepGoing = 0x200,

        /// <summary>
        /// Single File Parse
        /// </summary>
        /// <remarks>
        /// Sets the preprocessor in a mode for parsing a single file only.
        /// </remarks>
        SingleFileParse = 0x400,

        /// <summary>
        /// Limit Skip Function Bodies To Preamble
        /// </summary>
        /// <remarks>
        /// Used in combination with <c>CXTranslationUnit_SkipFunctionBodies</c> to
        /// constrain the skipping of function bodies to the preamble.
        ///
        /// The function bodies of the main file are not skipped.
        /// </remarks>
        LimitSkipFunctionBodiesToPreamble = 0x800,

        /// <summary>
        /// Include Attributed Type
        /// </summary>
        /// <remarks>
        /// Used to indicate that attributed types should be included in <c>CXType</c>.
        /// </remarks>
        IncludeAttributedTypes = 0x1000,

        /// <summary>
        /// Visit Implicit Attributes
        /// </summary>
        /// <remarks>
        /// Used to indicate that implicit attributes should be visited.
        /// </remarks>
        VisitImplicitAttributes = 0x2000,

        /// <summary>
        /// Ignore No Errors From Included Files
        /// </summary>
        /// <remarks>
        /// Used to indicate that non-errors from included files should be ignored.
        ///
        /// If set, clang_getDiagnosticSetFromTU() will not report e.g. warnings from
        /// included files anymore. This speeds up clang_getDiagnosticSetFromTU() for
        /// the case where these warnings are not of interest, as for an IDE for
        /// example, which typically shows only the diagnostics in the main file.
        /// </remarks>
        IgnoreNonErrorsFromIncludedFiles = 0x4000,
    }
}
