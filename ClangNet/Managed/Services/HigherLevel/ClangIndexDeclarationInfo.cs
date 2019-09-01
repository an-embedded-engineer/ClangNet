using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Declaration Info
    /// </summary>
    public class ClangIndexDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Declaration Info
        /// </summary>
        internal CXIdxDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo Entity
        {
            get { return new ClangIndexEntityInfo(this.Info.EntityInfo); }
        }

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public ClangCursor Cursor
        {
            get { return this.Info.Cursor.ToManaged(); }
        }

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public ClangIndexLocation Location
        {
            get { return this.Info.Loc.ToManaged(); }
        }

        /// <summary>
        /// Semantic Clang Index Container Info
        /// </summary>
        public ClangIndexContainerInfo SemanticContainer
        {
            get { return new ClangIndexContainerInfo(this.Info.SemanticContainer); }
        }

        /// <summary>
        /// Lexical Clang Index Container Info
        /// </summary>
        public ClangIndexContainerInfo LexicalContainer
        {
            get { return new ClangIndexContainerInfo(this.Info.LexicalContainer); }
        }

        /// <summary>
        /// Redeclaration Flag
        /// </summary>
        public bool IsRedeclaration
        {
            get { return this.Info.IsRedeclaration.ToBool(); }
        }

        /// <summary>
        /// Definition Flag
        /// </summary>
        public bool IsDefinition
        {
            get { return this.Info.IsDefinition.ToBool(); }
        }

        /// <summary>
        /// Container Flag
        /// </summary>
        public bool IsContainer
        {
            get { return this.Info.IsContainer.ToBool(); }
        }

        /// <summary>
        /// Declaration Clang Index Container Info
        /// </summary>
        public ClangIndexContainerInfo DeclarationAsContainer
        {
            get { return new ClangIndexContainerInfo(this.Info.DeclAsContainer); }
        }

        /// <summary>
        /// Implicit Flag
        /// </summary>
        public bool IsImplicit
        {
            get { return this.Info.IsImplicit.ToBool(); }
        }

        /// <summary>
        /// Attribute Count
        /// </summary>
        public int AttributeCount
        {
            get { return (int)this.Info.NumAttributes; }
        }

        /// <summary>
        /// Clang Index Attribute Info List
        /// </summary>
        public IEnumerable<ClangIndexAttributeInfo> Attributes
        {
            get { return this.Info.Attributes.ToManagedObjects<CXIdxAttrInfo, ClangIndexAttributeInfo>(this.AttributeCount); }
        }

        /// <summary>
        /// Clang Index Objective-C Container Declaration Info
        /// </summary>
        public ClangIndexObjCContainerDeclarationInfo ObjCContainerDeclaration
        {
            get { return LibClang.clang_index_getObjCContainerDeclInfo(this.Address).ToManaged<ClangIndexObjCContainerDeclarationInfo>(); }
        }

        /// <summary>
        /// Clang Index Objective-C Interface Declaration Info
        /// </summary>
        public ClangIndexObjCInterfaceDeclarationInfo ObjCInterfaceDeclaration
        {
            get { return LibClang.clang_index_getObjCInterfaceDeclInfo(this.Address).ToManaged<ClangIndexObjCInterfaceDeclarationInfo>(); }
        }

        /// <summary>
        /// Clang Index Objective-C Category Declaration Info
        /// </summary>
        public ClangIndexObjCCategoryDeclarationInfo ObjCCategoryDeclaration
        {
            get { return LibClang.clang_index_getObjCCategoryDeclInfo(this.Address).ToManaged<ClangIndexObjCCategoryDeclarationInfo>(); }
        }

        /// <summary>
        /// Clang Index Objective-C Protocol Reference List Info
        /// </summary>
        public ClangIndexObjCProtocolReferenceListInfo ObjCProtocolReferenceList
        {
            get { return LibClang.clang_index_getObjCProtocolRefListInfo(this.Address).ToManaged<ClangIndexObjCProtocolReferenceListInfo>(); }
        }

        /// <summary>
        /// Clang Index Objective-C Property Declaration Info
        /// </summary>
        public ClangIndexObjCPropertyDeclarationInfo ObjCPropertyDeclaration
        {
            get { return LibClang.clang_index_getObjCPropertyDeclInfo(this.Address).ToManaged<ClangIndexObjCPropertyDeclarationInfo>(); }
        }

        /// <summary>
        /// Clang Index C++ Class Declaration Info
        /// </summary>
        public ClangIndexCxxClassDeclarationInfo CxxClassDeclaration
        {
            get { return LibClang.clang_index_getCXXClassDeclInfo(this.Address).ToManaged<ClangIndexCxxClassDeclarationInfo>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Declaration Info Address</param>
        internal ClangIndexDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxDeclInfo>();
        }
    }
}
