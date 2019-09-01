using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Availability Kind
    /// </summary>
    /// <remarks>
    /// Describes the availability of a particular entity, which indicates
    /// whether the use of this entity will result in a warning or error due to
    /// it being deprecated or unavailable.
    /// </remarks>
    public enum AvailabilityKind
    {
        /// <summary>
        /// Available
        /// </summary>
        /// <remarks>
        /// The entity is available.
        /// </remarks>
        Available,

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <remarks>
        /// The entity is available, but has been deprecated
        /// (and its use is not recommended).
        /// </remarks>
        Deprecated,

        /// <summary>
        /// Not Available
        /// </summary>
        /// <remarks>
        /// The entity is not available;
        /// any use of it will be an error.
        /// </remarks>
        NotAvailable,

        /// <summary>
        /// Not Accessible
        /// </summary>
        /// <remarks>
        /// The entity is available, but not accessible;
        /// any use of it will be an error.
        /// </remarks>
        NotAccessible,
    }
}
