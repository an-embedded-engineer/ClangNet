#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // Opaque pointer representing a policy that controls pretty printing
    // for <c>clang_getCursorPrettyPrinted</c>.
    using CXPrintingPolicy = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Cross Referencing
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve a Unified Symbol Resolution (USR) for the entity referenced
        /// by the given cursor.
        ///
        /// A Unified Symbol Resolution (USR) is a string that identifies a particular
        /// entity (function, class, variable, etc.) within a program.USRs can be
        /// compared across translation units to determine, e.g., when references in
        /// one translation refer to an entity defined in another translation unit.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Unified Symbol Resolution (USR) String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCursorUSR(CXCursor cursor);

        /// <summary>
        /// Construct a USR for a specified Objective-C class.
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <returns>Objective-C Class USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCClass(string class_name);

        /// <summary>
        /// Construct a USR for a specified Objective-C category.
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <param name="category_name">Category Name</param>
        /// <returns>Objective-C Category USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCCategory(string class_name, string category_name);

        /// <summary>
        /// Construct a USR for a specified Objective-C protocol.
        /// </summary>
        /// <param name="protocol_name">Protocol Name</param>
        /// <returns>Objective-C Protocol USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCProtocol(string protocol_name);

        /// <summary>
        /// Construct a USR for a specified Objective-C instance variable and
        /// the USR for its containing class.
        /// </summary>
        /// <param name="name">Instance Variable Name</param>
        /// <param name="class_usr">Class USR String</param>
        /// <returns>Objective-C Instance Variable USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCIvar(string name, CXString class_usr);

        /// <summary>
        /// Construct a USR for a specified Objective-C method and
        /// the USR for its containing class.
        /// </summary>
        /// <param name="name">Method Name</param>
        /// <param name="isInstance_method">Instance Method Flag</param>
        /// <param name="class_usr">Class USR String</param>
        /// <returns>Objective-C Method USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCMethod(string name, uint isInstance_method, CXString class_usr);

        /// <summary>
        /// Construct a USR for a specified Objective-C property and the USR
        /// for its containing class.
        /// </summary>
        /// <param name="property">Property Name</param>
        /// <param name="class_usr">Class USR String</param>
        /// <returns>Objective-C Property USR String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_constructUSR_ObjCProperty(string property, CXString class_usr);

        /// <summary>
        /// Retrieve a name for the entity referenced by this cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Cursor Spelling</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCursorSpelling(CXCursor cursor);

        /// <summary>
        /// Retrieve a range for a piece that forms the cursors spelling name.
        /// Most of the times there is only one range for the complete spelling but for
        /// Objective-C methods and Objective-C message expressions, there are multiple
        /// pieces for each selector identifier.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="piece_index">
        /// the index of the spelling name piece. If this is greater
        /// than the actual number of pieces, it will return a NULL(invalid) range.
        /// </param>
        /// <param name="options">Reserved.</param>
        /// <returns>Source Range for Cursor Spelling Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_Cursor_getSpellingNameRange(CXCursor cursor, uint piece_index, uint options);

        /// <summary>
        /// Get a property value for the given printing policy.
        /// </summary>
        /// <param name="policy">Printing Policy</param>
        /// <param name="property">Printing Policy Property</param>
        /// <returns>Property Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_PrintingPolicy_getProperty(CXPrintingPolicy policy, PrintingPolicyProperty property);

        /// <summary>
        /// Set a property value for the given printing policy.
        /// </summary>
        /// <param name="policy">Printing Policy</param>
        /// <param name="property">Printing Policy Property</param>
        /// <param name="value">Property Value</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_PrintingPolicy_setProperty(CXPrintingPolicy policy, PrintingPolicyProperty property, uint value);

        /// <summary>
        /// Retrieve the default policy for the cursor.
        ///
        /// The policy should be released after use with
        /// <c>clang_PrintingPolicy_dispose()</c>.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Default Printing Policy</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXPrintingPolicy clang_getCursorPrintingPolicy(CXCursor cursor);

        /// <summary>
        /// Release a printing policy.
        /// </summary>
        /// <param name="policy">Printing Policy</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_PrintingPolicy_dispose(CXPrintingPolicy policy);

        /// <summary>
        /// Pretty print declarations.
        /// </summary>
        /// <param name="cursor">The cursor representing a declaration.</param>
        /// <param name="policy">
        /// Policy The policy to control the entities being printed. If
        /// NULL, a default policy is used.
        /// </param>
        /// <returns>
        /// The pretty printed declaration or the empty string for
        /// other cursors.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCursorPrettyPrinted(CXCursor cursor, CXPrintingPolicy policy);

        /// <summary>
        /// Retrieve the display name for the entity referenced by this cursor.
        ///
        /// The display name contains extra information that helps identify the cursor,
        /// such as the parameters of a function or template or the arguments of a
        /// class template specialization.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Display Name</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCursorDisplayName(CXCursor cursor);

        /// <summary>
        /// For a cursor that is a reference, retrieve a cursor representing the
        /// entity that it references.
        ///
        /// Reference cursors refer to other entities in the AST. For example, an
        /// Objective-C superclass reference cursor refers to an Objective-C class.
        /// This function produces the cursor for the Objective-C class from the
        /// cursor for the superclass reference.If the input cursor is a declaration or
        /// definition, it returns that declaration or definition unchanged.
        /// Otherwise, returns the NULL cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Refferenced Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCursorReferenced(CXCursor cursor);

        /// <summary>
        /// For a cursor that is either a reference to or a declaration
        /// of some entity, retrieve a cursor that describes the definition of
        /// that entity.
        ///
        /// Some entities can be declared multiple times within a translation
        /// unit, but only one of those declarations can also be a
        /// definition.For example, given:
        ///
        /// <code>
        /// int f(int, int);
        /// int g(int x, int y) { return f(x, y); }
        /// int f(int a, int b) { return a + b; }
        /// int f(int, int);
        /// </code>
        ///
        /// there are three declarations of the function "f", but only the
        /// second one is a definition.The <c>clang_getCursorDefinition()</c>
        /// function will take any cursor pointing to a declaration of "f"
        /// (the first or fourth lines of the example) or a cursor referenced
        /// that uses "f" (the call to "f' inside "g") and will return a
        /// declaration cursor pointing to the definition(the second "f"
        /// declaration).
        ///
        /// If given a cursor for which there is no corresponding definition,
        /// e.g., because there is no definition of that entity within this
        /// translation unit, returns a NULL cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Definition Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCursorDefinition(CXCursor cursor);

        /// <summary>
        /// Determine whether the declaration pointed to by this cursor
        /// is also a definition of that entity.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Definition
        /// Other : Definition
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isCursorDefinition(CXCursor cursor);

        /// <summary>
        /// Retrieve the canonical cursor corresponding to the given cursor.
        ///
        /// In the C family of languages, many kinds of entities can be declared several
        /// times within a single translation unit.For example, a structure type can
        /// be forward-declared(possibly multiple times) and later defined:
        ///
        /// <code>
        /// struct X;
        /// struct X;
        /// struct X
        /// {
        ///     int member;
        /// };
        /// </code>
        ///
        /// The declarations and the definition of <c>X</c> are represented by three
        /// different cursors, all of which are declarations of the same underlying
        /// entity.One of these cursor is considered the "canonical" cursor, which
        /// is effectively the representative for the underlying entity.One can
        /// determine if two cursors are declarations of the same underlying entity by
        /// comparing their canonical cursors.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>The canonical cursor for the entity referred to by the given cursor.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCanonicalCursor(CXCursor cursor);

        /// <summary>
        /// If the cursor points to a selector identifier in an Objective-C
        /// method or message expression, this returns the selector index.
        ///
        /// After getting a cursor with #clang_getCursor, this can be called to
        /// determine if the location points to a selector identifier.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// The selector index if the cursor is an Objective-C method or message
        /// expression and the cursor is pointing to a selector identifier, or -1
        /// otherwise.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Cursor_getObjCSelectorIndex(CXCursor cursor);

        /// <summary>
        /// Given a cursor pointing to a C++ method call or an Objective-C
        /// message, returns non-zero if the method/message is "dynamic", meaning:
        ///
        /// For a C++ method: the call is virtual.
        /// For an Objective-C message: the receiver is an object instance, not 'super'
        /// or a specific class.
        ///
        /// If the method/message is "static" or the cursor does not point to a
        /// method/message, it will return zero.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Dynamic Call
        /// Other : Dynamic Call
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Cursor_isDynamicCall(CXCursor cursor);

        /// <summary>
        /// Given a cursor pointing to an Objective-C message or property
        /// reference, or C++ method call, returns the CXType of the receiver.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Get Receiver Type</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_Cursor_getReceiverType(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents a property declaration, return the
        /// associated property attributes.The bits are formed from
        /// <c>CXObjCPropertyAttrKind</c>.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="reserved">Reserved for future use, pass 0.</param>
        /// <returns>Get Objective-C Property Attribute Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ObjCPropertyAttrKind clang_Cursor_getObjCPropertyAttributes(CXCursor cursor, uint reserved);

        /// <summary>
        /// Given a cursor that represents a property declaration, return the
        /// name of the method that implements the getter.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Objective-C Property Getter Name String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Cursor_getObjCPropertyGetterName(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents a property declaration, return the
        /// name of the method that implements the setter, if any.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Objective-C Property Setter Name String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Cursor_getObjCPropertySetterName(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents an Objective-C method or parameter
        /// declaration, return the associated Objective-C qualifiers for the return
        /// type or the parameter respectively.The bits are formed from
        /// <c>CXObjCDeclQualifierKind</c>.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Objective-C Declaration Qualifier Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ObjCDeclQualifierKind clang_Cursor_getObjCDeclQualifiers(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents an Objective-C method or property
        /// declaration, return non-zero if the declaration was affected by "@optional".
        /// Returns zero if the cursor is not such a declaration or it is "@required".
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Objective-C Optional
        /// Other : Objective-C Optional
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isObjCOptional(CXCursor cursor);

        /// <summary>
        /// Returns non-zero if the given cursor is a variadic function or method.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// 0 : Not Variadic Function or Method
        /// Other : Variadic Function or Method
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isVariadic(CXCursor cursor);

        /// <summary>
        /// Returns non-zero if the given cursor points to a symbol marked with
        /// external_source_symbol attribute.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="language">
        /// If non-NULL, and the attribute is present, will be set to
        /// the 'language' string from the attribute.
        /// </param>
        /// <param name="defined_in">
        /// If non-NULL, and the attribute is present, will be set to
        /// the 'definedIn' string from the attribute.
        /// </param>
        /// <param name="is_generated">
        /// If non-NULL, and the attribute is present, will be set to
        /// non-zero if the 'generated_declaration' is set in the attribute.
        /// </param>
        /// <returns>
        /// 0 : Not External Symbol
        /// Other : External Symbol
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Cursor_isExternalSymbol(CXCursor cursor, out CXString language, out CXString defined_in, out uint is_generated);

        /// <summary>
        /// Given a cursor that represents a declaration, return the associated
        /// comment's source range.
        /// The range may include multiple consecutive comments
        /// with whitespace in between.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Source Range of Comments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_Cursor_getCommentRange(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents a declaration, return the associated
        /// comment text, including comment markers.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Raw Comment Text</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Cursor_getRawCommentText(CXCursor cursor);

        /// <summary>
        /// Given a cursor that represents a documentable entity (e.g.,
        /// declaration), return the associated \paragraph; otherwise return the
        /// first paragraph.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Brief Comment Text</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Cursor_getBriefCommentText(CXCursor cursor);
    }
}
