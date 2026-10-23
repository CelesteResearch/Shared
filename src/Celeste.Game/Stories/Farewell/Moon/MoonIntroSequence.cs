using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.Farewell.Moon
{
    public class MoonIntroSequence : OriginalCutsceneEntityState
    {
        public const string Flag = "moon_intro";
        private readonly RoomPlayerSession player;
        private readonly ISourceEngineContext engine;
        private BadelineDummyPresentation badeline;
        private BirdNpcState bird;
        private float fade = 1f;
        private readonly float targetX;

        public MoonIntroSequence(RoomPlayerSession player, ISourceEngineContext engine)
            : base(engine)
        {
            Depth = -8500;
            this.player = player;
            this.engine = engine;
            targetX = player.CameraTarget.X + 8f;
        }

        private void PlaySourceSound(string name, Vector2 at)
        {
            var process = (IOriginalGameplayProcess)engine;
            process.AudioSession.Play(name, at, process.SaveContext);
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            bird = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<BirdNpcState>();
            player.Machine.State = 11;
            if (level.Wipe != null) level.Wipe.Cancel();
            _ = new FadeWipePresentation(level, true);
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Visible = false;
            player.Active = false;
            player.Data.Dashes = 2;
            for (var t = 0f; t < 1f; t += engine.DeltaTime / .9f)
            {
                level.Wipe.Percent = 0f;
                yield return null;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, FadeIn(5f)));
            level.Camera.Position = level.LevelOffset + new Vector2(-100f, 0f);
            yield return CameraTo(engine, new(targetX, level.Camera.Y), 6f,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut);
            level.Camera.Position = new(targetX, level.Camera.Y);
            if (bird != null)
            {
                yield return bird.StartleAndFlyAway();
                level.Session.DoNotLoad.Add(bird.EntityID);
                bird = null;
            }

            yield return .5f;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Position = level.GetSpawnPoint(player.Position);
            player.Active = true;
            player.Machine.State = 23;
            while (player.Top > level.Bounds.Bottom) yield return null;
            yield return .2f;
            PlaySourceSound("event:/new_content/char/madeline/screenentry_lowgrav", player.Position);
            while (player.Machine.State == 23) yield return null;
            player.Position = new((int)player.Position.X, (int)player.Position.Y);
            while (!player.OnGround() && player.Bottom < level.Bounds.Bottom) player.MoveVExact(16);
            player.Machine.State = 11;
            yield return .5f;
            yield return BadelineAppears();
            yield return TextboxState.Say("CH9_LANDING", engine, BadelineTurns,
                BadelineVanishes);
            EndCutscene(level);
        }

        private IEnumerator BadelineTurns()
        {
            yield return .1f;
            var num = Math.Sign(badeline.Sprite.Scale.X);
            var target = num * -1;
            var component = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(
                .5f,
                3f,
                v => badeline.Sprite.Scale = new Vector2(target, 1f) * (1f + .2f * v),
                true, true);
            OwnedComponents.Add(component);
            PlaySourceSound(target < 0 ? "event:/char/badeline/jump_wall_left" : "event:/char/badeline/jump_wall_left",
                badeline.Position);
            yield return .6f;
        }

        private IEnumerator BadelineAppears()
        {
            Level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            badeline = BadelineDummyPresentation.Create(Level, player.Position);
            ((ISourceScene)Level).SourceScene.QueueSourceEntity(badeline);
            Level.Displacement.AddBurst(player.Center, .5f, 8f, 32f, .5f);
            PlaySourceSound("event:/char/badeline/maddy_split", player.Position);
            badeline.Sprite.Scale.X = 1f;
            yield return badeline.FloatTo(player.Position + new Vector2(-16f, -16f), 1, false);
            player.Data.Facing = -1;
            yield return null;
        }

        private IEnumerator BadelineVanishes()
        {
            yield return .5f;
            badeline.Vanish();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            badeline = null;
            yield return .8f;
            player.Data.Facing = 1;
            yield return .6f;
        }

        private IEnumerator FadeIn(float duration)
        {
            while (fade > 0f)
            {
                fade = ScalarMath.Approach(fade, 0f, engine.DeltaTime / duration,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            player.Depth = 0;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Position = level.GetSpawnPoint(player.Position) + new Vector2(0f, -32f);
            player.Active = true;
            player.Visible = true;
            player.Machine.State = 0;
            player.Position = new((int)player.Position.X, (int)player.Position.Y);
            while (!player.OnGround() && player.Bottom < level.Bounds.Bottom) player.MoveVExact(16);
            if (badeline != null) badeline.RemoveSelf();
            if (bird != null)
            {
                bird.RemoveSelf();
                level.Session.DoNotLoad.Add(bird.EntityID);
            }

            level.Camera.Position = new(targetX, level.Camera.Y);
            level.Session.SetFlag(Flag);
        }

        public override void Render(ISourceRenderContext context)
        {
            var camera = (Scene as OriginalLevelSceneRoot).Camera;
            SourcePrimitiveDrawing.Rect(context, this, camera.X - 10f, camera.Y - 10f, 340f, 200f,
                PackedColor.Black * fade);
        }
    }
}
