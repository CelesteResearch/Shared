using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Effects.AbsorbOrbs
{
    public class OriginalAbsorbOrbState : SceneEntityState
    {
        public ISourceEntityCollider AbsorbInto;

        public Vector2? AbsorbTarget;

        private SimpleCurve curve;

        private float duration;

        private float percent;

        private float consumeDelay;

        private float burstSpeed;

        private readonly Vector2 burstDirection;

        private Vector2 burstScale;

        private float alpha = 1f;

        private readonly SpriteImage sprite;

        private BloomPointState bloom;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public OriginalAbsorbOrbState(ISourceEngineContext engine, Vector2 position, ISourceEntityCollider into = null,
            Vector2? absorbTarget = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            AbsorbInto = into;
            AbsorbTarget = absorbTarget;
            Position = position;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            Depth = -2000000;
            consumeDelay = 0.7f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 0.3f;
            burstSpeed = 80f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 40f;
            burstDirection = Vector2Geometry.AngleToVector(
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * ((float)Math.PI * 2f), 1f);
            OwnedComponents.Add(sprite =
                new(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["collectables/heartGem/orb"]));
            sprite.CenterOrigin();
            OwnedComponents.Add(bloom = new(1f, 16f));
        }

        public override void Update()
        {
            base.Update();
            var vector = Vector2.Zero;
            var flag = false;
            if (AbsorbInto != null)
            {
                vector = AbsorbInto.Position +
                         (AbsorbInto.Collider != null ? AbsorbInto.Collider.Center : Vector2.Zero);
                flag = ((ISourceEntityScene)AbsorbInto).Scene == null ||
                       (AbsorbInto is RoomPlayerSession && (AbsorbInto as RoomPlayerSession).Dead);
            }
            else if (AbsorbTarget.HasValue)
            {
                vector = AbsorbTarget.Value;
            }
            else
            {
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null) vector = entity.Center;

                flag = entity == null || entity.Scene == null || entity.Dead;
            }

            if (flag)
            {
                Position += burstDirection * burstSpeed * engine.RawDeltaTime;
                burstSpeed = ScalarMath.Approach(burstSpeed, 800f, engine.RawDeltaTime * 200f, Extrema);
                sprite.Rotation = Vector2Geometry.Angle(burstDirection);
                sprite.Scale = new(Extrema.Min(2f, 0.5f + burstSpeed * 0.02f),
                    Extrema.Max(0.05f, 0.5f - burstSpeed * 0.004f));
                sprite.Color = PackedColor.White * (alpha = ScalarMath.Approach(alpha, 0f, engine.DeltaTime, Extrema));
            }
            else if (consumeDelay > 0f)
            {
                Position += burstDirection * burstSpeed * engine.RawDeltaTime;
                burstSpeed = ScalarMath.Approach(burstSpeed, 0f, engine.RawDeltaTime * 120f, Extrema);
                sprite.Rotation = Vector2Geometry.Angle(burstDirection);
                sprite.Scale = new(Extrema.Min(2f, 0.5f + burstSpeed * 0.02f),
                    Extrema.Max(0.05f, 0.5f - burstSpeed * 0.004f));
                consumeDelay -= engine.RawDeltaTime;
                if (consumeDelay <= 0f)
                {
                    var position = Position;
                    var vector2 = vector;
                    var vector3 = VectorArithmetic.Divide(position + vector2, 2f);
                    var vector4 =
                        Vector2Geometry.Perpendicular(VectorArithmetic.SafeNormalize(vector2 - position,
                            Vector2.Zero)) *
                        VectorArithmetic.Length(position - vector2) * (0.05f +
                                                                       SourceRandomMath.NextFloat(
                                                                           ((ISourceRandomEnvironment)engine).Random) *
                                                                       0.45f);
                    var value = vector2.X - position.X;
                    var value2 = vector2.Y - position.Y;
                    if ((Math.Abs(value) > Math.Abs(value2) && Math.Sign(vector4.X) != Math.Sign(value)) ||
                        (Math.Abs(value2) > Math.Abs(value2) && Math.Sign(vector4.Y) != Math.Sign(value2)))
                        vector4 *= -1f;

                    curve = new(position, vector2, vector3 + vector4);
                    duration = 0.3f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.25f);
                    burstScale = sprite.Scale;
                }
            }
            else
            {
                curve.End = vector;
                if (percent >= 1f) RemoveSelf();

                percent = ScalarMath.Approach(percent, 1f, engine.RawDeltaTime / duration, Extrema);
                var num = Easing.CubeIn(percent);
                Position = curve.GetPoint(num, CurveArithmetic);
                var num2 = ScalarMath.YoYo(num) * curve.GetLengthParametric(10, CurveArithmetic, VectorArithmetic);
                sprite.Scale = new(Extrema.Min(2f, 0.5f + num2 * 0.02f),
                    Extrema.Max(0.05f, 0.5f - num2 * 0.004f));
                sprite.Color = PackedColor.White * (1f - num);
                sprite.Rotation =
                    Vector2Geometry.Angle(Position, curve.GetPoint(Easing.CubeIn(percent + 0.01f), CurveArithmetic));
            }
        }
    }
}
