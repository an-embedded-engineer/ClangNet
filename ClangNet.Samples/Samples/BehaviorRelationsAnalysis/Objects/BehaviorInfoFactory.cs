using System;

namespace ClangNet.Samples
{
    /// <summary>
    /// Behavior Info Factory
    /// </summary>
    public static class BehaviorInfoFactory
    {
        /// <summary>
        /// Create Behavior Info
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <returns>Behavior Info</returns>
        public static BehaviorInfo Create(ClangCursor cursor)
        {
            switch(cursor.Kind)
            {
                case CursorKind.Constructor:
                    return new ConstructorInfo(cursor);
                case CursorKind.Destructor:
                    return new DestructorInfo(cursor);
                case CursorKind.FunctionDeclaration:
                    return new FunctionInfo(cursor);
                case CursorKind.CXXMethod:
                    return new CppMethodInfo(cursor);
                default:
                    throw new ArgumentException($"Not Behavior Cursor");
            }
        }
    }
}
