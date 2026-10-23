using System;
using Celeste.Core.Reflection.Methods;
using Celeste.Game.Reflection.Metadata;
using Celeste.Game.Reflection.Metadata.Sdk;
using Celeste.Game.Profiles;

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
            sourceOriginalMethods = new SourceAssemblyMethodCatalog();
            SourceGameMethodMetadata.PublishOriginal(sourceOriginalMethods);
        }

        internal void PublishSourceCanonicalDrawRectangleBindings()
        {
            if (sourceDrawRectangleBindingsPublished)
                throw new InvalidOperationException(
                    "The canonical Draw/Rectangle source bindings are already published.");
            if (SourceProfile == GameProfile.Original)
            {
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaRectangleMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaVector2Metadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaColorMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                if (PhysicalIO.CompiledSourceDeployment != null)
                    SourceDrawRectanglePhysicalBindings.BindOriginalXnaCompiled(SourceMembers, CanonicalSourceMethods,
                        Draw);
                else
                    SourceDrawRectanglePhysicalBindings.BindOriginalXna(SourceMembers, CanonicalSourceMethods, Draw);
            }
            else
            {
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaRectangleMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaVector2Metadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaColorMetadata
                    .PublishMethodFacts(CanonicalSourceMethods);
                SourceDrawRectanglePhysicalBindings.BindInstalledFna(SourceMembers, CanonicalSourceMethods, Draw);
            }

            sourceDrawRectangleBindingsPublished = true;
        }
    }
}
