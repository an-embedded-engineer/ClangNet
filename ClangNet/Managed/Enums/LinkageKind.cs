using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Linkage Kind
    /// </summary>
    /// <remarks>
    /// Describe the linkage of the entity referred to by a cursor.
    /// </remarks>
    public enum LinkageKind
    {
        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// This value indicates that no linkage information is available
        /// for a provided <c>CXCursor</c>.
        /// </remarks>
        Invalid,

        /// <summary>
        /// No Linkage
        /// </summary>
        /// <remarks>
        /// This is the linkage for variables, parameters, and so on that have automatic storage.
        /// This covers normal (non-extern) local variables.
        /// </remarks>
        NoLinkage,

        /// <summary>
        /// Internal
        /// </summary>
        /// <remarks>
        /// This is the linkage for static variables and static functions.
        /// </remarks>
        Internal,

        /// <summary>
        /// Unique External
        /// </summary>
        /// <remarks>
        /// This is the linkage for entities with external linkage that live
        /// in C++ anonymous namespaces.
        /// </remarks>
        UniqueExternal,

        /// <summary>
        /// External
        /// </summary>
        /// <remarks>
        /// This is the linkage for entities with true, external linkage.
        /// </remarks>
        External,
    }
}
