using System;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Reflection;
using Celeste.Game.Audio;
using Celeste.Game.Reflection.Metadata;
using Celeste.Game.Reflection.Metadata.Resources;
using Celeste.Game.Runtime.Reflection.Members;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEverestReflectionEnvironment,
        ISourceEverestReflectionAssemblyEnvironment, ISourceEverestModulesProcessEnvironment
    {
        private SourceEverestReflectionProcessState sourceReflection;

        public SourceEverestReflectionProcessState Reflection => sourceReflection ??
                                                                 throw new InvalidOperationException(
                                                                     "The actual Installed reflection process has not been constructed.");

        public string OriginalGameAssemblyIdentity =>
            SourceMembers.GetOriginalTypeDefinition(typeof(OriginalSfxProcess)).AssemblyIdentity;

        internal void ConstructSourceInstalledReflection()
        {
            if (sourceReflection != null)
                throw new InvalidOperationException("The actual Installed reflection process is already constructed.");
            sourceReflection = new(this, this, SourceMembers);
            PublishSourceInstalledTextInputMemberOwner();
            SourceGamePhysicalTypeBindings.Register(SceneCatalog, SourceMembers, true);
            SourceLevelSessionMemberBinding.Register(SourceMembers);
            SourceLevelPublicMemberBindings.Register(SourceMembers);
            PublishSourceEngineSceneMemberOwner();
            SourceGameMethodMetadata.PublishInstalled(sourceReflection.SourceMethods);
            SourceGameEmbeddedResources.PublishInstalled(
                sourceReflection.SourceResources);
        }
    }
}
