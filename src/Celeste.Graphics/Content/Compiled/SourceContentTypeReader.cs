using System;
using JetBrains.Annotations;

namespace Celeste.Graphics.Content.Compiled
{
    public abstract class SourceContentTypeReader(Type targetType)
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access | ImplicitUseKindFlags.Assign)]
        private Type targetType = targetType;

        public virtual bool CanDeserializeIntoExistingObject => false;
        public Type TargetType => targetType;
        public virtual int TypeVersion => 0;

        protected internal virtual void Initialize(SourceContentTypeReaderManager manager)
        {
        }

        protected internal abstract object Read(SourceContentReader input, object existingInstance);
    }
}
