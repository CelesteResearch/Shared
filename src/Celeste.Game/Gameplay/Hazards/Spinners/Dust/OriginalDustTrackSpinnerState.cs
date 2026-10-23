using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Dust
{
    public class OriginalDustTrackSpinnerState : OriginalTrackSpinnerState
    {
        private DustGraphicState dusty;
        private Vector2 outwards;

        public OriginalDustTrackSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
            OwnedComponents.Add(dusty = new DustGraphicState(engine, true));
            dusty.EyeDirection = dusty.EyeTargetDirection =
                ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(End - Start);
            dusty.OnEstablish = Establish;
            Depth = -50;
        }

        private void Establish()
        {
            Vector2 vector = ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(End - Start);
            Vector2 perpendicular = new Vector2(0f - vector.Y, vector.X);
            bool flag = CheckSolid(new IntRect((int)(X + perpendicular.X * 4f) - 2,
                (int)(Y + perpendicular.Y * 4f) - 2, 4, 4));
            if (!flag)
            {
                perpendicular = -perpendicular;
                flag = CheckSolid(new IntRect((int)(X + perpendicular.X * 4f) - 2,
                    (int)(Y + perpendicular.Y * 4f) - 2, 4, 4));
            }

            if (!flag) return;
            float length = ((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(End - Start);
            for (int index = 8; (float)index < length && flag; index += 8)
                flag = flag && CheckSolid(new IntRect((int)(X + perpendicular.X * 4f + vector.X * (float)index) - 2,
                    (int)(Y + perpendicular.Y * 4f + vector.Y * (float)index) - 2, 4, 4));
            if (!flag) return;
            List<DustGraphicState.Node> nodes = null;
            if (perpendicular.X < 0f) nodes = dusty.LeftNodes;
            else if (perpendicular.X > 0f) nodes = dusty.RightNodes;
            else if (perpendicular.Y < 0f) nodes = dusty.TopNodes;
            else if (perpendicular.Y > 0f) nodes = dusty.BottomNodes;
            if (nodes != null)
                foreach (var node in nodes)
                    node.Enabled = false;
            outwards = -perpendicular;
            dusty.Position -= perpendicular;
            dusty.EyeDirection = dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(
                ScalarMath.AngleLerp(Vector2Geometry.Angle(outwards), Up ? Angle + (float)System.Math.PI : Angle, .3f),
                1f);
        }

        private bool CheckSolid(IntRect rectangle)
        {
            foreach (object item in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"))
            {
                var solid = (ISourceEntityCollider)item;
                if (solid.Collidable && solid.Collider != null && solid.Collider.Collide(rectangle)) return true;
            }

            return false;
        }

        public override void Update()
        {
            base.Update();
            var level = (OriginalLevelSceneRoot)Scene;
            if (Moving && PauseTimer < 0f && level.Clock.OnInterval(.02f, Engine))
                level.ParticlesBG.Emit(((IOriginalGameplayProcess)Engine).ParticleTypes.DustStaticSpinner.P_Move,
                    1, Position, Vector2.One * 4f);
        }

        public override void OnPlayer(RoomPlayerSession player)
        {
            base.OnPlayer(player);
            dusty.OnHitPlayer();
        }

        public override void OnTrackEnd()
        {
            if (outwards != Vector2.Zero)
            {
                dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(
                    ScalarMath.AngleLerp(Vector2Geometry.Angle(outwards), Up ? Angle + (float)System.Math.PI : Angle,
                        .3f),
                    1f);
                return;
            }

            dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(Up ? Angle + (float)System.Math.PI : Angle, 1f);
            dusty.EyeFlip = -dusty.EyeFlip;
        }
    }
}
