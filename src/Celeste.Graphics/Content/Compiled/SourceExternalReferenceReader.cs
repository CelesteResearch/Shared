namespace Celeste.Graphics.Content.Compiled
{
    /// <summary>
    /// External reference reader, provided for compatibility with XNA Framework built content
    /// </summary>
    internal class SourceExternalReferenceReader : SourceContentTypeReader
    {
        public SourceExternalReferenceReader()
            : base(null)
        {
        }

        protected internal override object Read(SourceContentReader input, object existingInstance)
        {
            return input.ReadExternalReference<object>();
        }
    }
}
