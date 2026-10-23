using System;
using Celeste.Core.Reflection.Methods;
using Celeste.Game.Profiles;
using Celeste.Game.Reflection.Metadata;
using Celeste.Game.Reflection.Metadata.Sdk;
using Celeste.Game.Reflection.Metadata.Sdk.InstalledFna;
using Celeste.Game.Reflection.Metadata.Sdk.OriginalXna;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceAssemblyMethodCatalog sourceOriginalMethods;
        private bool sourceDrawRectangleBindingsPublished;

        public SourceAssemblyMethodCatalog CanonicalSourceMethods =>
            SourceProfile == GameProfile.Original
                ? sourceOriginalMethods ??
                  throw new InvalidOperationException("The original source method catalog is not constructed.")
                : Reflection.SourceMethods;

        internal void ConstructSourceOriginalMethodMetadata()
        {
            if (SourceProfile != GameProfile.Original || sourceOriginalMethods != null)
                throw new InvalidOperationException(
                    "The selected original source method catalog must be constructed once.");
            sourceOriginalMethods = new();
            SourceGameMethodMetadata.PublishOriginal(sourceOriginalMethods);
        }

        internal void PublishSourceCanonicalDrawRectangleBindings()
        {
            if (sourceDrawRectangleBindingsPublished)
                throw new InvalidOperationException(
                    "The canonical Draw/Rectangle source bindings are already published.");
            if (SourceProfile == GameProfile.Original)
            {
                OriginalXnaRectangleMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                OriginalXnaVector2Metadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                OriginalXnaColorMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                if (PhysicalIO.CompiledSourceDeployment != null)
                    SourceDrawRectanglePhysicalBindings.BindOriginalXnaCompiled(SourceMembers, CanonicalSourceMethods,
                        Draw);
                else
                    SourceDrawRectanglePhysicalBindings.BindOriginalXna(SourceMembers, CanonicalSourceMethods, Draw);
            }
            else
            {
                InstalledFnaRectangleMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                InstalledFnaVector2Metadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                InstalledFnaColorMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                SourceDrawRectanglePhysicalBindings.BindInstalledFna(SourceMembers, CanonicalSourceMethods, Draw);
            }

            sourceDrawRectangleBindingsPublished = true;
        }
    }
}
