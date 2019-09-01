using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Index Entity Kind
    /// </summary>
    public enum IndexEntityKind
    {
        /// <summary>
        /// Unexposed
        /// </summary>
        Unexposed = 0,

        /// <summary>
        /// Typedef
        /// </summary>
        Typedef = 1,

        /// <summary>
        /// Function
        /// </summary>
        Function = 2,

        /// <summary>
        /// Variable
        /// </summary>
        Variable = 3,

        /// <summary>
        /// Field
        /// </summary>
        Field = 4,

        /// <summary>
        /// Enum Constant
        /// </summary>
        EnumConstant = 5,

        /// <summary>
        /// Objective-C Class
        /// </summary>
        ObjCClass = 6,

        /// <summary>
        /// Objective-C Protocol
        /// </summary>
        ObjCProtocol = 7,

        /// <summary>
        /// Objective-C Category
        /// </summary>
        ObjCCategory = 8,

        /// <summary>
        /// Objective-C Instance Method
        /// </summary>
        ObjCInstanceMethod = 9,

        /// <summary>
        /// Objective-C Class Method
        /// </summary>
        ObjCClassMethod = 10,

        /// <summary>
        /// Objective-C Property
        /// </summary>
        ObjCProperty = 11,

        /// <summary>
        /// Objective-C Instance Variable
        /// </summary>
        ObjCIvar = 12,

        /// <summary>
        /// Enum
        /// </summary>
        Enum = 13,

        /// <summary>
        /// Struct
        /// </summary>
        Struct = 14,

        /// <summary>
        /// Union
        /// </summary>
        Union = 15,

        /// <summary>
        /// C++ Class
        /// </summary>
        CXXClass = 16,

        /// <summary>
        /// C++ Namespace
        /// </summary>
        CXXNamespace = 17,

        /// <summary>
        /// C++ Namespace Alias
        /// </summary>
        CXXNamespaceAlias = 18,

        /// <summary>
        /// C++ Static Variable
        /// </summary>
        CXXStaticVariable = 19,

        /// <summary>
        /// C++ Static Method
        /// </summary>
        CXXStaticMethod = 20,

        /// <summary>
        /// C++ Instance Method
        /// </summary>
        CXXInstanceMethod = 21,

        /// <summary>
        /// C++ Constructor
        /// </summary>
        CXXConstructor = 22,

        /// <summary>
        /// C++ Destructor
        /// </summary>
        CXXDestructor = 23,

        /// <summary>
        /// C++ Conversion Function
        /// </summary>
        CXXConversionFunction = 24,

        /// <summary>
        /// C++ Type Alias
        /// </summary>
        CXXTypeAlias = 25,

        /// <summary>
        /// C++ Interface
        /// </summary>
        CXXInterface = 26,
    }

    /// <summary>
    /// Index Entity Kind Extension
    /// </summary>
    public static class IndexEntityKindEx
    {
        /// <summary>
        /// Check Index Entity Kind is Objective-C Container
        /// </summary>
        /// <param name="kind">Index Entity Kind</param>
        /// <returns>Objective-C Container Flag</returns>
        public static bool IsEntityObjCContainer(this IndexEntityKind kind)
        {
            return LibClang.clang_index_isEntityObjCContainerKind(kind).ToBool();
        }
    }
}
