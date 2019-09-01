using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Source Location
    /// </summary>
    public struct ClangSourceLocation
    {
        /// <summary>
        /// Native Clang Source Location
        /// </summary>
        internal CXSourceLocation Source { get; }

        /// <summary>
        /// In System Header Flag
        /// </summary>
        public bool IsInSystemHeader
        {
            get { return LibClang.clang_Location_isInSystemHeader(this.Source).ToBool(); }
        }

        /// <summary>
        /// From Main File Flag
        /// </summary>
        public bool IsFromMainFile
        {
            get { return LibClang.clang_Location_isFromMainFile(this.Source).ToBool(); }
        }

        /// <summary>
        /// Expansion Clang Physical Location
        /// </summary>
        public ClangPhysicalLocation ExpansionLocation
        {
            get
            {
                LibClang.clang_getExpansionLocation(this.Source, out var file, out var line, out var column, out var offset);

                return new ClangPhysicalLocation(file.ToManaged<ClangFile>(), line, column, offset);
            }
        }

        /// <summary>
        /// Presumed Clang Logical Location
        /// </summary>
        public ClangLogicalLocation PresumedLocation
        {
            get
            {
                LibClang.clang_getPresumedLocation(this.Source, out var file_name, out var line, out var column);

                return new ClangLogicalLocation(file_name.ToManaged(), line, column);
            }
        }

        /// <summary>
        /// Instantiation Clang Physical Location
        /// </summary>
        public ClangPhysicalLocation InstantiationLocation
        {
            get
            {
                LibClang.clang_getInstantiationLocation(this.Source, out var file, out var line, out var column, out var offset);

                return new ClangPhysicalLocation(file.ToManaged<ClangFile>(), line, column, offset);
            }
        }

        /// <summary>
        /// Spelling Clang Physical Location
        /// </summary>
        public ClangPhysicalLocation SpellingLocation
        {
            get
            {
                LibClang.clang_getSpellingLocation(this.Source, out var file, out var line, out var column, out var offset);

                return new ClangPhysicalLocation(file.ToManaged<ClangFile>(), line, column, offset);
            }
        }

        /// <summary>
        /// File Clang Physical Location
        /// </summary>
        public ClangPhysicalLocation FileLocation
        {
            get
            {
                LibClang.clang_getFileLocation(this.Source, out var file, out var line, out var column, out var offset);

                return new ClangPhysicalLocation(file.ToManaged<ClangFile>(), line, column, offset);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Source Location</param>
        internal ClangSourceLocation(CXSourceLocation source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Check Result</returns>
        public override bool Equals(object obj)
        {
            return (obj != null && obj is ClangSourceLocation sloc) ? this.Equals(sloc) : false;
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Clang Source Location</param>
        /// <returns>Check Result</returns>
        public bool Equals(ClangSourceLocation other)
        {
            return LibClang.clang_equalLocations(this.Source, other.Source).ToBool();
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="o1">Clang Source Location 1</param>
        /// <param name="o2">Clang Source Location 2</param>
        /// <returns>Check Result</returns>
        public static bool operator ==(ClangSourceLocation o1, ClangSourceLocation o2)
        {
            return o1.Equals(o2);
        }

        /// <summary>
        /// Check Not Equality
        /// </summary>
        /// <param name="o1">Clang Source Location 1</param>
        /// <param name="o2">Clang Source Location 2</param>
        /// <returns>Check Result</returns>
        public static bool operator !=(ClangSourceLocation o1, ClangSourceLocation o2)
        {
            return !o1.Equals(o2);
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return this.Source.GetHashCode();
        }
    }
}
