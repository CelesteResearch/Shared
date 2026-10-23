using System.Collections;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class TestWipesState : SourceSceneState
    {
        private readonly SimulationCoroutine coroutine;

        private PackedColor lastColor = PackedColor.White;

        public TestWipesState(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            coroutine = new(engine, routine());
        }

        private IEnumerator routine()
        {
            var dur = 1f;
            yield return 1f;
            while (true)
            {
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.Black;
                new CurtainWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new(255, 0, 52, 255);
                new AngledWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new(11, 9, 96, 255);
                new DreamWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new(57, 191, 0, 255);
                new KeyDoorWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor =
                    new(67, 118, 179, 255);
                new WindWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new(255, 174, 0, 255);
                new DropWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor =
                    new(204, 84, 255, 255);
                new FallWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new(255, 0, 122, 255);
                new MountainWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.White;
                new HeartWipePresentation(this, false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
            }
        }

        public override void Update()
        {
            base.Update();
            coroutine.Update();
        }

        public override void Render()
        {
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin();
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, -1f, -1f, 1920f, 1080f, lastColor);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
            base.Render();
        }
    }
}
