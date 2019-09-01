using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Visibility Kind
    /// </summary>
    public enum VisibilityKind
    {
        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// This value indicates that no visibility information is available
        /// for a provided <c>CXCursor</c>.
        /// </remarks>
        Invalid,

        /// <summary>
        /// Hidden
        /// </summary>
        /// <remarks>
        /// Symbol not seen by the linker.
        /// </remarks>
        Hidden,

        /// <summary>
        /// Protected
        /// </summary>
        /// <remarks>
        /// Symbol seen by the linker but resolves to a symbol inside this object.
        /// </remarks>
        Protected,

        /// <summary>
        /// Default
        /// </summary>
        /// <remarks>
        /// Symbol seen by the linker and acts like a normal symbol.
        /// </remarks>
        Default,
    }
}
