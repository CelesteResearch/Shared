using Celeste.Game.Controls.Source;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Input.Gui;
using Celeste.Game.UI.Controls;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Menus.Overworld
{
    public sealed class OverworldInputState : SceneEntityState
    {
        public readonly OverworldSequence Overworld;
        private readonly WigglerComponent confirmWiggle;
        private readonly WigglerComponent cancelWiggle;
        private float confirmWiggleDelay;
        private float cancelWiggleDelay;

        public OverworldInputState(OverworldSequence overworld)
            : base(((ISourceEntitySourceDataEnvironment)overworld.EngineContext).EntitySourceDataRegistration)
        {
            Overworld = overworld;
            Tags = OriginalSceneTags.HUD;
            Depth = -100000;
            var pool = ((ISourceWigglerPoolScope)overworld.EngineContext).WigglerPool;
            Components.Add(confirmWiggle = pool.Create(0.4f, 4f));
            Components.Add(cancelWiggle = pool.Create(0.4f, 4f));
        }

        public override void Update()
        {
            var input = ((IOriginalGameInputProcessEnvironment)Overworld.EngineContext).InputSource;
            if (input.MenuConfirm.Pressed && confirmWiggleDelay <= 0f)
            {
                confirmWiggle.Start();
                confirmWiggleDelay = 0.5f;
            }

            if (input.MenuCancel.Pressed && cancelWiggleDelay <= 0f)
            {
                cancelWiggle.Start();
                cancelWiggleDelay = 0.5f;
            }

            confirmWiggleDelay -= Overworld.EngineContext.Frame.DeltaTime;
            cancelWiggleDelay -= Overworld.EngineContext.Frame.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            float inputEase = Overworld.inputEase;
            if (inputEase > 0f)
            {
                float scale = 0.5f;
                int spacing = 32;
                var engine = Overworld.EngineContext;
                var text = ((IOriginalGameTextEnvironment)engine).Text;
                string cancel = text.CleanDialog("ui_cancel");
                string confirm = text.CleanDialog("ui_confirm");
                var input = ((IOriginalGameInputProcessEnvironment)engine).InputSource;
                float cancelWidth = OriginalButtonUi.Width(engine, cancel, input.MenuCancel);
                float confirmWidth = OriginalButtonUi.Width(engine, confirm, input.MenuConfirm);
                Vector2 position = new Vector2(1880f, 1024f);
                position.X += (40f + (confirmWidth + cancelWidth) * scale + spacing)
                              * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(inputEase));
                OriginalButtonUi.Render(context, this, engine, position, cancel, input.MenuCancel,
                    scale, 1f, cancelWiggle.Value * 0.05f);
                if (Overworld.ShowConfirmUI)
                {
                    position.X -= scale * cancelWidth + spacing;
                    OriginalButtonUi.Render(context, this, engine, position, confirm, input.MenuConfirm,
                        scale, 1f, confirmWiggle.Value * 0.05f);
                }
            }
        }
    }
}
