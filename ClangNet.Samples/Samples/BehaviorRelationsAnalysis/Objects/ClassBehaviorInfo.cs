namespace ClangNet.Samples
{
    /// <summary>
    /// Class Behavior Info
    /// </summary>
    public abstract class ClassBehaviorInfo : BehaviorInfo
    {
        /// <summary>
        /// Class Name
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public ClassBehaviorInfo(ClangCursor cursor) : base(cursor)
        {
            var parent_class = cursor.SemanticParent;

            this.ClassName = parent_class.Spelling;
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[ClassBehavior][{this.Type}] {this.Definition}";
        }
    }
}
