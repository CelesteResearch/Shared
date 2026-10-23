using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Formats.Graphics.Models
{
    public sealed class ObjectModelPolicy : ISourceObjModelPolicy
    {
        public static readonly ObjectModelPolicy Instance = new();

        private ObjectModelPolicy()
        {
        }

        public ObjectModel CreateModel(ISourceGraphicsDeviceEnvironment environment) =>
            new ObjectModel(environment);

        public bool SkipStreamRead(ISourceGraphicsDeviceEnvironment environment) => false;
    }
}
