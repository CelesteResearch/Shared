using System;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Presentation.Platforms.Effects
{
    public static class MovingSolidParticleEffects
    {
        public static void Stop(SceneEntityState block, ISourceEngineContext engine, Vector2 moved)
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)block.Scene;
            float direction = (float)Math.Atan2(moved.Y, moved.X);
            if (moved.X > 0f)
            {
                Vector2 vector = new Vector2(block.Right - 1f, block.Top);
                for (int i = 0; (float)i < block.Height; i += 4)
                {
                    level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FinalBossMovingBlock.P_Stop,
                        vector + Vector2.UnitY * (2 + i + ((ISourceRandomEnvironment)engine).Random.Next(-1, 1)),
                        direction);
                }
            }
            else if (moved.X < 0f)
            {
                Vector2 vector2 = new Vector2(block.Left, block.Top);
                for (int j = 0; (float)j < block.Height; j += 4)
                {
                    level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FinalBossMovingBlock.P_Stop,
                        vector2 + Vector2.UnitY * (2 + j + ((ISourceRandomEnvironment)engine).Random.Next(-1, 1)),
                        direction);
                }
            }

            if (moved.Y > 0f)
            {
                Vector2 vector3 = new Vector2(block.Left, block.Bottom - 1f);
                for (int k = 0; (float)k < block.Width; k += 4)
                {
                    level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FinalBossMovingBlock.P_Stop,
                        vector3 + Vector2.UnitX * (2 + k + ((ISourceRandomEnvironment)engine).Random.Next(-1, 1)),
                        direction);
                }
            }
            else if (moved.Y < 0f)
            {
                Vector2 vector4 = new Vector2(block.Left, block.Top);
                for (int l = 0; (float)l < block.Width; l += 4)
                {
                    level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FinalBossMovingBlock.P_Stop,
                        vector4 + Vector2.UnitX * (2 + l + ((ISourceRandomEnvironment)engine).Random.Next(-1, 1)),
                        direction);
                }
            }
        }

        public static void Impact(SceneEntityState block, ISourceEngineContext engine, Vector2 moved)
        {
            if (moved.X < 0f)
            {
                Vector2 vector = new Vector2(0f, 2f);
                for (int i = 0; (float)i < block.Height / 8f; i++)
                {
                    Vector2 vector2 = new Vector2(block.Left - 1f, block.Top + 4f + (float)(i * 8));
                    if (!SourceSceneCollision.CheckPoint(((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Water",
                            vector2) && SourceSceneCollision.CheckPoint(
                            ((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Solid", vector2))
                    {
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector2 + vector, 0f);
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector2 - vector, 0f);
                    }
                }
            }
            else if (moved.X > 0f)
            {
                Vector2 vector3 = new Vector2(0f, 2f);
                for (int j = 0; (float)j < block.Height / 8f; j++)
                {
                    Vector2 vector4 = new Vector2(block.Right + 1f, block.Top + 4f + (float)(j * 8));
                    if (!SourceSceneCollision.CheckPoint(((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Water",
                            vector4) && SourceSceneCollision.CheckPoint(
                            ((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Solid", vector4))
                    {
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector4 + vector3, (float)Math.PI);
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector4 - vector3, (float)Math.PI);
                    }
                }
            }

            if (moved.Y < 0f)
            {
                Vector2 vector5 = new Vector2(2f, 0f);
                for (int k = 0; (float)k < block.Width / 8f; k++)
                {
                    Vector2 vector6 = new Vector2(block.Left + 4f + (float)(k * 8), block.Top - 1f);
                    if (!SourceSceneCollision.CheckPoint(((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Water",
                            vector6) && SourceSceneCollision.CheckPoint(
                            ((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Solid", vector6))
                    {
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector6 + vector5, (float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector6 - vector5, (float)Math.PI / 2f);
                    }
                }
            }
            else
            {
                if (!(moved.Y > 0f))
                {
                    return;
                }

                Vector2 vector7 = new Vector2(2f, 0f);
                for (int l = 0; (float)l < block.Width / 8f; l++)
                {
                    Vector2 vector8 = new Vector2(block.Left + 4f + (float)(l * 8), block.Bottom + 1f);
                    if (!SourceSceneCollision.CheckPoint(((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Water",
                            vector8) && SourceSceneCollision.CheckPoint(
                            ((ISourceScene)block.Scene).SourceScene.Entities,
                            "Celeste.Solid", vector8))
                    {
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector8 + vector7, -(float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)block.Scene).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact,
                            vector8 - vector7, -(float)Math.PI / 2f);
                    }
                }
            }
        }
    }
}
