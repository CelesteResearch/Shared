using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceEffectReader : SourceContentTypeReader<SourceEffect>
    {
        internal static byte[] ReadCode(SourceContentReader input)
        {
            return ReadCode(input, input.ReadInt32());
        }

        private static byte[] ReadCode(SourceContentReader input, int count)
        {
            return input.ReadBytes(count);
        }

        protected internal override SourceEffect Read(SourceContentReader input, SourceEffect existingInstance)
        {
            var count = input.ReadInt32();
            return new(input.ContentManager.GetGraphicsDevice(), ReadCode(input, count))
            {
                Name = input.AssetName,
            };
        }
    }
}
