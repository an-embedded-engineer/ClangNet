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
    /// Managed Clang Source Range
    /// </summary>
    public struct ClangSourceRange
    {
        /// <summary>
        /// Native Clang Source Range
        /// </summary>
        internal CXSourceRange Source { get; }

        /// <summary>
        /// Null Source Range Flag
        /// </summary>
        public bool IsNull
        {
            get { return LibClang.clang_Range_isNull(this.Source).ToBool(); }
        }

        /// <summary>
        /// Start Clang Source Location
        /// </summary>
        public ClangSourceLocation Start
        {
            get { return LibClang.clang_getRangeStart(this.Source).ToManaged(); }
        }

        /// <summary>
        /// End Clang Source Location
        /// </summary>
        public ClangSourceLocation End
        {
            get { return LibClang.clang_getRangeEnd(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Source Range</param>
        internal ClangSourceRange(CXSourceRange source)
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
            return (obj != null && obj is ClangSourceRange srange) ? this.Equals(srange) : false;
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Clang Source Range</param>
        /// <returns>Check Result</returns>
        public bool Equals(ClangSourceRange other)
        {
            return LibClang.clang_equalRanges(this.Source, other.Source).ToBool();
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="o1">Clang Source Range 1</param>
        /// <param name="o2">Clang Source Range 2</param>
        /// <returns>Check Result</returns>
        public static bool operator ==(ClangSourceRange o1, ClangSourceRange o2)
        {
            return o1.Equals(o2);
        }

        /// <summary>
        /// Check Not Equality
        /// </summary>
        /// <param name="o1">Clang Source Range 1</param>
        /// <param name="o2">Clang Source Range 2</param>
        /// <returns>Check Result</returns>
        public static bool operator !=(ClangSourceRange o1, ClangSourceRange o2)
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
