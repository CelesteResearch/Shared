namespace Celeste.Graphics.Content.Compiled
{
    public abstract class SourceContentTypeReader<T> : SourceContentTypeReader
    {
        protected SourceContentTypeReader()
            : base(typeof(T))
        {
        }

        /// <summary>
        /// Reads an object from the input stream.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <param name="existingInstance">
        /// Existing instance of an object to receive the data, or null if a new object
        /// instance should be created.
        /// </param>
        protected internal override object Read(SourceContentReader input, object existingInstance)
        {
            if (existingInstance == null)
            {
                return Read(input, default(T));
            }

            return Read(input, (T)existingInstance);
        }

        protected internal abstract T Read(SourceContentReader input, T existingInstance);
    }
}
