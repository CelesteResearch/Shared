namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceStringReader : SourceContentTypeReader<string>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceStringReader()
        {
        }

        protected internal override string Read(SourceContentReader input, string existingInstance)
        {
            return input.ReadString();
        }
    }
}
