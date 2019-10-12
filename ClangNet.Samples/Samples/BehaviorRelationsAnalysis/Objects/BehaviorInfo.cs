using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClangNet.Samples
{
    /// <summary>
    /// Behavior Info
    /// </summary>
    public abstract class BehaviorInfo : AstNodeInfo
    {
        /// <summary>
        /// Behavior Type
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Behavior Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Behavior Parameters
        /// </summary>
        public string Parameters { get; }

        /// <summary>
        /// Behavior Namespace
        /// </summary>
        public string NameSpace { get; }

        /// <summary>
        /// Definition
        /// </summary>
        public string Definition => this.GetDefinition();

        /// <summary>
        /// ID
        /// </summary>
        public string ID => this.GenerateBehaviorID();

        /// <summary>
        /// Invokation List
        /// </summary>
        public List<InvokationInfo> Invokations { get; } = new List<InvokationInfo>();

        /// <summary>
        /// Get Behavior Definition
        /// </summary>
        /// <returns>Behavior Definition</returns>
        protected abstract string GetDefinition();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public BehaviorInfo(ClangCursor cursor) : base(cursor)
        {
            this.Type = cursor.IsDefinition ? "Definition" : "Declaration";

            this.Name = cursor.Spelling;

            this.Parameters = cursor.DisplayName.Replace(cursor.Spelling, "");

            this.NameSpace = this.GetNamespace(cursor);
        }

        /// <summary>
        /// Add Invokation Info
        /// </summary>
        /// <param name="invokation_info">Invokation Info</param>
        public void AddInvokation(InvokationInfo invokation_info)
        {
            this.Invokations.Add(invokation_info);
        }

        /// <summary>
        /// Generate Behavior ID
        /// </summary>
        /// <returns>Behavior ID</returns>
        private string GenerateBehaviorID()
        {
            return this.Definition;
        }

        /// <summary>
        /// Get Behavior Namespace
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <returns>Behavior Namespace</returns>
        private string GetNamespace(ClangCursor cursor)
        {
            var namespace_stack = new Stack<string>();

            this.ParseNamespace(cursor, namespace_stack);

            if (namespace_stack.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                var sb = new StringBuilder();

                sb.Append(namespace_stack.Pop());

                while(namespace_stack.Count != 0)
                {
                    sb.Append("::");
                    sb.Append(namespace_stack.Pop());
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Parse Namespace
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <param name="namespace_stack">Namespace Stack</param>
        private void ParseNamespace(ClangCursor cursor, Stack<string> namespace_stack)
        {
            var parent = cursor.SemanticParent;

            if (parent != null)
            {
                if (parent.Kind == CursorKind.TranslationUnit)
                {
                    /* Parse End */
                }
                else if(parent.Kind == CursorKind.Namespace)
                {
                    namespace_stack.Push(parent.Spelling);

                    this.ParseNamespace(parent, namespace_stack);
                }
                else
                {
                    this.ParseNamespace(parent, namespace_stack);
                }
            }
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Detail</returns>
        public override string ToString()
        {
            return $"[Behavior][{this.Type}] {this.Definition}";
        }
    }
}
