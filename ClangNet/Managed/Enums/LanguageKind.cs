using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Language Kind
    /// </summary>
    /// <remarks>
    /// Describe the "language" of the entity referred to by a cursor.
    /// </remarks>
    public enum LanguageKind
    {
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// C
        /// </summary>
        C,

        /// <summary>
        /// Objective-C
        /// </summary>
        ObjC,

        /// <summary>
        /// C++
        /// </summary>
        CPlusPlus,
    }
}
