using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Behavior Cross Reference Info
    /// </summary>
    public class BehaviorCrossReferenceInfo : ValueObject<BehaviorCrossReferenceInfo>
    {
        /// <summary>
        /// Behavior ID
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Reference Type
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Referenced Location
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Behavior Info</param>
        public BehaviorCrossReferenceInfo(BehaviorInfo info)
        {
            this.ID = info.ID;

            this.Type = info.Type;

            this.Location = info.Location;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Invokation Info</param>
        public BehaviorCrossReferenceInfo(InvokationInfo info)
        {
            this.ID = info.ID;

            this.Type = "Call";

            this.Location = info.Location;
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[{this.Type}]{this.ID} @ {this.Location}";
        }

        /// <summary>
        /// Equals Core
        /// </summary>
        /// <param name="other">Other Object</param>
        /// <returns>Equality</returns>
        protected override bool EqualsCore(BehaviorCrossReferenceInfo other)
        {
            return (this.ID == other.ID && this.Type == other.Type && this.Location == other.Location);
        }

        /// <summary>
        /// Get Hash Code Parameters
        /// </summary>
        /// <returns>Hash Code Parameters</returns>
        protected override IEnumerable<object> GetHashCodeParameters()
        {
            var objs = new List<object>()
            {
                this.ID,
                this.Type,
                this.Location,
            };

            return objs;
        }
    }
}
