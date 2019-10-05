using ClangNet.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Cursor Kind
    /// </summary>
    /// <remarks>
    /// Describes the kind of entity that a cursor refers to.
    /// </remarks>
    public enum CursorKind
    {
        /// <summary>
        /// Unexposed Declaration
        /// </summary>
        /// <remarks>
        /// A declaration whose specific kind is not exposed via this
        /// interface.
        ///
        /// Unexposed declarations have the same operations as any other kind
        /// of declaration; one can extract their location information,
        /// spelling, find their definitions, etc. However, the specific kind
        /// of the declaration is not reported.
        /// </remarks>
        UnexposedDeclaration = 1,

        /// <summary>
        /// Struct Declaration
        /// </summary>
        /// <remarks>
        /// A C or C++ struct.
        /// </remarks>
        StructDeclaration = 2,

        /// <summary>
        /// Union Declaration
        /// </summary>
        /// <remarks>
        /// A C or C++ union.
        /// </remarks>
        UnionDeclaration = 3,

        /// <summary>
        /// Class Declaration
        /// </summary>
        /// <remarks>
        /// A C++ class.
        /// </remarks>
        ClassDeclaration = 4,

        /// <summary>
        /// Enum Declaration
        /// </summary>
        /// <remarks>
        /// An enumeration.
        /// </remarks>
        EnumDeclaration = 5,

        /// <summary>
        /// Field Declaration
        /// </summary>
        /// <remarks>
        /// A field (in C) or non-static data member (in C++) in a
        /// struct, union, or C++ class.
        /// </remarks>
        FieldDeclaration = 6,

        /// <summary>
        /// Enum Constant Declaration
        /// </summary>
        /// <remarks>
        /// An enumerator constant.
        /// </remarks>
        EnumConstantDeclaration = 7,

        /// <summary>
        /// Function Declaration
        /// </summary>
        /// <remarks>
        /// A function.
        /// </remarks>
        FunctionDeclaration = 8,

        /// <summary>
        /// Variable Declaration
        /// </summary>
        /// <remarks>
        /// A variable.
        /// </remarks>
        VarDeclaration = 9,

        /// <summary>
        /// Parameter Declaration
        /// </summary>
        /// <remarks>
        /// A function or method parameter.
        /// </remarks>
        ParmDeclaration = 10,

        /// <summary>
        /// Objective-C Interface Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @interface.
        /// </remarks>
        ObjCInterfaceDeclaration = 11,

        /// <summary>
        /// Objective-C Category Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @interface for a category.
        /// </remarks>
        ObjCCategoryDeclaration = 12,

        /// <summary>
        /// Objective-C Protocol Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @protocol declaration.
        /// </remarks>
        ObjCProtocolDeclaration = 13,

        /// <summary>
        /// Objective-C Property Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @property declaration.
        /// </remarks>
        ObjCPropertyDeclaration = 14,

        /// <summary>
        /// Objective-C Instance Variable Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C instance variable.
        /// </remarks>
        ObjCIvarDeclaration = 15,

        /// <summary>
        /// Objective-C Instance Method Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C instance method.
        /// </remarks>
        ObjCInstanceMethodDeclaration = 16,

        /// <summary>
        /// Objective-C Class Method
        /// </summary>
        /// <remarks>
        /// An Objective-C class method.
        /// </remarks>
        ObjCClassMethodDeclaration = 17,

        /// <summary>
        /// Objective-C Implementation Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @implementation.
        /// </remarks>
        ObjCImplementationDeclaration = 18,

        /// <summary>
        /// Objective-C Category Implementation Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @implementation for a category.
        /// </remarks>
        ObjCCategoryImplDeclaration = 19,

        /// <summary>
        /// Typedef Declaration
        /// </summary>
        /// <remarks>
        /// A typedef.
        /// </remarks>
        TypedefDeclaration = 20,

        /// <summary>
        /// C++ Method
        /// </summary>
        /// <remarks>
        /// A C++ class method.
        /// </remarks>
        CXXMethod = 21,

        /// <summary>
        /// Namespace
        /// </summary>
        /// <remarks>
        /// A C++ namespace.
        /// </remarks>
        Namespace = 22,

        /// <summary>
        /// Linkage Specification
        /// </summary>
        /// <remarks>
        /// A linkage specification, e.g. 'extern "C"'.
        /// </remarks>
        LinkageSpec = 23,

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// A C++ constructor.
        /// </remarks>
        Constructor = 24,

        /// <summary>
        /// Destructor
        /// </summary>
        /// <remarks>
        /// A C++ destructor.
        /// </remarks>
        Destructor = 25,

        /// <summary>
        /// Conversion Function
        /// </summary>
        /// <remarks>
        /// A C++ conversion function.
        /// </remarks>
        ConversionFunction = 26,

        /// <summary>
        /// Template Type Parameter
        /// </summary>
        /// <remarks>
        /// A C++ template type parameter.
        /// </remarks>
        TemplateTypeParameter = 27,

        /// <summary>
        /// Non-Type Template Parameter
        /// </summary>
        /// <remarks>
        /// A C++ non-type template parameter.
        /// </remarks>
        NonTypeTemplateParameter = 28,

        /// <summary>
        /// Template Template Parameter
        /// </summary>
        /// <remarks>
        /// A C++ template template parameter.
        /// </remarks>
        TemplateTemplateParameter = 29,

        /// <summary>
        /// Function Template
        /// </summary>
        /// <remarks>
        /// A C++ function template.
        /// </remarks>
        FunctionTemplate = 30,

        /// <summary>
        /// Class Template
        /// </summary>
        /// <remarks>
        /// A C++ class template.
        /// </remarks>
        ClassTemplate = 31,

        /// <summary>
        /// Class Template Partial Specialization
        /// </summary>
        /// <remarks>
        /// A C++ class template partial specialization.
        /// </remarks>
        ClassTemplatePartialSpecialization = 32,

        /// <summary>
        /// Namespace Alias
        /// </summary>
        /// <remarks>
        /// A C++ namespace alias declaration.
        /// </remarks>
        NamespaceAlias = 33,

        /// <summary>
        /// Using Directive
        /// </summary>
        /// <remarks>
        /// A C++ using directive.
        /// </remarks>
        UsingDirective = 34,

        /// <summary>
        /// Using Declaration
        /// </summary>
        /// <remarks>
        /// A C++ using declaration.
        /// </remarks>
        UsingDeclaration = 35,

        /// <summary>
        /// Type Alias Declaration
        /// </summary>
        /// <remarks>
        /// A C++ alias declaration.
        /// </remarks>
        TypeAliasDeclaration = 36,

        /// <summary>
        /// Objective-C Synthesize Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @synthesize definition.
        /// </remarks>
        ObjCSynthesizeDeclaration = 37,

        /// <summary>
        /// Objective-C Dynamic Declaration
        /// </summary>
        /// <remarks>
        /// An Objective-C @dynamic definition.
        /// </remarks>
        ObjCDynamicDeclaration = 38,

        /// <summary>
        /// C++ Access Specifier
        /// </summary>
        /// <remarks>
        /// An access specifier.
        /// </remarks>
        CXXAccessSpecifier = 39,

        /// <summary>
        /// First Declaration
        /// </summary>
        FirstDeclaration = UnexposedDeclaration,

        /// <summary>
        /// Last Declaration
        /// </summary>
        LastDeclaration = CXXAccessSpecifier,

        /// <summary>
        /// First Reference
        /// </summary>
        FirstReference = 40,

        /* Declaration references */

        /// <summary>
        /// Objective-C Super Class Reference
        /// </summary>
        ObjCSuperClassReference = 40,

        /// <summary>
        /// Objective-C Protocol Reference
        /// </summary>
        ObjCProtocolReference = 41,

        /// <summary>
        /// Objective-C Class Reference
        /// </summary>
        ObjCClassReference = 42,

        /// <summary>
        /// Type Reference
        /// </summary>
        /// <remarks>
        /// A reference to a type declaration.
        ///
        /// A type reference occurs anywhere where a type is named but not
        /// declared. For example, given:
        /// <code>
        /// typedef unsigned size_type;
        /// size_type size;
        /// </code>
        /// The typedef is a declaration of size_type (TypedefDecl),
        /// while the type of the variable "size" is referenced. The cursor
        /// referenced by the type of size is the typedef for size_type.
        /// </remarks>
        TypeReference = 43,

        /// <summary>
        /// C++ Base Specifier
        /// </summary>
        CXXBaseSpecifier = 44,

        /// <summary>
        /// Template Reference
        /// </summary>
        /// <remarks>
        /// A reference to a class template, function template, template
        /// template parameter, or class template partial specialization.
        /// </remarks>
        TemplateReference = 45,

        /// <summary>
        /// Namespace Reference
        /// </summary>
        /// <remarks>
        /// A reference to a namespace or namespace alias.
        /// </remarks>
        NamespaceReference = 46,

        /// <summary>
        /// Member Reference
        /// </summary>
        /// <remarks>
        /// A reference to a member of a struct, union, or class that occurs in
        /// some non-expression context, e.g., a designated initializer.
        /// </remarks>
        MemberReference = 47,

        /// <summary>
        /// Label Reference
        /// </summary>
        /// <remarks>
        /// A reference to a labeled statement.
        ///
        /// This cursor kind is used to describe the jump to "start_over" in the
        /// goto statement in the following example:
        /// <code>
        /// start_over:
        ///     ++counter;
        ///
        ///     goto start_over;
        /// </code>
        /// A label reference cursor refers to a label statement.
        /// </remarks>
        LabelReference = 48,

        /// <summary>
        /// Overloaded Declaration Reference
        /// </summary>
        /// <remarks>
        /// A reference to a set of overloaded functions or function templates
        /// that has not yet been resolved to a specific function or function template.
        ///
        /// An overloaded declaration reference cursor occurs in C++ templates where
        /// a dependent name refers to a function. For example:
        ///
        /// <code>
        /// template&lt;typename T&gt; void swap(T&amp;, T&amp;);
        ///
        /// struct X { ... };
        /// void swap(X&amp;, X&amp;);
        ///
        /// template&lt;typename T&gt;
        /// void reverse(T* first, T* last) {
        ///   while (first &lt; last - 1) {
        ///     swap(*first, *--last);
        ///     ++first;
        ///   }
        /// }
        ///
        /// struct Y { };
        /// void swap(Y&amp;, Y&amp;);
        /// </code>
        ///
        /// Here, the identifier "swap" is associated with an overloaded declaration
        /// reference. In the template definition, "swap" refers to either of the two
        /// "swap" functions declared above, so both results will be available. At
        /// instantiation time, "swap" may also refer to other functions found via
        /// argument-dependent lookup (e.g., the "swap" function at the end of the
        /// example).
        ///
        /// The functions <c>clang_getNumOverloadedDecls()</c> and
        /// <c>clang_getOverloadedDecl()</c> can be used to retrieve the definitions
        /// referenced by this cursor.
        /// </remarks>
        OverloadedDeclarationReference = 49,

        /// <summary>
        /// Variable Reference
        /// </summary>
        /// <remarks>
        /// A reference to a variable that occurs in some non-expression
        /// context, e.g., a C++ lambda capture list.
        /// </remarks>
        VariableReference = 50,

        /// <summary>
        /// Last Reference
        /// </summary>
        LastReference = VariableReference,

        /* Error conditions */

        /// <summary>
        /// First Invalid
        /// </summary>
        FirstInvalid = 70,

        /// <summary>
        /// Invalid File
        /// </summary>
        InvalidFile = 70,

        /// <summary>
        /// No Declaration Found
        /// </summary>
        NoDeclarationFound = 71,

        /// <summary>
        /// Not Implemented
        /// </summary>
        NotImplemented = 72,

        /// <summary>
        /// Invalid Code
        /// </summary>
        InvalidCode = 73,

        /// <summary>
        /// Last Invalid
        /// </summary>
        LastInvalid = InvalidCode,

        /* Expressions */

        /// <summary>
        /// First Expression
        /// </summary>
        FirstExpression = 100,

        /// <summary>
        /// Unexposed Expression
        /// </summary>
        /// <remarks>
        /// An expression whose specific kind is not exposed via this
        /// interface.
        ///
        /// Unexposed expressions have the same operations as any other kind
        /// of expression; one can extract their location information,
        /// spelling, children, etc. However, the specific kind of the
        /// expression is not reported.
        /// </remarks>
        UnexposedExpression = 100,

        /// <summary>
        /// Declaration Reference Expression
        /// </summary>
        /// <remarks>
        /// An expression that refers to some value declaration, such
        /// as a function, varible, or enumerator.
        /// </remarks>
        DeclarationReferenceExpression = 101,

        /// <summary>
        /// Member Reference Expression
        /// </summary>
        /// <remarks>
        /// An expression that refers to a member of a struct, union,
        /// class, Objective-C class, etc.
        /// </remarks>
        MemberReferenceExpression = 102,

        /// <summary>
        /// Call Expression
        /// </summary>
        /// <remarks>
        /// An expression that calls a function.
        /// </remarks>
        CallExpression = 103,

        /// <summary>
        /// Objective-C Message Expression
        /// </summary>
        /// <remarks>
        /// An expression that sends a message to an Objective-C
        /// object or class.
        /// </remarks>
        ObjCMessageExpression = 104,

        /// <summary>
        /// Block Expression
        /// </summary>
        /// <remarks>
        /// An expression that represents a block literal.
        /// </remarks>
        BlockExpression = 105,

        /// <summary>
        /// Integral Literal
        /// </summary>
        /// <remarks>
        /// An integer literal.
        /// </remarks>
        IntegerLiteral = 106,

        /// <summary>
        /// Floating Literal
        /// </summary>
        /// <remarks>
        /// A floating point number literal.
        /// </remarks>
        FloatingLiteral = 107,

        /// <summary>
        /// Imaginary Literal
        /// </summary>
        /// <remarks>
        /// An imaginary number literal.
        /// </remarks>
        ImaginaryLiteral = 108,

        /// <summary>
        /// String Literal
        /// </summary>
        /// <remarks>
        /// A string literal.
        /// </remarks>
        StringLiteral = 109,

        /// <summary>
        /// Character Literal
        /// </summary>
        /// <remarks>
        /// A character literal.
        /// </remarks>
        CharacterLiteral = 110,

        /// <summary>
        /// Parenthesized Expression
        /// </summary>
        /// <remarks>
        /// A parenthesized expression, e.g. "(1)".
        ///
        /// This AST node is only formed if full location information is requested.
        /// </remarks>
        ParenExpression = 111,

        /// <summary>
        /// Unary Operator Expression
        /// </summary>
        /// <remarks>
        /// This represents the unary-expression's (except sizeof and
        /// alignof).
        /// </remarks>
        UnaryOperator = 112,

        /// <summary>
        /// Array Subscripting Expression
        /// </summary>
        /// <remarks>
        /// [C99 6.5.2.1] Array Subscripting.
        /// </remarks>
        ArraySubscriptExpression = 113,

        /// <summary>
        /// Binary Operator Expression
        /// </summary>
        /// <remarks>
        /// A builtin binary operation expression such as "x + y" or
        /// "x &lt;= y".
        /// </remarks>
        BinaryOperator = 114,

        /// <summary>
        /// Compound Assign Operator
        /// </summary>
        /// <remarks>
        /// Compound assignment such as "+=".
        /// </remarks>
        CompoundAssignOperator = 115,

        /// <summary>
        /// Conditional Operator
        /// </summary>
        /// <remarks>
        /// The ?: ternary operator.
        /// </remarks>
        ConditionalOperator = 116,

        /// <summary>
        /// C Style Cast Expression
        /// </summary>
        /// <remarks>
        /// An explicit cast in C (C99 6.5.4) or a C-style cast in C++
        /// (C++ [expr.cast]), which uses the syntax (Type)expr.
        ///
        /// For example: (int)f.
        /// </remarks>
        CStyleCastExpression = 117,

        /// <summary>
        /// Compound Literal Expression
        /// </summary>
        /// <remarks>
        /// [C99 6.5.2.5]
        /// </remarks>
        CompoundLiteralExpression = 118,

        /// <summary>
        /// Initializer List Expression
        /// </summary>
        /// <remarks>
        ///  Describes an C or C++ initializer list.
        /// </remarks>
        InitListExpression = 119,

        /// <summary>
        /// Address Label Expression
        /// </summary>
        /// <remarks>
        /// The GNU address of label extension, representing &amp;&amp;label.
        /// </remarks>
        AddrLabelExpression = 120,

        /// <summary>
        /// Statement Expression
        /// </summary>
        /// <remarks>
        /// This is the GNU Statement Expression extension: ({int X=4; X;})
        /// </remarks>
        StatementExpression = 121,

        /// <summary>
        /// Generic Selection Expression
        /// </summary>
        /// <remarks>
        /// Represents a C11 generic selection.
        /// </remarks>
        GenericSelectionExpression = 122,

        /// <summary>
        /// GNU Null Expression
        /// </summary>
        /// <remarks>
        /// Implements the GNU __null extension, which is a name for a null
        /// pointer constant that has integral type (e.g., int or long) and is the same
        /// size and alignment as a pointer.
        ///
        /// The __null extension is typically only used by system headers, which define
        /// NULL as __null in C++ rather than using 0 (which is an integer that may not
        /// match the size of a pointer).
        /// </remarks>
        GNUNullExpression = 123,

        /// <summary>
        /// C++ Static Cast Expression
        /// </summary>
        /// <remarks>
        /// C++'s static_cast&lt;&gt; expression.
        /// </remarks>
        CXXStaticCastExpression = 124,

        /// <summary>
        /// C++ Dynamic Cast Expression
        /// </summary>
        /// <remarks>
        /// C++'s dynamic_cast&lt;&gt; expression.
        /// </remarks>
        CXXDynamicCastExpression = 125,

        /// <summary>
        /// C++ Reinterpret Cast Expression
        /// </summary>
        /// <remarks>
        /// C++'s reinterpret_cast&lt;&gt; expression.
        /// </remarks>
        CXXReinterpretCastExpression = 126,

        /// <summary>
        /// C++ Const Cast Expression
        /// </summary>
        /// <remarks>
        /// C++'s const_cast&lt;&gt; expression.
        /// </remarks>
        CXXConstCastExpression = 127,

        /// <summary>
        /// C++ Functional Cast Expression
        /// </summary>
        /// <remarks>
        /// Represents an explicit C++ type conversion that uses "functional"
        /// notion (C++ [expr.type.conv]).
        ///
        /// Example:
        /// <code>
        ///   x = int(0.5);
        /// </code>
        /// </remarks>
        CXXFunctionalCastExpression = 128,

        /// <summary>
        /// C++ Type ID Expression
        /// </summary>
        /// <remarks>
        /// A C++ typeid expression (C++ [expr.typeid]).
        /// </remarks>
        CXXTypeidExpression = 129,

        /// <summary>
        /// C++ Bool Literal Expression
        /// </summary>
        /// <remarks>
        /// [C++ 2.13.5] C++ Boolean Literal.
        /// </remarks>
        CXXBoolLiteralExpression = 130,

        /// <summary>
        /// C++ Null Pointer Literal Expression
        /// </summary>
        /// <remarks>
        /// [C++0x 2.14.7] C++ Pointer Literal.
        /// </remarks>
        CXXNullPtrLiteralExpression = 131,

        /// <summary>
        /// C++ This Expression
        /// </summary>
        /// <remarks>
        /// Represents the "this" expression in C++
        /// </remarks>
        CXXThisExpression = 132,

        /// <summary>
        /// C++ Throw Expression
        /// </summary>
        /// <remarks>
        /// [C++ 15] C++ Throw Expression.
        ///
        /// This handles 'throw' and 'throw' assignment-expression. When
        /// assignment-expression isn't present, Op will be null.
        /// </remarks>
        CXXThrowExpression = 133,

        /// <summary>
        /// C++ New Expression
        /// </summary>
        /// <remarks>
        /// A new expression for memory allocation and constructor calls, e.g:
        /// "new CXXNewExpr(foo)".
        /// </remarks>
        CXXNewExpression = 134,

        /// <summary>
        /// C++ Delete Expression
        /// </summary>
        /// <remarks>
        /// A delete expression for memory deallocation and destructor calls,
        /// e.g. "delete[] pArray".
        /// </remarks>
        CXXDeleteExpression = 135,

        /// <summary>
        /// Unary Expression
        /// </summary>
        /// <remarks>
        /// A unary expression.
        /// </remarks>
        UnaryExpression = 136,

        /// <summary>
        /// Objective-C String Literal
        /// </summary>
        /// <remarks>
        /// An Objective-C string literal i.e. @"foo".
        /// </remarks>
        ObjCStringLiteral = 137,

        /// <summary>
        /// Objective-C Encode Expression
        /// </summary>
        /// <remarks>
        /// An Objective-C @encode expression.
        /// </remarks>
        ObjCEncodeExpression = 138,

        /// <summary>
        /// Objective-C Selector Expression
        /// </summary>
        /// <remarks>
        /// An Objective-C @selector expression.
        /// </remarks>
        ObjCSelectorExpression = 139,

        /// <summary>
        /// Objective-C Protocol Expression
        /// </summary>
        /// <remarks>
        /// An Objective-C @protocol expression.
        /// </remarks>
        ObjCProtocolExpression = 140,

        /// <summary>
        /// Objective-C Bridged Cast Expression
        /// </summary>
        /// <remarks>
        /// An Objective-C "bridged" cast expression, which casts between
        /// Objective-C pointers and C pointers, transferring ownership in the process.
        ///
        /// <code>
        ///   NSString *str = (__bridge_transfer NSString *)CFCreateString();
        /// </code>
        /// </remarks>
        ObjCBridgedCastExpression = 141,

        /// <summary>
        /// Pack Expansiont Expression
        /// </summary>
        /// <remarks>
        /// Represents a C++0x pack expansion that produces a sequence of
        /// expressions.
        ///
        /// A pack expansion expression contains a pattern (which itself is an
        /// expression) followed by an ellipsis. For example:
        ///
        /// <code>
        /// template&lt;typename F, typename ...Types&gt;
        /// void forward(F f, Types &amp;&amp;...args) {
        ///  f(static_cast&lt;Types&amp;&amp;&gt;(args)...);
        /// }
        /// </code>
        /// </remarks>
        PackExpansionExpression = 142,

        /// <summary>
        /// Size Of Pack Expression
        /// </summary>
        /// <remarks>
        /// Represents an expression that computes the length of a parameter pack.
        ///
        /// <code>
        /// template&lt;typename ...Types&gt;
        /// struct count {
        ///   static const unsigned value = sizeof...(Types);
        /// };
        /// </code>
        /// </remarks>
        SizeOfPackExpression = 143,

        /// <summary>
        /// Lambda Expression
        /// </summary>
        /// <remarks>
        /// Represents a C++ lambda expression that produces a local function
        /// object.
        ///
        /// <code>
        /// void abssort(float *x, unsigned N) {
        ///   std::sort(x, x + N,
        ///             [](float a, float b) {
        ///               return std::abs(a) &lt; std::abs(b);
        ///             });
        /// }
        /// </code>
        /// </remarks>
        LambdaExpression = 144,

        /// <summary>
        /// Objective-C Boolean Literal
        /// </summary>
        /// <remarks>
        /// Objective-c Boolean Literal.
        /// </remarks>
        ObjCBoolLiteralExpression = 145,

        /// <summary>
        /// Objective-C Self Expression
        /// </summary>
        /// <remarks>
        /// Represents the "self" expression in a ObjC method.
        /// </remarks>
        ObjCSelfExpression = 146,

        /// <summary>
        /// OpenMP Array Selection Expression
        /// </summary>
        /// <remarks>
        /// OpenMP 4.0 [2.4, Array Section].
        /// </remarks>
        OMPArraySectionExpression = 147,

        /// <summary>
        /// Objective-C Availability Check Expression
        /// </summary>
        /// <remarks>
        /// Represents an @available(...) check.
        /// </remarks>
        ObjCAvailabilityCheckExpression = 148,

        /// <summary>
        /// Fixed Point Literal
        /// </summary>
        /// <remarks>
        /// Fixed point literal
        /// </remarks>
        FixedPointLiteral = 149,

        /// <summary>
        /// Last Expression
        /// </summary>
        LastExpression = FixedPointLiteral,

        /* Statements */

        /// <summary>
        /// First Statement
        /// </summary>
        FirstStatement = 200,

        /// <summary>
        /// Unexposed Statement
        /// </summary>
        /// <remarks>
        /// A statement whose specific kind is not exposed via this
        /// interface.
        ///
        /// Unexposed statements have the same operations as any other kind of
        /// statement; one can extract their location information, spelling,
        /// children, etc. However, the specific kind of the statement is not
        /// reported.
        /// </remarks>
        UnexposedStatement = 200,

        /// <summary>
        /// Label Statement
        /// </summary>
        /// <remarks>
        /// A labelled statement in a function.
        ///
        /// This cursor kind is used to describe the "start_over:" label statement in
        /// the following example:
        ///
        /// <code>
        ///   start_over:
        ///     ++counter;
        /// </code>
        /// </remarks>
        LabelStatement = 201,

        /// <summary>
        /// Compound Statement
        /// </summary>
        /// <remarks>
        /// A group of statements like { stmt stmt }.
        ///
        /// This cursor kind is used to describe compound statements,
        /// e.g. function bodies.
        /// </remarks>
        CompoundStatement = 202,

        /// <summary>
        /// Case Statement
        /// </summary>
        /// <remarks>
        /// A case statement.
        /// </remarks>
        CaseStatement = 203,

        /// <summary>
        /// Default Statement
        /// </summary>
        /// <remarks>
        /// A default statement.
        /// </remarks>
        DefaultStatement = 204,

        /// <summary>
        /// If Statement
        /// </summary>
        /// <remarks>
        /// An if statement
        /// </remarks>
        IfStatement = 205,

        /// <summary>
        /// Switch Statement
        /// </summary>
        /// <remarks>
        /// A switch statement.
        /// </remarks>
        SwitchStatement = 206,

        /// <summary>
        /// While Statement
        /// </summary>
        /// <remarks>
        /// A while statement.
        /// </remarks>
        WhileStatement = 207,

        /// <summary>
        /// Do Statement
        /// </summary>
        /// <remarks>
        /// A do statement.
        /// </remarks>
        DoStatement = 208,

        /// <summary>
        /// For Statement
        /// </summary>
        /// <remarks>
        /// A for statement.
        /// </remarks>
        ForStatement = 209,

        /// <summary>
        /// Goto Statement
        /// </summary>
        /// <remarks>
        /// A goto statement.
        /// </remarks>
        GotoStatement = 210,

        /// <summary>
        /// Indirect Goto Statement
        /// </summary>
        /// <remarks>
        /// An indirect goto statement.
        /// </remarks>
        IndirectGotoStatement = 211,

        /// <summary>
        /// Continue Statement
        /// </summary>
        /// <remarks>
        /// A continue statement.
        /// </remarks>
        ContinueStatement = 212,

        /// <summary>
        /// Break Statement
        /// </summary>
        BreakStatement = 213,

        /// <summary>
        /// Return Statement
        /// </summary>
        /// <remarks>
        /// A return statement.
        /// </remarks>
        ReturnStatement = 214,

        /// <summary>
        /// GCC Inline Assembly Statement
        /// </summary>
        /// <remarks>
        /// A GCC inline assembly statement extension.
        /// </remarks>
        GCCAsmStatement = 215,

        /// <summary>
        /// Assembly Statement
        /// </summary>
        AsmStatement = GCCAsmStatement,

        /// <summary>
        /// Objective-C Try Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's overall @try-@catch-@finally statement.
        /// </remarks>
        ObjCAtTryStatement = 216,

        /// <summary>
        /// Objective-C Catch Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's @catch statement.
        /// </remarks>
        ObjCAtCatchStatement = 217,

        /// <summary>
        /// Objective-C Finally Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's @finally statement.
        /// </remarks>
        ObjCAtFinallyStatement = 218,

        /// <summary>
        /// Objective-C Throw Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's @throw statement.
        /// </remarks>
        ObjCAtThrowStatement = 219,

        /// <summary>
        /// Objective-C Synchronized Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's @synchronized statement.
        /// </remarks>
        ObjCAtSynchronizedStatement = 220,

        /// <summary>
        /// Objective-C Auto Release Pool Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's autorelease pool statement.
        /// </remarks>
        ObjCAutoreleasePoolStatement = 221,

        /// <summary>
        /// Objective-C For Collection Statement
        /// </summary>
        /// <remarks>
        /// Objective-C's collection statement.
        /// </remarks>
        ObjCForCollectionStatement = 222,

        /// <summary>
        /// C++ Catch Statemtn
        /// </summary>
        /// <remarks>
        /// C++'s catch statement.
        /// </remarks>
        CXXCatchStatement = 223,

        /// <summary>
        /// C++ Try Statement
        /// </summary>
        /// <remarks>
        /// C++'s try statement.
        /// </remarks>
        CXXTryStatement = 224,

        /// <summary>
        /// C++ For Range Statement
        /// </summary>
        /// <remarks>
        /// C++'s for (* : *) statement.
        /// </remarks>
        CXXForRangeStatement = 225,

        /// <summary>
        /// SEH(Structured Exception Hnadling) Try Statement
        /// </summary>
        /// <remarks>
        /// Windows Structured Exception Handling's try statement.
        /// </remarks>
        SEHTryStatement = 226,

        /// <summary>
        /// SEH(Structured Exception Hnadling) Except Statement
        /// </summary>
        /// <remarks>
        /// Windows Structured Exception Handling's except statement.
        /// </remarks>
        SEHExceptStatement = 227,

        /// <summary>
        ///SEH(Structured Exception Hnadling) Finally Statement
        /// </summary>
        /// <remarks>
        /// Windows Structured Exception Handling's finally statement.
        /// </remarks>
        SEHFinallyStatement = 228,

        /// <summary>
        /// MS inline Assembly Statement
        /// </summary>
        /// <remarks>
        /// A MS inline assembly statement extension.
        /// </remarks>
        MSAsmStatement = 229,

        /// <summary>
        /// Null Statemant
        /// </summary>
        /// <remarks>
        /// The null satement ";": C99 6.8.3p3.
        ///
        /// This cursor kind is used to describe the null statement.
        /// </remarks>
        NullStatement = 230,

        /// <summary>
        /// Declaration Statement
        /// </summary>
        /// <remarks>
        /// Adaptor class for mixing declarations with statements and expressions.
        /// </remarks>
        DeclarationStatement = 231,

        /// <summary>
        /// OpenMP Parallel Directive
        /// </summary>
        /// <remarks>
        /// OpenMP parallel directive.
        /// </remarks>
        OMPParallelDirective = 232,

        /// <summary>
        /// OpenMP SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP SIMD directive.
        /// </remarks>
        OMPSimdDirective = 233,

        /// <summary>
        /// OpenMP For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP for directive.
        /// </remarks>
        OMPForDirective = 234,

        /// <summary>
        /// OpenMP Sections Directive
        /// </summary>
        /// <remarks>
        /// OpenMP sections directive.
        /// </remarks>
        OMPSectionsDirective = 235,

        /// <summary>
        /// OpenMP Section Directive
        /// </summary>
        /// <remarks>
        /// OpenMP section directive.
        /// </remarks>
        OMPSectionDirective = 236,

        /// <summary>
        /// OpenMP Single Directive
        /// </summary>
        /// <remarks>
        /// OpenMP single directive.
        /// </remarks>
        OMPSingleDirective = 237,

        /// <summary>
        /// OpenMP Parallel For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP parallel for directive.
        /// </remarks>
        OMPParallelForDirective = 238,

        /// <summary>
        /// OpenMP Parallel Sections Directive
        /// </summary>
        /// <remarks>
        /// OpenMP parallel sections directive.
        /// </remarks>
        OMPParallelSectionsDirective = 239,

        /// <summary>
        /// OpenMP Task Directive
        /// </summary>
        /// <remarks>
        /// OpenMP task directive.
        /// </remarks>
        OMPTaskDirective = 240,

        /// <summary>
        /// OpenMP Master Directive
        /// </summary>
        /// <remarks>
        /// OpenMP master directive.
        /// </remarks>
        OMPMasterDirective = 241,

        /// <summary>
        /// OpenMP Critical Directive
        /// </summary>
        /// <remarks>
        /// OpenMP critical directive.
        /// </remarks>
        OMPCriticalDirective = 242,

        /// <summary>
        /// OpenMP Taskyield Directive
        /// </summary>
        /// <remarks>
        /// OpenMP taskyield directive.
        /// </remarks>
        OMPTaskyieldDirective = 243,

        /// <summary>
        /// OpenMP Barrier Directive
        /// </summary>
        /// <remarks>
        /// OpenMP barrier directive.
        /// </remarks>
        OMPBarrierDirective = 244,

        /// <summary>
        /// OpenMP Taskwait Directive
        /// </summary>
        /// <remarks>
        /// OpenMP taskwait directive.
        /// </remarks>
        OMPTaskwaitDirective = 245,

        /// <summary>
        /// OpenMP Flush Directive
        /// </summary>
        /// <remarks>
        /// OpenMP flush directive.
        /// </remarks>
        OMPFlushDirective = 246,

        /// <summary>
        /// SEHL(Structured Exception Handling)
        /// </summary>
        /// <remarks>
        /// Windows Structured Exception Handling's leave statement.
        /// </remarks>
        SEHLeaveStmt = 247,

        /// <summary>
        /// OpenMP Ordered Directive
        /// </summary>
        /// <remarks>
        /// OpenMP ordered directive.
        /// </remarks>
        OMPOrderedDirective = 248,

        /// <summary>
        /// OpenMP Atomic Directive
        /// </summary>
        /// <remarks>
        /// OpenMP atomic directive.
        /// </remarks>
        OMPAtomicDirective = 249,

        /// <summary>
        /// OpenMP For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP for SIMD directive.
        /// </remarks>
        OMPForSimdDirective = 250,

        /// <summary>
        /// OpenMP Parallel For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP parallel for SIMD directive.
        /// </remarks>
        OMPParallelForSimdDirective = 251,

        /// <summary>
        /// OpenMP Target Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target directive.
        /// </remarks>
        OMPTargetDirective = 252,

        /// <summary>
        /// OpenMP Team Directive
        /// </summary>
        /// <remarks>
        /// OpenMP teams directive.
        /// </remarks>
        OMPTeamsDirective = 253,

        /// <summary>
        /// OpenMP Taskgroup Directive
        /// </summary>
        /// <remarks>
        /// OpenMP taskgroup directive.
        /// </remarks>
        OMPTaskgroupDirective = 254,

        /// <summary>
        /// OpenMP Cancellation Point Directive
        /// </summary>
        /// <remarks>
        /// OpenMP cancellation point directive.
        /// </remarks>
        OMPCancellationPointDirective = 255,

        /// <summary>
        /// OpenMP Cancel Directive
        /// </summary>
        /// <remarks>
        /// OpenMP cancel directive.
        /// </remarks>
        OMPCancelDirective = 256,

        /// <summary>
        /// OpenMP Target Data Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target data directive.
        /// </remarks>
        OMPTargetDataDirective = 257,

        /// <summary>
        /// OpenMP Task Loop Directive
        /// </summary>
        /// <remarks>
        /// OpenMP taskloop directive.
        /// </remarks>
        OMPTaskLoopDirective = 258,

        /// <summary>
        /// OpenMP Task Loop SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP taskloop simd directive.
        /// </remarks>
        OMPTaskLoopSimdDirective = 259,

        /// <summary>
        /// OpenMP Distribute Directive
        /// </summary>
        /// <remarks>
        /// OpenMP distribute directive.
        /// </remarks>
        OMPDistributeDirective = 260,

        /// <summary>
        /// OpenMP Target Enter Data Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target enter data directive.
        /// </remarks>
        OMPTargetEnterDataDirective = 261,

        /// <summary>
        /// OpenMP Target Exit Data Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target exit data directive.
        /// </remarks>
        OMPTargetExitDataDirective = 262,

        /// <summary>
        /// OpenMP Target Parallel Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target parallel directive.
        /// </remarks>
        OMPTargetParallelDirective = 263,

        /// <summary>
        /// OpenMP Target Parallel For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target parallel for directive.
        /// </remarks>
        OMPTargetParallelForDirective = 264,

        /// <summary>
        /// OpenMP Target Update Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target update directive.
        /// </remarks>
        OMPTargetUpdateDirective = 265,

        /// <summary>
        /// OpenMP Distribute Parallel For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP distribute parallel for directive.
        /// </remarks>
        OMPDistributeParallelForDirective = 266,

        /// <summary>
        /// OpenMP Distribute Parallel For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP distribute parallel for simd directive.
        /// </remarks>
        OMPDistributeParallelForSimdDirective = 267,

        /// <summary>
        /// OpenMP Distribute SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP distribute simd directive.
        /// </remarks>
        OMPDistributeSimdDirective = 268,

        /// <summary>
        /// OpenMP Target Parallel For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target parallel for simd directive.
        /// </remarks>
        OMPTargetParallelForSimdDirective = 269,

        /// <summary>
        /// OpenMP Target SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target simd directive.
        /// </remarks>
        OMPTargetSimdDirective = 270,

        /// <summary>
        /// OpenMP Teams Distribute Directive
        /// </summary>
        /// <remarks>
        /// OpenMP teams distribute directive.
        /// </remarks>
        OMPTeamsDistributeDirective = 271,

        /// <summary>
        /// OpenMP Teams Distribute SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP teams distribute simd directive.
        /// </remarks>
        OMPTeamsDistributeSimdDirective = 272,

        /// <summary>
        /// OpenMP Teams Distribute Parallel For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP teams distribute parallel for simd directive.
        /// </remarks>
        OMPTeamsDistributeParallelForSimdDirective = 273,

        /// <summary>
        /// OpenMP Teams Distribute Parallel For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP teams distribute parallel for directive.
        /// </remarks>
        OMPTeamsDistributeParallelForDirective = 274,

        /// <summary>
        /// OpenMP Target Teams Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target teams directive.
        /// </remarks>
        OMPTargetTeamsDirective = 275,

        /// <summary>
        /// OpenMP Target Teams Distribute Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target teams distribute directive.
        /// </remarks>
        OMPTargetTeamsDistributeDirective = 276,

        /// <summary>
        /// OpemMP Target Teams Distribute Parallel For Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target teams distribute parallel for directive.
        /// </remarks>
        OMPTargetTeamsDistributeParallelForDirective = 277,

        /// <summary>
        /// OpenMP Target Teams Distribute Parallel For SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target teams distribute parallel for simd directive.
        /// </remarks>
        OMPTargetTeamsDistributeParallelForSimdDirective = 278,

        /// <summary>
        /// OpenMP Target Teams Distribute SIMD Directive
        /// </summary>
        /// <remarks>
        /// OpenMP target teams distribute simd directive.
        /// </remarks>
        OMPTargetTeamsDistributeSimdDirective = 279,

        /// <summary>
        /// Builtin Bit Cast Expression
        /// </summary>
        /// <remarks>
        /// C++2a std::bit_cast expression.
        /// </remarks>
        BuiltinBitCastExpr = 280,

        /// <summary>
        /// Last Statement
        /// </summary>
        LastStatement = BuiltinBitCastExpr,

        /// <summary>
        /// Translation Unit
        /// </summary>
        /// <remarks>
        /// Cursor that represents the translation unit itself.
        ///
        /// The translation unit cursor exists primarily to act as the root
        /// cursor for traversing the contents of a translation unit.
        /// </remarks>
        TranslationUnit = 300,

        /* Attributes */

        /// <summary>
        /// First Attribute
        /// </summary>
        FirstAttribute = 400,

        /// <summary>
        /// Unexposed Attribute
        /// </summary>
        /// <remarks>
        /// An attribute whose specific kind is not exposed via this interface.
        /// </remarks>
        UnexposedAttribute = 400,

        /// <summary>
        /// IBAction Attribute
        /// </summary>
        IBActionAttribute = 401,

        /// <summary>
        /// IBOutlet Attribute
        /// </summary>
        IBOutletAttribute = 402,

        /// <summary>
        /// IBOutlet Collection Attribute
        /// </summary>
        IBOutletCollectionAttribute = 403,

        /// <summary>
        /// C++ Final Attribute
        /// </summary>
        CXXFinalAttribute = 404,

        /// <summary>
        /// C++ Override Attribute
        /// </summary>
        CXXOverrideAttribute = 405,

        /// <summary>
        /// C++ Annotate Attribute
        /// </summary>
        AnnotateAttribute = 406,

        /// <summary>
        /// Assembly Label Attribute
        /// </summary>
        AsmLabelAttribute = 407,

        /// <summary>
        /// Packed Attribute
        /// </summary>
        PackedAttribute = 408,

        /// <summary>
        /// Pure Attribute
        /// </summary>
        PureAttribute = 409,

        /// <summary>
        /// Const Attribute
        /// </summary>
        ConstAttribute = 410,

        /// <summary>
        /// No Duplicate Attribute
        /// </summary>
        NoDuplicateAttribute = 411,

        /// <summary>
        /// CUDA Constant Attribute
        /// </summary>
        CUDAConstantAttribute = 412,

        /// <summary>
        /// CUDA Device Attribute
        /// </summary>
        CUDADeviceAttribute = 413,

        /// <summary>
        /// CUDA Global Attribute
        /// </summary>
        CUDAGlobalAttribute = 414,

        /// <summary>
        /// CUDA Host Attribute
        /// </summary>
        CUDAHostAttribute = 415,

        /// <summary>
        /// CUDA Shared Attribute
        /// </summary>
        CUDASharedAttribute = 416,

        /// <summary>
        /// Visibility Attribute
        /// </summary>
        VisibilityAttribute = 417,

        /// <summary>
        /// DLL Export
        /// </summary>
        DLLExport = 418,

        /// <summary>
        /// DLL Import
        /// </summary>
        DLLImport = 419,

        /// <summary>
        /// NS Return Retained
        /// </summary>
        NSReturnsRetained = 420,

        /// <summary>
        /// NS Return Not Retained
        /// </summary>
        NSReturnsNotRetained = 421,

        /// <summary>
        /// NS Return Auto Released
        /// </summary>
        NSReturnsAutoreleased = 422,

        /// <summary>
        /// NS Consumes Self
        /// </summary>
        NSConsumesSelf = 423,

        /// <summary>
        /// NS Consumed
        /// </summary>
        NSConsumed = 424,

        /// <summary>
        /// Objective-C Exception
        /// </summary>
        ObjCException = 425,

        /// <summary>
        /// Objective-C NS Object
        /// </summary>
        ObjCNSObject = 426,

        /// <summary>
        /// Objective-C Independent Class
        /// </summary>
        ObjCIndependentClass = 427,

        /// <summary>
        /// Objective-C Precise Lifetime
        /// </summary>
        ObjCPreciseLifetime = 428,

        /// <summary>
        /// Objective-C Return Inner Pointer
        /// </summary>
        ObjCReturnsInnerPointer = 429,

        /// <summary>
        /// Objective-C Requires Super
        /// </summary>
        ObjCRequiresSuper = 430,

        /// <summary>
        /// Objective-C Root Class
        /// </summary>
        ObjCRootClass = 431,

        /// <summary>
        /// Objective-C Sub Classing Restricted
        /// </summary>
        ObjCSubclassingRestricted = 432,

        /// <summary>
        /// Objective-C Explicit Protocol Implementation
        /// </summary>
        ObjCExplicitProtocolImpl = 433,

        /// <summary>
        /// Objective-C Designated Initializer
        /// </summary>
        ObjCDesignatedInitializer = 434,

        /// <summary>
        /// Objective-C Runtime Visible
        /// </summary>
        ObjCRuntimeVisible = 435,

        /// <summary>
        /// Objective-C Boxable
        /// </summary>
        ObjCBoxable = 436,

        /// <summary>
        /// Flag Enum
        /// </summary>
        FlagEnum = 437,

        /// <summary>
        /// Convergent Attribute
        /// </summary>
        ConvergentAttr = 438,

        /// <summary>
        /// Warn Unused Attribute
        /// </summary>
        WarnUnusedAttr = 439,

        /// <summary>
        /// Warn Unused Result Attribute
        /// </summary>
        WarnUnusedResultAttr = 440,

        /// <summary>
        /// Aligned Attribute
        /// </summary>
        AlignedAttr = 441,

        /// <summary>
        /// Last Attribute
        /// </summary>
        LastAttribute = AlignedAttr,

        /* Preprocessing */

        /// <summary>
        /// Preprocessing Directive
        /// </summary>
        PreprocessingDirective = 500,

        /// <summary>
        /// Macro Definition
        /// </summary>
        MacroDefinition = 501,

        /// <summary>
        /// Macro Expansion
        /// </summary>
        MacroExpansion = 502,

        /// <summary>
        /// Macro Instantiation
        /// </summary>
        MacroInstantiation = MacroExpansion,

        /// <summary>
        /// Inclusion Directive
        /// </summary>
        InclusionDirective = 503,

        /// <summary>
        /// First Preprocessing
        /// </summary>
        FirstPreprocessing = PreprocessingDirective,

        /// <summary>
        /// Last Preprocessing
        /// </summary>
        LastPreprocessing = InclusionDirective,

        /// <summary>
        /// Module Import Declaration
        /// </summary>
        /// <remarks>
        /// A module import declaration.
        /// </remarks>
        ModuleImportDecl = 600,

        /// <summary>
        /// Type Alias Template Declaration
        /// </summary>
        TypeAliasTemplateDecl = 601,

        /// <summary>
        /// Static Assert
        /// </summary>
        /// <remarks>
        /// A static_assert or _Static_assert node
        /// </remarks>
        StaticAssert = 602,

        /// <summary>
        /// Friend Declaration
        /// </summary>
        /// <remarks>
        /// a friend declaration.
        /// </remarks>
        FriendDecl = 603,

        /// <summary>
        /// Firxt Extra Declaration
        /// </summary>
        FirstExtraDecl = ModuleImportDecl,

        /// <summary>
        /// Last Extra Declaration
        /// </summary>
        LastExtraDecl = FriendDecl,

        /// <summary>
        /// Overload Candidate
        /// </summary>
        /// <remarks>
        /// A code completion overload candidate.
        /// </remarks>
        OverloadCandidate = 700,
    }

    /// <summary>
    /// Clang Cursor Kind Extensions
    /// </summary>
    public static class CursorKindEx
    {
        /// <summary>
        /// Check Cursor is Declaration
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Declaration Flag</returns>
        public static bool IsDeclaration(this CursorKind kind)
        {
            return LibClang.clang_isDeclaration(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Reference
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Reference Flag</returns>
        public static bool IsReference(this CursorKind kind)
        {
            return LibClang.clang_isReference(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Expression
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Expression Flag</returns>
        public static bool IsExpression(this CursorKind kind)
        {
            return LibClang.clang_isExpression(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Attribute
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Attribute Flag</returns>
        public static bool IsAttribute(this CursorKind kind)
        {
            return LibClang.clang_isAttribute(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Invalid
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Invalid Flag</returns>
        public static bool IsInvalid(this CursorKind kind)
        {
            return LibClang.clang_isInvalid(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Translation Unit
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Translation Unit Flag</returns>
        public static bool IsTranslationUnit(this CursorKind kind)
        {
            return LibClang.clang_isTranslationUnit(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Preprocessing
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Preprocessing Flag</returns>
        public static bool IsPreprocessing(this CursorKind kind)
        {
            return LibClang.clang_isPreprocessing(kind).ToBool();
        }

        /// <summary>
        /// Check Cursor is Unexposed
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Unexposed Flag</returns>
        public static bool IsUnexposed(this CursorKind kind)
        {
            return LibClang.clang_isUnexposed(kind).ToBool();
        }

        /// <summary>
        /// Get Cursor Kind Spelling
        /// </summary>
        /// <param name="kind">Clang Cursor Kind</param>
        /// <returns>Cursor Kind Spelling</returns>
        public static string Spelling(this CursorKind kind)
        {
            return LibClang.clang_getCursorKindSpelling(kind).ToManaged();
        }
    }
}
