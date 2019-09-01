namespace ClangNet
{
    /// <summary>
    /// Clang Class Value Object
    /// </summary>
    /// <typeparam name="T">Sub Class Type</typeparam>
    public abstract class ClangValueObject<T> where T : class
    {
        /// <summary>
        /// Check Equality Core
        /// </summary>
        /// <param name="other">Other Object</param>
        /// <returns>Check Result</returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Get Hash Code Core
        /// </summary>
        /// <returns>Hash Code</returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="left">Left Value Object</param>
        /// <param name="right">Right Value Object</param>
        /// <returns>Check Result</returns>
        public static bool operator==(ClangValueObject<T> left, ClangValueObject<T> right)
        {
            if(ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            else
            {
                return ReferenceEquals(left, null) || left.Equals(right);
            }
        }

        /// <summary>
        /// Check Not Equality
        /// </summary>
        /// <param name="left">Left Value Object</param>
        /// <param name="right">Right Value Object</param>
        /// <returns>Check Result</returns>
        public static bool operator!=(ClangValueObject<T> left, ClangValueObject<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="obj">Other Object</param>
        /// <returns>Check Result</returns>
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return this.EqualsCore(obj as T);
            }
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return this.GetHashCodeCore();
        }
    }
}
