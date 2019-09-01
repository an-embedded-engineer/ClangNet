using System;
using System.Linq;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Action
    /// </summary>
    public class ClangIndexAction : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Index Action Pointer</param>
        internal ClangIndexAction(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Index Source File
        /// </summary>
        /// <param name="client_data">Native Client Data Pointer</param>
        /// <param name="index_callbacks">Clang Indexer Callbacks</param>
        /// <param name="options">Index Option Flags</param>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <param name="out_tu">Clang Translation Unit</param>
        /// <param name="tu_options">Translation Unit Parse Options</param>
        /// <returns>Error Code</returns>
        public ErrorCode IndexSourceFile(IntPtr client_data, ClangIndexerCallbacks[] index_callbacks, IndexOptionFlags options, string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files, out ClangTranslationUnit out_tu, TranslationUnitFlags tu_options)
        {
            if (index_callbacks == null)
            {
                throw new ArgumentNullException("index_callbacks is null");
            }

            var native_callbacks = index_callbacks.Select(ic => ic.ToNative()).ToArray();

            var native_unsaved_files = unsaved_files.Select(uf => uf.ToNative()).ToArray();

            var ret = LibClang.clang_indexSourceFile(this.Handle,
                                                    client_data,
                                                    native_callbacks,
                                                    (uint)native_callbacks.Length,
                                                    options,
                                                    source_filename,
                                                    command_line_args,
                                                    command_line_args.Length,
                                                    native_unsaved_files,
                                                    (uint)native_unsaved_files.Length,
                                                    out var native_out_tu,
                                                    tu_options);

            out_tu = (ret == ErrorCode.Success) ? native_out_tu.ToManaged<ClangTranslationUnit>() : null;

            return ret;
        }

        /// <summary>
        /// Index Source File with Full Argument Variables
        /// </summary>
        /// <param name="client_data">Native Client Data Pointer</param>
        /// <param name="index_callbacks">Clang Indexer Callbacks</param>
        /// <param name="options">Index Option Flags</param>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <param name="out_tu">Clang Translation Unit</param>
        /// <param name="tu_options">Translation Unit Parse Options</param>
        /// <returns>Error Code</returns>
        public ErrorCode IndexSourceFileFullArgv(IntPtr client_data, ClangIndexerCallbacks[] index_callbacks, IndexOptionFlags options, string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files, out ClangTranslationUnit out_tu, TranslationUnitFlags tu_options)
        {
            if (index_callbacks == null)
            {
                throw new ArgumentNullException("index_callbacks is null");
            }

            var native_callbacks = index_callbacks.Select(ic => ic.ToNative()).ToArray();

            var native_unsaved_files = unsaved_files.Select(uf => uf.ToNative()).ToArray();

            var ret = LibClang.clang_indexSourceFileFullArgv(this.Handle,
                                                             client_data,
                                                             native_callbacks,
                                                             (uint)native_callbacks.Length,
                                                             options,
                                                             source_filename,
                                                             command_line_args,
                                                             command_line_args.Length,
                                                             native_unsaved_files,
                                                             (uint)native_unsaved_files.Length,
                                                             out var native_out_tu,
                                                             tu_options);

            out_tu = (ret == ErrorCode.Success) ? native_out_tu.ToManaged<ClangTranslationUnit>() : null;

            return ret;
        }

        /// <summary>
        /// Index Clang Translation Unit
        /// </summary>
        /// <param name="client_data">Native Client Data Pointer</param>
        /// <param name="index_callbacks">Clang Indexer Callbacks</param>
        /// <param name="options">Index Option Flags</param>
        /// <param name="tu">Clang Transaltion Unit</param>
        /// <returns>Error Code</returns>
        public ErrorCode IndexTranslationUnit(IntPtr client_data, ClangIndexerCallbacks[] index_callbacks, IndexOptionFlags options, ClangTranslationUnit tu)
        {
            if (index_callbacks == null)
            {
                throw new ArgumentNullException("Indexer Callbacks is null");
            }

            if (tu == null)
            {
                throw new ArgumentNullException("Translation Unit is null");
            }

            var native_callbacks = index_callbacks.Select(ic => ic.ToNative()).ToArray();

            var ret = LibClang.clang_indexTranslationUnit(this.Handle,
                                                          client_data,
                                                          native_callbacks,
                                                          (uint)native_callbacks.Length,
                                                          options,
                                                          tu.Handle);

            return ret;
        }

        /// <summary>
        /// Dispose Clang Index Action
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_IndexAction_dispose(this.Handle);
        }
    }
}
