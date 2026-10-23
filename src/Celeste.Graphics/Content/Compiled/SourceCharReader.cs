namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceCharReader : SourceContentTypeReader<char>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceCharReader()
        {
        }

        protected internal override char Read(SourceContentReader input, char existingInstance)
        {
            return input.ReadChar();
        }
    }
}
