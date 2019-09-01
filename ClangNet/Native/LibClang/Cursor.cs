#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // A fast container representing a set of CXCursors.
    // struct CXCursorSetImpl*
    using CXCursorSet = IntPtr;

    // CXCursor**
    using CXCursorPtrPtr = IntPtr;

    // CXCursor*
    using CXCursorPtr = IntPtr;

    // CXPlatformAvailability*
    using CXPlatformAvailabilityPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Cursor Manipulations
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve the NULL cursor, which represents no entity.
        /// </summary>
        /// <returns>NULL Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getNullCursor();

        /// <summary>
        /// Retrieve the cursor that represents the given translation unit.
        ///
        /// The translation unit cursor can be used to start traversing the
        /// various declarations within the given translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getTranslationUnitCursor(CXTranslationUnit tu);

        /// <summary>
        /// Determine whether two cursors are equivalent.
        /// </summary>
        /// <param name="cursor1">Cursor1</param>
        /// <param name="cursor2">Cursor2</param>
        /// <returns>
        /// 0 : Not Equal
        /// Other : Equal
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_equalCursors(CXCursor cursor1, CXCursor cursor2);

        /// <summary>
        /// Returns non-zero if <paramref name="cursor"/> is null.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Null Cursor
        /// Other : Not Null Cursor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Cursor_isNull(CXCursor cursor);

        /// <summary>
        /// Compute a hash value for the given cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Hash Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_hashCursor(CXCursor cursor);

        /// <summary>
        /// Retrieve the kind of the given cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Cursor Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CursorKind clang_getCursorKind(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor kind represents a declaration.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Declaration
        /// Other : Declaration
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isDeclaration(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given declaration is invalid.
        ///
        /// A declaration is invalid if it could not be parsed successfully.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// non-zero if the cursor represents a declaration and it is
        /// invalid, otherwise NULL.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isInvalidDeclaration(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor kind represents a simple reference.
        ///
        /// Note that other kinds of cursors(such as expressions) can also refer to
        /// other cursors.
        /// Use <c>clang_getCursorReferenced()</c> to determine whether a
        /// particular cursor refers to another entity.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Reference
        /// Other : Reference
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isReference(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor kind represents an expression.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Expression
        /// Other : Expression
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isExpression(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor kind represents a statement.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Statement
        /// Other : Statement
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isStatement(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor kind represents an attribute.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Attribute
        /// Other : Attribute
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isAttribute(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor has any attributes.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Has Attribute
        /// Other : Has Attribute
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_hasAttrs(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor kind represents an invalid cursor.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Invalid
        /// Other : Invalid
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isInvalid(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor kind represents a translation unit.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Translation Unit
        /// Other : Translation Unit
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isTranslationUnit(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor represents a preprocessing
        /// element, such as a preprocessor directive or macro instantiation.
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Translation Unit
        /// Other : Translation Unit
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isPreprocessing(CursorKind cursor_kind);

        /// <summary>
        /// Determine whether the given cursor represents a currently
        /// unexposed piece of the AST(e.g., <c>CXCursor_UnexposedStmt</c>).
        /// </summary>
        /// <param name="cursor_kind">Cursor Kind</param>
        /// <returns>
        /// 0 : Not Unexposed
        /// Other : Unexposed
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isUnexposed(CursorKind cursor_kind);

        /// <summary>
        /// Determine the linkage of the entity referred to by a given cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Linkage Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern LinkageKind clang_getCursorLinkage(CXCursor cursor);

        /// <summary>
        /// Describe the visibility of the entity referred to by a cursor.
        ///
        /// This returns the default visibility if not explicitly specified by
        /// a visibility attribute.The default visibility may be changed by
        /// commandline arguments.
        /// </summary>
        /// <param name="cursor">The cursor to query.</param>
        /// <returns>The visibility of the cursor.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern VisibilityKind clang_getCursorVisibility(CXCursor cursor);

        /// <summary>
        /// Determine the availability of the entity that this cursor refers to,
        /// taking the current target platform into account.
        /// </summary>
        /// <param name="cursor">The cursor to query.</param>
        /// <returns>The availability of the cursor.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern AvailabilityKind clang_getCursorAvailability(CXCursor cursor);

        /// <summary>
        /// Determine the availability of the entity that this cursor refers to
        /// on any platforms for which availability information is known.
        /// </summary>
        /// <param name="cursor">The cursor to query.</param>
        /// <param name="always_deprecated">
        /// If non-NULL, will be set to indicate whether the
        /// entity is deprecated on all platforms.
        /// </param>
        /// <param name="deprecated_message">
        /// If non-NULL, will be set to the message text
        /// provided along with the unconditional deprecation of this entity.
        /// The client is responsible for deallocating this string.
        /// </param>
        /// <param name="always_unavailable">
        /// If non-NULL, will be set to indicate whether the
        /// entity is unavailable on all platforms.
        /// </param>
        /// <param name="unavailable_message">
        /// If non-NULL, will be set to the message text
        /// provided along with the unconditional unavailability of this entity.
        /// The client is responsible for deallocating this string.
        /// </param>
        /// <param name="availability">
        /// If non-NULL, an array of CXPlatformAvailability instances
        /// that will be populated with platform availability information, up to either
        /// the number of platforms for which availability information is available(as
        /// returned by this function) or <paramref name="availability_size"/>, whichever is smaller.
        /// </param>
        /// <param name="availability_size">
        /// The number of elements available in the
        /// <paramref name="availability"/> array.
        /// </param>
        /// <returns>
        /// The number of platforms (N) for which availability information is
        /// available(which is unrelated to <paramref name="availability_size"/>).
        /// </returns>
        /// <remarks>
        /// Note that the client is responsible for calling
        /// <c>clang_disposeCXPlatformAvailability()</c> to free each of the
        /// platform-availability structures returned.
        /// There are <c>min(N, availability_size)</c> such structures.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getCursorPlatformAvailability(CXCursor cursor,
                                                                       out int always_deprecated,
                                                                       out CXString deprecated_message,
                                                                       out int always_unavailable,
                                                                       out CXString unavailable_message,
                                                                       ref CXPlatformAvailabilityPtr availability,
                                                                       int availability_size);

        /// <summary>
        /// Free the memory associated with a <c>CXPlatformAvailability</c> structure.
        /// </summary>
        /// <param name="availability">Platform Availability</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeCXPlatformAvailability(CXPlatformAvailabilityPtr availability);

        /// <summary>
        /// Determine the "language" of the entity referred to by a given cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Language Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern LanguageKind clang_getCursorLanguage(CXCursor cursor);

        /// <summary>
        /// Determine the "thread-local storage (TLS) kind" of the declaration
        /// referred to by a cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Thread Local Storage(TLS) Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TLSKind clang_getCursorTLSKind(CXCursor cursor);

        /// <summary>
        /// Returns the translation unit that a cursor originated from.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Translation Unit</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTranslationUnit clang_Cursor_getTranslationUnit(CXCursor cursor);

        /// <summary>
        /// Creates an empty CXCursorSet.
        /// </summary>
        /// <returns>Cursor Set</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursorSet clang_createCXCursorSet();

        /// <summary>
        /// Disposes a CXCursorSet and releases its associated memory.
        /// </summary>
        /// <param name="cset">Cursor Set</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeCXCursorSet(CXCursorSet cset);

        /// <summary>
        /// Queries a CXCursorSet to see if it contains a specific CXCursor.
        /// </summary>
        /// <param name="cset">Cursor Set</param>
        /// <param name="cursor">Cursor</param>
        /// <returns>non-zero if the set contains the specified cursor.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXCursorSet_contains(CXCursorSet cset, CXCursor cursor);

        /// <summary>
        /// Inserts a CXCursor into a CXCursorSet.
        /// </summary>
        /// <param name="cset">Cursor Set</param>
        /// <param name="cursor">Cursor</param>
        /// <returns>zero if the CXCursor was already in the set, and non-zero otherwise.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXCursorSet_insert(CXCursorSet cset, CXCursor cursor);

        /// <summary>
        /// Determine the semantic parent of the given cursor.
        ///
        /// The semantic parent of a cursor is the cursor that semantically contains
        /// the given <paramref name="cursor"/>.For many declarations, the lexical and semantic parents
        /// are equivalent (the lexical parent is returned by
        /// <c>clang_getCursorLexicalParent()</c>). They diverge when declarations or
        /// definitions are provided out-of-line.For example:
        /// <code>
        /// class C
        ///  {
        ///  void f();
        /// };
        ///
        /// void C::f() { }
        /// </code>
        ///
        /// In the out-of-line definition of <c>C::f</c>, the semantic parent is
        /// the class <c>C</c>, of which this function is a member. The lexical parent is
        /// the place where the declaration actually occurs in the source code; in this
        /// case, the definition occurs in the translation unit.In general, the
        /// lexical parent for a given entity can change without affecting the semantics
        /// of the program, and the lexical parent of different declarations of the
        /// same entity may be different. Changing the semantic parent of a declaration,
        /// on the other hand, can have a major impact on semantics, and redeclarations
        /// of a particular entity should all have the same semantic context.
        ///
        /// In the example above, both declarations of <c>C::f</c> have <c>C</c> as their
        /// semantic context, while the lexical context of the first <c>C::f</c> is <c>C</c>
        /// and the lexical context of the second <c>C::f</c> is the translation unit.
        ///
        /// For global declarations, the semantic parent is the translation unit.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Semantic Parent Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCursorSemanticParent(CXCursor cursor);

        /// <summary>
        /// Determine the lexical parent of the given cursor.
        ///
        /// The lexical parent of a cursor is the cursor in which the given <paramref name="cursor"/>
        /// was actually written.For many declarations, the lexical and semantic parents
        /// are equivalent(the semantic parent is returned by
        /// <c>clang_getCursorSemanticParent()</c>).
        /// They diverge when declarations or
        /// definitions are provided out-of-line.For example:
        ///
        /// <code>
        /// class C
        ///  {
        ///  void f();
        /// };
        ///
        /// void C::f() { }
        /// </code>
        ///
        /// In the out-of-line definition of <c>C::f</c>, the semantic parent is
        /// the class <c>C</c>, of which this function is a member. The lexical parent is
        /// the place where the declaration actually occurs in the source code; in this
        /// case, the definition occurs in the translation unit.In general, the
        /// lexical parent for a given entity can change without affecting the semantics
        /// of the program, and the lexical parent of different declarations of the
        /// same entity may be different. Changing the semantic parent of a declaration,
        /// on the other hand, can have a major impact on semantics, and redeclarations
        /// of a particular entity should all have the same semantic context.
        ///
        /// In the example above, both declarations of <c>C::f</c> have <c>C</c> as their
        /// semantic context, while the lexical context of the first <c>C::f</c> is <c>C</c>
        /// and the lexical context of the second <c>C::f</c> is the translation unit.
        ///
        /// For declarations written in the global scope, the lexical parent is
        /// the translation unit.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Lexical Parent Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCursorLexicalParent(CXCursor cursor);

        /// <summary>
        /// Determine the set of methods that are overridden by the given
        /// method.
        ///
        /// In both Objective-C and C++, a method(aka virtual member function,
        /// in C++) can override a virtual method in a base class. For
        /// Objective-C, a method is said to override any method in the class's
        /// base class, its protocols, or its categories' protocols, that has the same
        /// selector and is of the same kind(class or instance).
        /// If no such method exists, the search continues to the class's superclass,
        /// its protocols, and its categories, and so on.A method from an Objective-C
        /// implementation is considered to override the same methods as its
        /// corresponding method in the interface.
        ///
        /// For C++, a virtual member function overrides any virtual member
        /// function with the same signature that occurs in its base
        /// classes.With multiple inheritance, a virtual member function can
        /// override several virtual member functions coming from different
        /// base classes.
        ///
        /// In all cases, this function determines the immediate overridden
        /// method, rather than all of the overridden methods.For example, if
        /// a method is originally declared in a class A, then overridden in B
        /// (which in inherits from A) and also in C(which inherited from B),
        /// then the only overridden method returned from this function when
        /// invoked on C's method will be B's method. The client may then
        /// invoke this function again, given the previously-found overridden
        /// methods, to map out the complete method-override set.
        /// </summary>
        /// <param name="cursor">
        /// A cursor representing an Objective-C or C++
        /// method.This routine will compute the set of methods that this
        /// method overrides.
        /// </param>
        /// <param name="overridden">
        /// A pointer whose pointee will be replaced with a
        /// pointer to an array of cursors, representing the set of overridden
        /// methods.If there are no overridden methods, the pointee will be
        /// set to NULL.The pointee must be freed via a call to
        /// <c>clang_disposeOverriddenCursors()</c>.
        /// </param>
        /// <param name="num_overridden">
        /// A pointer to the number of overridden
        /// functions, will be set to the number of overridden functions in the
        /// array pointed to by <paramref name="overridden"/>.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getOverriddenCursors(CXCursor cursor, out CXCursorPtrPtr overridden, out uint num_overridden);

        /// <summary>
        /// Free the set of overridden cursors returned by
        /// <c>clang_getOverriddenCursors()</c>.
        /// </summary>
        /// <param name="overridden">the set of overridden cursors</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeOverriddenCursors(CXCursorPtr overridden);

        /// <summary>
        /// Retrieve the file that is included by the given inclusion directive cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Included File</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXFile clang_getIncludedFile(CXCursor cursor);
    }
}
