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
    /// Managed Clang Diagnostic
    /// </summary>
    public class ClangDiagnostic : ClangObject, IDisposable
    {
        /// <summary>
        /// Child Diagnostic Set
        /// </summary>
        public ClangDiagnosticSet ChildDiagnostics
        {
            get { return LibClang.clang_getChildDiagnostics(this.Handle).ToManaged<ClangDiagnosticSet>(); }
        }

        /// <summary>
        /// Diagnostic Severity
        /// </summary>
        public DiagnosticSeverity Severity
        {
            get { return LibClang.clang_getDiagnosticSeverity(this.Handle); }
        }

        /// <summary>
        /// Diagnostic Clang Source Location
        /// </summary>
        public ClangSourceLocation Location
        {
            get { return LibClang.clang_getDiagnosticLocation(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Diagnostic Spelling
        /// </summary>
        public string DiagnosticSpelling
        {
            get { return LibClang.clang_getDiagnosticSpelling(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Clang Command Line Options
        /// </summary>
        public ClangCommandLineOptions Options
        {
            get
            {
                var enable = LibClang.clang_getDiagnosticOption(this.Handle, out var disable);

                var cloptions = new ClangCommandLineOptions(enable.ToManaged(), disable.ToManaged());

                return cloptions;
            }
        }

        /// <summary>
        /// Clang Diagnostic Category
        /// </summary>
        public ClangDiagnosticCategory Category
        {
            get { return new ClangDiagnosticCategory(LibClang.clang_getDiagnosticCategory(this.Handle)); }
        }

        /// <summary>
        /// Diagnostic Category Text
        /// </summary>
        public string CategoryText
        {
            get { return LibClang.clang_getDiagnosticCategoryText(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Diagnostic Source Range Count
        /// </summary>
        public int RangeCount
        {
            get { return (int)LibClang.clang_getDiagnosticNumRanges(this.Handle); }
        }

        /// <summary>
        /// Diagnostic Fix It Count
        /// </summary>
        public int FixItCount
        {
            get { return (int)LibClang.clang_getDiagnosticNumFixIts(this.Handle); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Diagnostic Pointer</param>
        internal ClangDiagnostic(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Format Diagnostic
        /// </summary>
        /// <param name="options">Diagnostic Display Options</param>
        /// <returns>Formated Diagnostic</returns>
        public string FormatDiagnostic(DiagnosticDisplayOptions options)
        {
            return LibClang.clang_formatDiagnostic(this.Handle, options).ToManaged();
        }

        /// <summary>
        /// Format Diagnostic by Default
        /// </summary>
        /// <returns>Formated Diagnostic</returns>
        public string FormatDiagnostic()
        {
            var options = Clang.GetDefaultDiagnosticDisplayOptions();

            return LibClang.clang_formatDiagnostic(this.Handle, options).ToManaged();
        }

        /// <summary>
        /// Get Diagnostic Clang Source Range
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Diagnostic Clang Source Range</returns>
        public ClangSourceRange GetDiagnosticRange(int index)
        {
            return LibClang.clang_getDiagnosticRange(this.Handle, (uint)index).ToManaged();
        }

        /// <summary>
        /// Get Diagnostic Clang Fix It
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Diagnostic Clang Fix It</returns>
        public ClangFixIt GetFixIt(int index)
        {
            var fixit = LibClang.clang_getDiagnosticFixIt(this.Handle, (uint)index, out var replacement_range);

            return new ClangFixIt(replacement_range.ToManaged(), fixit.ToManaged());
        }

        /// <summary>
        /// Dispose Clang Diagnostic
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeDiagnostic(this.Handle);
        }
    }
}
