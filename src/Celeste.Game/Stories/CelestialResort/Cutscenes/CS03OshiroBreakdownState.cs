using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Hazards.Spinners.Dust;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroBreakdownState : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_breakdown";

        private const int PlayerWalkTo = 200;

        private readonly List<OriginalDustStaticSpinnerState> creatures = [];

        private readonly List<Vector2> creatureHomes = [];

        private readonly OriginalNpcState oshiro;

        private readonly RoomPlayerSession player;

        private readonly Vector2 origin;

        private const int DustAmountA = 4;

        private readonly ISourceEngineContext engine;

        public CS03OshiroBreakdownState(ISourceEngineContext engine, RoomPlayerSession player,
            OriginalNpcState oshiro) :
            base(engine)
        {
            this.engine = engine;
            this.oshiro = oshiro;
            this.player = player;
            origin = oshiro.Position;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkTo(player.X - 64f)));
            var
                list = level.SourceScene.Entities.FindAll<OriginalDustStaticSpinnerState>();
            list.Shuffle(((ISourceRandomEnvironment)engine).Random);
            foreach (var item in list)
                if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(item.Position - oshiro.Position) < 128f)
                {
                    creatures.Add(item);
                    creatureHomes.Add(item.Position);
                    item.Visible = false;
                }

            yield return PanCamera(level.Bounds.Left);
            yield return 0.2f;
            yield return Level.ZoomTo(new(100f, 120f), 2f, 0.5f);
            yield return TextboxState.Say("CH3_OSHIRO_BREAKDOWN", engine, WalkLeft, WalkRight, CreateDustA,
                CreateDustB);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                oshiro.MoveTo(new(level.Bounds.Left - 64, oshiro.Y))));
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/char/oshiro/move_06_04d_exit"));
            yield return 0.25f;
            yield return PanCamera(player.CameraTarget.X);
            EndCutscene(level);
        }

        private IEnumerator PanCamera(float to)
        {
            var from = Level.Camera.X;
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                Level.Camera.X = from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p);
                yield return null;
            }
        }

        private IEnumerator WalkLeft()
        {
            (oshiro.Sprite as OshiroSpriteState).AllowSpriteChanges = false;
            yield return oshiro.MoveTo(origin + new Vector2(-24f, 0f));
            (oshiro.Sprite as OshiroSpriteState).AllowSpriteChanges = true;
        }

        private IEnumerator WalkRight()
        {
            (oshiro.Sprite as OshiroSpriteState).AllowSpriteChanges = false;
            yield return oshiro.MoveTo(origin + new Vector2(0f, 0f));
            (oshiro.Sprite as OshiroSpriteState).AllowSpriteChanges = true;
        }

        private IEnumerator CreateDustA()
        {
            var sourceSound = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            sourceSound.Position = oshiro.Position;
            sourceSound.Play("event:/game/03_resort/sequence_oshirofluff_pt1");
            OwnedComponents.Add(sourceSound);
            (oshiro.Sprite as OshiroSpriteState).AllowSpriteChanges = false;
            oshiro.Sprite.Play("fall");
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/oshiro/chat_collapse", oshiro.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            engine.Effects.AnxietyOrigin = new(0.5f, 0.5f);
            for (var i = 0; i < 4; i++)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, MoveDust(creatures[i], creatureHomes[i])));
                engine.Effects.Anxiety =
                    0.1f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.1f);
                if (i % 4 == 0)
                {
                    engine.Effects.Anxiety =
                        0.1f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.1f);
                    Level.Shake();
                    ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2,
                        1);
                    yield return 0.4f;
                }
                else
                {
                    yield return 0.1f;
                }
            }

            yield return 0.5f;
        }

        private IEnumerator CreateDustB()
        {
            var sourceSound = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            sourceSound.Position = oshiro.Position;
            sourceSound.Play("event:/game/03_resort/sequence_oshirofluff_pt2");
            OwnedComponents.Add(sourceSound);
            for (var i = 4; i < creatures.Count; i++)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, MoveDust(creatures[i], creatureHomes[i])));
                engine.Effects.Anxiety =
                    0.1f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.1f);
                Level.Shake();
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
                if ((i - 4) % 4 == 0)
                {
                    engine.Effects.Anxiety =
                        0.1f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.1f);
                    yield return 0.4f;
                }
                else
                {
                    yield return 0.1f;
                }
            }

            yield return 1f;
            while (engine.Effects.Anxiety > 0f)
            {
                engine.Effects.Anxiety -= engine.DeltaTime;
                yield return null;
            }

            yield return Level.ZoomBack(0.5f);
            yield return player.DummyWalkToExact(Level.Bounds.Left + 200);
            yield return 1f;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/oshiro/chat_get_up", oshiro.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            oshiro.Sprite.Play("recover");
            yield return 0.7f;
            oshiro.Sprite.Scale.X = 1f;
            yield return 0.5f;
        }

        private IEnumerator MoveDust(OriginalDustStaticSpinnerState creature, Vector2 to)
        {
            var vector = oshiro.Position + new Vector2(0f, -12f);
            var curve = new SimpleCurve(vector, to,
                (to + vector) / 2f + Vector2.UnitY *
                (-30f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 60f)));
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                yield return null;
                creature.Sprite.Scale = 0.5f + p * 0.5f;
                creature.Position = curve.GetPoint(((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p),
                    ((ISourceCurveEnvironment)engine).CurveArithmetic);
                creature.Visible = true;
                if (Level.OnInterval(0.02f))
                    Level.ParticlesBG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.DustStaticSpinner.P_Move, 1,
                        creature.Position, Vector2.One * 4f);
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            if (WasSkipped)
            {
                player.X = level.Bounds.Left + 200;
                while (!player.OnGround()) player.Y++;

                for (var i = 0; i < creatures.Count; i++)
                {
                    creatures[i].ForceInstantiate();
                    creatures[i].Visible = true;
                    creatures[i].Position = creatureHomes[i];
                }
            }

            level.Camera.Position = player.CameraTarget;
            oshiro.RemoveSelf();
            level.Session.SetFlag("oshiro_breakdown");
        }
    }
}
