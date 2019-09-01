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
    /// Managed Clang Source Range List
    /// </summary>
    public class ClangSourceRangeList : ClangObject
    {
        /// <summary>
        /// Native Clang Source Range List
        /// </summary>
        internal CXSourceRangeList Source { get; }

        /// <summary>
        /// Source Range Count
        /// </summary>
        public int Count
        {
            get { return (int)this.Source.Count; }
        }

        /// <summary>
        /// Clang Source Range List
        /// </summary>
        public IEnumerable<ClangSourceRange> Ranges
        {
            get { return this.Source.Ranges.ToNativeStructs<CXSourceRange>(this.Count).Select(r => r.ToManaged()); }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Source Range</returns>
        public ClangSourceRange this[int i]
        {
            get { return this.Ranges.ElementAt(i); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Source Range List Pointer</param>
        public ClangSourceRangeList(IntPtr handle) : base(handle)
        {
            this.Source = this.Handle.ToNativeStuct<CXSourceRangeList>();
        }
    }
}
