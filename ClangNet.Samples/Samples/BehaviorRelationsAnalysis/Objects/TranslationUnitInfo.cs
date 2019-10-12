using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Translation Unit Info
    /// </summary>
    public class TranslationUnitInfo : AstNodeInfo
    {
        /// <summary>
        /// Translation Unit Path
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Behavior Map
        /// </summary>
        public BehaviorLocationMap BehaviorMap { get; } = new BehaviorLocationMap();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public TranslationUnitInfo(ClangCursor cursor) : base(cursor)
        {
            this.Path = System.IO.Path.GetFullPath(cursor.Spelling);
        }

        /// <summary>
        /// Add Behavior Info
        /// </summary>
        /// <param name="behavior">Behavior Info</param>
        public void AddBehavior(BehaviorInfo behavior)
        {
            this.BehaviorMap.Add(behavior);
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[TranslationUnit]{this.Path}";
        }
    }
}
