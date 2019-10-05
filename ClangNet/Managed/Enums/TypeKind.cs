using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Type Kind
    /// </summary>
    /// <remarks>
    /// Describes the kind of type
    /// </remarks>
    public enum TypeKind
    {
        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// Reprents an invalid type (e.g., where no type is available).
        /// </remarks>
        Invalid = 0,

        /// <summary>
        /// Unexposed
        /// </summary>
        /// <remarks>
        /// A type whose specific kind is not exposed via this interface.
        /// </remarks>
        Unexposed = 1,

        /* Builtin types */

        /// <summary>
        /// Void
        /// </summary>
        Void = 2,

        /// <summary>
        /// Bool
        /// </summary>
        Bool = 3,

        /// <summary>
        /// Character Unsigned
        /// </summary>
        CharU = 4,

        /// <summary>
        /// Unsigned Char
        /// </summary>
        UChar = 5,

        /// <summary>
        /// Character 16bit
        /// </summary>
        Char16 = 6,

        /// <summary>
        /// Character 32bit
        /// </summary>
        Char32 = 7,

        /// <summary>
        /// Unsigned Short
        /// </summary>
        UShort = 8,

        /// <summary>
        /// Unsigned Integer
        /// </summary>
        UInt = 9,

        /// <summary>
        /// Unsigned Long
        /// </summary>
        ULong = 10,

        /// <summary>
        /// Unsigned Long Long
        /// </summary>
        ULongLong = 11,

        /// <summary>
        /// Unsigned Integer 128bit
        /// </summary>
        UInt128 = 12,

        /// <summary>
        /// Character Signed
        /// </summary>
        CharS = 13,

        /// <summary>
        /// Signed Character
        /// </summary>
        SChar = 14,

        /// <summary>
        /// Wide Character
        /// </summary>
        WChar = 15,

        /// <summary>
        /// Signed Short
        /// </summary>
        Short = 16,

        /// <summary>
        /// Signed Integer
        /// </summary>
        Int = 17,

        /// <summary>
        /// Signed Long
        /// </summary>
        Long = 18,

        /// <summary>
        /// Signed Long Long
        /// </summary>
        LongLong = 19,

        /// <summary>
        /// Integer 128bit
        /// </summary>
        Int128 = 20,

        /// <summary>
        /// Float
        /// </summary>
        Float = 21,

        /// <summary>
        /// Double
        /// </summary>
        Double = 22,

        /// <summary>
        /// Long Double
        /// </summary>
        LongDouble = 23,

        /// <summary>
        /// Null Pointer
        /// </summary>
        NullPtr = 24,

        /// <summary>
        /// Overload
        /// </summary>
        Overload = 25,

        /// <summary>
        /// Dependent
        /// </summary>
        Dependent = 26,

        /// <summary>
        /// Objective-C ID
        /// </summary>
        ObjCId = 27,

        /// <summary>
        /// Objective-C Class
        /// </summary>
        ObjCClass = 28,

        /// <summary>
        /// Objective-C Selector
        /// </summary>
        ObjCSel = 29,

        /// <summary>
        /// Float 128bit
        /// </summary>
        Float128 = 30,

        /// <summary>
        /// Half
        /// </summary>
        Half = 31,

        /// <summary>
        /// Float 16bit
        /// </summary>
        Float16 = 32,

        /// <summary>
        /// Short Accumulation
        /// </summary>
        ShortAccum = 33,

        /// <summary>
        /// Accumulation
        /// </summary>
        Accum = 34,

        /// <summary>
        /// Long Accumulation
        /// </summary>
        LongAccum = 35,

        /// <summary>
        /// Unsigned Short Accumulation
        /// </summary>
        UShortAccum = 36,

        /// <summary>
        /// Unsigned Accumulation
        /// </summary>
        UAccum = 37,

        /// <summary>
        /// Unsigned Long Accumulation
        /// </summary>
        ULongAccum = 38,

        /// <summary>
        /// First Builtin
        /// </summary>
        FirstBuiltin = Void,

        /// <summary>
        /// Last Builtin
        /// </summary>
        LastBuiltin = ULongAccum,

        /// <summary>
        /// Complex
        /// </summary>
        Complex = 100,

        /// <summary>
        /// Pointer
        /// </summary>
        Pointer = 101,

        /// <summary>
        /// Block Pointer
        /// </summary>
        BlockPointer = 102,

        /// <summary>
        /// L Value Reference
        /// </summary>
        LValueReference = 103,

        /// <summary>
        /// R Value Reference
        /// </summary>
        RValueReference = 104,

        /// <summary>
        /// Record
        /// </summary>
        Record = 105,

        /// <summary>
        /// Enum
        /// </summary>
        Enum = 106,

        /// <summary>
        /// Typedef
        /// </summary>
        Typedef = 107,

        /// <summary>
        /// Objective-C Interface
        /// </summary>
        ObjCInterface = 108,

        /// <summary>
        /// Objective-C Object Pointer
        /// </summary>
        ObjCObjectPointer = 109,

        /// <summary>
        /// Function No Prototype
        /// </summary>
        FunctionNoProto = 110,

        /// <summary>
        /// Function Prototype
        /// </summary>
        FunctionProto = 111,

        /// <summary>
        /// Constant Array
        /// </summary>
        ConstantArray = 112,

        /// <summary>
        /// Vector
        /// </summary>
        Vector = 113,

        /// <summary>
        /// Incomplete Array
        /// </summary>
        IncompleteArray = 114,

        /// <summary>
        /// Variable Array
        /// </summary>
        VariableArray = 115,

        /// <summary>
        /// Dependent Sized Array
        /// </summary>
        DependentSizedArray = 116,

        /// <summary>
        /// Member Pointer
        /// </summary>
        MemberPointer = 117,

        /// <summary>
        /// Auto
        /// </summary>
        Auto = 118,

        /// <summary>
        /// Elaborated
        /// </summary>
        /// <remarks>
        /// Represents a type that was referred to using an elaborated type keyword.
        /// E.g., struct S, or via a qualified name, e.g., N::M::type, or both.
        /// </remarks>
        Elaborated = 119,

        /// <summary>
        /// Pipe
        /// </summary>
        Pipe = 120,

        /* OpenCL builtin types. */

        /// <summary>
        /// OpenCL Image 1D Read Only
        /// </summary>
        OCLImage1dRO = 121,

        /// <summary>
        /// OpenCL Image 1D Array Read Only
        /// </summary>
        OCLImage1dArrayRO = 122,

        /// <summary>
        /// OpendCL Image 1D Buffer Read Only
        /// </summary>
        OCLImage1dBufferRO = 123,

        /// <summary>
        /// OpenCL Image 2D Read Only
        /// </summary>
        OCLImage2dRO = 124,

        /// <summary>
        /// OpenCL Image 2D Array Read Only
        /// </summary>
        OCLImage2dArrayRO = 125,

        /// <summary>
        /// OpenCL Image 2D Depth Read Only
        /// </summary>
        OCLImage2dDepthRO = 126,

        /// <summary>
        /// OpenCL Image 2D Array Depth Read Only
        /// </summary>
        OCLImage2dArrayDepthRO = 127,

        /// <summary>
        /// OpenCL Image 2D MSAA Read Only
        /// </summary>
        OCLImage2dMSAARO = 128,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Read Only
        /// </summary>
        OCLImage2dArrayMSAARO = 129,

        /// <summary>
        /// OpenCL Image 2D MSAA Depth Read Only
        /// </summary>
        OCLImage2dMSAADepthRO = 130,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Depth Read Only
        /// </summary>
        OCLImage2dArrayMSAADepthRO = 131,

        /// <summary>
        /// OpenCL Image 3D Read Only
        /// </summary>
        OCLImage3dRO = 132,

        /// <summary>
        /// OpenCL Image 1D Write Only
        /// </summary>
        OCLImage1dWO = 133,

        /// <summary>
        /// OpenCL Image 1D Array Write Only
        /// </summary>
        OCLImage1dArrayWO = 134,

        /// <summary>
        /// OpenCL Image 1D Buffer Write Only
        /// </summary>
        OCLImage1dBufferWO = 135,

        /// <summary>
        /// OpenCL Image 2D Write Only
        /// </summary>
        OCLImage2dWO = 136,

        /// <summary>
        /// OpenCL Image 2D Array Write Only
        /// </summary>
        OCLImage2dArrayWO = 137,

        /// <summary>
        /// OpenCL Image 2D Depth Write Only
        /// </summary>
        OCLImage2dDepthWO = 138,

        /// <summary>
        /// OpenCL Image 2D Array Depth Write Only
        /// </summary>
        OCLImage2dArrayDepthWO = 139,

        /// <summary>
        /// OpenCL Image 2D MSAA Write Only
        /// </summary>
        OCLImage2dMSAAWO = 140,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Write Only
        /// </summary>
        OCLImage2dArrayMSAAWO = 141,

        /// <summary>
        /// OpenCL Imaeg 2D MSAA Depth Write Only
        /// </summary>
        OCLImage2dMSAADepthWO = 142,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Depth Write Only
        /// </summary>
        OCLImage2dArrayMSAADepthWO = 143,

        /// <summary>
        /// OpenCL Image 3D Write Only
        /// </summary>
        OCLImage3dWO = 144,

        /// <summary>
        /// OpenCL Image 1D Read / Write
        /// </summary>
        OCLImage1dRW = 145,

        /// <summary>
        /// OpenCL Image 1D Array Read / Write
        /// </summary>
        OCLImage1dArrayRW = 146,

        /// <summary>
        /// OpenCL Image 1D Buffer Read / Write
        /// </summary>
        OCLImage1dBufferRW = 147,

        /// <summary>
        /// OpenCL Image 2D Read / Write
        /// </summary>
        OCLImage2dRW = 148,

        /// <summary>
        /// OpenCL Image 2D Array Read / Write
        /// </summary>
        OCLImage2dArrayRW = 149,

        /// <summary>
        /// OpenCL Image 2D Depth Read / Write
        /// </summary>
        OCLImage2dDepthRW = 150,

        /// <summary>
        /// OpenCL Image 2D Array Depth Read / Write
        /// </summary>
        OCLImage2dArrayDepthRW = 151,

        /// <summary>
        /// OpenCL Image 2D MSAA Read / Write
        /// </summary>
        OCLImage2dMSAARW = 152,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Read / Write
        /// </summary>
        OCLImage2dArrayMSAARW = 153,

        /// <summary>
        /// OpenCL Image 2D MSAA Depth Read / Write
        /// </summary>
        OCLImage2dMSAADepthRW = 154,

        /// <summary>
        /// OpenCL Image 2D Array MSAA Depth Read / Write
        /// </summary>
        OCLImage2dArrayMSAADepthRW = 155,

        /// <summary>
        /// OpenCL Image 3D Read / Write
        /// </summary>
        OCLImage3dRW = 156,

        /// <summary>
        /// OpenCL Sampler
        /// </summary>
        OCLSampler = 157,

        /// <summary>
        /// OpenCL Event
        /// </summary>
        OCLEvent = 158,

        /// <summary>
        /// OpenCL Queue
        /// </summary>
        OCLQueue = 159,

        /// <summary>
        /// OpenCl Reserve ID
        /// </summary>
        OCLReserveID = 160,

        /// <summary>
        /// Objective-C Object
        /// </summary>
        ObjCObject = 161,

        /// <summary>
        /// Objective-C Type Parameter
        /// </summary>
        ObjCTypeParam = 162,

        /// <summary>
        /// Attributed
        /// </summary>
        Attributed = 163,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Mce Payload
        /// </summary>
        OCLIntelSubgroupAVCMcePayload = 164,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Payload
        /// </summary>
        OCLIntelSubgroupAVCImePayload = 165,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ref Payload
        /// </summary>
        OCLIntelSubgroupAVCRefPayload = 166,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Sic Payload
        /// </summary>
        OCLIntelSubgroupAVCSicPayload = 167,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Mce Result
        /// </summary>
        OCLIntelSubgroupAVCMceResult = 168,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Result
        /// </summary>
        OCLIntelSubgroupAVCImeResult = 169,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ref Result
        /// </summary>
        OCLIntelSubgroupAVCRefResult = 170,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Sic Result
        /// </summary>
        OCLIntelSubgroupAVCSicResult = 171,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Result Single Ref Streamout
        /// </summary>
        OCLIntelSubgroupAVCImeResultSingleRefStreamout = 172,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Result Dual Ref Streamout
        /// </summary>
        OCLIntelSubgroupAVCImeResultDualRefStreamout = 173,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Single Ref Streamin
        /// </summary>
        OCLIntelSubgroupAVCImeSingleRefStreamin = 174,

        /// <summary>
        /// OpenCL Intel Subgroup AVC Ime Dual Ref Streamin
        /// </summary>
        OCLIntelSubgroupAVCImeDualRefStreamin = 175,

        /// <summary>
        /// Extended Vector
        /// </summary>
        ExtVector = 176,
    }

    /// <summary>
    /// Type Kind Extensions
    /// </summary>
    public static class TypeKindEx
    {
        /// <summary>
        /// Convert To Type Kind Spelling
        /// </summary>
        /// <param name="kind">Type Kind</param>
        /// <returns>Type Kind Spelling</returns>
        public static string ToSpelling(this TypeKind kind)
        {
            return LibClang.clang_getTypeKindSpelling(kind).ToManaged();
        }
    }
}
