using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation
    {
        public abstract class Item
        {
            public TextMenuResources Resources;

            protected TextMenuResources ResourceSet =>
                Resources ?? Container.Resources;

            protected internal TextMenuDrawing ActiveFont =>
                Container != null
                    ? Container.drawing
                    : new(Resources);

            public bool Selectable;

            public bool Visible = true;

            public bool Disabled;

            public bool IncludeWidthInMeasurement = true;

            public bool AboveAll;

            public TextMenuPresentation Container;

            public WigglerComponent SelectWiggler;

            public WigglerComponent ValueWiggler;

            public Action OnEnter;

            public Action OnLeave;

            public Action OnPressed;

            public Action OnAltPressed;

            public Action OnUpdate;

            public bool Hoverable
            {
                get
                {
                    if (Selectable && Visible) return !Disabled;

                    return false;
                }
            }

            public float Width => LeftWidth() + RightWidth();

            public Item Enter(Action onEnter)
            {
                OnEnter = onEnter;
                return this;
            }

            public Item Leave(Action onLeave)
            {
                OnLeave = onLeave;
                return this;
            }

            public Item Pressed(Action onPressed)
            {
                OnPressed = onPressed;
                return this;
            }

            public Item AltPressed(Action onPressed)
            {
                OnAltPressed = onPressed;
                return this;
            }

            public virtual string SearchLabel()
            {
                return null;
            }

            public virtual void ConfirmPressed()
            {
            }

            public virtual void LeftPressed()
            {
            }

            public virtual void RightPressed()
            {
            }

            public virtual void Added()
            {
            }

            public virtual void Update()
            {
            }

            public virtual float LeftWidth()
            {
                return 0f;
            }

            public virtual float RightWidth()
            {
                return 0f;
            }

            public virtual float Height()
            {
                return 0f;
            }

            public virtual void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
            }
        }
    }
}
