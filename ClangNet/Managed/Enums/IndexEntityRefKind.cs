using System;

namespace ClangNet
{
    /// <summary>
    /// Index Entity Reference Kind
    /// </summary>
    /// <remarks>
    /// Data for <c>IndexerCallbacks#indexEntityReference</c>.
    /// </remarks>
    public enum IndexEntityRefKind
    {
        /// <summary>
        /// Direct
        /// </summary>
        /// <remarks>
        /// The entity is referenced directly in user's code.
        /// </remarks>
        Direct = 1,

        /// <summary>
        /// Implicit
        /// </summary>
        /// <remarks>
        /// An implicit reference, e.g. a reference of an ObjC method via the dot syntax.
        /// </remarks>
        Implicit = 2,
    }
}
