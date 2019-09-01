using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Evaluation Result
    /// </summary>
    public class ClangEvaluationResult : ClangObject, IDisposable
    {
        /// <summary>
        /// Evaluation Result Kind
        /// </summary>
        public EvalResultKind Kind
        {
            get { return LibClang.clang_EvalResult_getKind(this.Handle); }
        }

        /// <summary>
        /// Integer Evaluation Result Value
        /// </summary>
        public int AsInt
        {
            get { return LibClang.clang_EvalResult_getAsInt(this.Handle); }
        }

        /// <summary>
        /// Long Evaluation Result Value
        /// </summary>
        public long AsLong
        {
            get { return LibClang.clang_EvalResult_getAsLongLong(this.Handle); }
        }

        /// <summary>
        /// Unsigned Integer Evaluation Result Value
        /// </summary>
        public bool IsUnsignedInt
        {
            get { return LibClang.clang_EvalResult_isUnsignedInt(this.Handle).ToBool(); }
        }

        /// <summary>
        /// Unsigned Long Evaluation Result Value
        /// </summary>
        public ulong AsUnsignedLong
        {
            get { return LibClang.clang_EvalResult_getAsUnsigned(this.Handle); }
        }

        /// <summary>
        /// Dobule Evaluation Result Value
        /// </summary>
        public double AsDouble
        {
            get { return LibClang.clang_EvalResult_getAsDouble(this.Handle); }
        }

        /// <summary>
        /// String Evaluation Result Value
        /// </summary>
        public string AsString
        {
            get { return LibClang.clang_EvalResult_getAsStr(this.Handle); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Evaluation Result Pointer</param>
        internal ClangEvaluationResult(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Dispose Clang Evaluation Result
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_EvalResult_dispose(this.Handle);
        }
    }

}
