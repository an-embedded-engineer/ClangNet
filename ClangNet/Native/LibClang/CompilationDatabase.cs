#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A compilation database holds all information used to compile files in a
    // project. For each file in the database, it can be queried for the working
    // directory or the command line used for the compiler invocation.
    //
    // Must be freed by clang_CompilationDatabase_dispose
    using CXCompilationDatabase = IntPtr;

    // Contains the results of a search in the compilation database
    //
    // When searching for the compile command for a file, the compilation db can
    // return several commands, as the file may have been compiled with
    // different options in different places of the project.This choice of compile
    // commands is wrapped in this opaque data structure.It must be freed by
    // clang_CompileCommands_dispose.
    using CXCompileCommands = IntPtr;

    // Represents the command line invocation to compile a specific file.
    using CXCompileCommand = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Compilation Database
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Creates a compilation database from the database found in directory
        /// buildDir.For example, CMake can output a compile_commands.json which can
        /// be used to build the database.
        ///
        /// It must be freed by <c>clang_CompilationDatabase_dispose()</c>.
        /// </summary>
        /// <param name="build_dir">Build Directory</param>
        /// <param name="error_code">Error Code</param>
        /// <returns>Compilation Database</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompilationDatabase clang_CompilationDatabase_fromDirectory(string build_dir, out CompilationDatabaseError error_code);

        /// <summary>
        /// Free the given compilation database
        /// </summary>
        /// <param name="compilation_database">Compilation Database</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_CompilationDatabase_dispose(CXCompilationDatabase compilation_database);

        /// <summary>
        /// Find the compile commands used for a file. The compile commands
        /// must be freed by <c>clang_CompileCommands_dispose()</c>.
        /// </summary>
        /// <param name="compilation_database">Compilation Database</param>
        /// <param name="complete_filename">Complete Filename</param>
        /// <returns>Compile Commands</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompileCommands clang_CompilationDatabase_getCompileCommands(CXCompilationDatabase compilation_database, string complete_filename);

        /// <summary>
        /// Get all the compile commands in the given compilation database.
        /// </summary>
        /// <param name="compilation_database">Compilation Database</param>
        /// <returns>Compile Commands</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompileCommands clang_CompilationDatabase_getAllCompileCommands(CXCompilationDatabase compilation_database);

        /// <summary>
        /// Free the given CompileCommands
        /// </summary>
        /// <param name="compile_commands">Compile Commands</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_CompileCommands_dispose(CXCompileCommands compile_commands);

        /// <summary>
        /// Get the number of CompileCommand we have for a file
        /// </summary>
        /// <param name="compile_commands">Compile Commands</param>
        /// <returns>the number of CompileCommand</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CompileCommands_getSize(CXCompileCommands compile_commands);

        /// <summary>
        /// Get the I'th CompileCommand for a file
        /// Note : 0 &lt;= i &lt; clang_CompileCommands_getSize(CXCompileCommands)
        /// </summary>
        /// <param name="compile_commands">Compile Commands</param>
        /// <param name="i">Index</param>
        /// <returns>Compile Command</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCompileCommand clang_CompileCommands_getCommand(CXCompileCommands compile_commands, uint i);

        /// <summary>
        /// Get the working directory where the CompileCommand was executed from
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <returns>Working Direction Path</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_CompileCommand_getDirectory(CXCompileCommand compile_command);

        /// <summary>
        /// Get the filename associated with the CompileCommand.
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <returns>Filename</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_CompileCommand_getFilename(CXCompileCommand compile_command);

        /// <summary>
        /// Get the number of arguments in the compiler invocation.
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <returns>the number of arguments</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CompileCommand_getNumArgs(CXCompileCommand compile_command);

        /// <summary>
        /// Get the I'th argument value in the compiler invocations
        ///
        /// Invariant :
        ///  - argument 0 is the compiler executable
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <param name="i">Index</param>
        /// <returns>Argument Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_CompileCommand_getArg(CXCompileCommand compile_command, uint i);

        /// <summary>
        /// Get the number of source mappings for the compiler invocation.
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <returns>the number of source mappings</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_CompileCommand_getNumMappedSources(CXCompileCommand compile_command);

        /// <summary>
        /// Get the I'th mapped source path for the compiler invocation.
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <param name="i">Index</param>
        /// <returns>Mapped Source Path</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_CompileCommand_getMappedSourcePath(CXCompileCommand compile_command, uint i);

        /// <summary>
        /// Get the I'th mapped source content for the compiler invocation.
        /// </summary>
        /// <param name="compile_command">Compile Command</param>
        /// <param name="i">Index</param>
        /// <returns>Mapped Source Content</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_CompileCommand_getMappedSourceContent(CXCompileCommand compile_command, uint i);
    }
}
