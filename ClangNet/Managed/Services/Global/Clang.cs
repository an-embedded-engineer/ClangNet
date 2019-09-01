using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Clang Services
    /// </summary>
    public static class Clang
    {
        /// <summary>
        /// Create Clang Index
        /// </summary>
        /// <param name="exclude_declarations_from_pch">Exclude Declarations From PCH Flag</param>
        /// <param name="display_diagnostics">Display Diagnostics Flag</param>
        /// <returns>Clang Index</returns>
        public static ClangIndex CreateIndex(bool exclude_declarations_from_pch, bool display_diagnostics)
        {
            return LibClang.clang_createIndex(exclude_declarations_from_pch.ToInt(), display_diagnostics.ToInt()).ToManaged<ClangIndex>();
        }

        /// <summary>
        /// Get Null Clang Source Location
        /// </summary>
        /// <returns>Null Clang Source Location</returns>
        public static ClangSourceLocation GetNullLocation()
        {
            return LibClang.clang_getNullLocation().ToManaged();
        }

        /// <summary>
        /// Get Null Clang Source Range
        /// </summary>
        /// <returns>Null Clang Source Range</returns>
        public static ClangSourceRange GetNullRange()
        {
            return LibClang.clang_getNullRange().ToManaged();
        }

        /// <summary>
        /// Load Clang Diagnostics File
        /// </summary>
        /// <param name="file">Clang Diagnostics Bitcode File Name</param>
        /// <returns>Clang Diagnostics Set</returns>
        public static ClangDiagnosticSet LoadDiagnositics(string file)
        {
            var native_diag_set = LibClang.clang_loadDiagnostics(file, out var error, out var error_str);

            if (error != LoadDiagError.None)
            {
                var message = error_str.ToManaged();
                throw new ClangServiceException($"Load Diagnostics Failed : File={file}, Code={error}, Message={message}");
            }

            return native_diag_set.ToManaged<ClangDiagnosticSet>();
        }

        /// <summary>
        /// Get Default Diagnostic Display Options
        /// </summary>
        /// <returns>Diagnostic Display Options</returns>
        public static DiagnosticDisplayOptions GetDefaultDiagnosticDisplayOptions()
        {
            return LibClang.clang_defaultDiagnosticDisplayOptions();
        }

        /// <summary>
        /// Get Null Clang Cursor
        /// </summary>
        /// <returns>Null Clang Cursor</returns>
        public static ClangCursor GetNullCursor()
        {
            return LibClang.clang_getNullCursor().ToManaged();
        }

        /// <summary>
        /// Create Clang Cursor Set
        /// </summary>
        /// <returns>Clang Cursor Set</returns>
        public static ClangCursorSet CreateCursorSet()
        {
            return LibClang.clang_createCXCursorSet().ToManaged<ClangCursorSet>();
        }

        /// <summary>
        /// Construct USR of Objective-C Class
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <returns>USR of Objective-C Class</returns>
        public static string ConstructUSRObjCClass(string class_name)
        {
            return LibClang.clang_constructUSR_ObjCClass(class_name).ToManaged();
        }

        /// <summary>
        /// Construct USR of Objective-C Category
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <param name="category_name">Category Name</param>
        /// <returns>USR of Objective-C Category</returns>
        public static string ConstructUSRObjCCategory(string class_name, string category_name)
        {
            return LibClang.clang_constructUSR_ObjCCategory(class_name, category_name).ToManaged();
        }

        /// <summary>
        /// Construct USR of Objective-C Protocol
        /// </summary>
        /// <param name="protocol_name">Protocol Name</param>
        /// <returns>USR of Objective-C Protocol</returns>
        public static string ConstructUSRObjCProtocol(string protocol_name)
        {
            return LibClang.clang_constructUSR_ObjCProtocol(protocol_name).ToManaged();
        }

        /// <summary>
        /// Construct USR of Objective-C IVar(Instance Variable)
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <param name="name">IVar Name</param>
        /// <returns>USR of Objective-C IVar</returns>
        public static string ConstructUSRObjCIVar(string class_name, string name)
        {
            var class_usr = LibClang.clang_constructUSR_ObjCClass(class_name);

            return LibClang.clang_constructUSR_ObjCIvar(name, class_usr).ToManaged();
        }

        /// <summary>
        /// Construct USR of Objective-C Method
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <param name="name">Method Name</param>
        /// <param name="is_instance_method">Instance Method Flag</param>
        /// <returns>USR of Objective-C Method</returns>
        public static string ConstructUSRObjCMethod(string class_name, string name, bool is_instance_method)
        {
            var class_usr = LibClang.clang_constructUSR_ObjCClass(class_name);

            return LibClang.clang_constructUSR_ObjCMethod(name, is_instance_method.ToUInt(), class_usr).ToManaged();
        }

        /// <summary>
        /// Construct USR of Objective-C Property
        /// </summary>
        /// <param name="class_name">Class Name</param>
        /// <param name="property">Property Name</param>
        /// <returns>USR of Objective-C Property</returns>
        public static string ConstructUSRObjCProperty(string class_name, string property)
        {
            var class_usr = LibClang.clang_constructUSR_ObjCClass(class_name);

            return LibClang.clang_constructUSR_ObjCProperty(property, class_usr).ToManaged();
        }

        /// <summary>
        /// Enable Stack Traces
        /// </summary>
        public static void EnableStackTraces()
        {
            LibClang.clang_enableStackTraces();
        }

        /// <summary>
        /// Execute Function On Thread
        /// </summary>
        /// <param name="func">Function</param>
        /// <param name="user_data">Native User Data Pointer</param>
        /// <param name="stack_size">Stack Size</param>
        public static void ExecuteOnThread(Action<IntPtr> func, IntPtr user_data, int stack_size)
        {
            LibClang.clang_executeOnThread(func, user_data, (uint)stack_size);
        }

        /// <summary>
        /// Get Default Code Complete Options
        /// </summary>
        /// <returns>Default Code Complete Options</returns>
        public static CodeCompleteFlags GetDefaultCodeCompleteOptions()
        {
            return LibClang.clang_defaultCodeCompleteOptions();
        }

        /// <summary>
        /// Get Clang Version
        /// </summary>
        /// <returns>Clang Version</returns>
        public static string GetClangVersion()
        {
            return LibClang.clang_getClangVersion().ToManaged();
        }

        /// <summary>
        /// Toggle Crash Recovery Mode
        /// </summary>
        /// <param name="is_enabled">Enabled Flag</param>
        public static void ToggleCrashRecovery(bool is_enabled)
        {
            LibClang.clang_toggleCrashRecovery(is_enabled.ToUInt());
        }

        /// <summary>
        /// Get Clang Remappings from File
        /// </summary>
        /// <param name="path">Remappings Metadata Path</param>
        /// <returns>Clang Remapping</returns>
        public static ClangRemapping GetRemappings(string path)
        {
            return LibClang.clang_getRemappings(path).ToManaged<ClangRemapping>();
        }

        /// <summary>
        /// Get Clang Remappings from File List
        /// </summary>
        /// <param name="file_paths">Remappings Metadata Path List</param>
        /// <returns>Clang Remapping</returns>
        public static ClangRemapping GetRemappings(string[] file_paths)
        {
            return LibClang.clang_getRemappingsFromFileList(file_paths, (uint)file_paths.Length).ToManaged<ClangRemapping>();
        }

        /// <summary>
        /// Create Clang Compilation Database from Directory
        /// </summary>
        /// <param name="build_dir">Build Directory</param>
        /// <returns>Clang Compilation Database</returns>
        public static ClangCompilationDatabase CreateCompilationDatabaseFromDirectory(string build_dir)
        {
            var native_compilation_database = LibClang.clang_CompilationDatabase_fromDirectory(build_dir, out var error_code);

            if (error_code != CompilationDatabaseError.NoError)
            {
                throw new ClangServiceException($"Create Compilation Directory Failed : {error_code}");
            }

            return native_compilation_database.ToManaged<ClangCompilationDatabase>();
        }

        /// <summary>
        /// Get Build Session Time Stamp
        /// </summary>
        /// <returns>Build Session Time Stamp</returns>
        public static ulong GetBuildSessionTimestamp()
        {
            return LibClang.clang_getBuildSessionTimestamp();
        }

        /// <summary>
        /// Create Clang Virtual File Overlay
        /// </summary>
        /// <returns>Clang Virtual File Overlay</returns>
        public static ClangVirtualFileOverlay CreateVirtualFileOverlay()
        {
            return LibClang.clang_VirtualFileOverlay_create(0u).ToManaged<ClangVirtualFileOverlay>();
        }

        /// <summary>
        /// Create Clang Module Map Descriptor
        /// </summary>
        /// <returns>Clang Module Map Descriptor</returns>
        public static ClangModuleMapDescriptor CreateModuleMapDescriptor()
        {
            return LibClang.clang_ModuleMapDescriptor_create(0u).ToManaged<ClangModuleMapDescriptor>();
        }
    }
}
