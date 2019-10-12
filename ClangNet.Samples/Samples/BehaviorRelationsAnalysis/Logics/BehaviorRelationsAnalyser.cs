using System.Collections.Generic;

namespace ClangNet.Samples
{
    /// <summary>
    /// Invokation Tree Generator
    /// </summary>
    public static class BehaviorRelationsAnalyser
    {
        /// <summary>
        /// Execute Behavior Relations Analysis Process
        /// </summary>
        public static void Execute()
        {
            var setting = new TranslationUnitParseSetting()
            {
                Sources = new List<string>()
                {
                    "./Code2/src/main.cpp",
                    "./Code2/src/TestClass.cpp",
                },
                CommandLineArgs = new List<string>()
                {
                    "-I./Code2/inc",
                },
                ParseOptions = TranslationUnitFlags.None,
                DisplayDiag = true,
                DumpAST = true,
            };

            var map = TranslationUnitsParser.Parse(setting);

            InvokationTreeDumper.Dump(map);

            CrossReferencesDumper.Dump(map);
        }
    }
}
