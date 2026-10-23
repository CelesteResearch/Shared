using System;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Audio.State.Globals;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public class SeekerEffectsControllerState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        private float randomAnxietyOffset;
        public bool enabled = true;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public SeekerEffectsControllerState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            switch (((IGameProfileEnvironment)engine).SourceProfile)
            {
                case GameProfile.Original:
                    var level = scene as OriginalLevelSceneRoot;
                    level.Session.Audio.Music.Layer(3, 0f,
                        ((IOriginalAudioStateGlobalsEnvironment)engine)
                        .AudioStateGlobals.LayerParameters);
                    var process = (IOriginalGameplayProcess)engine;
                    OriginalAudioSession.Apply(level.Session.Audio, process.AudioSession.ChannelOutput,
                        process.AudioApplyPolicy);
                    break;
                case GameProfile.InstalledEverest:
                    break;
                default: throw new InvalidOperationException("Unknown source game profile.");
            }
        }

        public override void Update()
        {
            base.Update();
            var level = Scene as OriginalLevelSceneRoot;
            if (enabled)
            {
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.05f, engine))
                    randomAnxietyOffset = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -.2f, .2f);
                var position = level.Camera.Position;
                var player =
                    level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                float target, intensity;
                if (player != null && !player.Dead)
                {
                    float nearest = -1f, attacking = -1f;
                    foreach (OriginalSeekerState seeker in level.SourceScene.Entities.GetTrackedEntities(
                                 "Celeste.Seeker"))
                    {
                        var distance =
                            ((ISourceVectorEnvironment)engine).VectorArithmetic.DistanceSquared(player.Center,
                                seeker.Center);
                        if (!seeker.Regenerating) nearest = !(nearest < 0f) ? Math.Min(nearest, distance) : distance;
                        if (seeker.Attacking) attacking = !(attacking < 0f) ? Math.Min(attacking, distance) : distance;
                    }

                    target = !(attacking >= 0f) ? 1f : ScalarMath.ClampedMap(attacking, 256f, 4096f, .5f);
                    engine.Effects.AnxietyOrigin = new((player.Center.X - position.X) / 320f,
                        (player.Center.Y - position.Y) / 180f);
                    intensity = !(nearest >= 0f) ? 0f : ScalarMath.ClampedMap(nearest, 256f, 16384f, 1f, 0f);
                }
                else
                {
                    target = 1f;
                    intensity = 0f;
                }

                engine.Effects.TimeRate = ScalarMath.Approach(engine.Effects.TimeRate, target, 4f * engine.DeltaTime);
                engine.Effects.GameRate = ScalarMath.Approach(engine.Effects.GameRate,
                    ScalarMath.Map(engine.Effects.TimeRate, .5f, 1f), engine.DeltaTime * 2f);
                engine.Effects.Anxiety = ScalarMath.Approach(engine.Effects.Anxiety,
                    (.5f + randomAnxietyOffset) * intensity, 8f * engine.DeltaTime);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (engine.Effects.TimeRate == 1f && /* ReSharper disable once CompareOfFloatsByEqualityOperator */ engine.Effects.GameRate == 1f && engine.Effects.Anxiety == 0f
                    && level.SourceScene.Entities.GetTrackedEntities("Celeste.Seeker").Count == 0) enabled = false;
            }
            else if (level.SourceScene.Entities.GetTrackedEntities("Celeste.Seeker").Count > 0)
            {
                enabled = true;
            }
        }
    }
}
