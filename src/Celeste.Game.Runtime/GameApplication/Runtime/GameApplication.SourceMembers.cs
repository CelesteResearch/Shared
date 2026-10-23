using Celeste.Core.Display;
using System;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Forwarders;
using Celeste.Core.Reflection.Intrinsics;
using Celeste.Game.Reflection.Metadata;
using Celeste.Game.Profiles;
using Celeste.Everest.Reflection;
using Celeste.Everest.Diagnostics.Logging;

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
            sourceTypeForwarders = new SourceTypeForwarderCatalog(SourceProfile.ToString());
            if (SourceProfile == GameProfile.InstalledEverest)
                SourceInstalledBclForwarderMetadata.Publish(sourceTypeForwarders);
            if (SourceProfile == GameProfile.Original)
            {
                sourceMembers = new SourceMemberCatalog(new SourceConsoleMemberLookupDiagnostics(SourceConsoleOutput),
                    sourceTypeForwarders);
                SourceIntrinsicMemberMetadata.PublishOriginalBcl(sourceMembers);
                SourceIntrinsicMemberMetadata.PublishOriginalXna(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaRectangleMetadata
                    .PublishMembersFacts(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaVector2Metadata
                    .PublishMembersFacts(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.OriginalXna.OriginalXnaColorMetadata
                    .PublishMembersFacts(sourceMembers);
                SourceGameMemberMetadata.PublishOriginal(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterOriginalBcl(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterOriginalXnaColor(sourceMembers,
                    typeof(global::Celeste.Core.Display.PackedColor));
                SourceIntrinsicPhysicalBindings.RegisterOriginalXnaVectors(sourceMembers);
            }
            else
            {
                sourceMembers = new SourceMemberCatalog(new EverestSourceMemberLookupDiagnostics(
                    ((IEverestLoggerProcessEnvironment)this).Logger), sourceTypeForwarders);
                SourceInstalledBclNecessaryMemberMetadata.Publish(sourceMembers);
                SourceIntrinsicMemberMetadata.PublishInstalledFna(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaRectangleMetadata
                    .PublishMembersFacts(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaVector2Metadata
                    .PublishMembersFacts(sourceMembers);
                global::Celeste.Game.Reflection.Metadata.Sdk.InstalledFna.InstalledFnaColorMetadata
                    .PublishMembersFacts(sourceMembers);
                SourceGameMemberMetadata.PublishInstalled(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterInstalledBcl(sourceMembers);
                SourceIntrinsicPhysicalBindings.RegisterInstalledFnaColor(sourceMembers,
                    typeof(global::Celeste.Core.Display.PackedColor));
                SourceIntrinsicPhysicalBindings.RegisterInstalledFnaVectors(sourceMembers);
            }

            const string gameAssembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            sourceMembers.RegisterSourceType(SourceProfile == GameProfile.InstalledEverest
                    ? typeof(global::Celeste.Everest.Runtime.Startup.EverestGameLoaderScene)
                    : typeof(global::Celeste.Game.Menus.Loading.GameLoaderScene),
                gameAssembly, "Celeste.GameLoader");
            sourceMembers.RegisterSourceType(SourceProfile == GameProfile.InstalledEverest
                    ? typeof(global::Celeste.Everest.Menus.Overworld.EverestOverworldSequence)
                    : typeof(global::Celeste.Game.Menus.Overworld.OverworldSequence),
                gameAssembly, "Celeste.Overworld");
            sourceMembers.RegisterSourceType(typeof(global::Celeste.Game.Menus.Overworld.OverworldLoaderSequence),
                gameAssembly, "Celeste.OverworldLoader");
            sourceMembers.RegisterSourceType(
                typeof(global::Celeste.Game.Execution.LevelLoader.OriginalLevelLoaderScene),
                gameAssembly, "Celeste.LevelLoader");
            sourceMembers.RegisterSourceType(typeof(global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot),
                gameAssembly, "Celeste.Level");

            sourceMembers.RegisterSourceType(typeof(global::Celeste.Graphics.Content.VirtualAssets.VirtualTexture),
                gameAssembly, "Monocle.VirtualTexture");

            PublishSourceOuiMembers();
            PublishSourceOverworldNavigationMembers();
            sourceMembers.BindActualTypeBindingSource(SceneCatalog);
            global::Celeste.Game.Reflection.Bindings.VirtualTexturePhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Startup.MainMenuPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.TextMenuPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.FallingBlockPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.BumperPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.DecalPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.StrawberryPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.SpikesPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.MoonCreaturePhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.FlyFeatherPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.CameraOffsetTriggerPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.CrushBlockPhysicalMemberBindings.Register(sourceMembers);
            global::Celeste.Game.Reflection.Bindings.DreamBlockPhysicalMemberBindings.Register(sourceMembers);
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                global::Celeste.Game.Reflection.Bindings.VirtualTexturePhysicalMemberBindings.RegisterInstalled(
                    sourceMembers);
                global::Celeste.Everest.Reflection.Bindings.DreamBlockInstalledPhysicalMemberBindings.Register(
                    sourceMembers);
                global::Celeste.Everest.Reflection.Bindings.CustomNpcPhysicalMemberBindings.Register(sourceMembers);
                global::Celeste.Everest.Reflection.Bindings.SmoothCameraOffsetTriggerPhysicalMemberBindings.Register(
                    sourceMembers);
            }
        }
    }
}
