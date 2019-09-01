using System;

namespace ClangNet
{
    /// <summary>
    /// Index Option Flags
    /// </summary>
    [Flags]
    public enum IndexOptionFlags
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Used to indicate that no special indexing options are needed.
        /// </remarks>
        None = 0x00,

        /// <summary>
        /// Supress Redundant References
        /// </summary>
        /// <remarks>
        /// Used to indicate that IndexerCallbacks#indexEntityReference should
        /// be invoked for only one reference of an entity per source file that does
        /// not also include a declaration/definition of the entity.
        /// </remarks>
        SuppressRedundantRefs = 0x01,

        /// <summary>
        /// Index Function Local Symbols
        /// </summary>
        /// <remarks>
        /// Function-local symbols should be indexed.
        /// If this is not set function-local symbols will be ignored.
        /// </remarks>
        IndexFunctionLocalSymbols = 0x02,

        /// <summary>
        /// Index Implicit Template Instantiations
        /// </summary>
        /// <remarks>
        /// Implicit function/class template instantiations should be indexed.
        /// If this is not set, implicit instantiations will be ignored.
        /// </remarks>
        IndexImplicitTemplateInstantiations = 0x04,

        /// <summary>
        /// Suppress Warnings
        /// </summary>
        /// <remarks>
        /// Suppress all compiler warnings when parsing for indexing.
        /// </remarks>
        SuppressWarnings = 0x08,

        /// <summary>
        /// Skip Parsed Bodies In Session
        /// </summary>
        /// <remarks>
        /// Skip a function/method body that was already parsed during an
        /// indexing session assosiated with a <c>CXIndexAction</c> object.
        /// Bodies in system headers are always skipped.
        /// </remarks>
        SkipParsedBodiesInSession = 0x10,
    }
}
