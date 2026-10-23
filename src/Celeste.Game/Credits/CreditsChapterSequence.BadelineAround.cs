using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator BadelineAround(Vector2 start, Vector2 around,
            BadelineDummyPresentation aroundBadeline = null)
        {
            bool removeAtEnd = aroundBadeline == null;
            if (aroundBadeline == null)
            {
                aroundBadeline = BadelineDummyPresentation.Create(Level, start);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(aroundBadeline);
            }

            aroundBadeline.Sprite.Play("fallSlow");
            float angle = Vector2Geometry.Angle(around, start);
            float distance = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(around - start);
            float duration = 3f;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime / duration)
            {
                float number = p * 2f;
                aroundBadeline.Position = around + Vector2Geometry.AngleToVector(
                    angle - number * ((float)Math.PI * 2f),
                    distance + ScalarMath.YoYo(p) * 16f
                             + (float)Math.Sin(p * ((float)Math.PI * 2f) * 4f) * 5f);
                aroundBadeline.Sprite.Scale.X = Math.Sign(around.X - aroundBadeline.Position.X);
                if (!removeAtEnd)
                    player.Data.Facing = Math.Sign(aroundBadeline.Position.X - player.Position.X);
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.1f, engine))
                    TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine,
                        aroundBadeline, PlayerHairAppearance.NormalHairColor);
                yield return null;
            }

            if (removeAtEnd)
                aroundBadeline.Vanish();
            else
                aroundBadeline.Sprite.Play("laugh");
        }
    }
}
