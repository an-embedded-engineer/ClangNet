namespace ClangNet.Samples
{
    /// <summary>
    /// Constructor Name
    /// </summary>
    public class ConstructorInfo : ClassBehaviorInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public ConstructorInfo(ClangCursor cursor) : base(cursor)
        {
        }

        /// <summary>
        /// Get Behavior Definition
        /// </summary>
        /// <returns>Behavior Definition</returns>
        protected override string GetDefinition()
        {
            var ns = this.NameSpace == string.Empty ? "" : $"{this.NameSpace}::";

            return $"{ns}{this.ClassName}::{this.Name}{this.Parameters}";
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[Constructor][{this.Type}] {this.Definition}";
        }
    }
}
