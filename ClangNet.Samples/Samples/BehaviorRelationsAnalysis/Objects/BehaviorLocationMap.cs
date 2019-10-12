using System;
using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Behavior Location Map
    /// </summary>
    public class BehaviorLocationMap : Dictionary<string, BehaviorInfo>
    {
        /// <summary>
        /// Add Behavior Info
        /// </summary>
        /// <param name="behavior">Behavior Info</param>
        public void Add(BehaviorInfo behavior)
        {
            if (this.ContainsKey(behavior.Location) == false)
            {
                this.Add(behavior.Location, behavior);
            }
            else
            {
                throw new InvalidOperationException($"Behavior Already Registered : {behavior.ID}");
            }
        }

        /// <summary>
        /// Add Behavior Info When Not Registered
        /// </summary>
        /// <param name="behavior">Behavior Info</param>
        public void AddIfNotRegistered(BehaviorInfo behavior)
        {
            if (this.ContainsKey(behavior.Location) == false)
            {
                this.Add(behavior.Location, behavior);
            }
            else
            {
                /* Nothing to do */
            }
        }
    }
}
