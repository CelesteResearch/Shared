using Celeste.Core.Display;
using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public abstract class OriginalWaveDashPage
    {
        protected readonly ISourceEngineContext engine;

        protected OriginalWaveDashPage(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public enum Transitions
        {
            ScaleIn,
            FadeIn,
            Rotate3D,
            Blocky,
            Spiral
        }

        public OriginalWaveDashPresentationState Presentation;

        public PackedColor ClearColor;

        public Transitions Transition;

        public bool AutoProgress;

        public bool WaitingForInput;

        public int Width => Presentation.ScreenWidth;

        public int Height => Presentation.ScreenHeight;

        public abstract IEnumerator Routine();

        public virtual void Added(OriginalWaveDashPresentationState presentation)
        {
            Presentation = presentation;
        }

        public virtual void Update()
        {
        }

        public virtual void Render(ISourceRenderContext context)
        {
        }

        protected IEnumerator PressButton()
        {
            WaitingForInput = true;
            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed)
            {
                yield return null;
            }

            WaitingForInput = false;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/ppt_mouseclick");
        }
    }
}
