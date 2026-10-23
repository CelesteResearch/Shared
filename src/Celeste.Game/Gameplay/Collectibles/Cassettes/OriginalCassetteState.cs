using Celeste.Core.Display;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Collectibles.Cassettes
{
    public class OriginalCassetteState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalGameTextProcess TextProcess => ((IOriginalGameTextEnvironment)engine).Text;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;


        public bool IsGhost;

        private Sprite sprite;

        private SineWaveState hover;

        private BloomPointState bloom;

        private VertexLightState light;

        private WigglerComponent scaleWiggler;

        private bool collected;

        private Vector2[] nodes;

        private ISourceAudioEventReference remixSfx;

        private bool collecting;

        public OriginalCassetteState(Vector2 position, Vector2[] nodes, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            base.Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            this.nodes = nodes;
            Add(new PlayerColliderComponentState(OnPlayer));
        }

        public OriginalCassetteState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.NodesOffset(offset), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            IsGhost = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(Process.SaveContext
                    .CurrentSave)[
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys
                    .GetSessionArea(((OriginalLevelSceneRoot)Scene).Session)
                    .ID]
                .Cassette;
            Add(sprite = Graphics.SpriteBank.Create(IsGhost ? "cassetteGhost" : "cassette"));
            sprite.Play("idle");
            Add(scaleWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f + f * 0.25f); }));
            Add(bloom = new BloomPointState(0.25f, 16f));
            Add(light = new VertexLightState(engine, PackedColor.White, 0.4f, 32, 64));
            Add(hover = new SineWaveState(engine, 0.5f));
            hover.OnUpdate = delegate(float f)
            {
                Sprite obj = sprite;
                VertexLightState vertexLight = light;
                float num = (bloom.Y = f * 2f);
                float y = (vertexLight.Y = num);
                obj.Y = y;
            };
            if (IsGhost)
            {
                sprite.Color = PackedColor.White * 0.8f;
            }
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(remixSfx);
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(remixSfx);
        }

        public override void Update()
        {
            base.Update();
            if (!collecting && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine))
            {
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(Process.ParticleTypes.Cassette.P_Shine, 1, base.Center,
                    new Vector2(12f, 10f));
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!collected)
            {
                player?.RefillStamina();
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/cassette_get",
                    Position);
                collected = true;
                ((ISourceFreezeEnvironment)engine).Freeze(0.1f);
                Add(new SimulationCoroutine(engine, CollectRoutine(player)));
            }
        }

        private IEnumerator CollectRoutine(RoomPlayerSession player)
        {
            collecting = true;
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            OriginalCassetteBlockManagerState cbm =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalCassetteBlockManagerState>(
                    "Celeste.CassetteBlockManager");
            level.PauseLock = true;
            level.Frozen = true;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            level.Session.Cassette = true;
            level.Session.RespawnPoint = level.GetSpawnPoint(nodes[1]);
            level.Session.UpdateLevelStartDashes();
            ((IOriginalSaveCassetteEnvironment)engine).SaveCassette.RegisterCassette(Process.SaveContext.CurrentSave,
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session));
            cbm?.StopBlocks();
            base.Depth = -1000000;
            level.Shake();
            level.Flash(PackedColor.White);
            level.Displacement.Clear();
            Vector2 camWas = level.Camera.Position;
            Vector2 camTo = Vector2Clamping.Clamp(Position - new Vector2(160f, 90f), level.Bounds.Left - 64,
                level.Bounds.Top - 32, level.Bounds.Right + 64 - 320, level.Bounds.Bottom + 32 - 180);
            level.Camera.Position = camTo;
            level.ZoomSnap(Vector2Clamping.Clamp(Position - level.Camera.Position, 60f, 60f, 260f, 120f), 2f);
            sprite.Play("spin", restart: true);
            sprite.Rate = 2f;
            for (float p = 0f; p < 1.5f; p += engine.DeltaTime)
            {
                sprite.Rate += engine.DeltaTime * 4f;
                yield return null;
            }

            sprite.Rate = 0f;
            sprite.SetAnimationFrame(0);
            scaleWiggler.Start();
            yield return 0.25f;
            Vector2 from = Position;
            Vector2 to = new Vector2(base.X, level.Camera.Top - 16f);
            float duration = 0.4f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                sprite.Scale.X = ScalarMath.Lerp(1f, 0.1f, p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                sprite.Scale.Y = ScalarMath.Lerp(1f, 3f, p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                Position = Vector2Interpolation.Lerp(from, to, Easing.CubeIn(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            Visible = false;
            remixSfx = Process.AudioSession.Play("event:/game/general/cassette_preview", "remix",
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).ID);
            UnlockedBSideState message = new UnlockedBSideState(engine);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(message);
            yield return message.EaseIn();
            while (!((Celeste.Input.Gameplay.IGameInputEnvironment)engine)
                   .Input[Celeste.Input.Gameplay.GameAction.MenuConfirm].Pressed)
            {
                yield return null;
            }

            Process.AudioSession.SetParameter(remixSfx, "end", 1f);
            yield return message.EaseOut();
            duration = 0.25f;
            Add(new SimulationCoroutine(engine, level.ZoomBack(duration - 0.05f)));
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                level.Camera.Position = Vector2Interpolation.Lerp(camTo, camWas, Easing.SineInOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            if (!player.Dead && nodes != null && nodes.Length >= 2)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/cassette_bubblereturn",
                    level.Camera.Position + new Vector2(160f, 90f));
                player.StartCassetteFly(nodes[1], nodes[0]);
            }

            foreach (OriginalSandwichLavaState item in level.Scheduler.Entities.FindAll<OriginalSandwichLavaState>())
            {
                item.Leave();
            }

            level.Frozen = false;
            yield return 0.25f;
            cbm?.Finish();
            level.PauseLock = false;
            level.ResetZoom();
            RemoveSelf();
        }
    }
}
