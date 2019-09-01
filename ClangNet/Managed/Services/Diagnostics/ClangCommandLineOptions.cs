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
    /// Clang Command Line Options
    /// </summary>
    public struct ClangCommandLineOptions
    {
        /// <summary>
        /// Enabled Options
        /// </summary>
        public string Enable { get; private set; }

        /// <summary>
        /// Disabled Options
        /// </summary>
        public string Disable { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enable">Enabled Options</param>
        /// <param name="disable">Disabled Options</param>
        public ClangCommandLineOptions(string enable, string disable)
        {
            this.Enable = enable;
            this.Disable = disable;
        }
    }
}
