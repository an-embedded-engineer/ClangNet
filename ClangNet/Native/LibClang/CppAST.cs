#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    /// <summary>
    /// Libclang P/Invoke : C++ AST Introspection
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Determine if a C++ constructor is a converting constructor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Converting Constructor
        /// Other : Converting Construcctor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXConstructor_isConvertingConstructor(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ constructor is a copy constructor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Copy Constructor
        /// Other : Copy Construcctor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXConstructor_isCopyConstructor(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ constructor is the default constructor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Default Constructor
        /// Other : Default Construcctor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXConstructor_isDefaultConstructor(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ constructor is a move constructor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Move Constructor
        /// Other : Move Construcctor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXConstructor_isMoveConstructor(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ field is declared 'mutable'.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Mutable Field
        /// Other : Mutable Field
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXField_isMutable(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ method is declared '= default'.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Defaulted Method
        /// Other : Defaulted Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXMethod_isDefaulted(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ member function or member function template is pure virtual.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Pure Virtual Method
        /// Other : Pure Virtual Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXMethod_isPureVirtual(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ member function or member function template is declared 'static'.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Static Method
        /// Other Static Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXMethod_isStatic(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ member function or member function template is
        /// explicitly declared 'virtual' or if it overrides a virtual method from
        /// one of the base classes.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Virtual Method
        /// Other Virtual Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXMethod_isVirtual(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ record is abstract, i.e. whether a class or struct
        /// has a pure virtual member function.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Abstract Record
        /// Other Abstract Record
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXRecord_isAbstract(CXCursor cursor);

        /// <summary>
        /// Determine if an enum declaration refers to a scoped enum.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Scoped Enum
        /// Other : Scoped Enum
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_EnumDecl_isScoped(CXCursor cursor);

        /// <summary>
        /// Determine if a C++ member function or member function template is
        /// declared 'const'.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Constant Method
        /// Other : Constant Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CXXMethod_isConst(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents a template, determine
        /// the cursor kind of the specializations would be generated by instantiating
        /// the template.
        ///
        /// This routine can be used to determine what flavor of function template,
        /// class template, or class template partial specialization is stored in the
        /// cursor.For example, it can describe whether a class template cursor is
        /// declared with "struct", "class" or "union".
        /// </summary>
        /// <param name="cursor">The cursor to query. This cursor should represent a template declaration</param>
        /// <returns>
        /// The cursor kind of the specializations that would be generated
        /// by instantiating the template <paramref name="cursor"/>.
        /// If <paramref name="cursor"/> is not a template, returns <c>XCursor_NoDeclFound</c>C.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CursorKind clang_getTemplateCursorKind(CXCursor cursor);

        /// <summary>
        /// Given a cursor that may represent a specialization or instantiation
        /// of a template, retrieve the cursor that represents the template that it
        /// specializes or from which it was instantiated.
        ///
        /// This routine determines the template involved both for explicit
        /// specializations of templates and for implicit instantiations of the template,
        /// both of which are referred to as "specializations". For a class template
        /// specialization(e.g., <c>std::vector&lt;bool&gt;</c>), this routine will return
        /// either the primary template(<c>std::vector</c>) or, if the specialization was
        /// nstantiated from a class template partial specialization, the class template
        /// partial specialization.For a class template partial specialization and a
        /// unction template specialization(including instantiations), this
        /// this routine will return the specialized template.
        ///
        /// For members of a class template (e.g., member functions, member classes, or
        /// static data members), returns the specialized or instantiated member.
        /// Although not strictly "templates" in the C++ language, members of class
        /// templates have the same notions of specializations and instantiations that
        /// templates do, so this routine treats them similarly.
        /// </summary>
        /// <param name="cursor">A cursor that may be a specialization of a template or a member of a template.</param>
        /// <returns>
        /// If the given cursor is a specialization or instantiation of a
        /// template or a member thereof, the template or member that it specializes or
        /// from which it was instantiated.Otherwise, returns a NULL cursor.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getSpecializedCursorTemplate(CXCursor cursor);

        /// <summary>
        /// Given a cursor that references something else, return the source range
        /// covering that reference.
        /// </summary>
        /// <param name="cursor">A cursor pointing to a member reference, a declaration reference, or an operator call.</param>
        /// <param name="named_flags">
        /// A bitset with three independent flags:
        /// CXNameRange_WantQualifier,
        /// CXNameRange_WantTemplateArgs,
        /// CXNameRange_WantSinglePiece.
        /// </param>
        /// <param name="piece_index">
        /// For contiguous names or when passing the flag
        /// CXNameRange_WantSinglePiece, only one piece with index 0 is
        /// available.When the CXNameRange_WantSinglePiece flag is not passed for a
        /// non-contiguous names, this index can be used to retrieve the individual
        /// pieces of the name.See also CXNameRange_WantSinglePiece.
        /// </param>
        /// <returns>
        /// The piece of the name pointed to by the given cursor. If there is no
        /// name, or if the PieceIndex is out-of-range, a null-cursor will be returned.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getCursorReferenceNameRange(CXCursor cursor, NameRefFlags named_flags, uint piece_index);
    }
}
