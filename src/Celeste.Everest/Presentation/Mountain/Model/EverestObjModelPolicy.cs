using System.Threading.Tasks;
using Celeste.Formats.Graphics.Models;
using Celeste.Everest.Runtime.Threading;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public sealed class EverestObjModelPolicy : ISourceObjModelPolicy
    {
        public static readonly EverestObjModelPolicy Instance = new();

        private EverestObjModelPolicy()
        {
        }

        public ObjectModel CreateModel(ISourceGraphicsDeviceEnvironment environment) =>
            new EverestObjModel(environment);

        public bool SkipStreamRead(ISourceGraphicsDeviceEnvironment environment)
            => ((Celeste.Everest.Runtime.IEverestHeadlessEnvironment)environment).IsHeadless;
    }
}
