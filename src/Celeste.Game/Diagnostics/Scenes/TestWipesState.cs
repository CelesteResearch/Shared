using Celeste.Core.Display;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class TestWipesState : SourceSceneState
    {
        private SimulationCoroutine coroutine;

        private PackedColor lastColor = PackedColor.White;

        public TestWipesState(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            coroutine = new SimulationCoroutine(engine, routine());
        }

        private IEnumerator routine()
        {
            float dur = 1f;
            yield return 1f;
            while (true)
            {
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.Black;
                new CurtainWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new PackedColor(255, 0, 52, 255);
                new AngledWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new PackedColor(11, 9, 96, 255);
                new DreamWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new PackedColor(57, 191, 0, 255);
                new KeyDoorWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor =
                    new PackedColor(67, 118, 179, 255);
                new WindWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new PackedColor(255, 174, 0, 255);
                new DropWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor =
                    new PackedColor(204, 84, 255, 255);
                new FallWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = new PackedColor(255, 0, 122, 255);
                new MountainWipePresentation(this, wipeIn: false).Duration = dur;
                yield return dur;
                lastColor = ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
                ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = PackedColor.White;
                new HeartWipePresentation(this, wipeIn: false).Duration = dur;
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
