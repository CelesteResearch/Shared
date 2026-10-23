using System;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityType : ISourceCommandTypeMetadata
    {
        private ISourceCommandMethodMetadata[] sourceCommandMethods;

        internal void PublishDeclaredCommandMethods(ISourceCommandMethodMetadata[] methods)
        {
            if (sourceCommandMethods != null)
                throw new InvalidOperationException("Source method facts are already published.");
            sourceCommandMethods = methods;
        }

        public ISourceCommandMethodMetadata[] GetDeclaredStaticMethods()
        {
            if (sourceCommandMethods == null)
                throw new InvalidOperationException("The complete source static method facts are not published.");
            return (ISourceCommandMethodMetadata[])sourceCommandMethods.Clone();
        }
    }
}
