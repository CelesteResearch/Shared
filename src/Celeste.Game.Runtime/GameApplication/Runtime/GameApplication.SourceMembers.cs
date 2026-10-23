using System;
using Celeste.Core.Display;
using Celeste.Core.Reflection.Forwarders;
using Celeste.Core.Reflection.Intrinsics;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Menus.Overworld;
using Celeste.Everest.Reflection;
using Celeste.Everest.Reflection.Bindings;
using Celeste.Everest.Runtime.Startup;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Profiles;
using Celeste.Game.Reflection.Bindings;
using Celeste.Game.Reflection.Metadata;
using Celeste.Game.Reflection.Metadata.Sdk.InstalledFna;
using Celeste.Game.Reflection.Metadata.Sdk.OriginalXna;
using Celeste.Game.Reflection.Startup;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceMemberCatalog sourceMembers;
        private SourceTypeForwarderCatalog sourceTypeForwarders;

        public SourceMemberCatalog SourceMembers => sourceMembers ??
                                                    throw new InvalidOperationException(
                                                        "The actual source member catalog has not been constructed.");

        internal void ConstructSourceMembers()
        {
            if (sourceMembers != null || sourceTypeForwarders != null)
                throw new InvalidOperationException("The actual source member catalog is already constructed.");
            if (SourceProfile != GameProfile.Original &&
                SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The actual source profile has not been selected.");
            sourceTypeForwarders = new(SourceProfile.ToString());
            if (SourceProfile == GameProfile.InstalledEverest)
                SourceInstalledBclForwarderMetadata.Publish(sourceTypeForwarders);
            if (SourceProfile == GameProfile.Original)
            {
                sourceMembers = new(new SourceConsoleMemberLookupDiagnostics(SourceConsoleOutput),
                    sourceTypeForwarders);
                SourceIntrinsicMemberMetadata.PublishOriginalBcl(sourceMembers);
                SourceIntrinsicMemberMetadata.PublishOriginalXna(sourceMembers);
                OriginalXnaRectangleMetadata
                    .PublishMembersFacts(sourceMembers);
                OriginalXnaVector2Metadata
                    .PublishMembersFacts(sourceMembers);
                OriginalXnaColorMetadata
                    .PublishMembersFacts(sourceMembers);
                SourceGameMemberMetadata.PublishOriginal(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterOriginalBcl(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterOriginalXnaColor(sourceMembers,
                    typeof(PackedColor));
                SourceIntrinsicPhysicalBindings.RegisterOriginalXnaVectors(sourceMembers);
            }
            else
            {
                sourceMembers = new(new EverestSourceMemberLookupDiagnostics(
                    Logger), sourceTypeForwarders);
                SourceInstalledBclNecessaryMemberMetadata.Publish(sourceMembers);
                SourceIntrinsicMemberMetadata.PublishInstalledFna(sourceMembers);
                InstalledFnaRectangleMetadata
                    .PublishMembersFacts(sourceMembers);
                InstalledFnaVector2Metadata
                    .PublishMembersFacts(sourceMembers);
                InstalledFnaColorMetadata
                    .PublishMembersFacts(sourceMembers);
                SourceGameMemberMetadata.PublishInstalled(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterInstalledBcl(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterInstalledFnaColor(sourceMembers,
                    typeof(PackedColor));
                SourceIntrinsicPhysicalBindings.RegisterInstalledFnaVectors(sourceMembers);
            }

            const string gameAssembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            sourceMembers.RegisterSourceType(SourceProfile == GameProfile.InstalledEverest
                    ? typeof(EverestGameLoaderScene)
                    : typeof(GameLoaderScene),
                gameAssembly, "Celeste.GameLoader");
            sourceMembers.RegisterSourceType(SourceProfile == GameProfile.InstalledEverest
                    ? typeof(EverestOverworldSequence)
                    : typeof(OverworldSequence),
                gameAssembly, "Celeste.Overworld");
            sourceMembers.RegisterSourceType(typeof(OverworldLoaderSequence),
                gameAssembly, "Celeste.OverworldLoader");
            sourceMembers.RegisterSourceType(
                typeof(OriginalLevelLoaderScene),
                gameAssembly, "Celeste.LevelLoader");
            sourceMembers.RegisterSourceType(typeof(OriginalLevelSceneRoot),
                gameAssembly, "Celeste.Level");

            sourceMembers.RegisterSourceType(typeof(VirtualTexture),
                gameAssembly, "Monocle.VirtualTexture");

            PublishSourceOuiMembers();
            PublishSourceOverworldNavigationMembers();
            sourceMembers.BindActualTypeBindingSource(SceneCatalog);
            VirtualTexturePhysicalMemberBindings.Register(sourceMembers);
            MainMenuPhysicalMemberBindings.Register(sourceMembers);
            TextMenuPhysicalMemberBindings.Register(sourceMembers);
            FallingBlockPhysicalMemberBindings.Register(sourceMembers);
            BumperPhysicalMemberBindings.Register(sourceMembers);
            DecalPhysicalMemberBindings.Register(sourceMembers);
            StrawberryPhysicalMemberBindings.Register(sourceMembers);
            SpikesPhysicalMemberBindings.Register(sourceMembers);
            MoonCreaturePhysicalMemberBindings.Register(sourceMembers);
            FlyFeatherPhysicalMemberBindings.Register(sourceMembers);
            CameraOffsetTriggerPhysicalMemberBindings.Register(sourceMembers);
            CrushBlockPhysicalMemberBindings.Register(sourceMembers);
            DreamBlockPhysicalMemberBindings.Register(sourceMembers);
            if (!(SourceProfile == GameProfile.InstalledEverest))
                return;
            VirtualTexturePhysicalMemberBindings.RegisterInstalled(
                sourceMembers);
            DreamBlockInstalledPhysicalMemberBindings.Register(
                sourceMembers);
            CustomNpcPhysicalMemberBindings.Register(sourceMembers);
            SmoothCameraOffsetTriggerPhysicalMemberBindings.Register(
                sourceMembers);
        }
    }
}
