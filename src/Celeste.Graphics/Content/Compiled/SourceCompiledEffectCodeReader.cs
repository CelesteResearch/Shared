using System.IO;
using Celeste.Core.Framework.Services;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceCompiledEffectCodeReader : ISourceContentTypeIdentity
    {
        private SourceCompiledEffectCodeReader()
        {
        }

        // Uses the standard XNB readers and LZX decoder; creates no graphics device or effect.
        // The supplied stream is disposed after reading, as with ContentManager.Load.
        public static byte[] Read(Stream stream, string assetName)
        {
            var process = new SourceContentProcessState(null, new SourceCompiledEffectCodeReader(),
                null, null, null, null, null, null);
            using var manager = new SourceContentManager(new SourceGameServiceContainer(), process);
            return manager.ReadEffectCode(stream, assetName);
        }

        System.Type ISourceContentTypeIdentity.ResolveActualType(string preparedSourceTypeName)
            => SourceXnbWireTypeResolver.Resolve(preparedSourceTypeName);
    }
}
