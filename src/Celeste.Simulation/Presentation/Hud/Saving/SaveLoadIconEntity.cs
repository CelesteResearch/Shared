using System.Collections;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Animation;

namespace Celeste.Simulation.Presentation.Hud.Saving
{
    public sealed class SaveLoadIconEntity : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly SaveLoadIconProcess process;
        private readonly Sprite icon;
        private readonly WigglerComponent wiggler;
        internal bool Display = true;

        public SaveLoadIconEntity(ISourceEngineContext engine, ISaveLoadIconResources resources,
            SaveLoadIconProcess process)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.process = process;
            Tags = resources.Tags;
            Depth = -1000000;
            icon = resources.GuiSpriteBank.Create("save");
            Add(icon);
            icon.UseRawDeltaTime = true;
            wiggler = resources.WigglerPool.Create(.4f, 4f, value => icon.Rotation = value * .1f);
            Add(wiggler);
            wiggler.UseRawDeltaTime = true;
            Add(new SimulationCoroutine(engine, Routine()) { UseRawDeltaTime = true });
            icon.Visible = false;
        }

        private IEnumerator Routine()
        {
            icon.Play("start", true);
            icon.Visible = true;
            yield return .25f;
            float timer = 1f;
            while (Display)
            {
                timer -= engine.DeltaTime;
                if (timer <= 0f)
                {
                    wiggler.Start();
                    timer = 1f;
                }

                yield return null;
            }

            icon.Play("end");
            yield return .5f;
            icon.Visible = false;
            yield return null;
            process.Instance = null;
            RemoveSelf();
        }

        public override void Render(ISourceRenderContext context)
        {
            Position = new Vector2(1760f, 920f);
            base.Render(context);
        }
    }
}
