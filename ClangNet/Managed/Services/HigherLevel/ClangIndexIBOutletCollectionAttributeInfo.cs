using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index IBOutlet Collection Attribute Info
    /// </summary>
    public class ClangIndexIBOutletCollectionAttributeInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index IBOutlet Collection Attribute Info
        /// </summary>
        internal CXIdxIBOutletCollectionAttrInfo Info { get; }

        /// <summary>
        /// Clang Index Attribute Info
        /// </summary>
        public ClangIndexAttributeInfo Attribute
        {
            get { return this.Info.AttrInfo.ToManaged<ClangIndexAttributeInfo>(); }
        }

        /// <summary>
        /// Objective-C Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo ObjCClass
        {
            get { return this.Info.ObjcClass.ToManaged<ClangIndexEntityInfo>(); }
        }

        /// <summary>
        /// Class Clang Cursor
        /// </summary>
        public ClangCursor ClassCursor
        {
            get { return this.Info.ClassCursor.ToManaged(); }
        }

        /// <summary>
        /// Class Clang Index Location
        /// </summary>
        public ClangIndexLocation ClassLocation
        {
            get { return this.Info.ClassLoc.ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index IBOutlet Collection Attribute Info Address</param>
        internal ClangIndexIBOutletCollectionAttributeInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxIBOutletCollectionAttrInfo>();
        }
    }
}
