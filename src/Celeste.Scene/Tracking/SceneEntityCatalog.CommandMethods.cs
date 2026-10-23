using System;
using System.Reflection;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        public void PublishDeclaredCommandMethods(string identity, ISourceCommandMethodMetadata[] methods)
        {
            foreach (var type in types.Values)
                if (type.Identity == identity)
                {
                    type.PublishDeclaredCommandMethods(methods);
                    RepublishTrackingSnapshot();
                    return;
                }

            throw new InvalidOperationException("Source type facts must be published first.");
        }

        public void BindActualCommandMethod(string identity, int sourceMethodToken, MethodInfo method)
        {
            var type = FindLogicalMetadata(identity) ??
                       throw new InvalidOperationException("Source type facts are missing.");
            foreach (var sourceMethod in type.GetDeclaredStaticMethods())
                if (sourceMethod.MetadataToken == sourceMethodToken)
                {
                    ((SourceCommandMethodFacts)sourceMethod).BindActualMethod(method);
                    return;
                }

            throw new InvalidOperationException("The exact source method token is not published.");
        }
    }
}
