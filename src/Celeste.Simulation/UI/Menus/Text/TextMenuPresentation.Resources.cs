using Celeste.Input.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation : SceneEntityState
    {
        public readonly ISourceEngineContext EngineContext;
        private ITextMenuProcessEnvironment Process => (ITextMenuProcessEnvironment)EngineContext;
        public TextMenuResources Resources => Process.TextMenuResources;
        internal ISourceMenuInput Input => ((ISourceMenuInputEnvironment)EngineContext).MenuInput;

        private Celeste.Core.Rendering.ISourceGraphicsContext Graphics
            => ((Celeste.Core.Rendering.ISourceRenderEnvironment)EngineContext).CurrentContext.Graphics;

        private readonly TextMenuDrawing drawing;
        public float RawDeltaTime => EngineContext.Frame.RawDeltaTime;
        private static float Clamp(float value, float min, float max) => Math.Min(Math.Max(value, min), max);
        private static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);

        public SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var coroutine = new SimulationCoroutine(EngineContext, routine);
            OwnedComponents.Add(coroutine);
            return coroutine;
        }

        internal void PlaySound(string eventPath) => Process.PlayMenuSound(eventPath);
        public void AddButton(string label, Action pressed) => Add(new Button(label).Pressed(pressed));
    }
}
