using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes;
using Celeste.Game.Profiles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Backdrops.Stars;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public class OriginalBadelineCryingState : OriginalNpcState
    {
        private bool started;
        private readonly SpriteImage white;
        private readonly BloomPointState bloom;
        private readonly VertexLightState light;
        public SoundSourceComponentState LoopingSfx;
        private readonly List<OriginalBadelineCryingOrbState> orbs = [];

        public OriginalBadelineCryingState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            Sprite = ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("badeline_boss");
            OwnedComponents.Add(Sprite);
            Sprite.Play("scaredIdle");
            white = new(
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas["characters/badelineBoss/calm_white"]);
            OwnedComponents.Add(white);
            white.Color = PackedColor.White * 0f;
            white.Origin = Sprite.Origin;
            white.Position = Sprite.Position;
            bloom = new(new(0f, -6f), 0f, 16f);
            OwnedComponents.Add(bloom);
            light = new(Engine, new(0f, -6f),
                PackedColor.White, 1f, 24, 64);
            OwnedComponents.Add(light);
            LoopingSfx = ((ISourceSoundSourceEnvironment)Engine).SoundSources.Create();
            LoopingSfx.Play(((IGameProfileEnvironment)Engine).SourceProfile ==
                            GameProfile.InstalledEverest
                ? "event:/none"
                : "event:/char/badeline/boss_idle_ground");
            OwnedComponents.Add(LoopingSfx);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!Session.GetFlag("badeline_connection")) return;
            var starfield = ((OriginalLevelSceneRoot)scene).Background
                .Get<FinalBossStarfieldBackdropPresentation>();
            if (starfield != null) starfield.Alpha = 0f;
            foreach (SceneEntityState tentacles in ((ISourceScene)Scene)
                     .SourceScene.Entities.GetTrackedEntities("Celeste.ReflectionTentacles"))
                tentacles.RemoveSelf();
            RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (!started && player != null && player.X > X - 32f)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new CS06BossEndState(player, this, Engine));
                started = true;
            }
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            foreach (var orb in orbs) orb.RemoveSelf();
        }

        public IEnumerator TurnWhite(float duration)
        {
            var alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Engine.DeltaTime / duration;
                white.Color = PackedColor.White * alpha;
                bloom.Alpha = alpha;
                yield return null;
            }

            Sprite.Visible = false;
        }

        public IEnumerator Disperse()
        {
            ((ISourceRumbleEnvironment)Engine).RumbleSession.Rumble(0, 2);
            var size = 1f;
            while (orbs.Count < 8)
            {
                var to = size - .125f;
                while (size > to)
                {
                    white.Scale = Vector2.One * size;
                    light.Alpha = size;
                    bloom.Alpha = size;
                    size -= Engine.DeltaTime;
                    yield return null;
                }

                var orb = new OriginalBadelineCryingOrbState(Position, Engine);
                orb.Target = Position + new Vector2(-16f, -40f);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(orb);
                orbs.Add(orb);
            }

            yield return 3.25f;
            var i = 0;
            foreach (var orb in orbs)
            {
                orb.Routine.Replace(orb.CircleRoutine(i / 8f * ((float)Math.PI * 2f)));
                i++;
                yield return .2f;
            }

            yield return 2f;
            foreach (var orb in orbs) orb.Routine.Replace(orb.AbsorbRoutine());
            yield return 1f;
        }
    }
}
