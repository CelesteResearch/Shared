using System;
using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Mountain.Characters;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Menus.Overworld
{
    public class OverworldReflectionsFallSequence : SourceSceneState
    {
        private readonly OriginalLevelSceneRoot returnTo;
        private readonly Action returnCallback;
        private readonly Maddy3DState maddy;
        private readonly MountainRendererState mountain;
        private readonly MountainCameraState startCamera;
        private readonly MountainCameraState fallCamera;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        public OverworldReflectionsFallSequence(ISourceEngineContext engine, OriginalLevelSceneRoot returnTo,
            Action returnCallback)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            startCamera =
                new(new(-8f, 12f, -0.4f), new(-2f, 9f, -0.5f), VectorArithmetic);
            fallCamera = new(new(-10f, 6f, -0.4f), new(-4.25f, 1.5f, -1.25f),
                VectorArithmetic);
            this.returnTo = returnTo;
            this.returnCallback = returnCallback;
            Renderers.Add(mountain = new(engine));
            mountain.SnapCamera(-1, new(SourceVector3Math.Add(startCamera.Position,
                    SourceVector3Math.Multiply(
                        VectorArithmetic.SafeNormalize(SourceVector3Math.Subtract(startCamera.Target,
                            startCamera.Position)), 2f)),
                startCamera.Target, VectorArithmetic));
            Renderers.Add(new HiresSnowState(engine) { ParticleAlpha = 0f });
            SourceScene.QueueSourceEntity(new Snow3DState(mountain.Model));
            SourceScene.QueueSourceEntity(maddy = new(mountain));
            maddy.Falling();
            var routineEntity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
            routineEntity.Components.Add(new SimulationCoroutine(engine, Routine()));
            SourceScene.QueueSourceEntity(routineEntity);
        }

        private IEnumerator Routine()
        {
            mountain.EaseCamera(-1, startCamera, 0.4f);
            var duration = 4f;
            maddy.Position = startCamera.Target;
            for (var i = 0; i < 30; i++)
            {
                maddy.Position = SourceVector3Math.Add(startCamera.Target, new(
                    SourceRandomMath.Range(((ISourceRandomEnvironment)EngineContext).Random, -0.05f, 0.05f),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)EngineContext).Random, -0.05f, 0.05f),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)EngineContext).Random, -0.05f, 0.05f)));
                yield return 0.01f;
            }

            yield return 0.1f;
            maddy.Components.Add(new SimulationCoroutine(EngineContext, MaddyFall(duration + 0.1f)));
            yield return 0.1f;
            mountain.EaseCamera(-1, fallCamera, duration);
            mountain.ForceNearFog = true;
            yield return duration;
            yield return 0.25f;
            var transform = new MountainCameraState(SourceVector3Math.Add(fallCamera.Position,
                SourceVector3Math.Multiply(mountain.Model.Forward, 3f)), fallCamera.Target, VectorArithmetic);
            mountain.EaseCamera(-1, transform, 0.5f);
            Return();
        }

        private IEnumerator MaddyFall(float duration)
        {
            for (var p = 0f; p < 1f; p += EngineContext.DeltaTime / duration)
            {
                maddy.Position = SourceVector3Math.Lerp(startCamera.Target, fallCamera.Target, p,
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                yield return null;
            }
        }

        private void Return()
        {
            new FadeWipePresentation(this, false, delegate
            {
                mountain.Dispose();
                if (returnTo != null)
                    EngineContext.Frame.Scenes.NextScene = returnTo;
                returnCallback();
            });
        }
    }
}
