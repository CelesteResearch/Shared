using System;
using System.Collections.Generic;
using System.Reflection;
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

        public EverestMapWipeProcess(IEverestFakeEntryAssemblyEnvironment assemblyEnvironment)
            => this.assemblyEnvironment =
                assemblyEnvironment ?? throw new ArgumentNullException(nameof(assemblyEnvironment));

        public Action<ISourceRendererScene, bool, Action> ParseWipe(string wipe)
        {
            if (OnParseWipe == null) return null;
            Delegate[] handlers = OnParseWipe.GetInvocationList();
            for (int i = 0; i < handlers.Length; i++)
            {
                Action<ISourceRendererScene, bool, Action> result = ((ParseWipeHandler)handlers[i])(wipe);
                if (result != null) return result;
            }

            return null;
        }

        public void Apply(EverestArea area, string wipe)
        {
            Action<ISourceRendererScene, bool, Action> value = ParseWipe(wipe);
            if (value != null) area.Wipe = value;
            else if (WipeLoaders.TryGetValue(wipe, out value) && value != null) area.Wipe = value;
            else
            {
                Type type = assemblyEnvironment.FakeEntryAssembly.GetType(wipe);
                ConstructorInfo ctor = type?.GetConstructor(new Type[]
                    { typeof(ISourceRendererScene), typeof(bool), typeof(Action) });
                if (type != null && ctor != null)
                    area.Wipe = (scene, wipeIn, onComplete) => ctor.Invoke(new object[] { scene, wipeIn, onComplete });
            }
        }
    }
}
