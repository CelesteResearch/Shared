namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSByteReader : SourceContentTypeReader<sbyte>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceSByteReader()
        {
        }

        protected internal override sbyte Read(SourceContentReader input, sbyte existingInstance)
        {
            return input.ReadSByte();
        }
    }
}
