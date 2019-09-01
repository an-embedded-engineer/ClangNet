using ClangNet.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Resource Usage Kind
    /// </summary>
    /// <remarks>
    /// Categorizes how memory is being used by a translation unit.
    /// </remarks>
    public enum ResourceUsageKind
    {
        /// <summary>
        /// AST
        /// </summary>
        AST = 1,

        /// <summary>
        /// Identifiers
        /// </summary>
        Identifiers = 2,

        /// <summary>
        /// Selectors
        /// </summary>
        Selectors = 3,

        /// <summary>
        /// Global Completion Results
        /// </summary>
        GlobalCompletionResults = 4,

        /// <summary>
        /// Source Manager Content Cache
        /// </summary>
        SourceManagerContentCache = 5,

        /// <summary>
        /// AST Side Tables
        /// </summary>
        ASTSideTables = 6,

        /// <summary>
        /// Source Manager Memory Buffer Memory Allocation
        /// </summary>
        SourceManagerMembufferMalloc = 7,

        /// <summary>
        /// Source Manager Memory Buffer Memory Map
        /// </summary>
        SourceManagerMembufferMMap = 8,

        /// <summary>
        /// External AST Source Memory Buffer Memory Allocation
        /// </summary>
        ExternalASTSourceMembufferMalloc = 9,

        /// <summary>
        /// External AST Source Memory Buffer Memory Map
        /// </summary>
        ExternalASTSourceMembufferMMap = 10,

        /// <summary>
        /// Preprocessor
        /// </summary>
        Preprocessor = 11,

        /// <summary>
        /// Preprocessing Record
        /// </summary>
        PreprocessingRecord = 12,

        /// <summary>
        /// Source Manager Data Structures
        /// </summary>
        SourceManagerDataStructures = 13,

        /// <summary>
        /// Preprocessor Header Search
        /// </summary>
        PreprocessorHeaderSearch = 14,

        /// <summary>
        /// Mmoery In Bytes Begin
        /// </summary>
        MemoryInBytesBegin = AST,

        /// <summary>
        /// Memory In Bytes End
        /// </summary>
        MemoryInBytesEnd = PreprocessorHeaderSearch,

        /// <summary>
        /// First Resource Usage Kind
        /// </summary>
        First = AST,

        /// <summary>
        /// End Resource Usage Kind
        /// </summary>
        Last = PreprocessorHeaderSearch,
    }

    /// <summary>
    /// Resource Usage Kind Extensions
    /// </summary>
    public static class ResourceUsageKindEx
    {
        /// <summary>
        /// Get Resourece Usage Name
        /// </summary>
        /// <param name="kind">Resource Usage Kind</param>
        /// <returns>Resourece Usage Name</returns>
        public static string GetResourceUsageName(this ResourceUsageKind kind)
        {
            return LibClang.clang_getTUResourceUsageName(kind);
        }
    }
}
