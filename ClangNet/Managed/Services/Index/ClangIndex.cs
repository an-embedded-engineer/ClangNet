using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index
    /// </summary>
    public class ClangIndex : ClangObject, IDisposable
    {
        /// <summary>
        /// Global Option Flags
        /// </summary>
        public GlobalOptionFlags GlobalOptionFlags
        {
            get { return LibClang.clang_CXIndex_getGlobalOptions(this.Handle); }
            set { LibClang.clang_CXIndex_setGlobalOptions(this.Handle, value); }
        }

        /// <summary>
        /// Invocation Emission Path Option
        /// </summary>
        public string InvocationEmissionPathOption
        {
            set { LibClang.clang_CXIndex_setInvocationEmissionPathOption(this.Handle, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Index Pointer</param>
        internal ClangIndex(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Create Clang Transaltion Unit from Source File
        /// </summary>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <returns>Clang Translation Unit</returns>
        public ClangTranslationUnit CreateTranslationUnitFromSourceFile(string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files)
        {
            return LibClang.clang_createTranslationUnitFromSourceFile(this.Handle,
                                                                      source_filename,
                                                                      command_line_args.Length,
                                                                      command_line_args,
                                                                      (uint)unsaved_files.Length,
                                                                      unsaved_files.ToNativeArray()).ToManaged<ClangTranslationUnit>();
        }

        /// <summary>
        /// Create Clang Translation Unit
        /// </summary>
        /// <param name="ast_filename">AST File Name</param>
        /// <returns>Clang Translation Unit</returns>
        public ClangTranslationUnit CreateTranslationUnit(string ast_filename)
        {
            return LibClang.clang_createTranslationUnit(this.Handle, ast_filename).ToManaged<ClangTranslationUnit>();
        }

        /// <summary>
        /// Create Clang Translation Unit
        /// </summary>
        /// <param name="ast_filename">AST File Name</param>
        /// <param name="out_tu">Clang Translation Unit</param>
        /// <returns>Error Code</returns>
        public ErrorCode CreateTranslationUnit(string ast_filename, out ClangTranslationUnit out_tu)
        {
            var error_code = LibClang.clang_createTranslationUnit2(this.Handle, ast_filename, out var native_tu);

            out_tu = (error_code == ErrorCode.Success) ? native_tu.ToManaged<ClangTranslationUnit>() : null;

            return error_code;
        }

        /// <summary>
        /// Parse Clang Translation Unit
        /// </summary>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <param name="options">Translation Unit Parse Options</param>
        /// <returns>Clang Translation Unit</returns>
        public ClangTranslationUnit ParseTranslationUnit(string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files, TranslationUnitFlags options)
        {
            return LibClang.clang_parseTranslationUnit(this.Handle,
                                                       source_filename,
                                                       command_line_args,
                                                       command_line_args.Length,
                                                       unsaved_files.ToNativeArray(),
                                                       (uint)unsaved_files.Length,
                                                       options).ToManaged<ClangTranslationUnit>();
        }

        /// <summary>
        /// Parse Clang Translation Unit
        /// </summary>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <param name="options">Translation Unit Parse Options</param>
        /// <param name="out_tu">Clang Translation Unit</param>
        /// <returns>Error Code</returns>
        public ErrorCode ParseTranslationUnit(string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files, TranslationUnitFlags options, out ClangTranslationUnit out_tu)
        {
            var error_code = LibClang.clang_parseTranslationUnit2(this.Handle,
                                                                  source_filename,
                                                                  command_line_args,
                                                                  command_line_args.Length,
                                                                  unsaved_files.ToNativeArray(),
                                                                  (uint)unsaved_files.Length,
                                                                  options,
                                                                  out var native_tu);

            out_tu = (error_code == ErrorCode.Success) ? native_tu.ToManaged<ClangTranslationUnit>() : null;

            return error_code;
        }

        /// <summary>
        /// Parse Clang Translation Unit with Full Argument Variables
        /// </summary>
        /// <param name="source_filename">Source File Name</param>
        /// <param name="command_line_args">Command Line Arguments</param>
        /// <param name="unsaved_files">Clang Unsaved Files</param>
        /// <param name="options">Translation Unit Parse Options</param>
        /// <param name="out_tu">Clang Translation Unit</param>
        /// <returns>Error Code</returns>
        public ErrorCode ParseTranslationUnitFullArgv(string source_filename, string[] command_line_args, ClangUnsavedFile[] unsaved_files, TranslationUnitFlags options, out ClangTranslationUnit out_tu)
        {
            var error_code = LibClang.clang_parseTranslationUnit2FullArgv(this.Handle,
                                                                          source_filename,
                                                                          command_line_args,
                                                                          command_line_args.Length,
                                                                          unsaved_files.ToNativeArray(),
                                                                          (uint)unsaved_files.Length,
                                                                          options,
                                                                          out var native_tu);

            out_tu = (error_code == ErrorCode.Success) ? native_tu.ToManaged<ClangTranslationUnit>() : null;

            return error_code;
        }

        /// <summary>
        /// Create Clang Index Action
        /// </summary>
        /// <returns>Clang Index Action</returns>
        public ClangIndexAction CreateIndexAction()
        {
            return new ClangIndexAction(LibClang.clang_IndexAction_create(this.Handle));
        }

        /// <summary>
        /// Dispose Clang Index
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeIndex(this.Handle);
        }
    }
}
