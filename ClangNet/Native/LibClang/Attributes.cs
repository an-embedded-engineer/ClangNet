#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    /// <summary>
    /// Libclang P/Invoke : Attributes
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// <para>Get IBOutlet Collection Type</para>
        /// <para>IBOutletコレクションタイプを取得</para>
        /// </summary>
        /// <param name="cursor">
        /// <para>Clang Cursor</para>
        /// <para>カーソル</para>
        /// </param>
        /// <returns>
        /// <para>IBOutlet Collection Element Type</para>
        /// <para>IBOutletコレクション要素タイプ</para>
        /// </returns>
        /// <remarks>
        /// <para>For cursors representing an IBOutlet Collection attribute,
        /// this function returns the collection element type.</para>
        /// <para>IBOutletコレクション属性を表すカーソルの場合、この関数はコレクション要素タイプを返します。</para>
        /// </remarks>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXType clang_getIBOutletCollectionType(CXCursor cursor);
    }
}
