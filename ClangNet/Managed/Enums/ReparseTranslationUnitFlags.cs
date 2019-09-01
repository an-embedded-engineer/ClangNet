using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Reparse Translation Unit Flags
    /// </summary>
    /// <remarks>
    /// Flags that control the reparsing of translation units.
    ///
    /// The enumerators in this enumeration type are meant to be bitwise
    /// ORed together to specify which options should be used when
    /// reparsing the translation unit.
    /// </remarks>
    [Flags]
    public enum ReparseTranslationUnitFlags
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Used to indicate that no special reparsing options are needed.
        /// </remarks>
        None = 0x0,
    }
}
