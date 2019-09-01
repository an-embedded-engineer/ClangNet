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
    /// Managed Clang File Unique ID
    /// </summary>
    public class ClangFileUniqueId : ClangValueObject<ClangFileUniqueId>
    {
        /// <summary>
        /// Native Clang File Unique ID
        /// </summary>
        internal CXFileUniqueID Source { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang File Unique ID</param>
        internal ClangFileUniqueId(CXFileUniqueID source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>File Unique ID Data</returns>
        public override string ToString()
        {
            return $"{this.Source.Data1:X08},{this.Source.Data2:X08},{this.Source.Data3:X08}";
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Clang File Unique ID</param>
        /// <returns>Check Result</returns>
        protected override bool EqualsCore(ClangFileUniqueId other)
        {
            return this.Source.Data1 == other.Source.Data1 && this.Source.Data2 == other.Source.Data2 && this.Source.Data3 == other.Source.Data3;
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        protected override int GetHashCodeCore()
        {
            return (this.Source.Data1.GetHashCode() ^ this.Source.Data2.GetHashCode() ^ this.Source.Data3.GetHashCode());
        }
    }
}
