using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Bool Extensions
    /// </summary>
    public static class BoolEx
    {
        /// <summary>
        /// Convert To Int
        /// </summary>
        /// <param name="value">Bool Value</param>
        /// <returns>Int Value</returns>
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Convert To Unsigned Int
        /// </summary>
        /// <param name="value">Bool Value</param>
        /// <returns>Unsigned int</returns>
        public static uint ToUInt(this bool value)
        {
            return value ? 1u : 0u;
        }

        /// <summary>
        /// Convert To Bool
        /// </summary>
        /// <param name="value">Int Value</param>
        /// <returns>Bool Value</returns>
        public static bool ToBool(this int value)
        {
            return value == 0 ? false : true;
        }

        /// <summary>
        /// Convert To Bool
        /// </summary>
        /// <param name="value">Unsigned Int Value</param>
        /// <returns>Bool Value</returns>
        public static bool ToBool(this uint value)
        {
            return value == 0 ? false : true;
        }
    }
}