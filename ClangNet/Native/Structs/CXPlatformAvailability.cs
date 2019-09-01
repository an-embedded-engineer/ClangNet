using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Platform Availability
    /// </summary>
    /// <remarks>
    /// Describes the availability of a given entity on a particular platform,
    /// e.g., a particular class might only be available on Mac OS 10.7 or newer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXPlatformAvailability
    {
        /// <summary>
        /// Platform Clang String
        /// </summary>
        /// <remarks>
        /// A string that describes the platform for which this structure
        /// provides availability information.
        ///
        /// Possible values are "ios" or "macos".
        /// </remarks>
        public readonly CXString Platform;

        /// <summary>
        /// Introduced Clang Version
        /// </summary>
        /// <remarks>
        /// The version number in which this entity was introduced.
        /// </remarks>
        public readonly CXVersion Introduced;

        /// <summary>
        /// Deprecated Clang Version
        /// </summary>
        /// <remarks>
        /// The version number in which this entity was deprecated (but is still available).
        /// </remarks>
        public readonly CXVersion Deprecated;

        /// <summary>
        /// Obsoleted Clang Version
        /// </summary>
        /// <remarks>
        /// The version number in which this entity was obsoleted, and therefore
        /// is no longer available.
        /// </remarks>
        public readonly CXVersion Obsoleted;

        /// <summary>
        /// Unavailable Flag
        /// </summary>
        /// <remarks>
        /// Whether the entity is unconditionally unavailable on this platform.
        /// </remarks>
        public readonly int Unavailable;

        /// <summary>
        /// Optional Message Clang String
        /// </summary>
        /// <remarks>
        /// An optional message to provide to a user of this API,
        /// e.g., to suggest replacement APIs.
        /// </remarks>
        public readonly CXString Message;
    }
}
