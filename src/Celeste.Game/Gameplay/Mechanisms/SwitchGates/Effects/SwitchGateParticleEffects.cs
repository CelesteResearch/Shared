using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates.Effects
{
    public static class SwitchGateParticleEffects
    {
        public static void EmitEdgeDust(SourceSolidEntityState gate, Vector2 start, Vector2 node,
            IOriginalSwitchGateProcess process)
        {
            if (node.X <= start.X)
            {
                var vector = new Vector2(0f, 2f);
                for (var num = 0; num < gate.Height / 8f; num++)
                {
                    var vector2 = new Vector2(gate.Left - 1f, gate.Top + 4f + num * 8);
                    var point = vector2 + Vector2.UnitX;
                    if (SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            vector2) != null &&
                        !(SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            point) != null))
                    {
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector2 + vector,
                            (float)Math.PI);
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector2 - vector,
                            (float)Math.PI);
                    }
                }
            }

            if (node.X >= start.X)
            {
                var vector3 = new Vector2(0f, 2f);
                for (var num2 = 0; num2 < gate.Height / 8f; num2++)
                {
                    var vector4 = new Vector2(gate.Right + 1f, gate.Top + 4f + num2 * 8);
                    var point2 = vector4 - Vector2.UnitX * 2f;
                    if (SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            vector4) != null &&
                        !(SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            point2) != null))
                    {
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector4 + vector3, 0f);
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector4 - vector3, 0f);
                    }
                }
            }

            if (node.Y <= start.Y)
            {
                var vector5 = new Vector2(2f, 0f);
                for (var num3 = 0; num3 < gate.Width / 8f; num3++)
                {
                    var vector6 = new Vector2(gate.Left + 4f + num3 * 8, gate.Top - 1f);
                    var point3 = vector6 + Vector2.UnitY;
                    if (SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            vector6) != null &&
                        !(SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            point3) != null))
                    {
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector6 + vector5,
                            -(float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector6 - vector5,
                            -(float)Math.PI / 2f);
                    }
                }
            }

            if (node.Y >= start.Y)
            {
                var vector7 = new Vector2(2f, 0f);
                for (var num4 = 0; num4 < gate.Width / 8f; num4++)
                {
                    var vector8 = new Vector2(gate.Left + 4f + num4 * 8, gate.Bottom + 1f);
                    var point4 = vector8 - Vector2.UnitY * 2f;
                    if (SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            vector8) != null &&
                        !(SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                            ((OriginalLevelSceneRoot)gate.Scene).Scheduler.Entities,
                            "Celeste.Solid",
                            point4) != null))
                    {
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector8 + vector7,
                            (float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.SwitchGate.P_Dust,
                            vector8 - vector7,
                            (float)Math.PI / 2f);
                    }
                }
            }
        }

        public static void EmitIconFire(SourceSolidEntityState gate, Vector2 iconOffset,
            IOriginalSwitchGateProcess process)
        {
            for (var index = 0; index < 32; index++)
            {
                var angle = SourceRandomMath.NextFloat(process.Random, (float)Math.PI * 2f);
                ((OriginalLevelSceneRoot)gate.Scene).ParticlesFG.Emit(process.ParticleTypes.TouchSwitch.P_Fire,
                    gate.Position + iconOffset + Vector2Geometry.AngleToVector(angle, 4f), angle);
            }
        }
    }
}
