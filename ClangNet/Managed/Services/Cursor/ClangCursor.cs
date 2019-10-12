using ClangNet.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Cursor
    /// </summary>
    public class ClangCursor : ClangValueObject<ClangCursor>
    {
        /// <summary>
        /// Native Clang Cursor
        /// </summary>
        internal CXCursor Source { get; }

        /// <summary>
        /// Null Cursor Flag
        /// </summary>
        public bool IsNull
        {
            get { return LibClang.clang_Cursor_isNull(this.Source).ToBool(); }
        }

        /// <summary>
        /// Cursor Kind
        /// </summary>
        public CursorKind Kind
        {
            get { return LibClang.clang_getCursorKind(this.Source); }
        }

        /// <summary>
        /// Invalid Declaration Flag
        /// </summary>
        public bool IsInvalidDeclaration
        {
            get { return LibClang.clang_isInvalidDeclaration(this.Source).ToBool(); }
        }

        /// <summary>
        /// Attributes Exists Flag
        /// </summary>
        public bool HasAttributes
        {
            get { return LibClang.clang_Cursor_hasAttrs(this.Source).ToBool(); }
        }

        /// <summary>
        /// Linkage
        /// </summary>
        public LinkageKind Linkage
        {
            get { return LibClang.clang_getCursorLinkage(this.Source); }
        }

        /// <summary>
        /// Visibility
        /// </summary>
        public VisibilityKind Visibility
        {
            get { return LibClang.clang_getCursorVisibility(this.Source); }
        }

        /// <summary>
        /// Availability
        /// </summary>
        public AvailabilityKind Availability
        {
            get { return LibClang.clang_getCursorAvailability(this.Source); }
        }

        /// <summary>
        /// Language
        /// </summary>
        public LanguageKind Language
        {
            get { return LibClang.clang_getCursorLanguage(this.Source); }
        }

        /// <summary>
        /// TLS(Thread Local Storage) Kind
        /// </summary>
        public TLSKind TLS
        {
            get { return LibClang.clang_getCursorTLSKind(this.Source); }
        }

        /// <summary>
        /// Clang Translation Unit
        /// </summary>
        public ClangTranslationUnit TranslationUnit
        {
            get { return LibClang.clang_Cursor_getTranslationUnit(this.Source).ToManaged<ClangTranslationUnit>(); }
        }

        /// <summary>
        /// Semantic Parent Clang Cursor
        /// </summary>
        public ClangCursor SemanticParent
        {
            get { return LibClang.clang_getCursorSemanticParent(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Lexical Parent Clang Cursor
        /// </summary>
        public ClangCursor LexicalParent
        {
            get { return LibClang.clang_getCursorLexicalParent(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Overriden Clang Cursors
        /// </summary>
        public ClangCursor[] OverridenCursors
        {
            get
            {
                LibClang.clang_getOverriddenCursors(this.Source, out var overriden, out var num_overriden);

                var overriden_cursors = overriden.ToNativeStructs<CXCursor>((int)num_overriden).Select(c => c.ToManaged()).ToArray();

                LibClang.clang_disposeOverriddenCursors(overriden);

                return overriden_cursors;
            }
        }

        /// <summary>
        /// Included File
        /// </summary>
        public ClangFile IncludedFile
        {
            get { return LibClang.clang_getIncludedFile(this.Source).ToManaged<ClangFile>(); }
        }

        /// <summary>
        /// Clang Source Location
        /// </summary>
        public ClangSourceLocation Location
        {
            get { return LibClang.clang_getCursorLocation(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Source Range
        /// </summary>
        public ClangSourceRange Extent
        {
            get { return LibClang.clang_getCursorExtent(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Type
        /// </summary>
        public ClangType Type
        {
            get { return LibClang.clang_getCursorType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Typedef Declaration Underlying Clang Type
        /// </summary>
        public ClangType TypedefDeclUnderlyingType
        {
            get { return LibClang.clang_getTypedefDeclUnderlyingType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Enum Declaration Integer Clang Type
        /// </summary>
        public ClangType EnumDeclIntegerType
        {
            get { return LibClang.clang_getEnumDeclIntegerType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Enum Constant Declaration Signed Value
        /// </summary>
        public long EnumConstantDeclValue
        {
            get { return LibClang.clang_getEnumConstantDeclValue(this.Source); }
        }

        /// <summary>
        /// Enum Constant Declaration Unsigned Value
        /// </summary>
        public ulong EnumConstantDeclUnsignedValue
        {
            get { return LibClang.clang_getEnumConstantDeclUnsignedValue(this.Source); }
        }

        /// <summary>
        /// Field Declaration Bit Width
        /// </summary>
        public int FieldDeclBitWidth
        {
            get { return LibClang.clang_getFieldDeclBitWidth(this.Source); }
        }

        /// <summary>
        /// Function or Method Argument Count
        /// </summary>
        public int ArgumentCount
        {
            get { return LibClang.clang_Cursor_getNumArguments(this.Source); }
        }

        /// <summary>
        /// Template Argument Count
        /// </summary>
        public int TemplateArgumentCount
        {
            get { return LibClang.clang_Cursor_getNumTemplateArguments(this.Source); }
        }

        /// <summary>
        /// Function Like Macro Flag
        /// </summary>
        public bool IsMacroFunctionLike
        {
            get { return LibClang.clang_Cursor_isMacroFunctionLike(this.Source).ToBool(); }
        }

        /// <summary>
        /// Builtin Macro Flag
        /// </summary>
        public bool IsMacroBuiltin
        {
            get { return LibClang.clang_Cursor_isMacroBuiltin(this.Source).ToBool(); }
        }

        /// <summary>
        /// Inlined Function Flag
        /// </summary>
        public bool IsFunctionInlined
        {
            get { return LibClang.clang_Cursor_isFunctionInlined(this.Source).ToBool(); }
        }

        /// <summary>
        /// Objective-C Type Declaration Encoding
        /// </summary>
        public string DeclObjCTypeEncoding
        {
            get { return LibClang.clang_getDeclObjCTypeEncoding(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Function Return Clang Type
        /// </summary>
        public ClangType ResultType
        {
            get { return LibClang.clang_getCursorResultType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Exception Specification Type
        /// </summary>
        public int ExceptionSpecificationType
        {
            get { return LibClang.clang_getCursorExceptionSpecificationType(this.Source); }
        }

        /// <summary>
        /// Offset of Field
        /// </summary>
        public long OffsetOfField
        {
            get { return LibClang.clang_Cursor_getOffsetOfField(this.Source); }
        }

        /// <summary>
        /// Anonymous Tag or Namespace
        /// </summary>
        public bool IsAnonymous
        {
            get { return LibClang.clang_Cursor_isAnonymous(this.Source).ToBool(); }
        }

        /// <summary>
        /// Anonymous Record Flag
        /// </summary>
        public bool IsAnonymousRecordDecl
        {
            get { return LibClang.clang_Cursor_isAnonymousRecordDecl(this.Source).ToBool(); }
        }

        /// <summary>
        /// Inline Namespace Flag
        /// </summary>
        public bool IsInlineNamespace
        {
            get { return LibClang.clang_Cursor_isInlineNamespace(this.Source).ToBool(); }
        }

        /// <summary>
        /// Bit Field Flag
        /// </summary>
        public bool IsBitField
        {
            get { return LibClang.clang_Cursor_isBitField(this.Source).ToBool(); }
        }

        /// <summary>
        /// Virtual Base Flag
        /// </summary>
        public bool IsVirtualBase
        {
            get { return LibClang.clang_isVirtualBase(this.Source).ToBool(); }
        }

        /// <summary>
        /// C++ Access Specifier
        /// </summary>
        public CxxAccessSpecifier CxxAccessSpecifier
        {
            get { return LibClang.clang_getCXXAccessSpecifier(this.Source); }
        }

        /// <summary>
        /// Storage Class
        /// </summary>
        public StorageClass StorageClass
        {
            get { return LibClang.clang_Cursor_getStorageClass(this.Source); }
        }

        /// <summary>
        /// Overloaded Declaration Count
        /// </summary>
        public int OverloadedDeclCount
        {
            get { return (int)LibClang.clang_getNumOverloadedDecls(this.Source); }
        }

        /// <summary>
        /// IBOutlet Collection Clang Type
        /// </summary>
        public ClangType IBOutletCollectionType
        {
            get { return LibClang.clang_getIBOutletCollectionType(this.Source).ToManaged(); }
        }

        /// <summary>
        /// USR(Unified Symbol Resolution)
        /// </summary>
        public string USR
        {
            get { return LibClang.clang_getCursorUSR(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Spelling
        /// </summary>
        public string Spelling
        {
            get { return LibClang.clang_getCursorSpelling(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Printing Policy
        /// </summary>
        public ClangPrintingPolicy PrintingPolicy
        {
            get { return LibClang.clang_getCursorPrintingPolicy(this.Source).ToManaged<ClangPrintingPolicy>(); }
        }

        /// <summary>
        /// Display Name
        /// </summary>
        public string DisplayName
        {
            get { return LibClang.clang_getCursorDisplayName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Referenced Clang Cursor
        /// </summary>
        public ClangCursor Referenced
        {
            get { return LibClang.clang_getCursorReferenced(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Definition Clang Cursor
        /// </summary>
        public ClangCursor Definition
        {
            get { return LibClang.clang_getCursorDefinition(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Definition Flag
        /// </summary>
        public bool IsDefinition
        {
            get { return LibClang.clang_isCursorDefinition(this.Source).ToBool(); }
        }

        /// <summary>
        /// Canonical Clang Cursor
        /// </summary>
        public ClangCursor CanonicalCursor
        {
            get { return LibClang.clang_getCanonicalCursor(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Selector Index
        /// </summary>
        public int ObjCSelectorIndex
        {
            get { return LibClang.clang_Cursor_getObjCSelectorIndex(this.Source); }
        }

        /// <summary>
        /// Dynamic Call Flag
        /// </summary>
        public bool IsDynamicCall
        {
            get { return LibClang.clang_Cursor_isDynamicCall(this.Source).ToBool(); }
        }

        /// <summary>
        /// Receiver Clang Type
        /// </summary>
        public ClangType ReceiverType
        {
            get
            {
                var kind = this.Source.Kind;

                if(kind == CursorKind.ObjCMessageExpression
                    || kind == CursorKind.MemberReferenceExpression
                    || kind == CursorKind.CallExpression)
                {
                    return LibClang.clang_Cursor_getReceiverType(this.Source).ToManaged();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Objective-C Property Attributes
        /// </summary>
        public ObjCPropertyAttrKind ObjCPropertyAttributes
        {
            get { return LibClang.clang_Cursor_getObjCPropertyAttributes(this.Source, 0); }
        }

        /// <summary>
        /// Objective-C Property Getter Name
        /// </summary>
        public string ObjCPropertyGetterName
        {
            get { return LibClang.clang_Cursor_getObjCPropertyGetterName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Property Setter Name
        /// </summary>
        public string ObjCPropertySetterName
        {
            get { return LibClang.clang_Cursor_getObjCPropertySetterName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Declaration Qualifiers
        /// </summary>
        public ObjCDeclQualifierKind ObjCDeclQualifiers
        {
            get { return LibClang.clang_Cursor_getObjCDeclQualifiers(this.Source); }
        }

        /// <summary>
        /// Objective-C Optional Flag
        /// </summary>
        public bool IsObjCOptional
        {
            get { return LibClang.clang_Cursor_isObjCOptional(this.Source).ToBool(); }
        }

        /// <summary>
        /// Variadic Function or Method Flag
        /// </summary>
        public bool IsVariadic
        {
            get { return LibClang.clang_Cursor_isVariadic(this.Source).ToBool(); }
        }

        /// <summary>
        /// Comment Clang Source Range
        /// </summary>
        public ClangSourceRange CommentRange
        {
            get { return LibClang.clang_Cursor_getCommentRange(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Raw Comment Text
        /// </summary>
        public string RawCommentText
        {
            get { return LibClang.clang_Cursor_getRawCommentText(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Brief Comment Text
        /// </summary>
        public string BriefComment
        {
            get { return LibClang.clang_Cursor_getBriefCommentText(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Mangling
        /// </summary>
        public string Mangling
        {
            get { return LibClang.clang_Cursor_getMangling(this.Source).ToManaged(); }
        }

        /// <summary>
        /// C++ Manglings
        /// </summary>
        public string[] CXXManglings
        {
            get { return LibClang.clang_Cursor_getCxxManglings(this.Source).ToManagedStringSet(); }
        }

        /// <summary>
        /// Objective-C Manglings
        /// </summary>
        public string[] ObjCManglings
        {
            get { return LibClang.clang_Cursor_getObjCManglings(this.Source).ToManagedStringSet(); }
        }

        /// <summary>
        /// Clang Module
        /// </summary>
        public ClangModule Module
        {
            get { return LibClang.clang_Cursor_getModule(this.Source).ToManaged<ClangModule>(); }
        }

        /// <summary>
        /// Converting Constructor Flag
        /// </summary>
        public bool IsConvertingConstructor
        {
            get { return LibClang.clang_CXXConstructor_isConvertingConstructor(this.Source).ToBool(); }
        }

        /// <summary>
        /// Copy Constructor Flag
        /// </summary>
        public bool IsCopyConstructor
        {
            get { return LibClang.clang_CXXConstructor_isCopyConstructor(this.Source).ToBool(); }
        }

        /// <summary>
        /// Default Constructor Flag
        /// </summary>
        public bool IsDefaultConstructor
        {
            get { return LibClang.clang_CXXConstructor_isDefaultConstructor(this.Source).ToBool(); }
        }

        /// <summary>
        /// Move Constructor Flag
        /// </summary>
        public bool IsMoveConstructor
        {
            get { return LibClang.clang_CXXConstructor_isMoveConstructor(this.Source).ToBool(); }
        }

        /// <summary>
        /// Mutable Field Flag
        /// </summary>
        public bool IsMutableField
        {
            get { return LibClang.clang_CXXField_isMutable(this.Source).ToBool(); }
        }

        /// <summary>
        /// Defaulted Method Flag
        /// </summary>
        public bool IsDefaultedMethod
        {
            get { return LibClang.clang_CXXMethod_isDefaulted(this.Source).ToBool(); }
        }

        /// <summary>
        /// Pure Virtual Method Flag
        /// </summary>
        public bool IsPureVirtualMethod
        {
            get { return LibClang.clang_CXXMethod_isPureVirtual(this.Source).ToBool(); }
        }

        /// <summary>
        /// Static Method Flag
        /// </summary>
        public bool IsStaticMethod
        {
            get { return LibClang.clang_CXXMethod_isStatic(this.Source).ToBool(); }
        }

        /// <summary>
        /// Virtual Method Flag
        /// </summary>
        public bool IsVirtualMethod
        {
            get { return LibClang.clang_CXXMethod_isVirtual(this.Source).ToBool(); }
        }

        /// <summary>
        /// Abstract Record Flag
        /// </summary>
        public bool IsAbstractRecord
        {
            get { return LibClang.clang_CXXRecord_isAbstract(this.Source).ToBool(); }
        }

        /// <summary>
        /// Scoped Enum Flag
        /// </summary>
        public bool IsScopedEnum
        {
            get { return LibClang.clang_EnumDecl_isScoped(this.Source).ToBool(); }
        }

        /// <summary>
        /// Const Method Flag
        /// </summary>
        public bool IsConstMethod
        {
            get { return LibClang.clang_CXXMethod_isConst(this.Source).ToBool(); }
        }

        /// <summary>
        /// Template Cursor Kind
        /// </summary>
        public CursorKind TemplateCursorKind
        {
            get { return LibClang.clang_getTemplateCursorKind(this.Source); }
        }

        /// <summary>
        /// Specialized Cursor Template Clang Cursor
        /// </summary>
        public ClangCursor SpecializedCursorTemplate
        {
            get { return LibClang.clang_getSpecializedCursorTemplate(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Completion String
        /// </summary>
        public ClangCompletionString CompletionString
        {
            get { return LibClang.clang_getCursorCompletionString(this.Source).ToManaged<ClangCompletionString>(); }
        }

        /// <summary>
        /// Clang Evaluation Result
        /// </summary>
        public ClangEvaluationResult Evalulate
        {
            get { return LibClang.clang_Cursor_Evaluate(this.Source).ToManaged<ClangEvaluationResult>(); }
        }

        /// <summary>
        /// Parsed Clang Comment
        /// </summary>
        public ClangComment ParsedComment
        {
            get { return LibClang.clang_Cursor_getParsedComment(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Cursor</param>
        internal ClangCursor(CXCursor source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Get Platform Availability
        /// </summary>
        /// <param name="is_always_deprecated">Always Deprecated Flag</param>
        /// <param name="deprecated_message">Deprecated Message</param>
        /// <param name="is_always_unavaiable">Always Unavailable Flag</param>
        /// <param name="unavailable_message">Unavailable Message</param>
        /// <returns>Clang Platform Availabilities</returns>
        public ClangPlatformAvailability[] GetPlatformAvailability(out bool is_always_deprecated, out string deprecated_message,
                                                                   out bool is_always_unavaiable, out string unavailable_message)
        {
            var av_dummy = IntPtr.Zero;
            var n = LibClang.clang_getCursorPlatformAvailability(this.Source, out var ad_dummy, out var dm_dummy, out var au_dummy, out var um_dummy, ref av_dummy, 0);

            var size = Marshal.SizeOf(typeof(CXPlatformAvailability));

            var av_ptr = Marshal.AllocHGlobal(size * n);

            LibClang.clang_getCursorPlatformAvailability(this.Source, out var ad, out var dm, out var au, out var um, ref av_ptr, n);

            is_always_deprecated = ad.ToBool();
            deprecated_message = dm.ToManaged();
            is_always_unavaiable = au.ToBool();
            unavailable_message = um.ToManaged();

            return av_ptr.ToManagedObjects<CXPlatformAvailability, ClangPlatformAvailability>(n).ToArray();
        }

        /// <summary>
        /// Get Argument Clang Cursor
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Argument Clang Cursor</returns>
        public ClangCursor GetArgument(int i)
        {
            return LibClang.clang_Cursor_getArgument(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Template Argument Kind
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Template Argument Kind</returns>
        public TemplateArgumentKind GetTemplateArgumentKind(int i)
        {
            return LibClang.clang_Cursor_getTemplateArgumentKind(this.Source, (uint)i);
        }

        /// <summary>
        /// Get Template Argument Clang Type
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Template Argument Clang Type</returns>
        public ClangType GetTemplateArgumentType(int i)
        {
            return LibClang.clang_Cursor_getTemplateArgumentType(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Template Argument Signed Value
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Template Argument Signed Value</returns>
        public long GetTemplateArgumentValue(int i)
        {
            return LibClang.clang_Cursor_getTemplateArgumentValue(this.Source, (uint)i);
        }

        /// <summary>
        /// Get Template Argument Unsigned Value
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Template Argument Unsigned Value</returns>
        public ulong GetTemplateArgumentUnsignedValue(int i)
        {
            return LibClang.clang_Cursor_getTemplateArgumentUnsignedValue(this.Source, (uint)i);
        }

        /// <summary>
        /// Get Overloaded Declaration Clang Cursor
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Overloaded Declaration Clang Cursor</returns>
        public ClangCursor GetOverloadedDecl(int i)
        {
            return LibClang.clang_getOverloadedDecl(this.Source, (uint)i).ToManaged(); ;
        }

        /// <summary>
        /// Visit Children
        /// </summary>
        /// <typeparam name="T">Client Data Type</typeparam>
        /// <param name="visitor">Visitor</param>
        /// <param name="client_data">Client Data</param>
        /// <returns>Child Cursor Visit Result</returns>
        public ChildVisitResult VisitChildren<T> (Func<ClangCursor, ClangCursor, T, ChildVisitResult> visitor, T client_data)
        {
            ClangServiceException service_exception = null;
            var ret = LibClang.clang_visitChildren(this.Source,
                (cursor, parent, z) =>
                {
                    try
                    {
                        return visitor(new ClangCursor(cursor), new ClangCursor(parent), client_data);
                    }
                    catch(Exception ex)
                    {
                        service_exception = new ClangServiceException($"Visit Cursor Children Failed : {ex.Message}", ex);

                        return ChildVisitResult.Break;
                    }
                },
                IntPtr.Zero);
            if(service_exception != null)
            {
                throw service_exception;
            }
            return ret;
        }

        /// <summary>
        /// Get Spelling Name Clang Source Range
        /// </summary>
        /// <param name="piece_index">Piece Index</param>
        /// <returns>Spelling Name Clang Source Range</returns>
        public ClangSourceRange GetSpellingNameRange(uint piece_index)
        {
            return LibClang.clang_Cursor_getSpellingNameRange(this.Source, piece_index, 0).ToManaged();
        }

        /// <summary>
        /// Get Pretty Printed String
        /// </summary>
        /// <param name="policy">Clang Printing Policy</param>
        /// <returns>Pretty Printed String</returns>
        public string GetPrettyPrinted(ClangPrintingPolicy policy)
        {
            return LibClang.clang_getCursorPrettyPrinted(this.Source, policy.Handle).ToManaged();
        }

        /// <summary>
        /// Check Cursor is External Symbol
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="defined_in">Defined In</param>
        /// <param name="is_generated">Generated Flag</param>
        /// <returns>External Symbol Flag</returns>
        public bool IsExternalSymbol(out string language, out string defined_in, out bool is_generated)
        {
            var ret = LibClang.clang_Cursor_isExternalSymbol(this.Source, out var language_n, out var defined_in_n, out var is_generated_n);

            language = language_n.ToManaged();

            defined_in = defined_in_n.ToManaged();

            is_generated = is_generated_n.ToBool();

            return ret.ToBool();
        }

        /// <summary>
        /// Cursor Reference Name Clang Source Range
        /// </summary>
        /// <param name="name_flags">Name Reference Flags</param>
        /// <param name="piece_index">Piece Index</param>
        /// <returns>Reference Name Clang Source Range</returns>
        public ClangSourceRange GetCursorReferenceNameRange(NameRefFlags name_flags, int piece_index)
        {
            return LibClang.clang_getCursorReferenceNameRange(this.Source, name_flags, (uint)piece_index).ToManaged();
        }

        /// <summary>
        /// Get Definition Spelling And Extent
        /// </summary>
        /// <param name="spelling">Definition Spelling</param>
        /// <param name="start_line">Start Line</param>
        /// <param name="start_col">Start Column</param>
        /// <param name="end_line">End Line</param>
        /// <param name="end_col">End Column</param>
        public void GetDefinitionSpellingAndExtent(out string spelling, out int start_line, out int start_col, out int end_line, out int end_col)
        {
            LibClang.clang_getDefinitionSpellingAndExtent(this.Source, out var start_buf, out var end_buf, out var sl, out var sc, out var el, out var ec);

            var size = end_buf.ToInt64() - start_buf.ToInt64();

            spelling = start_buf.ToManagedString((int)size);
            start_line = (int)sl;
            start_col = (int)sc;
            end_line = (int)el;
            end_col = (int)ec;
        }

        /// <summary>
        /// Find Referenced In File
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <param name="visitor">Cursor And Range Visitor Function</param>
        /// <returns>Find Result</returns>
        public FindResult FindReferenceInFile(ClangFile file, Func<object, ClangCursor, ClangSourceRange, VisitorResult> visitor)
        {
            return LibClang.clang_findReferencesInFile(this.Source, file.Handle, this.CreateCursorAndRangeVisitor(visitor));
        }

        /// <summary>
        /// Create Native Cursor And Range Visitor
        /// </summary>
        /// <param name="visitor">Cursor And Range Visitor Function</param>
        /// <returns>Native Cursor And Range Visitor</returns>
        private CXCursorAndRangeVisitor CreateCursorAndRangeVisitor(Func<object, ClangCursor, ClangSourceRange, VisitorResult> visitor)
        {
            var v = new CXCursorAndRangeVisitor((native_ctx, native_cursor, native_range) =>
            {
                var cursor = native_cursor.ToManaged();
                var range = native_range.ToManaged();
                return visitor(native_ctx, cursor, range);
            });

            return v;
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Clang Cursor</param>
        /// <returns>Check Result</returns>
        protected override bool EqualsCore(ClangCursor other)
        {
            return LibClang.clang_equalCursors(this.Source, other.Source).ToBool();
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        protected override int GetHashCodeCore()
        {
            return (int)LibClang.clang_hashCursor(this.Source);
        }
    }
}
