using Celeste.Core.Display;
using Celeste.Core.Mathematics.LinearAlgebra;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Display;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Entities.Machines.WaveDash
{
    public class OriginalWaveDashTutorialMachineState : SourceJumpThruEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly ISourceSolidWorldFactory worlds;

        private static RoomPlayerSession FirstPlayer(SceneEntityRegistry entities)
        {
            var list = entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            return list.Count > 0 ? list[0] as RoomPlayerSession : null;
        }

        private SceneEntityState frontEntity;

        private SpriteImage backSprite;

        private SpriteImage frontRightSprite;

        private SpriteImage frontLeftSprite;

        private Sprite noise;

        private Sprite neon;

        private SourceSolidEntityState frontWall;

        private float insideEase;

        private float cameraEase;

        private bool playerInside;

        private bool inCutscene;

        private SimulationCoroutine routine;

        private OriginalWaveDashPresentationState presentation;

        private float interactStartZoom;

        private FmodEventReference snapshot;

        private FmodEventReference usingSfx;

        private SoundSourceComponentState signSfx;

        private OriginalTalkComponent talk;

        public OriginalWaveDashTutorialMachineState(Vector2 position, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds)
            : base(position, 88, true, worlds.CreateJumpThru(position, true))
        {
            this.engine = engine;
            this.worlds = worlds;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            base.Depth = 1000;
            ((HitboxColliderGeometry)Collider).Position = new Vector2(-41f, -59f);
            Add(backSprite =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        "objects/wavedashtutorial/building_back"]));
            backSprite.JustifyOrigin(0.5f, 1f);
            Add(noise = new Sprite(engine, ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas,
                "objects/wavedashtutorial/noise"));
            noise.AddLoop("static", "", 0.05f);
            noise.Play("static");
            noise.CenterOrigin();
            noise.Position = new Vector2(0f, -30f);
            noise.Color = PackedColor.White * 0.5f;
            Add(frontLeftSprite =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        "objects/wavedashtutorial/building_front_left"]));
            frontLeftSprite.JustifyOrigin(0.5f, 1f);
            Add(talk = new OriginalTalkComponent((IOriginalTalkProcess)engine, new IntRect(-12, -8, 24, 8),
                new Vector2(0f, -50f), OnInteract));
            talk.Enabled = false;
            SurfaceSoundIndex = 42;
        }

        public OriginalWaveDashTutorialMachineState(EntityData data, Vector2 position,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds)
            : this(data.Position + position, engine, worlds)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(frontEntity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                    Position));
            frontEntity.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            frontEntity.Depth = -10500;
            frontEntity.Add(frontRightSprite =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        "objects/wavedashtutorial/building_front_right"]));
            frontRightSprite.JustifyOrigin(0.5f, 1f);
            frontEntity.Add(neon = new Sprite(engine, ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas,
                "objects/wavedashtutorial/neon_"));
            neon.AddLoop("loop", "", 0.07f);
            neon.Play("loop");
            neon.JustifyOrigin(0.5f, 1f);
            var frontWallPosition = SourceVector2Math.Add(Position, new Vector2(-41f, -59f));
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(frontWall =
                new SourceSolidEntityState(frontWallPosition, 88f, 38f, true, worlds.Create(frontWallPosition, true)));
            frontWall.SurfaceSoundIndex = 42;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            Add(signSfx =
                new SoundSourceComponentState(engine, new Vector2(8f, -16f), "event:/new_content/env/local/cafe_sign"));
        }

        public override void Update()
        {
            base.Update();
            if (!inCutscene)
            {
                RoomPlayerSession entity = FirstPlayer(((ISourceScene)Scene).SourceScene.Entities);
                if (entity != null)
                {
                    frontWall.Collidable = true;
                    bool flag = (entity.X > base.X - 37f && entity.X < base.X + 46f && entity.Y > base.Y - 58f) ||
                                SourceEntityCollision.Check(frontWall, entity);
                    if (flag != playerInside)
                    {
                        playerInside = flag;
                        if (playerInside)
                        {
                            signSfx.Stop();
                            snapshot = ((IOriginalGameplayProcess)engine).AudioSession.CreateSnapshot(
                                "snapshot:/game_10_inside_cafe");
                        }
                        else
                        {
                            signSfx.Play("event:/new_content/env/local/cafe_sign");
                            ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
                            snapshot = null;
                        }
                    }
                }

                ((OriginalLevelSceneRoot)Scene).ZoomSnap(new Vector2(160f, 90f),
                    1f + ((ISourceEasingEnvironment)engine).EasingArithmetic.QuadInOut(cameraEase) * 0.75f);
            }

            talk.Enabled = playerInside;
            frontWall.Collidable = !playerInside;
            insideEase = ScalarMath.Approach(insideEase, playerInside ? 1f : 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            cameraEase = ScalarMath.Approach(cameraEase, playerInside ? 1f : 0f, engine.DeltaTime * 2f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            frontRightSprite.Color = PackedColor.White * (1f - insideEase);
            frontLeftSprite.Color = frontRightSprite.Color;
            neon.Color = frontRightSprite.Color;
            frontRightSprite.Visible = insideEase < 1f;
            frontLeftSprite.Visible = insideEase < 1f;
            neon.Visible = insideEase < 1f;
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
            {
                noise.Scale = ((ISourceRandomEnvironment)engine).Random.Choose(new Vector2(1f, 1f),
                    new Vector2(-1f, 1f),
                    new Vector2(1f, -1f), new Vector2(-1f, -1f));
            }
        }

        private void OnInteract(RoomPlayerSession player)
        {
            if (!inCutscene)
            {
                OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
                if (usingSfx != null)
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.SetParameter(usingSfx, "end", 1f);
                    usingSfx.Stop();
                }

                inCutscene = true;
                interactStartZoom = level.ZoomTarget;
                level.StartCutscene(SkipInteraction, fadeInOnSkip: true, endingChapterAfterCutscene: false,
                    resetZoomOnSkip: false);
                Add(routine = new SimulationCoroutine(engine, InteractRoutine(player)));
            }
        }

        private IEnumerator InteractRoutine(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return OriginalCutsceneEntityState.CameraTo(engine,
                SourceVector2Math.Subtract(new Vector2(base.X, base.Y - 30f), new Vector2(160f, 90f)), 0.25f,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut);
            yield return level.ZoomTo(new Vector2(160f, 90f), 10f, 1f);
            usingSfx = ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/state/cafe_computer_active",
                player.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/cafe_computer_on",
                player.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/game/10_farewell/cafe_computer_startupsfx", player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            presentation = new OriginalWaveDashPresentationState(engine, usingSfx);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(presentation);
            while (presentation.Viewing)
            {
                yield return null;
            }

            yield return level.ZoomTo(new Vector2(160f, 90f), interactStartZoom, 1f);
            player.Machine.Locked = false;
            player.Machine.State = 0;
            inCutscene = false;
            level.EndCutscene();
            ((IOriginalGameplayProcess)engine).AudioSession.SetAltMusic(null);
        }

        private void SkipInteraction(OriginalLevelSceneRoot level)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.SetAltMusic(null);
            inCutscene = false;
            level.ZoomSnap(new Vector2(160f, 90f), interactStartZoom);
            if (usingSfx != null)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetParameter(usingSfx, "end", 1f);
                usingSfx.Release();
            }

            if (presentation != null)
            {
                presentation.RemoveSelf();
            }

            presentation = null;
            if (routine != null)
            {
                routine.RemoveSelf();
            }

            routine = null;
            RoomPlayerSession entity = FirstPlayer(level.Scheduler.Entities);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        private void Dispose()
        {
            if (usingSfx != null)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetParameter(usingSfx, "quit", 1f);
                usingSfx.Release();
                usingSfx = null;
            }

            ((IOriginalGameplayProcess)engine).AudioSession.ReleaseSnapshot(snapshot);
            snapshot = null;
        }
    }
}
