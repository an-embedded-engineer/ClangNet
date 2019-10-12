using System.Linq;

namespace ClangNet.Samples
{
    /// <summary>
    /// Invokation Tree Dumper
    /// </summary>
    public static class InvokationTreeDumper
    {
        /// <summary>
        /// Dump Invokation Tree
        /// </summary>
        /// <param name="map">Translation Unit Map</param>
        public static void Dump(TranslationUnitMap map)
        {
            var impl = new InvokationTreeDumperImpl();

            impl.Execute(map);
        }

        /// <summary>
        /// Invokation Tree Dumper Implementation
        /// </summary>
        public class InvokationTreeDumperImpl : AMessageable
        {
            /// <summary>
            /// Translation Unit Map
            /// </summary>
            private TranslationUnitMap TranslationUnitMap { get; set; } = new TranslationUnitMap();

            /// <summary>
            /// Behavior Definition Map
            /// </summary>
            private BehaviorDefinitionMap BehaviorDefinitionMap { get; set; } = new BehaviorDefinitionMap();

            /// <summary>
            /// Execute
            /// </summary>
            /// <param name="map">Translation Unit Map</param>
            public void Execute(TranslationUnitMap map)
            {
                this.TranslationUnitMap = map;

                this.CreateBehaviorDefinitionMap();

                this.SendMessage();
                this.SendMessage("--------------------------------------");
                this.SendMessage("Invokation Tree:");

                this.DumpInvokationTrees();
            }

            /// <summary>
            /// Create Behavior Definition Map
            /// </summary>
            private void CreateBehaviorDefinitionMap()
            {
                foreach (var tu in this.TranslationUnitMap.Values)
                {
                    var behavior_definitions = tu.BehaviorMap.Values.Where(b => b.Type == "Definition").ToList();

                    foreach (var behavior_definition in behavior_definitions)
                    {
                        this.BehaviorDefinitionMap.AddIfNotRegistered(behavior_definition);
                    }
                }
            }

            /// <summary>
            /// Dump Invokation Trees
            /// </summary>
            private void DumpInvokationTrees()
            {
                var behavior_defnitions = this.BehaviorDefinitionMap.Values;

                foreach (var behavior in behavior_defnitions)
                {
                    this.SendMessage($"{behavior.Definition} @ {behavior.Location}");

                    this.DumpInvokationTree(behavior);

                    this.SendMessage();
                }
            }

            /// <summary>
            /// Dump Invokation Tree
            /// </summary>
            /// <param name="behavior">Behavior</param>
            /// <param name="depth">Depth</param>
            private void DumpInvokationTree(BehaviorInfo behavior, int depth = 1)
            {
                foreach (var invokation in behavior.Invokations)
                {
                    var indent = new string(' ', depth * 2);

                    var indent2 = new string(' ', (depth + 1) * 2);

                    this.SendMessage($"{indent}{invokation.ID} @ {invokation.Location}");

                    if (behavior.ID == invokation.ID)
                    {
                        this.SendMessage($"{indent2} <Recursive Call...>");
                    }
                    else
                    {
                        if (this.BehaviorDefinitionMap.ContainsKey(invokation.ID))
                        {
                            var child_behavior = this.BehaviorDefinitionMap[invokation.ID];

                            this.DumpInvokationTree(child_behavior, depth + 1);
                        }
                        else
                        {
                            this.SendMessage($"{indent2} <Behavior Definition Not Found...>");
                        }
                    }
                }
            }
        }
    }
}
