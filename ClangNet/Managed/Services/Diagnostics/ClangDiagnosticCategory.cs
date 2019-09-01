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
    /// Managed Clang Diagnostic Category
    /// </summary>
    public struct ClangDiagnosticCategory
    {
        /// <summary>
        /// Diagnostic Category Number
        /// </summary>
        public uint Number { get; }

        /// <summary>
        /// Diagnostic Catgory Name
        /// </summary>
        public string Name
        {
            get { return LibClang.clang_getDiagnosticCategoryName(this.Number).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="category">Diagnostic Category Number</param>
        public ClangDiagnosticCategory(uint category)
        {
            this.Number = category;
        }
    }
}
