using System;
using System.Collections.Generic;
using System.Text;

namespace ClangNet.Samples
{
    /// <summary>
    /// Value Object
    /// </summary>
    /// <typeparam name="T">Value Object Type</typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// Check Equality Core
        /// </summary>
        /// <param name="other">Other Object</param>
        /// <returns>Equality</returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Get Hash Code Parameters
        /// </summary>
        /// <returns>Hash Code Parameters</returns>
        protected abstract IEnumerable<object> GetHashCodeParameters();

        /// <summary>
        /// Equality Operator
        /// </summary>
        /// <param name="left">Left Value</param>
        /// <param name="right">Right Value</param>
        /// <returns>Equality</returns>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Inequality Operator
        /// </summary>
        /// <param name="left">Left Value</param>
        /// <param name="right">Right Value</param>
        /// <returns>Inequality</returns>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="obj">Other Object</param>
        /// <returns>Equality</returns>
        public override bool Equals(object obj)
        {
            var other = obj as T;

            if (other == null)
            {
                return false;
            }
            else
            {
                return this.EqualsCore(other);
            }
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            var objs = this.GetHashCodeParameters();

            var hash = 0;

            foreach(var obj in objs)
            {
                hash ^= obj.GetHashCode();
            }

            return hash;
        }
    }
}
