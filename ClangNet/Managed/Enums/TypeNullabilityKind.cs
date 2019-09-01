using System;

namespace ClangNet
{
    /// <summary>
    /// Type Nullability Kind
    /// </summary>
    public enum TypeNullabilityKind
    {
        /// <summary>
        /// Non Null
        /// </summary>
        /// <remarks>
        /// Values of this type can never be null.
        /// </remarks>
        NonNull = 0,

        /// <summary>
        /// Nullable
        /// </summary>
        /// <remarks>
        /// Values of this type can be null.
        /// </remarks>
        Nullable = 1,

        /// <summary>
        /// Unspecified
        /// </summary>
        /// <remarks>
        /// Whether values of this type can be null is (explicitly)
        /// unspecified. This captures a (fairly rare) case where we
        /// can't conclude anything about the nullability of the type even
        /// though it has been considered.
        /// </remarks>
        Unspecified = 2,

        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// Nullability is not applicable to this type.
        /// </remarks>
        Invalid = 3,
    }
}
