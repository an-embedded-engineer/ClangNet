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
    /// Libclang P/Invoke : Type Information
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve the type of a CXCursor (if any).
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getCursorType(CXCursor cursor);

        /// <summary>
        /// Pretty-print the underlying type using the rules of the
        /// language of the translation unit from which it came.
        ///
        /// If the type is invalid, an empty string is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Type Spelling String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getTypeSpelling(CXType type);

        /// <summary>
        /// Retrieve the underlying type of a typedef declaration.
        ///
        /// If the cursor does not reference a typedef declaration,
        /// an invalid type is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Typedef Underlying Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getTypedefDeclUnderlyingType(CXCursor cursor);

        /// <summary>
        /// Retrieve the integer type of an enum declaration.
        ///
        /// If the cursor does not reference an enum declaration,
        /// an invalid type is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Enum Declaration Integer Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getEnumDeclIntegerType(CXCursor cursor);

        /// <summary>
        /// Retrieve the integer value of an enum constant declaration as a signed
        /// long long.
        ///
        /// If the cursor does not reference an enum constant declaration, LLONG_MIN is returned.
        /// Since this is also potentially a valid constant value, the kind of the cursor
        /// must be verified before calling this function.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Enum Constant Declaration Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_getEnumConstantDeclValue(CXCursor cursor);

        /// <summary>
        /// Retrieve the integer value of an enum constant declaration as an unsigned
        /// long long.
        ///
        /// If the cursor does not reference an enum constant declaration, ULLONG_MAX is returned.
        /// Since this is also potentially a valid constant value, the kind of the cursor
        /// must be verified before calling this function.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Enum Constant Declaration Unsigned Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ulong clang_getEnumConstantDeclUnsignedValue(CXCursor cursor);

        /// <summary>
        /// Retrieve the bit width of a bit field declaration as an integer.
        ///
        /// If a cursor that is not a bit field declaration is passed in, -1 is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Field Declaration Bit Width</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getFieldDeclBitWidth(CXCursor cursor);

        /// <summary>
        /// Retrieve the number of non-variadic arguments associated with a given
        /// cursor.
        ///
        /// The number of arguments can be determined for calls as well as for
        /// declarations of functions or methods.For other cursors -1 is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Number of Non-Variadic Arguments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Cursor_getNumArguments(CXCursor cursor);

        /// <summary>
        /// Retrieve the argument cursor of a function or method.
        ///
        /// The argument cursor can be determined for calls as well as for declarations
        /// of functions or methods.For other cursors and for invalid indices, an
        /// invalid cursor is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="index">Index of Arguments</param>
        /// <returns>Argument of Function or Method</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_Cursor_getArgument(CXCursor cursor, uint index);

        /// <summary>
        /// Returns the number of template args of a function decl representing a
        /// template specialization.
        ///
        /// If the argument cursor cannot be converted into a template function
        /// declaration, -1 is returned.
        ///
        /// For example, for the following declaration and specialization:
        /// template&lt;typename T, int kInt, bool kBool&gt;
        /// void foo() { ... }
        ///
        /// template&lt;&gt;
        /// void foo&lt;float, -7, true&gt;();
        ///
        /// The value 3 would be returned from this call.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Number of Template Arguments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Cursor_getNumTemplateArguments(CXCursor cursor);

        /// <summary>
        /// Retrieve the kind of the I'th template argument of the CXCursor C.
        ///
        /// If the argument CXCursor does not represent a FunctionDecl, an invalid
        /// template argument kind is returned.
        ///
        /// For example, for the following declaration and specialization:
        /// template&lt;typename T, int kInt, bool kBool&gt;
        /// void foo() { ... }
        ///
        /// template&lt;&gt;
        /// void foo&lt;float, -7, true&gt;();
        ///
        /// For I = 0, 1, and 2, Type, Integral, and Integral will be returned,
        /// respectively.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="index">Index of Template Arguments</param>
        /// <returns>Template Argument Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TemplateArgumentKind clang_Cursor_getTemplateArgumentKind(CXCursor cursor, uint index);

        /// <summary>
        /// Retrieve a CXType representing the type of a TemplateArgument of a
        /// function decl representing a template specialization.
        ///
        /// If the argument CXCursor does not represent a FunctionDecl whose I'th
        /// template argument has a kind of CXTemplateArgKind_Integral, an invalid type
        /// is returned.
        ///
        /// For example, for the following declaration and specialization:
        /// template&lt;typename T, int kInt, bool kBool&gt;
        /// void foo() { ... }
        ///
        /// template&lt;&gt;
        /// void foo&lt;float, -7, true&gt;();
        ///
        /// If called with I = 0, "float", will be returned.
        /// Invalid types will be returned for I == 1 or 2.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="index">Index of Template Arguments</param>
        /// <returns>Template Argument Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Cursor_getTemplateArgumentType(CXCursor cursor, uint index);

        /// <summary>
        /// Retrieve the value of an Integral TemplateArgument (of a function
        /// decl representing a template specialization) as a signed long long.
        ///
        /// It is undefined to call this function on a CXCursor that does not represent a
        /// FunctionDecl or whose I'th template argument is not an integral value.
        ///
        /// For example, for the following declaration and specialization:
        /// template&lt;typename T, int kInt, bool kBool&gt;
        /// void foo() { ... }
        ///
        /// template&lt;&gt;
        /// void foo&lt;float, -7, true&gt;();
        ///
        /// If called with I = 1 or 2, -7 or true will be returned, respectively.
        /// For I == 0, this function's behavior is undefined.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="index">Index of Template Arguments</param>
        /// <returns>Template Argument Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_Cursor_getTemplateArgumentValue(CXCursor cursor, uint index);

        /// <summary>
        /// Retrieve the value of an Integral TemplateArgument (of a function
        /// decl representing a template specialization) as an unsigned long long.
        ///
        /// It is undefined to call this function on a CXCursor that does not represent a
        /// FunctionDecl or whose I'th template argument is not an integral value.
        ///
        /// For example, for the following declaration and specialization:
        /// template&lt;typename T, int kInt, bool kBool&gt;
        /// void foo() { ... }
        ///
        /// template&lt;&gt;
        /// void foo&lt;float, 2147483649, true&gt;();
        ///
        /// If called with I = 1 or 2, 2147483649 or true will be returned, respectively.
        /// For I == 0, this function's behavior is undefined.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="index">Index of Template Arguments</param>
        /// <returns>Template Argument Unsigned Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ulong clang_Cursor_getTemplateArgumentUnsignedValue(CXCursor cursor, uint index);

        /// <summary>
        /// Determine whether two CXTypes represent the same type.
        /// </summary>
        /// <param name="type1">Type1</param>
        /// <param name="type2">Type2</param>
        /// <returns>non-zero if the CXTypes represent the same type and zero otherwise.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_equalTypes(CXType type1, CXType type2);

        /// <summary>
        /// Return the canonical type for a CXType.
        ///
        /// Clang's type system explicitly models typedefs and all the ways
        /// a specific type can be represented.The canonical type is the underlying
        /// type with all the "sugar" removed.For example, if 'T' is a typedef
        /// for 'int', the canonical type for 'T' would be 'int'.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Canonical Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getCanonicalType(CXType type);

        /// <summary>
        /// Determine whether a CXType has the "const" qualifier set,
        /// without looking through typedefs that may have added "const" at a
        /// different level.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not Const Qualified Type
        /// Other : Const Qualified Type
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isConstQualifiedType(CXType type);

        /// <summary>
        /// Determine whether a  CXCursor that is a macro, is
        /// function like.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Function Like Macro
        /// Other : Function Like Macro
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isMacroFunctionLike(CXCursor cursor);

        /// <summary>
        /// Determine whether a  CXCursor that is a macro, is a
        /// builtin one.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Builtin Macro
        /// Other : Builtin Macro
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isMacroBuiltin(CXCursor cursor);

        /// <summary>
        ///  Determine whether a CXCursor that is a function declaration, is an
        ///  inline declaration.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Inlined Function
        /// Other : Inlined Function
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isFunctionInlined(CXCursor cursor);

        /// <summary>
        /// Determine whether a CXType has the "volatile" qualifier set,
        /// without looking through typedefs that may have added "volatile" at
        /// a different level.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not Volatile Qualified Type
        /// Other : Volatile Qualified Type
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isVolatileQualifiedType(CXType type);

        /// <summary>
        /// Determine whether a CXType has the "restrict" qualifier set,
        /// without looking through typedefs that may have added "restrict" at a
        /// different level.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not Restrict Qualified Type
        /// Other : Restrict Qualified Type
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isRestrictQualifiedType(CXType type);

        /// <summary>
        /// Returns the address space of the given type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Address Space of Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getAddressSpace(CXType type);

        /// <summary>
        /// Returns the typedef name of the given type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Typedef Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getTypedefName(CXType type);

        /// <summary>
        /// For pointer types, returns the type of the pointee.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Pointee Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getPointeeType(CXType type);

        /// <summary>
        /// Return the cursor for the declaration of the given type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Type Declaration Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getTypeDeclaration(CXType type);

        /// <summary>
        /// Returns the Objective-C type encoding for the specified declaration.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Objective-C Type Encoding String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDeclObjCTypeEncoding(CXCursor cursor);

        /// <summary>
        /// Returns the Objective-C type encoding for the specified CXType.
        /// </summary>
        /// <param name="type">Cursor</param>
        /// <returns>Objective-C Type Encoding</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Type_getObjCEncoding(CXType type);

        /// <summary>
        /// Retrieve the spelling of a given CXTypeKind.
        /// </summary>
        /// <param name="kind">Type Kind</param>
        /// <returns>Type Kind Spelling</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getTypeKindSpelling(TypeKind kind);

        /// <summary>
        /// Retrieve the calling convention associated with a function type.
        ///
        /// If a non-function type is passed in, CXCallingConv_Invalid is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Calling Convention</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CallingConvention clang_getFunctionTypeCallingConv(CXType type);

        /// <summary>
        /// Retrieve the return type associated with a function type.
        ///
        /// If a non-function type is passed in, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Result Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getResultType(CXType type);

        /// <summary>
        /// Retrieve the exception specification type associated with a function type.
        /// This is a value of type CXCursor_ExceptionSpecificationKind.
        ///
        /// If a non-function type is passed in, an error code of -1 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Exception Specification Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getExceptionSpecificationType(CXType type);

        /// <summary>
        /// Retrieve the number of non-variadic parameters associated with a
        /// function type.
        ///
        /// If a non-function type is passed in, -1 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Number of Non-Variadic Argument Types</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getNumArgTypes(CXType type);

        /// <summary>
        /// Retrieve the type of a parameter of a function type.
        ///
        /// If a non-function type is passed in or the function does not have enough
        /// parameters, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="index">Index of Argument Types</param>
        /// <returns>Argument Type of Function Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getArgType(CXType type, uint index);

        /// <summary>
        /// Retrieves the base type of the ObjCObjectType.
        ///
        /// If the type is not an ObjC object, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Objective-C Base Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getObjCObjectBaseType(CXType type);

        /// <summary>
        /// Retrieve the number of protocol references associated with an ObjC object/id.
        ///
        /// If the type is not an ObjC object, 0 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Number of Objective-C Protocol References</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Type_getNumObjCProtocolRefs(CXType type);

        /// <summary>
        /// Retrieve the decl for a protocol reference for an ObjC object/id.
        ///
        /// If the type is not an ObjC object or there are not enough protocol
        /// references, an invalid cursor is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="index">Index of Protocol References</param>
        /// <returns>Declaration Cursor for Protocol Reference</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_Type_getObjCProtocolDecl(CXType type, uint index);

        /// <summary>
        /// Retreive the number of type arguments associated with an ObjC object.
        ///
        /// If the type is not an ObjC object, 0 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Number of Objective-C Type Arguments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Type_getNumObjCTypeArgs(CXType type);

        /// <summary>
        /// Retrieve a type argument associated with an ObjC object.
        ///
        /// If the type is not an ObjC or the index is not valid,
        /// an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="index">Index of Type Arguments</param>
        /// <returns>Objective-C Type Argument</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getObjCTypeArg(CXType type, uint index);

        /// <summary>
        /// Return 1 if the CXType is a variadic function type, and 0 otherwise.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not Variadic Function Type
        /// Other : Variadic Function Type
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isFunctionTypeVariadic(CXType type);

        /// <summary>
        /// Retrieve the return type associated with a given cursor.
        ///
        /// This only returns a valid type if the cursor refers to a function or method.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Result Type of Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getCursorResultType(CXCursor cursor);

        /// <summary>
        /// Retrieve the exception specification type associated with a given cursor.
        /// This is a value of type CXCursor_ExceptionSpecificationKind.
        ///
        /// This only returns a valid result if the cursor refers to a function or method.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Exception Speficiation Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getCursorExceptionSpecificationType(CXCursor cursor);

        /// <summary>
        /// Return 1 if the CXType is a POD (plain old data) type, and 0
        /// otherwise.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not POD Type
        /// Other : POD Type
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isPODType(CXType type);

        /// <summary>
        /// Return the element type of an array, complex, or vector type.
        ///
        /// If a type is passed in that is not an array, complex, or vector type,
        /// an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Element Type of Array / Complex / Vector Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getElementType(CXType type);

        /// <summary>
        /// Return the number of elements of an array or vector type.
        ///
        /// If a type is passed in that is not an array or vector type,
        /// -1 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Number of Elements of Array or Vector Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_getNumElements(CXType type);

        /// <summary>
        /// Return the element type of an array type.
        ///
        /// If a non-array type is passed in, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Element Type of Array</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getArrayElementType(CXType type);

        /// <summary>
        /// Return the array size of a constant array.
        ///
        /// If a non-array type is passed in, -1 is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Array Size of Constant Array</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_getArraySize(CXType type);

        /// <summary>
        /// Retrieve the type named by the qualified-id.
        ///
        /// If a non-elaborated type is passed in, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Named Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getNamedType(CXType type);

        /// <summary>
        /// Determine if a typedef is 'transparent' tag.
        ///
        /// A typedef is considered 'transparent' if it shares a name and spelling
        /// location with its underlying tag type, as is the case with the NS_ENUM macro.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>
        /// 0 : Not Transparent Tag Typedef
        /// Other : Transparent Tag Typedef
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Type_isTransparentTagTypedef(CXType type);

        /// <summary>
        /// Retrieve the nullability kind of a pointer type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Type Nullability Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TypeNullabilityKind clang_Type_getNullability(CXType type);

        /// <summary>
        /// Return the alignment of a type in bytes as per C++[expr.alignof]
        /// standard.
        ///
        /// If the type declaration is invalid, CXTypeLayoutError_Invalid is returned.
        /// If the type declaration is an incomplete type, CXTypeLayoutError_Incomplete
        /// is returned.
        /// If the type declaration is a dependent type, CXTypeLayoutError_Dependent is
        /// returned.
        /// If the type declaration is not a constant size type,
        /// CXTypeLayoutError_NotConstantSize is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Alignment of Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_Type_getAlignOf(CXType type);

        /// <summary>
        /// Return the class type of an member pointer type.
        ///
        /// If a non-member-pointer type is passed in, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Class Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getClassType(CXType type);

        /// <summary>
        /// Return the size of a type in bytes as per C++[expr.sizeof] standard.
        ///
        /// If the type declaration is invalid, CXTypeLayoutError_Invalid is returned.
        /// If the type declaration is an incomplete type, CXTypeLayoutError_Incomplete
        /// is returned.
        /// If the type declaration is a dependent type, CXTypeLayoutError_Dependent is
        /// returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Size of Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_Type_getSizeOf(CXType type);

        /// <summary>
        /// Return the offset of a field named S in a record of type T in bits
        /// as it would be returned by __offsetof__ as per C++11[18.2p4]
        ///
        /// If the cursor is not a record field declaration, CXTypeLayoutError_Invalid
        /// is returned.
        /// If the field's type declaration is an incomplete type,
        /// CXTypeLayoutError_Incomplete is returned.
        /// If the field's type declaration is a dependent type,
        /// CXTypeLayoutError_Dependent is returned.
        /// If the field's name S is not found,
        /// CXTypeLayoutError_InvalidFieldName is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="str">Field Name</param>
        /// <returns>Offset of Field Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_Type_getOffsetOf(CXType type, string str);

        /// <summary>
        /// Return the type that was modified by this attributed type.
        ///
        /// If the type is not an attributed type, an invalid type is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Modified Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getModifiedType(CXType type);

        /// <summary>
        /// Return the offset of the field represented by the Cursor.
        ///
        /// If the cursor is not a field declaration, -1 is returned.
        /// If the cursor semantic parent is not a record field declaration,
        /// CXTypeLayoutError_Invalid is returned.
        /// If the field's type declaration is an incomplete type,
        /// CXTypeLayoutError_Incomplete is returned.
        /// If the field's type declaration is a dependent type,
        /// CXTypeLayoutError_Dependent is returned.
        /// If the field's name S is not found,
        /// CXTypeLayoutError_InvalidFieldName is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Offset of Field Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_Cursor_getOffsetOfField(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor represents an anonymous
        /// tag or namespace.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Anonymous Tag or Namespace
        /// Other : Anonymous Tag or Namespace
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isAnonymous(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor represents an anonymous record
        /// declaration.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Anonymous Record Declaration
        /// Other : Anonymous Record Declaration
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isAnonymousRecordDecl(CXCursor cursor);

        /// <summary>
        /// Determine whether the given cursor represents an inline namespace
        /// declaration.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Inline Namespace Declaration
        /// Other : Inline Namespace Declaration
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isInlineNamespace(CXCursor cursor);

        /// <summary>
        /// Returns the number of template arguments for given template
        /// specialization, or -1 if type <paramref name="type"/> is not a template specialization.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Number of Template Arguments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Type_getNumTemplateArguments(CXType type);

        /// <summary>
        /// Returns the type template argument of a template class specialization
        /// at given index.
        ///
        /// This function only returns template type arguments and does not handle
        /// template template arguments or variadic packs.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="index">Index of Template Arguments</param>
        /// <returns>Type Template Argument</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Type_getTemplateArgumentAsType(CXType type, uint index);

        /// <summary>
        /// Retrieve the ref-qualifier kind of a function or method.
        ///
        /// The ref-qualifier is returned for C++ functions or methods.For other types
        /// or non-C++ declarations, CXRefQualifier_None is returned.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Reference Qualifier Kind of Function or Method</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern RefQualifierKind clang_Type_getCXXRefQualifier(CXType type);

        /// <summary>
        /// Returns non-zero if the cursor specifies a Record member that is a
        /// bitfield.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Bitfield
        /// Other Bitfield
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isBitField(CXCursor cursor);

        /// <summary>
        /// Returns 1 if the base class specified by the cursor with kind
        /// CX_CXXBaseSpecifier is virtual.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Virtual Base Class
        /// Other : Virtual Base Class
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isVirtualBase(CXCursor cursor);

        /// <summary>
        /// Returns the access control level for the referenced object.
        ///
        /// If the cursor refers to a C++ declaration, its access control level within its
        /// parent scope is returned.Otherwise, if the cursor refers to a base specifier or
        /// access specifier, the specifier itself is returned.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>C++ Access Specifier</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CxxAccessSpecifier clang_getCXXAccessSpecifier(CXCursor cursor);

        /// <summary>
        /// Returns the storage class for a function or variable declaration.
        ///
        /// If the passed in Cursor is not a function or variable declaration,
        /// CX_SC_Invalid is returned else the storage class.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Storage Class</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern StorageClass clang_Cursor_getStorageClass(CXCursor cursor);

        /// <summary>
        /// Determine the number of overloaded declarations referenced by a
        /// <c>CXCursor_OverloadedDeclRef</c> cursor.
        /// </summary>
        /// <param name="cursor">The cursor whose overloaded declarations are being queried.</param>
        /// <returns>
        /// The number of overloaded declarations referenced by <paramref name="cursor"/>.
        /// If it is not a <c>CXCursor_OverloadedDeclRef</c> cursor, returns 0.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getNumOverloadedDecls(CXCursor cursor);

        /// <summary>
        /// Retrieve a cursor for one of the overloaded declarations referenced
        /// by a <c>CXCursor_OverloadedDeclRef</c> cursor.
        /// </summary>
        /// <param name="cursor">The cursor whose overloaded declarations are being queried.</param>
        /// <param name="index">index The zero-based index into the set of overloaded declarations in the cursor.</param>
        /// <returns>
        /// A cursor representing the declaration referenced by the given
        /// <paramref name="cursor"/> at the specified <paramref name="index"/>.If the cursor does not have an
        /// associated set of overloaded declarations, or if the index is out of bounds,
        /// returns <c>clang_getNullCursor()</c>;
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getOverloadedDecl(CXCursor cursor, uint index);
    }
}
