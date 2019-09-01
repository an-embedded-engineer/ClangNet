using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Diagnostic Severity
    /// </summary>
    /// <remarks>
    /// Describes the severity of a particular diagnostic.
    /// </remarks>
    public enum DiagnosticSeverity
    {
        /// <summary>
        /// Ignored
        /// </summary>
        /// <remarks>
        /// A diagnostic that has been suppressed, e.g.,
        /// by a command-line option.
        /// </remarks>
        Ignored = 0,

        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// This diagnostic is a note that should be attached to the
        /// previous (non-note) diagnostic.
        /// </remarks>
        Note = 1,

        /// <summary>
        /// Warning
        /// </summary>
        /// <remarks>
        /// This diagnostic indicates suspicious code that may not be wrong.
        /// </remarks>
        Warning = 2,

        /// <summary>
        /// Error
        /// </summary>
        /// <remarks>
        /// This diagnostic indicates that the code is ill-formed.
        /// </remarks>
        Error = 3,

        /// <summary>
        /// Fatal
        /// </summary>
        /// <remarks>
        /// This diagnostic indicates that the code is ill-formed such
        /// that future parser recovery is unlikely to produce useful results.
        /// </remarks>
        Fatal = 4,
    }
}
