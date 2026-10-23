using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Environment.Wind;

namespace Celeste.Game.Entities.Environment.Wind
{
    public class OriginalWindController : SceneEntityState
    {
        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;

        private RoomWindPattern pattern;

        private Vector2 targetSpeed;

        private SimulationCoroutine coroutine;

        private readonly RoomWindPattern startPattern;

        private bool everSetPattern;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public RoomWindPattern CurrentPattern => pattern;
        public Vector2 TargetSpeed => targetSpeed;

        public OriginalWindController(RoomWindPattern pattern, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            AddTag(((ISourcePersistentTransitionExecutionTagsEnvironment)engine)
                .PersistentTransitionExecutionTags.TransitionUpdate.Value);
            startPattern = pattern;
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            level = Scene as OriginalLevelSceneRoot;
        }

        public void SetStartPattern()
        {
            if (!everSetPattern) SetPattern(startPattern);
        }

        public void SetPattern(RoomWindPattern pattern)
        {
            if (CurrentPattern != pattern || !everSetPattern)
            {
                everSetPattern = true;
                this.pattern = pattern;
                if (coroutine != null)
                {
                    OwnedComponents.Remove(coroutine);
                    coroutine = null;
                }

                switch (pattern)
                {
                    case RoomWindPattern.None:
                        targetSpeed = Vector2.Zero;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.Left:
                        targetSpeed.X = -400f;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.Right:
                        targetSpeed.X = 400f;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.LeftStrong:
                        targetSpeed.X = -800f;
                        SetAmbienceStrength(true);
                        break;
                    case RoomWindPattern.RightStrong:
                        targetSpeed.X = 800f;
                        SetAmbienceStrength(true);
                        break;
                    case RoomWindPattern.Alternating:
                        AddCoroutine(AlternatingSequence());
                        break;
                    case RoomWindPattern.RightOnOff:
                        AddCoroutine(RightOnOffSequence());
                        break;
                    case RoomWindPattern.LeftOnOff:
                        AddCoroutine(LeftOnOffSequence());
                        break;
                    case RoomWindPattern.RightOnOffFast:
                        AddCoroutine(RightOnOffFastSequence());
                        break;
                    case RoomWindPattern.LeftOnOffFast:
                        AddCoroutine(LeftOnOffFastSequence());
                        break;
                    case RoomWindPattern.RightCrazy:
                        targetSpeed.X = 1200f;
                        SetAmbienceStrength(true);
                        break;
                    case RoomWindPattern.Down:
                        targetSpeed.Y = 300f;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.Up:
                        targetSpeed.Y = -400f;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.Space:
                        targetSpeed.Y = -600f;
                        SetAmbienceStrength(false);
                        break;
                    case RoomWindPattern.LeftGemsOnly:
                        break;
                }
            }
        }

        private void AddCoroutine(IEnumerator routine)
        {
            coroutine = new(engine, routine);
            OwnedComponents.Add(coroutine);
        }

        private void SetAmbienceStrength(bool strong)
        {
            var num = 0;
            if (targetSpeed.X != 0f)
                num = Math.Sign(targetSpeed.X);
            else if (targetSpeed.Y != 0f) num = Math.Sign(targetSpeed.Y);

            ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput.SetAmbienceParam("wind_direction", num);
            ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput.SetAmbienceParam("strong_wind",
                strong ? 1 : 0);
        }

        public void SnapWind()
        {
            if (coroutine != null && coroutine.Active) coroutine.Update();

            level.Wind = targetSpeed;
        }

        public override void Update()
        {
            base.Update();
            if (CurrentPattern == RoomWindPattern.LeftGemsOnly)
            {
                var flag = false;
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (var entry in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                             "Celeste.StrawberrySeed"))
                    if (((OriginalStrawberrySeedState)entry)
                        .Collected)
                    {
                        flag = true;
                        break;
                    }

                if (flag)
                {
                    targetSpeed.X = -400f;
                    SetAmbienceStrength(false);
                }
                else
                {
                    targetSpeed.X = 0f;
                    SetAmbienceStrength(false);
                }
            }

            ApplyWind(level, targetSpeed, 1000f, engine);
        }

        public static void ApplyWind(OriginalLevelSceneRoot level, Vector2 targetSpeed, float acceleration,
            ISourceEngineContext engine)
        {
            level.Wind = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(level.Wind, targetSpeed,
                acceleration * engine.DeltaTime);
            if (!(level.Wind != Vector2.Zero) || level.Transitioning) return;

            foreach (var entry in
                     level.SourceScene.Components.GetTrackedComponents("Celeste.WindMover"))
                ((WindMoverState)entry).Move(level.Wind * 0.1f * engine.DeltaTime);
        }

        private IEnumerator AlternatingSequence()
        {
            while (true)
            {
                targetSpeed.X = -400f;
                SetAmbienceStrength(false);
                yield return 3f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 2f;
                targetSpeed.X = 400f;
                SetAmbienceStrength(false);
                yield return 3f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 2f;
            }
        }

        private IEnumerator RightOnOffSequence()
        {
            while (true)
            {
                targetSpeed.X = 800f;
                SetAmbienceStrength(true);
                yield return 3f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 3f;
            }
        }

        private IEnumerator LeftOnOffSequence()
        {
            while (true)
            {
                targetSpeed.X = -800f;
                SetAmbienceStrength(true);
                yield return 3f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 3f;
            }
        }

        private IEnumerator RightOnOffFastSequence()
        {
            while (true)
            {
                targetSpeed.X = 800f;
                SetAmbienceStrength(true);
                yield return 2f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 2f;
            }
        }

        private IEnumerator LeftOnOffFastSequence()
        {
            while (true)
            {
                targetSpeed.X = -800f;
                SetAmbienceStrength(true);
                yield return 2f;
                targetSpeed.X = 0f;
                SetAmbienceStrength(false);
                yield return 2f;
            }
        }
    }
}
