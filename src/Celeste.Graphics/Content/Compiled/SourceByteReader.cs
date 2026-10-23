namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceByteReader : SourceContentTypeReader<byte>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceByteReader()
        {
        }

        protected internal override byte Read(SourceContentReader input, byte existingInstance)
        {
            return input.ReadByte();
        }
    }
}
