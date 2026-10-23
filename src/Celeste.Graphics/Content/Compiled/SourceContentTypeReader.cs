using System;

namespace Celeste.Graphics.Content.Compiled
{
    public abstract class SourceContentTypeReader
    {
        private Type targetType;

        public virtual bool CanDeserializeIntoExistingObject => false;

        public Type TargetType => targetType;

        public virtual int TypeVersion => 0;

        protected SourceContentTypeReader(Type targetType)
        {
            this.targetType = targetType;
        }

        protected internal virtual void Initialize(SourceContentTypeReaderManager manager)
        {
        }

        protected internal abstract object Read(SourceContentReader input, object existingInstance);
    }
}
