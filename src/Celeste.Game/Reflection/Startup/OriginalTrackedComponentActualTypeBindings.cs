using Celeste.Core.Components.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Switches;
using Celeste.Game.Gameplay.Assists.Solids;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Hazards.Puffer;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalTrackedComponentActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(
                typeof(SolidOnInvinciblePlayerState),
                "Celeste.SolidOnInvinciblePlayer");
            catalog.RegisterRuntimeType(typeof(PlayerHair),
                "Celeste.PlayerHair");
            catalog.RegisterRuntimeType(typeof(OriginalSwitchComponent),
                "Celeste.Switch");
            catalog.RegisterRuntimeType(
                typeof(Snow3DState.Particle),
                "Celeste.Snow3D.Particle");
            catalog.RegisterRuntimeType(
                typeof(MoonParticle3DState.Particle),
                "Celeste.MoonParticle3D.Particle");
            catalog.RegisterRuntimeType(typeof(BillboardState),
                "Celeste.Billboard");
            catalog.RegisterRuntimeType(
                typeof(DisplacementRenderHookState),
                "Celeste.DisplacementRenderHook");
            catalog.RegisterRuntimeType(typeof(RoomTransitionListener),
                "Celeste.TransitionListener");
            catalog.RegisterRuntimeType(typeof(WindMoverState),
                "Celeste.WindMover");
            catalog.RegisterRuntimeType(
                typeof(OriginalGrannyLaughSfxState),
                "Celeste.GrannyLaughSfx");
            catalog.RegisterRuntimeType(typeof(SimulationCoroutine),
                "Monocle.Coroutine");
            catalog.RegisterRuntimeType(typeof(TileGrid), "Monocle.TileGrid");
            catalog.RegisterRuntimeType(typeof(AnimatedTiles),
                "Celeste.AnimatedTiles");
            catalog.RegisterRuntimeType(typeof(TileInterceptorState),
                "Celeste.TileInterceptor");
            catalog.RegisterRuntimeType(typeof(ShakerComponentState),
                "Monocle.Shaker");
            catalog.RegisterRuntimeType(typeof(SoundSourceComponentState),
                "Celeste.SoundSource");
            catalog.RegisterRuntimeType(typeof(DeathsCounterState),
                "Celeste.DeathsCounter");
            catalog.RegisterRuntimeType(
                typeof(StrawberriesCounterState),
                "Celeste.StrawberriesCounter");
            catalog.RegisterRuntimeType(
                typeof(OriginalFlaglineState), "Celeste.Flagline");
            catalog.RegisterRuntimeType(
                typeof(WaterInteractionState),
                "Celeste.WaterInteraction");
            catalog.RegisterRuntimeType(
                typeof(DustGraphicState),
                "Celeste.DustGraphic");
            catalog.RegisterRuntimeType(
                typeof(DustEdgePresentation),
                "Celeste.DustEdge");
            catalog.RegisterRuntimeType(
                typeof(LedgeBlockerState),
                "Celeste.LedgeBlocker");
            catalog.RegisterRuntimeType(
                typeof(ClimbBlockerState),
                "Celeste.ClimbBlocker");
            catalog.RegisterRuntimeType(
                typeof(SafeGroundBlockerComponentState), "Celeste.SafeGroundBlocker");
            catalog.RegisterRuntimeType(
                typeof(PlayerColliderComponentState),
                "Celeste.PlayerCollider");
            catalog.RegisterRuntimeType(typeof(HoldableColliderState),
                "Celeste.HoldableCollider");
            catalog.RegisterRuntimeType(typeof(SeekerColliderState),
                "Celeste.SeekerCollider");
            catalog.RegisterRuntimeType(
                typeof(SourceStaticMoverState),
                "Celeste.StaticMover");
            catalog.RegisterRuntimeType(
                typeof(CoreModeListenerState),
                "Celeste.CoreModeListener");
            catalog.RegisterRuntimeType(
                typeof(BeforeRenderCallbackComponentState),
                "Celeste.BeforeRenderHook");
            catalog.RegisterRuntimeType(
                typeof(MirrorReflectionState),
                "Celeste.MirrorReflection");
            catalog.RegisterRuntimeType(typeof(DashListenerState),
                "Celeste.DashListener");
            catalog.RegisterRuntimeType(typeof(LightOccludeState),
                "Celeste.LightOcclude");
            catalog.RegisterRuntimeType(typeof(EffectCutoutState),
                "Celeste.EffectCutout");
            catalog.RegisterRuntimeType(typeof(HoldableState),
                "Celeste.Holdable");
            catalog.RegisterRuntimeType(typeof(PufferColliderState),
                "Celeste.PufferCollider");
            catalog.RegisterRuntimeType(typeof(Sprite), "Monocle.Sprite");
            catalog.RegisterRuntimeType(typeof(SpriteImage), "Monocle.Image");
            catalog.RegisterRuntimeType(typeof(SimulationStateMachine),
                "Monocle.StateMachine");
            catalog.RegisterRuntimeType(typeof(SineWaveState),
                "Monocle.SineWave");
            catalog.RegisterRuntimeType(typeof(WigglerComponent),
                "Monocle.Wiggler");
            catalog.RegisterRuntimeType(typeof(VertexLightState),
                "Celeste.VertexLight");
            catalog.RegisterRuntimeType(
                typeof(BloomPointState),
                "Celeste.BloomPoint");
            catalog.RegisterRuntimeType(
                typeof(CustomBloomCallbackComponentState),
                "Celeste.CustomBloom");
            catalog.RegisterRuntimeType(typeof(ScenePostUpdateHook),
                "Celeste.PostUpdateHook");
            catalog.RegisterRuntimeType(typeof(LevelEndingHookState),
                "Celeste.LevelEndingHook");
            catalog.RegisterRuntimeType(typeof(RoomCameraLocker),
                "Celeste.CameraLocker");
            catalog.RegisterRuntimeType(
                typeof(MirrorSurfaceState),
                "Celeste.MirrorSurface");
        }
    }
}
