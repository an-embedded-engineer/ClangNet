using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Type
    /// </summary>
    public class ClangType : ClangValueObject<ClangType>
    {
        /// <summary>
        /// Native Clang Type
        /// </summary>
        internal CXType Source { get; }

        /// <summary>
        /// Type Spelling
        /// </summary>
        public string Spelling
        {
            get { return LibClang.clang_getTypeSpelling(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Canonical Clang Type
        /// </summary>
        public ClangType CanonicalType
        {
            get { return LibClang.clang_getCanonicalType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Const Qualified Flag
        /// </summary>
        public bool IsConstQualified
        {
            get { return LibClang.clang_isConstQualifiedType(this.Source).ToBool(); }
        }

        /// <summary>
        /// Volatile Qualified Flag
        /// </summary>
        public bool IsVolatileQualified
        {
            get { return LibClang.clang_isVolatileQualifiedType(this.Source).ToBool(); }
        }

        /// <summary>
        /// Restrict Qualified Flag
        /// </summary>
        public bool IsRestrictQualified
        {
            get { return LibClang.clang_isRestrictQualifiedType(this.Source).ToBool(); }
        }

        /// <summary>
        /// Address Space
        /// </summary>
        public uint AddressSpace
        {
            get { return LibClang.clang_getAddressSpace(this.Source); }
        }

        /// <summary>
        /// Typedef Name
        /// </summary>
        public string TypedefName
        {
            get { return LibClang.clang_getTypedefName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Pointee Clang Type
        /// </summary>
        public ClangType PointeeType
        {
            get { return LibClang.clang_getPointeeType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Typedef Declaration Clang Cursor
        /// </summary>
        public ClangCursor TypeDeclaration
        {
            get { return LibClang.clang_getTypeDeclaration(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Type Encoding
        /// </summary>
        public string ObjeCEncoding
        {
            get { return LibClang.clang_Type_getObjCEncoding(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Function Type Calling Convention
        /// </summary>
        public CallingConvention FunctionTypeCallingConvention
        {
            get { return LibClang.clang_getFunctionTypeCallingConv(this.Source); }
        }

        /// <summary>
        /// Function or Method Return Clang Type
        /// </summary>
        public ClangType ResultType
        {
            get { return LibClang.clang_getResultType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Exception Specification Type
        /// </summary>
        public int ExceptionSpecificationType
        {
            get { return LibClang.clang_getExceptionSpecificationType(this.Source); }
        }

        /// <summary>
        /// Argument Type Count
        /// </summary>
        public int ArgumentTypeCount
        {
            get { return LibClang.clang_getNumArgTypes(this.Source); }
        }

        /// <summary>
        /// Objective-C Base Clang Type
        /// </summary>
        public ClangType ObjCObjectBaseType
        {
            get { return LibClang.clang_Type_getObjCObjectBaseType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Protocol Reference Count
        /// </summary>
        public int ObjCProtocolRefCount
        {
            get { return (int)LibClang.clang_Type_getNumObjCProtocolRefs(this.Source); }
        }

        /// <summary>
        /// Objective-C Type Argument Count
        /// </summary>
        public int ObjCTypeArgumentCount
        {
            get { return (int)LibClang.clang_Type_getNumObjCTypeArgs(this.Source); }
        }

        /// <summary>
        /// Variadic Function Type Flag
        /// </summary>
        public bool IsFunctionTypeVariadic
        {
            get { return LibClang.clang_isFunctionTypeVariadic(this.Source).ToBool(); }
        }

        /// <summary>
        /// POD(Plain Old Data) Type Flag
        /// </summary>
        public bool IsPOD
        {
            get { return LibClang.clang_isPODType(this.Source).ToBool(); }
        }

        /// <summary>
        /// Element Clang Type
        /// </summary>
        public ClangType ElementType
        {
            get { return LibClang.clang_getElementType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Element Count
        /// </summary>
        public long ElementCount
        {
            get { return LibClang.clang_getNumElements(this.Source); }
        }

        /// <summary>
        /// Array Element Clang Type
        /// </summary>
        public ClangType ArrayElementType
        {
            get { return LibClang.clang_getArrayElementType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Array Size
        /// </summary>
        public long ArraySize
        {
            get { return LibClang.clang_getArraySize(this.Source); }
        }

        /// <summary>
        /// Named Clang Type
        /// </summary>
        public ClangType NamedType
        {
            get { return LibClang.clang_Type_getNamedType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Transparent Tag Typedef Flag
        /// </summary>
        public bool IsTransparentTagTypedef
        {
            get { return LibClang.clang_Type_isTransparentTagTypedef(this.Source).ToBool(); }
        }

        /// <summary>
        /// Type Nullability Kind
        /// </summary>
        public TypeNullabilityKind Nullability
        {
            get { return LibClang.clang_Type_getNullability(this.Source); }
        }

        /// <summary>
        /// Alignment of Type
        /// </summary>
        public long AlignOf
        {
            get { return LibClang.clang_Type_getAlignOf(this.Source); }
        }

        /// <summary>
        /// Class Clang Type
        /// </summary>
        public ClangType ClassType
        {
            get { return LibClang.clang_Type_getClassType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Size of Type
        /// </summary>
        public long SizeOf
        {
            get { return LibClang.clang_Type_getSizeOf(this.Source); }
        }

        /// <summary>
        /// Modified Clang Type
        /// </summary>
        public ClangType ModifiedType
        {
            get { return LibClang.clang_Type_getModifiedType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Template Argument Count
        /// </summary>
        public int TemplateArgumentCount
        {
            get { return LibClang.clang_Type_getNumTemplateArguments(this.Source); }
        }

        /// <summary>
        /// C++ Reference Qualifier Kind
        /// </summary>
        public RefQualifierKind CxxRefQualifier
        {
            get { return LibClang.clang_Type_getCXXRefQualifier(this.Source); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Type</param>
        internal ClangType(CXType source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Get Argument Clang Type
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Argument Clang Type</returns>
        public ClangType GetArgumentType(int i)
        {
            return LibClang.clang_getArgType(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Objective-C Protocol Declaration Clang Cursor
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Objective-C Protocol Declaration Clang Cursor</returns>
        public ClangCursor GetObjCProtocolDecl(int i)
        {
            return LibClang.clang_Type_getObjCProtocolDecl(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Objective-C Argument Clang Type
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Objective-C Argument Clang Type</returns>
        public ClangType GetObjCTypeArgument(int i)
        {
            return LibClang.clang_Type_getObjCTypeArg(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Offset of Field
        /// </summary>
        /// <param name="field_name">Field Name</param>
        /// <returns>Offset</returns>
        public long GetOffsetOf(string field_name)
        {
            return LibClang.clang_Type_getOffsetOf(this.Source, field_name);
        }

        /// <summary>
        /// Get Template Argument Clang Type
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Template Argument Clang Type</returns>
        public ClangType GetTemplateArgumentAsType(int i)
        {
            return LibClang.clang_Type_getTemplateArgumentAsType(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Visit Fields
        /// </summary>
        /// <param name="visitor">Managed Clang Field Visitor Function</param>
        /// <param name="client_data">Native Client Data Pointer</param>
        /// <returns>Visit Result</returns>
        public bool VisitFields(Func<ClangCursor, IntPtr, VisitorResult> visitor, IntPtr client_data)
        {
            var native_visitor = this.CreateNativeFieldVisitor(visitor);

            var ret = LibClang.clang_Type_visitFields(this.Source, native_visitor, client_data).ToBool();

            return ret;
        }

        /// <summary>
        /// Create Native Clang Field Visitor
        /// </summary>
        /// <param name="visitor">Managed Clang Field Visitor Function</param>
        /// <returns>Native Clang Field Visitor</returns>
        private CXFieldVisitor CreateNativeFieldVisitor(Func<ClangCursor, IntPtr, VisitorResult> visitor)
        {
            CXFieldVisitor v = (native_cursor, client_data) =>
            {
                var cursor = native_cursor.ToManaged();
                return visitor(cursor, client_data);
            };

            return v;
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Clang Type</param>
        /// <returns>Check Result</returns>
        protected override bool EqualsCore(ClangType other)
        {
            return LibClang.clang_equalTypes(this.Source, other.Source).ToBool();
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        protected override int GetHashCodeCore()
        {
            return this.Source.GetHashCode();
        }
    }
}
