namespace ClangNet.Samples
{
    /// <summary>
    /// C++ Method Info
    /// </summary>
    public class CppMethodInfo : ClassBehaviorInfo
    {
        /// <summary>
        /// Return Type
        /// </summary>
        public string ReturnType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public CppMethodInfo(ClangCursor cursor) : base(cursor)
        {
            var rtype = cursor.ResultType;

            this.ReturnType = rtype.Spelling;
        }

        /// <summary>
        /// Get Behavior Definition
        /// </summary>
        /// <returns>Behavior Definition</returns>
        protected override string GetDefinition()
        {
            var ns = this.NameSpace == string.Empty ? "" : $"{this.NameSpace}::";

            return $"{this.ReturnType} {ns}{this.ClassName}::{this.Name}{this.Parameters}";
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[Function][{this.Type}] {this.Definition}";
        }
    }
}
