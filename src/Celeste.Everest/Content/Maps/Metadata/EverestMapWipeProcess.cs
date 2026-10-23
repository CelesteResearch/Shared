using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Scene.Rendering;

namespace Celeste.Everest.Content.Maps.Metadata
{
// Source AreaData.WipeLoaders and MapMeta.OnParseWipe have one explicit process owner.
    public sealed class EverestMapWipeProcess
    {
        public readonly Dictionary<string, Action<ISourceRendererScene, bool, Action>> WipeLoaders = new();

        public delegate Action<ISourceRendererScene, bool, Action> ParseWipeHandler(string wipe);

        public event ParseWipeHandler OnParseWipe;

        private readonly IEverestFakeEntryAssemblyEnvironment assemblyEnvironment;

        // ReSharper disable once ConvertToPrimaryConstructor
        public EverestMapWipeProcess(IEverestFakeEntryAssemblyEnvironment assemblyEnvironment)
        {
            this.assemblyEnvironment =
                assemblyEnvironment ?? throw new ArgumentNullException(nameof(assemblyEnvironment));
        }

        public Action<ISourceRendererScene, bool, Action> ParseWipe(string wipe)
        {
            if (OnParseWipe == null) return null;
            var handlers = OnParseWipe.GetInvocationList();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var handler in handlers)
            {
                var result = ((ParseWipeHandler)handler)(wipe);
                if (result != null) return result;
            }

            return null;
        }

        public void Apply(EverestArea area, string wipe)
        {
            var value = ParseWipe(wipe);
            if (value != null || (WipeLoaders.TryGetValue(wipe, out value) && value != null))
            {
                area.Wipe = value;
            }
            else
            {
                var type = assemblyEnvironment.FakeEntryAssembly.GetType(wipe);
                var ctor = type?.GetConstructor([typeof(ISourceRendererScene), typeof(bool), typeof(Action)]);
                if (type != null && ctor != null)
                    area.Wipe = (scene, wipeIn, onComplete) => ctor.Invoke([scene, wipeIn, onComplete]);
            }
        }
    }
}
