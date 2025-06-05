using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using ClangNet.Native;
using System.Diagnostics;

namespace ClangNet
{
    /// <summary>
    /// IntPtr Extensions
    /// </summary>
    public static class IntPtrEx
    {
        /// <summary>
        /// Convert to Managed Clang Object
        /// </summary>
        /// <typeparam name="T">Clang Object</typeparam>
        /// <param name="ptr">Native Clang Object Pointer</param>
        /// <returns>Managed Clang Object</returns>
        internal static T ToManaged<T>(this IntPtr ptr) where T : ClangObject
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                var type = typeof(T);

                var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance;

                var instance = Activator.CreateInstance(type, flags, null, new object[] { ptr }, CultureInfo.InvariantCulture) as T;

                return instance;
            }
        }

        /// <summary>
        /// Convert to Byte Array
        /// </summary>
        /// <param name="ptr">Native Pointer</param>
        /// <param name="size">Array Size</param>
        /// <returns>Byte Array</returns>
        public static byte[] ToByteArray(this IntPtr ptr, ulong size)
        {
            if (ptr == IntPtr.Zero)
            {
                return new byte[0];
            }
            else
            {
                if (size > int.MaxValue)
                {
                    throw new InvalidOperationException($"Buffer Size is out of range : {size}");
                }

                var contents_bytes = new byte[(int)size];

                Marshal.Copy(ptr, contents_bytes, 0, (int)size);

                return contents_bytes;
            }
        }

        /// <summary>
        /// Convert to Native Struct
        /// </summary>
        /// <typeparam name="T">Native Struct Type</typeparam>
        /// <param name="ptr">Native Struct Pointer</param>
        /// <returns>Native Struct</returns>
        public static T ToNativeStuct<T>(this IntPtr ptr) where T : struct
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException($"Pointer is null");
            }
            else
            {
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
        }

        /// <summary>
        /// Convert to Native Struct
        /// </summary>
        /// <typeparam name="T">Native Struct Type</typeparam>
        /// <param name="ptr">Native Struct Pointer</param>
        /// <param name="i">Array Index</param>
        /// <returns>Native Struct</returns>
        public static T ToNativeStuct<T>(this IntPtr ptr, int i) where T : struct
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException($"Pointer is null");
            }
            else
            {
                var struct_size = Marshal.SizeOf(typeof(T));

                return (T)Marshal.PtrToStructure(ptr + (struct_size * i), typeof(T));
            }
        }

        /// <summary>
        /// Convert to Native Struct Enumerable
        /// </summary>
        /// <typeparam name="T">Native Struct Type</typeparam>
        /// <param name="ptr">Native Stucts Pointer</param>
        /// <param name="count">Native Struct Count</param>
        /// <returns>Native Struct Enumerable</returns>
        public static IEnumerable<T> ToNativeStructs<T>(this IntPtr ptr, int count) where T : struct
        {
            if (ptr == IntPtr.Zero)
            {
                return Enumerable.Empty<T>();
            }
            else
            {
                var struct_size = Marshal.SizeOf(typeof(T));

                return Enumerable.Range(0, count).Select(i => ptr + (struct_size * i)).Select(address => address.ToNativeStuct<T>());
            }
        }

        /// <summary>
        /// Convert to Managed Clang Object Enumerable
        /// </summary>
        /// <typeparam name="TNative">Native Clang Struct Type</typeparam>
        /// <typeparam name="TManaged">Managed Clang Object Type</typeparam>
        /// <param name="ptr">Native Stucts Pointer</param>
        /// <param name="count">Native Struct Count</param>
        /// <returns>Managed Clang Object Enumerable</returns>
        public static IEnumerable<TManaged> ToManagedObjects<TNative, TManaged>(this IntPtr ptr, int count)
            where TNative : struct
            where TManaged : ClangObject
        {
            if (ptr == IntPtr.Zero)
            {
                return Enumerable.Empty<TManaged>();
            }
            else
            {
                var struct_size = Marshal.SizeOf(typeof(TNative));

                return Enumerable.Range(0, count).Select(i => ptr + (struct_size * i)).Select(address => address.ToManaged<TManaged>());
            }
        }

        /// <summary>
        /// Convert To Managed String
        /// </summary>
        /// <param name="char_ptr">Native Char Pointer</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Managed String</returns>
        public static string ToManagedString(this IntPtr char_ptr, string encoding = "utf-8")
        {
            if (char_ptr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                var bytes = new List<byte>();

                unsafe
                {
                    var byte_ptr = (byte*)char_ptr;
                    var x = 0;

                    while (byte_ptr[x] != 0)
                    {
                        bytes.Add(byte_ptr[x]);
                        x++;
                    }

                    var byte_array = bytes.ToArray();

                    var enc = EncodingAnalyser.Analyse(byte_array) ?? Encoding.GetEncoding(encoding);

                    var len = enc.GetCharCount(byte_ptr, x);

                    if (len == 0)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        var str_buf = stackalloc char[len];

                        var str_len = enc.GetChars(byte_ptr, x, str_buf, len);

                        var str = new string(str_buf, 0, str_len);

                        return str;
                    }
                }
            }
        }

        /// <summary>
        /// Convert To Managed String
        /// </summary>
        /// <param name="char_ptr">Native Char Pointer</param>
        /// <param name="size">Native Byte Size</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Managed String</returns>
        public static string ToManagedString(this IntPtr char_ptr, int size, string encoding = "utf-8")
        {
            if (char_ptr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                var bytes = new List<byte>();

                unsafe
                {
                    var byte_ptr = (byte*)char_ptr;

                    for(var x = 0; x < size; x++)
                    {
                        bytes.Add(byte_ptr[x]);
                    }

                    var byte_array = bytes.ToArray();

                    var enc = EncodingAnalyser.Analyse(byte_array) ?? Encoding.GetEncoding(encoding);

                    var len = enc.GetCharCount(byte_ptr, size);

                    if (len == 0)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        var str_buf = stackalloc char[len];

                        var str_len = enc.GetChars(byte_ptr, size, str_buf, len);

                        var str = new string(str_buf, 0, str_len);

                        return str;
                    }
                }
            }
        }

        /// <summary>
        /// Convert To Managed String Set Array
        /// </summary>
        /// <param name="string_set_ptr">Native String Set Pointer</param>
        /// <returns>Managed String Set Array</returns>
        public static string[] ToManagedStringSet(this IntPtr string_set_ptr)
        {
            if (string_set_ptr == IntPtr.Zero)
            {
                return new string[0];
            }
            else
            {
                var native_string_set = string_set_ptr.ToNativeStuct<CXStringSet>();

                var string_set = native_string_set.ToManaged();

                LibClang.clang_disposeStringSet(string_set_ptr);

                return string_set;
            }
        }
    }
}
