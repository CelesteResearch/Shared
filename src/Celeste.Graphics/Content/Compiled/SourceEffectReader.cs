using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceEffectReader : SourceContentTypeReader<SourceEffect>
    {
        internal static byte[] ReadCode(SourceContentReader input)
            => ReadCode(input, input.ReadInt32());

        private static byte[] ReadCode(SourceContentReader input, int count)
            => input.ReadBytes(count);

        protected internal override SourceEffect Read(SourceContentReader input, SourceEffect existingInstance)
        {
            int count = input.ReadInt32();
            return new SourceEffect(input.ContentManager.GetGraphicsDevice(), ReadCode(input, count))
            {
                Name = input.AssetName
            };
        }
    }
}
