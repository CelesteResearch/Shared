namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceDecimalReader : SourceContentTypeReader<decimal>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceDecimalReader()
        {
        }

        protected internal override decimal Read(SourceContentReader input, decimal existingInstance)
        {
            return input.ReadDecimal();
        }
    }
}
