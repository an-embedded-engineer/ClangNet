using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Version
    /// </summary>
    /// <remarks>
    /// Describes a version number of the form major.minor.subminor.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXVersion
    {
        /// <summary>
        /// Major Version Number
        /// </summary>
        /// <remarks>
        /// The major version number, e.g., the '10' in '10.7.3'.
        /// A negative value indicates that there is no version number at all.
        /// </remarks>
        public readonly int Major;

        /// <summary>
        /// Minor Version Number
        /// </summary>
        /// <remarks>
        /// The minor version number, e.g., the '7' in '10.7.3'.
        /// This value will be negative if no minor version number was provided,
        /// e.g., for version '10'.
        /// </remarks>
        public readonly int Minor;

        /// <summary>
        /// Subminor Version Number
        /// </summary>
        /// <remarks>
        /// The subminor version number, e.g., the '3' in '10.7.3'.
        /// This value will be negative if no minor or subminor version number was provided,
        /// e.g., in version '10' or '10.7'.
        /// </remarks>
        public readonly int SubMinor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="major">The major version number</param>
        /// <param name="minor">The minor version number</param>
        /// <param name="subminor">The subminor version number</param>
        public CXVersion(int major, int minor, int subminor)
        {
            Major = major;
            Minor = minor;
            SubMinor = subminor;
        }
    }
}
