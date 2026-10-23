using Celeste.Everest.Runtime;
using Celeste.Formats.Graphics.Models;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public sealed class EverestObjModelPolicy : ISourceObjModelPolicy
    {
        public static readonly EverestObjModelPolicy Instance = new();

        private EverestObjModelPolicy()
        {
        }

        public ObjectModel CreateModel(ISourceGraphicsDeviceEnvironment environment)
        {
            return new EverestObjModel(environment);
        }

        public bool SkipStreamRead(ISourceGraphicsDeviceEnvironment environment)
        {
            return ((IEverestHeadlessEnvironment)environment).IsHeadless;
        }
    }
}
