using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Save Translation Unit Flags
    /// </summary>
    /// <remarks>
    /// Flags that control how translation units are saved.
    ///
    /// The enumerators in this enumeration type are meant to be bitwise
    /// ORed together to specify which options should be used when
    /// saving the translation unit.
    /// </remarks>
    [Flags]
    public enum SaveTranslationUnitFlags
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Used to indicate that no special saving options are needed.
        /// </remarks>
        None = 0x0,
    }
}
