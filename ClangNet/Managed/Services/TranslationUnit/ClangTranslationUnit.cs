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
    /// Managed Clang Translation Unit
    /// </summary>
    public class ClangTranslationUnit : ClangObject, IDisposable
    {
        /// <summary>
        /// Diagnostic Count
        /// </summary>
        public int DiagnosticCount
        {
            get { return (int)LibClang.clang_getNumDiagnostics(this.Handle); }
        }

        /// <summary>
        /// Clang Diagnostic Set
        /// </summary>
        public ClangDiagnosticSet DiagnosticSet
        {
            get { return LibClang.clang_getDiagnosticSetFromTU(this.Handle).ToManaged<ClangDiagnosticSet>(); }
        }

        /// <summary>
        /// Translation Unit Spelling
        /// </summary>
        public string Spelling
        {
            get { return LibClang.clang_getTranslationUnitSpelling(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Default Translation Unit Save Options
        /// </summary>
        public SaveTranslationUnitFlags DefaultSaveOptions
        {
            get { return LibClang.clang_defaultSaveOptions(this.Handle); }
        }

        /// <summary>
        /// Default Translation Unit Reparse Options
        /// </summary>
        public ReparseTranslationUnitFlags DefaultReparseOptions
        {
            get { return LibClang.clang_defaultReparseOptions(this.Handle); }
        }

        /// <summary>
        /// Clang Target Info
        /// </summary>
        public ClangTargetInfo TargetInfo
        {
            get { return LibClang.clang_getTranslationUnitTargetInfo(this.Handle).ToManaged<ClangTargetInfo>(); }
        }

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public ClangCursor Cursor
        {
            get { return LibClang.clang_getTranslationUnitCursor(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Clang Translation Unit Resource Usage
        /// </summary>
        public ClangTranslationUnitResourceUsage ResourceUsage
        {
            get { return LibClang.clang_getCXTUResourceUsage(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Translation Unit Pointer</param>
        internal ClangTranslationUnit(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Check File is Multiple Include Guarded
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <returns>Check Result</returns>
        public bool IsFileMultipleIncludeGuarded(ClangFile file)
        {
            return LibClang.clang_isFileMultipleIncludeGuarded(this.Handle, file.Handle).ToBool();
        }

        /// <summary>
        /// Get Clang File
        /// </summary>
        /// <param name="file_name">File Name</param>
        /// <returns>Clang</returns>
        public ClangFile GetFile(string file_name)
        {
            return LibClang.clang_getFile(this.Handle, file_name).ToManaged<ClangFile>();
        }

        /// <summary>
        /// Get File Contents
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <returns>File Contents Byte Array</returns>
        public byte[] GetFileContents(ClangFile file)
        {
            return LibClang.clang_getFileContents(this.Handle, file.Handle, out var size).ToByteArray(size);
        }

        /// <summary>
        /// Get Clang Source Location
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        /// <returns>Clang Source Location</returns>
        public ClangSourceLocation GetLocation(ClangFile file, uint line, uint column)
        {
            return LibClang.clang_getLocation(this.Handle, file.Handle, line, column).ToManaged();
        }

        /// <summary>
        /// Get Clang Source Location
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <param name="offset">Offset</param>
        /// <returns>Clang Source Location</returns>
        public ClangSourceLocation GetLocation(ClangFile file, uint offset)
        {
            return LibClang.clang_getLocationForOffset(this.Handle, file.Handle, offset).ToManaged();
        }

        /// <summary>
        /// Get Skipped Clang Source Range List
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <returns>Skipped Clang Source Range List</returns>
        public ClangSourceRangeList GetSkippedRanges(ClangFile file)
        {
            return LibClang.clang_getSkippedRanges(this.Handle, file.Handle).ToManaged<ClangSourceRangeList>();
        }

        /// <summary>
        /// Get All Skipped Clang Source Range List
        /// </summary>
        /// <returns>All Skipped Clang Source Range List</returns>
        public ClangSourceRangeList GetAllSkippedRanges()
        {
            return LibClang.clang_getAllSkippedRanges(this.Handle).ToManaged<ClangSourceRangeList>();
        }

        /// <summary>
        /// Get Clang Diagnostic
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Clang Diagnostic</returns>
        public ClangDiagnostic GetDiagnostic(int index)
        {
            return LibClang.clang_getDiagnostic(this.Handle, (uint)index).ToManaged<ClangDiagnostic>();
        }

        /// <summary>
        /// Save Clang Translation Unit
        /// </summary>
        /// <param name="filename">File Name</param>
        /// <param name="options">Translation Unit Save Options</param>
        public void Save(string filename, SaveTranslationUnitFlags options)
        {
            var ret = LibClang.clang_saveTranslationUnit(this.Handle, filename, options);

            if(ret != SaveError.None)
            {
                throw new ClangServiceException($"Translation Unit Save Failed : {ret}");
            }
        }

        /// <summary>
        /// Suspend Clang Translation Unit
        /// </summary>
        /// <returns>Suspend Result</returns>
        public bool Suspend()
        {
            return LibClang.clang_suspendTranslationUnit(this.Handle).ToBool();
        }

        /// <summary>
        /// Reparse Clang Translation Unit
        /// </summary>
        /// <param name="unsaved_files">Clang Unsaved File Array</param>
        /// <param name="options">Translation Unit Reparse Options</param>
        public void Reparse(ClangUnsavedFile[] unsaved_files, ReparseTranslationUnitFlags options)
        {
            var ret = LibClang.clang_reparseTranslationUnit(this.Handle, (uint)unsaved_files.Length, unsaved_files.ToNativeArray(), options);

            if (ret != ErrorCode.Success)
            {
                throw new ClangServiceException($"Translation Unit Reparse Failed : {ret}");
            }
        }

        /// <summary>
        /// Get Clang Cursor
        /// </summary>
        /// <param name="loc">Clang Source Location</param>
        /// <returns>Clang Cursor</returns>
        public ClangCursor GetCursor(ClangSourceLocation loc)
        {
            return LibClang.clang_getCursor(this.Handle, loc.Source).ToManaged();
        }

        /// <summary>
        /// Get Clang Module for Clang File
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <returns>Clang Module</returns>
        public ClangModule GetModuleForFile(ClangFile file)
        {
            return LibClang.clang_Cursor_getModuleForFile(this.Handle, file.Handle).ToManaged<ClangModule>();
        }

        /// <summary>
        /// Get Top Level Header Count
        /// </summary>
        /// <param name="module">Clang Module</param>
        /// <returns>Top Level Header Count</returns>
        public int GetTopLevelHeaderCount(ClangModule module)
        {
            return (int)LibClang.clang_Module_getNumTopLevelHeaders(this.Handle, module.Handle);
        }

        /// <summary>
        /// Get Top Level Header Clang File
        /// </summary>
        /// <param name="module">Clang Module</param>
        /// <param name="i">Index</param>
        /// <returns>Top Level Header Clang File</returns>
        public ClangFile GetTopLevelHeader(ClangModule module, int i)
        {
            return LibClang.clang_Module_getTopLevelHeader(this.Handle, module.Handle, (uint)i).ToManaged<ClangFile>();
        }

        /// <summary>
        /// Get Clang Token
        /// </summary>
        /// <param name="location">Clang Source Location</param>
        /// <returns>Clang Token</returns>
        public ClangToken GetToken(ClangSourceLocation location)
        {
            var native_token_ptr = LibClang.clang_getToken(this.Handle, location.Source);

            if (native_token_ptr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                var token = native_token_ptr.ToNativeStuct<CXToken>().ToManaged(this.Handle);

                LibClang.clang_disposeTokens(this.Handle, native_token_ptr, 1);

                return token;
            }
        }

        /// <summary>
        /// Tokenize Clang Source Range
        /// </summary>
        /// <param name="range">Clang Source Range</param>
        /// <returns>Clang Token Set</returns>
        public ClangTokenSet Tokenize(ClangSourceRange range)
        {
            LibClang.clang_tokenize(this.Handle, range.Source, out var tokens, out var num_tokens);

            return new ClangTokenSet(this.Handle, tokens, (int)num_tokens);
        }

        /// <summary>
        /// Get Inclusions
        /// </summary>
        /// <param name="visitor">Managed Clang Inclusion Visitor Function</param>
        /// <param name="client_data">Native Client Data Pointer</param>
        public void GetInclusions(Action<ClangFile, ClangSourceLocation[], IntPtr> visitor, IntPtr client_data)
        {
            var native_visitor = this.CreateNativeInclusionVisitor(visitor);

            LibClang.clang_getInclusions(this.Handle, native_visitor, client_data);
        }

        /// <summary>
        /// Find Includes File
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <param name="visitor">Managed Clang Cursor And Range Visitor Function</param>
        /// <returns>Find Result</returns>
        public FindResult FindIncludesInFile(ClangFile file, Func<object, ClangCursor, ClangSourceRange, VisitorResult> visitor)
        {
            return LibClang.clang_findIncludesInFile(this.Handle, file.Handle, this.CreateNativeCursorAndRangeVisitor(visitor));
        }

        /// <summary>
        /// Dispose Clang Translation Unit
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeTranslationUnit(this.Handle);
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Check Reuslt</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClangTranslationUnit);
        }

        /// <summary>
        /// Check Equality
        /// </summary>
        /// <param name="other">Other Translation Unit</param>
        /// <returns>Check Result</returns>
        public bool Equals(ClangTranslationUnit other)
        {
            return other != null && this.Handle == other.Handle;
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return (IntPtr.Size > 4) ? (int)this.Handle.ToInt64() : this.Handle.ToInt32();
        }

        /// <summary>
        /// Create Native Clang Inclusion Visitor
        /// </summary>
        /// <param name="visitor">Managed Clang Inclusion Visitor Function</param>
        /// <returns>Native Clang Inclusion Visitor</returns>
        private CXInclusionVisitor CreateNativeInclusionVisitor(Action<ClangFile, ClangSourceLocation[], IntPtr> visitor)
        {
            CXInclusionVisitor v = (native_file, native_locations, native_len, native_client_data) =>
            {
                var file = native_file.ToManaged<ClangFile>();

                var locations = native_locations.ToNativeStructs<CXSourceLocation>((int)native_len).Select(loc => loc.ToManaged()).ToArray();

                var client_data = native_client_data;

                visitor(file, locations, client_data);
            };

            return v;
        }

        /// <summary>
        /// Create Native Clang Cursor And Range Visitor
        /// </summary>
        /// <param name="visitor">Managed Clang Cursor And Range Visitor Function</param>
        /// <returns>Native Clang Cursor And Range Visitor</returns>
        private CXCursorAndRangeVisitor CreateNativeCursorAndRangeVisitor(Func<object, ClangCursor, ClangSourceRange, VisitorResult> visitor)
        {
            var v = new CXCursorAndRangeVisitor((native_ctx, native_cursor, native_range) =>
            {
                var cursor = native_cursor.ToManaged();
                var range = native_range.ToManaged();
                return visitor(native_ctx, cursor, range);
            });

            return v;
        }
    }

}
