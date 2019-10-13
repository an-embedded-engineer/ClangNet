using System.Linq;

namespace ClangNet.Samples
{
    /// <summary>
    /// Cross References Dumper
    /// </summary>
    public static class CrossReferencesDumper
    {
        /// <summary>
        /// Dump Cross References
        /// </summary>
        /// <param name="map">Translation Unit Map</param>
        public static void Dump(TranslationUnitMap map)
        {
            var impl = new CrossReferencesDumperImpl();

            impl.Execute(map);
        }

        /// <summary>
        /// Cross References Dumper Implementation
        /// </summary>
        public class CrossReferencesDumperImpl : AMessageable
        {
            /// <summary>
            /// Translation Unit Map
            /// </summary>
            private TranslationUnitMap TranslationUnitMap { get; set; } = new TranslationUnitMap();

            /// <summary>
            /// Cross Reference Map
            /// </summary>
            private BehaviorCrossReferenceMap CrossReferenceMap { get; set; } = new BehaviorCrossReferenceMap();

            /// <summary>
            /// Execute
            /// </summary>
            /// <param name="map">Translation Unit Map</param>
            public void Execute(TranslationUnitMap map)
            {
                this.TranslationUnitMap = map;

                this.AnalyseCrossReferences();

                this.SendMessage();
                this.SendMessage("--------------------------------------");
                this.SendMessage("Cross References:");

                this.DumpCrossReferences();
            }

            /// <summary>
            /// Analyse Cross References
            /// </summary>
            private void AnalyseCrossReferences()
            {
                var map1 = new BehaviorCrossReferenceMap();

                foreach (var tu in this.TranslationUnitMap.Values)
                {
                    foreach (var behavior in tu.BehaviorMap.Values)
                    {
                        var xref_behavior = new BehaviorCrossReferenceInfo(behavior);

                        map1.Add(xref_behavior);

                        foreach (var invoke in behavior.Invokations)
                        {
                            var xref_invoke = new BehaviorCrossReferenceInfo(invoke);

                            map1.Add(xref_invoke);
                        }
                    }
                }

                var map2 = new BehaviorCrossReferenceMap();

                foreach (var key in this.CrossReferenceMap.Keys)
                {
                    var set = this.CrossReferenceMap[key];

                    var sorted_set = set.OrderBy(x => x.Type).ToHashSet();

                    map2.Add(key, sorted_set);
                }

                this.CrossReferenceMap = map2;
            }

            /// <summary>
            /// Dump Cross References
            /// </summary>
            private void DumpCrossReferences()
            {
                foreach (var xref_id in this.CrossReferenceMap.Keys)
                {
                    this.SendMessage($"{xref_id}");

                    var xref_hash_set = this.CrossReferenceMap[xref_id];

                    foreach (var xref_info in xref_hash_set)
                    {
                        var type = xref_info.Type;
                        var loc = xref_info.Location;
                        this.SendMessage($"  [{type}] @ {loc}");
                    }

                    this.SendMessage();
                }
            }
        }
    }
}
