using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Code Complete Results
    /// </summary>
    public class ClangCodeCompleteResults : ClangObject, IDisposable
    {
        /// <summary>
        /// Native Clang Code Complete Results
        /// </summary>
        internal CXCodeCompleteResults Source { get; }

        /// <summary>
        /// Result Count
        /// </summary>
        public int ResultCount
        {
            get { return (int)this.Source.NumResults; }
        }

        /// <summary>
        /// Clang Completion Result List
        /// </summary>
        public IEnumerable<ClangCompletionResult> Results
        {
            get { return this.Source.Results.ToManagedObjects<CXCompletionResult, ClangCompletionResult>(this.ResultCount); }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Completion Result</returns>
        public ClangCompletionResult this[int i]
        {
            get { return this.Results.ElementAt(i); }
        }

        /// <summary>
        /// Diagnostics Count
        /// </summary>
        public int DiagnosticsCount
        {
            get { return (int)LibClang.clang_codeCompleteGetNumDiagnostics(this.Handle); }
        }

        /// <summary>
        /// Completion Contexts
        /// </summary>
        public CompletionContext Contexts
        {
            get { return LibClang.clang_codeCompleteGetContexts(this.Handle); }
        }

        /// <summary>
        /// Container USR
        /// </summary>
        public string ContainerUSR
        {
            get { return LibClang.clang_codeCompleteGetContainerUSR(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Objective-C Selector
        /// </summary>
        public string ObjCSelector
        {
            get { return LibClang.clang_codeCompleteGetObjCSelector(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Code Complete Results Pointer</param>
        public ClangCodeCompleteResults(IntPtr handle) : base(handle)
        {
            this.Source = this.Handle.ToNativeStuct<CXCodeCompleteResults>();
        }

        /// <summary>
        /// Get Number of Completion Fix Its
        /// </summary>
        /// <param name="completion_index">Completion Index</param>
        /// <returns>Completion Number of Fix Its</returns>
        public int GetCompletionNumFixIts(int completion_index)
        {
            return (int)LibClang.clang_getCompletionNumFixIts(this.Handle, (uint)completion_index);
        }

        /// <summary>
        /// Get Completion Fix It
        /// </summary>
        /// <param name="completion_index">Completion Index</param>
        /// <param name="fixit_index">Fix It Index</param>
        /// <param name="replacement_range">Replacement Clang Source Range</param>
        /// <returns>Completion Fix It</returns>
        public string GetCompletionFixIt(int completion_index, int fixit_index, out ClangSourceRange replacement_range)
        {
            var native_range = new CXSourceRange();

            var ret = LibClang.clang_getCompletionFixIt(this.Handle, (uint)completion_index, (uint)fixit_index, ref native_range);

            replacement_range = native_range.ToManaged();

            return ret.ToManaged();
        }

        /// <summary>
        /// Sort Clang Code Complete Results
        /// </summary>
        public void Sort()
        {
            LibClang.clang_sortCodeCompletionResults(this.Handle, this.Source.NumResults);
        }

        /// <summary>
        /// Get Clang Diagnostic
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Clang Diagnostic</returns>
        public ClangDiagnostic GetDiagnostic(int index)
        {
            return LibClang.clang_codeCompleteGetDiagnostic(this.Handle, (uint)index).ToManaged<ClangDiagnostic>();
        }

        /// <summary>
        /// Get Container Cursor Kind
        /// </summary>
        /// <param name="is_incomplete">Incomplete Flag</param>
        /// <returns>Container Cursor Kind</returns>
        public CursorKind GetContainerKind(out bool is_incomplete)
        {
            var ret = LibClang.clang_codeCompleteGetContainerKind(this.Handle, out var native_is_incomplete);

            is_incomplete = native_is_incomplete.ToBool();

            return ret;
        }

        /// <summary>
        /// Dispose Clang Code Complete Results
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeCodeCompleteResults(this.Handle);
        }
    }
}
