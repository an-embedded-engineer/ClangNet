#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // char**
    using CharPtrPtr = IntPtr;

    // Object encapsulating information about overlaying virtual file/directories over the real file system.
    // 実ファイルシステム上の仮想ファイル/ディレクトリのオーバーレイに関する情報をカプセル化するオブジェクト。
    // struct CXVirtualFileOverlayImpl*
    using CXVirtualFileOverlay = IntPtr;

    // Object encapsulating information about a module.map file.
    // モジュールに関する情報をカプセル化するオブジェクト。mapファイル。
    // struct CXModuleMapDescriptorImpl*
    using CXModuleMapDescriptor = IntPtr;

    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Build System
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// <para>Get Build Session Timestamp</para>
        /// <para>ビルドセッションタイムスタンプの取得</para>
        /// </summary>
        /// <returns>
        /// <para>Build Session Timestamp</para>
        /// <para>ビルドセッションタイムスタンプ</para>
        /// </returns>
        /// <remarks>
        /// <para>Return the timestamp for use with Clang's
        /// <c>-fbuild-session-timestamp=</c> option.</para>
        /// <para>Clangの<c>-fbuild-session-timestamp=</c>で使用する
        /// タイムスタンプを返します。</para>
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ulong clang_getBuildSessionTimestamp();

        /// <summary>
        /// Create Virtual File Overlay
        /// </summary>
        /// <param name="options">reserved, always pass 0</param>
        /// <returns>CXVirtualFileOverlay Object</returns>
        /// <remarks>
        /// Create a <c>CXVirtualFileOverlay</c> object.
        /// Must be disposed with <c>clang_VirtualFileOverlay_dispose()</c>.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXVirtualFileOverlay clang_VirtualFileOverlay_create(uint options);

        /// <summary>
        /// Add File Mapping to Virtual File Overlay
        /// </summary>
        /// <param name="virtual_file_overlay">CXVirtualFileOverlay Object</param>
        /// <param name="virtual_path">Virtual Path</param>
        /// <param name="real_path">Real Path</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Map an absolute virtual file path to an absolute real one.
        /// The virtual path must be canonicalized (not contain "."/"..").
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_VirtualFileOverlay_addFileMapping(CXVirtualFileOverlay virtual_file_overlay, string virtual_path, string real_path);

        /// <summary>
        /// Set Case Sensitivity to Virtual File Overlay
        /// </summary>
        /// <param name="virtual_file_overlay">CXVirtualFileOverlay Object</param>
        /// <param name="case_sensitive">Case Sensitive</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Set the case sensitivity for the <c>CXVirtualFileOverlay</c> object.
        /// The <c>CXVirtualFileOverlay</c> object is case-sensitive by default,
        /// this option can be used to override the default.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_VirtualFileOverlay_setCaseSensitivity(CXVirtualFileOverlay virtual_file_overlay, int case_sensitive);

        /// <summary>
        /// Write Out Virtual File Overlay to Character Buffer
        /// </summary>
        /// <param name="virtual_file_overlay">CXVirtualFileOverlay Object</param>
        /// <param name="options">reserved, always pass 0.</param>
        /// <param name="out_buffer_ptr">pointer to receive the buffer pointer, which should be disposed using <c>clang_free()</c>.</param>
        /// <param name="out_buffer_size">pointer to receive the buffer size.</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Write out the <c>CXVirtualFileOverlay</c> object to a char buffer.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_VirtualFileOverlay_writeToBuffer(CXVirtualFileOverlay virtual_file_overlay, uint options, out CharPtrPtr out_buffer_ptr, out uint out_buffer_size);

        /// <summary>
        /// Free Character Buffer
        /// </summary>
        /// <param name="buffer">memory pointer to free.</param>
        /// <remarks>
        /// Free memory allocated by libclang, such as the buffer returned by
        /// <c>CXVirtualFileOverlay()</c> or <c>clang_ModuleMapDescriptor_writeToBuffer()</c>.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_free(VoidPtr buffer);

        /// <summary>
        /// Dispose Virtual File Overlay
        /// </summary>
        /// <param name="virtual_file_overlay">CXVirtualFileOverlay Object</param>
        /// <remarks>
        /// Dispose a <c>CXVirtualFileOverlay</c> object.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_VirtualFileOverlay_dispose(CXVirtualFileOverlay virtual_file_overlay);

        /// <summary>
        /// Create Module Map Descriptor
        /// </summary>
        /// <remarks>
        /// Must be disposed with <c>clang_ModuleMapDescriptor_dispose()</c>.
        /// </remarks>
        /// <param name="options">reserved, always pass 0.</param>
        /// <returns>CXModuleMapDescriptor Object</returns>
        /// <remarks>
        /// Create a <c>CXModuleMapDescriptor</c> object.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXModuleMapDescriptor clang_ModuleMapDescriptor_create(uint options);

        /// <summary>
        /// Set Framework Module Name to Module Map Descriptor
        /// </summary>
        /// <param name="module_map_descriptor">CXModuleMapDescriptor Object</param>
        /// <param name="name">the framework module name</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Sets the framework module name that the module.map describes.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_ModuleMapDescriptor_setFrameworkModuleName(CXModuleMapDescriptor module_map_descriptor, string name);

        /// <summary>
        /// Set Umbrella Header to Module Map Descriptor
        /// </summary>
        /// <param name="module_map_descriptor">CXModuleMapDescriptor Object</param>
        /// <param name="name">the umbrealla header name</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Sets the umbrealla header name that the module.map describes.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_ModuleMapDescriptor_setUmbrellaHeader(CXModuleMapDescriptor module_map_descriptor, string name);

        /// <summary>
        /// Write Out Module Map Descriptor to Character Buffer
        /// </summary>
        /// <param name="module_map_descriptor">CXModuleMapDescriptor Object</param>
        /// <param name="options">reserved, always pass 0.</param>
        /// <param name="out_buffer_ptr">pointer to receive the buffer pointer, which should be disposed using <c>clang_free()</c>.</param>
        /// <param name="out_buffer_size">pointer to receive the buffer size.</param>
        /// <returns>0 for success, non-zero to indicate an error.</returns>
        /// <remarks>
        /// Write out the <c>CXModuleMapDescriptor</c> object to a char buffer.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ErrorCode clang_ModuleMapDescriptor_writeToBuffer(CXModuleMapDescriptor module_map_descriptor, uint options, out CharPtrPtr out_buffer_ptr, out uint out_buffer_size);

        /// <summary>
        /// Dispose Module Map Descriptor
        /// </summary>
        /// <param name="module_map_descriptor">CXModuleMapDescriptor Object</param>
        /// <remarks>
        /// Dispose a <c>CXModuleMapDescriptor</c> object.
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_ModuleMapDescriptor_dispose(CXModuleMapDescriptor module_map_descriptor);
    }
}
