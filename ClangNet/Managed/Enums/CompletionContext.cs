using System;

namespace ClangNet.Native
{
    /// <summary>
    /// Completion Context
    /// </summary>
    /// <remarks>
    /// Bits that represent the context under which completion is occurring.
    ///
    /// The enumerators in this enumeration may be bitwise-OR'd together if multiple
    /// contexts are occurring simultaneously.
    /// </remarks>
    [Flags]
    public enum CompletionContext
    {
        /// <summary>
        /// Unexposed
        /// </summary>
        /// <remarks>
        /// The context for completions is unexposed, as only Clang results
        /// should be included. (This is equivalent to having no context bits set.)
        /// </remarks>
        Unexposed = 0,

        /// <summary>
        /// Any Type
        /// </summary>
        /// <remarks>
        /// Completions for any possible type should be included in the results.
        /// </remarks>
        AnyType = 1 << 0,

        /// <summary>
        /// Any Value
        /// </summary>
        /// <remarks>
        /// Completions for any possible value (variables, function calls, etc.)
        /// should be included in the results.
        /// </remarks>
        AnyValue = 1 << 1,

        /// <summary>
        /// Objective-C Object Value
        /// </summary>
        /// <remarks>
        /// Completions for values that resolve to an Objective-C object should
        /// be included in the results.
        /// </remarks>
        ObjCObjectValue = 1 << 2,

        /// <summary>
        /// Objective-C Selector Value
        /// </summary>
        /// <remarks>
        /// Completions for values that resolve to an Objective-C selector
        /// should be included in the results.
        /// </remarks>
        ObjCSelectorValue = 1 << 3,

        /// <summary>
        /// C++ Class Type Value
        /// </summary>
        /// <remarks>
        /// Completions for values that resolve to a C++ class type should be
        /// included in the results.
        /// </remarks>
        CXXClassTypeValue = 1 << 4,

        /// <summary>
        /// Dot Member Access
        /// </summary>
        /// <remarks>
        /// Completions for fields of the member being accessed using the dot
        /// operator should be included in the results.
        /// </remarks>
        DotMemberAccess = 1 << 5,

        /// <summary>
        /// Arrow Member Access
        /// </summary>
        /// <remarks>
        /// Completions for fields of the member being accessed using the arrow
        /// operator should be included in the results.
        /// </remarks>
        ArrowMemberAccess = 1 << 6,

        /// <summary>
        /// Objective-C Property Access
        /// </summary>
        /// <remarks>
        /// Completions for properties of the Objective-C object being accessed
        /// using the dot operator should be included in the results.
        /// </remarks>
        ObjCPropertyAccess = 1 << 7,

        /// <summary>
        /// Enum Tag
        /// </summary>
        /// <remarks>
        /// Completions for enum tags should be included in the results.
        /// </remarks>
        EnumTag = 1 << 8,

        /// <summary>
        /// Union Tag
        /// </summary>
        /// <remarks>
        /// Completions for union tags should be included in the results.
        /// </remarks>
        UnionTag = 1 << 9,

        /// <summary>
        /// Struct Tag
        /// </summary>
        /// <remarks>
        /// Completions for struct tags should be included in the results.
        /// </remarks>
        StructTag = 1 << 10,

        /// <summary>
        /// Class Tag
        /// </summary>
        /// <remarks>
        /// Completions for C++ class names should be included in the results.
        /// </remarks>
        ClassTag = 1 << 11,

        /// <summary>
        /// Namespace
        /// </summary>
        /// <remarks>
        /// Completions for C++ namespaces and namespace aliases should be
        /// included in the results.
        /// </remarks>
        Namespace = 1 << 12,

        /// <summary>
        /// Nested Name Specifier
        /// </summary>
        /// <remarks>
        /// Completions for C++ nested name specifiers should be included in
        /// the results.
        /// </remarks>
        NestedNameSpecifier = 1 << 13,

        /// <summary>
        /// Objective-C Interface
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C interfaces (classes) should be included
        /// in the results.
        /// </remarks>
        ObjCInterface = 1 << 14,

        /// <summary>
        /// Objective-C Protocol
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C protocols should be included in
        /// the results.
        /// </remarks>
        ObjCProtocol = 1 << 15,

        /// <summary>
        /// Objective-C Category
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C categories should be included in
        /// the results.
        /// </remarks>
        ObjCCategory = 1 << 16,

        /// <summary>
        /// Objective-C Instance Message
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C instance messages should be included
        /// in the results.
        /// </remarks>
        ObjCInstanceMessage = 1 << 17,

        /// <summary>
        /// Objective-C Class Message
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C class messages should be included in
        /// the results.
        /// </remarks>
        ObjCClassMessage = 1 << 18,

        /// <summary>
        /// Objective-C Selector Name
        /// </summary>
        /// <remarks>
        /// Completions for Objective-C selector names should be included in
        /// the results.
        /// </remarks>
        ObjCSelectorName = 1 << 19,

        /// <summary>
        /// Macro Name
        /// </summary>
        /// <remarks>
        /// Completions for preprocessor macro names should be included in
        /// the results.
        /// </remarks>
        MacroName = 1 << 20,

        /// <summary>
        /// Natural Language
        /// </summary>
        /// <remarks>
        /// Natural language completions should be included in the results.
        /// </remarks>
        NaturalLanguage = 1 << 21,

        /// <summary>
        /// Include File
        /// </summary>
        /// <remarks>
        /// #include file completions should be included in the results.
        /// </remarks>
        IncludeFile = 1 << 22,

        /// <summary>
        /// Unknown
        /// </summary>
        /// <remarks>
        /// The current context is unknown, so set all contexts.
        /// </remarks>
        Unknown = ((1 << 23) - 1),
    }
}
