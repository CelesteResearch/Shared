using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Dust
{
    public class OriginalDustTrackSpinnerState : OriginalTrackSpinnerState
    {
        private readonly DustGraphicState _dusty;
        private Vector2 _outwards;

        public OriginalDustTrackSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
            OwnedComponents.Add(_dusty = new(engine, true));
            _dusty.EyeDirection = _dusty.EyeTargetDirection =
                ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(End - Start);
            _dusty.OnEstablish = Establish;
            Depth = -50;
        }

        private void Establish()
        {
            var vector = ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(End - Start);
            var perpendicular = new Vector2(0f - vector.Y, vector.X);
            var flag = CheckSolid(new((int)(X + perpendicular.X * 4f) - 2,
                (int)(Y + perpendicular.Y * 4f) - 2, 4, 4));
            if (!flag)
            {
                perpendicular = -perpendicular;
                flag = CheckSolid(new((int)(X + perpendicular.X * 4f) - 2,
                    (int)(Y + perpendicular.Y * 4f) - 2, 4, 4));
            }

            if (!flag) return;
            var length = ((ISourceVectorEnvironment)Engine).VectorArithmetic.Length(End - Start);
            for (var index = 8; index < length && flag; index += 8)
                flag = flag && CheckSolid(new((int)(X + perpendicular.X * 4f + vector.X * index) - 2,
                    (int)(Y + perpendicular.Y * 4f + vector.Y * index) - 2, 4, 4));
            if (!flag) return;
            List<DustGraphicState.Node> nodes = null;
            if (perpendicular.X < 0f) nodes = _dusty.LeftNodes;
            else if (perpendicular.X > 0f) nodes = _dusty.RightNodes;
            else if (perpendicular.Y < 0f) nodes = _dusty.TopNodes;
            else if (perpendicular.Y > 0f) nodes = _dusty.BottomNodes;
            if (nodes != null)
                foreach (var node in nodes)
                    node.Enabled = false;
            _outwards = -perpendicular;
            _dusty.Position -= perpendicular;
            _dusty.EyeDirection = _dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(
                ScalarMath.AngleLerp(Vector2Geometry.Angle(_outwards), Up ? Angle + (float)Math.PI : Angle, .3f),
                1f);
        }

        private bool CheckSolid(IntRect rectangle)
        {
            foreach (var item in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"))
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
            _dusty.OnHitPlayer();
        }

        public override void OnTrackEnd()
        {
            if (_outwards != Vector2.Zero)
            {
                _dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(
                    ScalarMath.AngleLerp(Vector2Geometry.Angle(_outwards), Up ? Angle + (float)Math.PI : Angle,
                        .3f),
                    1f);
                return;
            }

            _dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(Up ? Angle + (float)Math.PI : Angle, 1f);
            _dusty.EyeFlip = -_dusty.EyeFlip;
        }
    }
}
