using System;
using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Translation Unit Map
    /// </summary>
    public class TranslationUnitMap : Dictionary<string, TranslationUnitInfo>
    {
        /// <summary>
        /// Add Translation Unit Info
        /// </summary>
        /// <param name="tu">Translation Unit Info</param>
        public void Add(TranslationUnitInfo tu)
        {
            if (this.ContainsKey(tu.Path) == false)
            {
                this.Add(tu.Path, tu);
            }
            else
            {
                throw new InvalidOperationException($"Translation Unit Already Registered : {tu.Path}");
            }
        }
    }
}
