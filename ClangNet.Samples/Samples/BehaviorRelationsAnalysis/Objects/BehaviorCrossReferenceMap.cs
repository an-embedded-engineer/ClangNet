using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Behavior Cross Reference Map
    /// </summary>
    public class BehaviorCrossReferenceMap : Dictionary<string, HashSet<BehaviorCrossReferenceInfo>>
    {
        /// <summary>
        /// Add Behavior Cross Reference Info
        /// </summary>
        /// <param name="info">Behavior Cross Reference Info</param>
        public void Add(BehaviorCrossReferenceInfo info)
        {
            if (this.ContainsKey(info.ID) == false)
            {
                this.Add(info.ID, new HashSet<BehaviorCrossReferenceInfo>());
            }

            this[info.ID].Add(info);
        }
    }
}
