using System;

namespace ClangNet.Samples
{
    /// <summary>
    /// Invokation Info
    /// </summary>
    public class InvokationInfo : AstNodeInfo
    {
        /// <summary>
        /// Behavior ID
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Behavior Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Declaration Behavior Info
        /// </summary>
        public BehaviorInfo Declaration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public InvokationInfo(ClangCursor cursor) : base(cursor)
        {
            this.Name = cursor.Spelling;

            if (cursor.Referenced != null)
            {
                this.Declaration = BehaviorInfoFactory.Create(cursor.Referenced);

                this.ID = this.Declaration.ID;
            }
            else
            {
                throw new FieldAccessException($"Behavior Declaration Not Found : {this.Name}");
            }
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[Invokation]{this.Name}";
        }
    }
}
