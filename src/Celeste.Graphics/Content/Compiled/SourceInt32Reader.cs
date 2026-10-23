namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceInt32Reader : SourceContentTypeReader<int>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceInt32Reader()
        {
        }

        protected internal override int Read(SourceContentReader input, int existingInstance)
        {
            return input.ReadInt32();
        }
    }
}
