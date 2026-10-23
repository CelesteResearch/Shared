using System;
using System.Numerics;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public class OriginalSeekerStatueState : SceneEntityState
    {
        private enum Hatch
        {
            Distance,
            PlayerRightOfX
        }

        private Hatch hatch;
        private Sprite sprite;
        private readonly IOriginalSeekerProcess engine;

        public OriginalSeekerStatueState(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.engine = engine;
            OriginalSeekerStatueState seekerStatue = this;
            Depth = 8999;
            OwnedComponents.Add(sprite = engine.GameGraphics.SpriteFactory.Create("seeker"));
            sprite.Play("statue");
            sprite.OnLastFrame = delegate(string frame)
            {
                if (frame == "hatch")
                {
                    OriginalSeekerState entity = engine.SeekerFactory.Create(data, offset, engine);
                    entity.Light.Alpha = 0f;
                    ((ISourceScene)seekerStatue.Scene).SourceScene.QueueSourceEntity(entity);
                    seekerStatue.RemoveSelf();
                }
            };
            hatch = EntityAttributeReader.Enum(data.Values, "hatch", Hatch.Distance);
        }

        public override void Update()
        {
            base.Update();
            var players =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            RoomPlayerSession entity = players.Count > 0 ? players[0] as RoomPlayerSession : null;
            if (entity != null && sprite.CurrentAnimationID == "statue")
            {
                bool flag = false;
                if (hatch == Hatch.Distance && engine.VectorArithmetic.Length(entity.Position - Position) < 220f)
                {
                    flag = true;
                }
                else if (hatch == Hatch.PlayerRightOfX && entity.X > X + 32f)
                {
                    flag = true;
                }

                if (flag)
                {
                    BreakOutParticles();
                    sprite.Play("hatch");
                    engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_statue_break", Position);
                    SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, .8f, BreakOutParticles);
                }
            }
        }

        private void BreakOutParticles()
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            for (float angle = 0f; angle < (float)Math.PI * 2f; angle += .17453292f)
            {
                Vector2 position = Center + Vector2Geometry.AngleToVector(
                    angle + SourceRandomMath.Range(engine.Random, -(float)Math.PI / 90f, (float)Math.PI / 90f),
                    SourceRandomMath.Range(engine.Random, 12, 20));
                level.Particles.Emit(engine.SeekerParticles.P_BreakOut, position, angle);
            }
        }
    }
}
