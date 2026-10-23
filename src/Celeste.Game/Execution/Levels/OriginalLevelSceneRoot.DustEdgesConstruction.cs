using System;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IDustEdgesRenderScene, IDustGraphicScene
    {
        public DustEdgesPresentation DustEdges { get; private set; }
        CameraState IDustEdgesRenderScene.Camera => Camera;
        VirtualRenderTarget IDustEdgesRenderScene.DustTempA => Buffers.TempA;
        VirtualRenderTarget IDustEdgesRenderScene.ResortDust => Buffers.ResortDust;
        SourceEffect IDustEdgesRenderScene.DustEffect => graphicsResources.FxDust;
        int IDustEdgesRenderScene.DustAreaId => Session.AreaID;

        bool IDustEdgesRenderScene.UseSafeDustTextures =>
            ((IGameProfileEnvironment)EngineContext).SourceProfile ==
            GameProfile.InstalledEverest;

        public void ConstructSourceDustEdges()
        {
            if (DustEdges != null) throw new InvalidOperationException("This Level already constructed its DustEdges.");
            DustEdges = new(EngineContext);
            Scheduler.QueueSourceEntity(DustEdges);
        }
    }
}
