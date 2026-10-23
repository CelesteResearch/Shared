using Celeste.Core.Display;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.UI.Menus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Color = global::Celeste.Core.Display.PackedColor;
using Celeste.Simulation.Rendering;


namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation : IPausableMenu
    {
        public enum InnerContentMode
        {
            OneColumn,
            TwoColumn
        }

        public bool Focused = true;
        public bool RenderAsFocused;

        public InnerContentMode InnerContent;

        private List<Item> items = new List<Item>();
        public List<Item> Items => items;

        public int Selection = -1;

        public Vector2 Justify;

        public float ItemSpacing = 4f;

        public float MinWidth;
        public bool CompactWidthMode;
        private bool batchMode;

        public bool BatchMode
        {
            get => batchMode;
            set
            {
                batchMode = value;
                if (!value) RecalculateSize();
            }
        }

        public bool WatchRawBatchMode
        {
            get => batchMode;
            set => batchMode = value;
        }

        public float Alpha = 1f;

        public global::Celeste.Core.Display.PackedColor HighlightColor =
            global::Celeste.Core.Display.PackedColor.White;

        public static readonly global::Celeste.Core.Display.PackedColor HighlightColorA =
            global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor("84FF54");

        public static readonly global::Celeste.Core.Display.PackedColor HighlightColorB =
            global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor("FCFF59");

        public Action OnESC { get; set; }

        public Action OnCancel { get; set; }

        public Action OnUpdate;

        public Action OnPause { get; set; }

        public Action OnClose;

        public bool AutoScroll = true;

        public Item Current
        {
            get
            {
                if (items.Count <= 0 || Selection < 0)
                {
                    return null;
                }

                return items[Selection];
            }
            set { Selection = items.IndexOf(value); }
        }

        // TextMenu.GetWidth/GetHeight recalculate while BatchMode is active, with a
        // reentrancy guard because item measurements can themselves read menu size.
        // Keep the raw fields separate: the original Watch All exposes both each
        // field and its property, and the values can differ until that getter runs.
        private float width, height, leftColumnWidth, rightColumnWidth;
        private bool recalculatingSizeInBatchMode;

        public new float Width
        {
            get
            {
                if (batchMode && !recalculatingSizeInBatchMode) RecalculateSize();
                return width;
            }
            private set => width = value;
        }

        public new float Height
        {
            get
            {
                if (batchMode && !recalculatingSizeInBatchMode) RecalculateSize();
                return height;
            }
            private set => height = value;
        }

        public float LeftColumnWidth
        {
            get
            {
                if (batchMode && !recalculatingSizeInBatchMode) RecalculateSize();
                return leftColumnWidth;
            }
            private set => leftColumnWidth = value;
        }

        public float RightColumnWidth
        {
            get
            {
                if (batchMode && !recalculatingSizeInBatchMode) RecalculateSize();
                return rightColumnWidth;
            }
            private set => rightColumnWidth = value;
        }

        public bool WatchRecalculatingSizeInBatchMode
        {
            get => recalculatingSizeInBatchMode;
            set => recalculatingSizeInBatchMode = value;
        }

        public float WatchRawWidth
        {
            get => width;
            set => width = value;
        }

        public float WatchRawHeight
        {
            get => height;
            set => height = value;
        }

        public float WatchRawLeftColumnWidth
        {
            get => leftColumnWidth;
            set => leftColumnWidth = value;
        }

        public float WatchRawRightColumnWidth
        {
            get => rightColumnWidth;
            set => rightColumnWidth = value;
        }

        public float ScrollableMinSize => Graphics.Height - 300;

        public int FirstPossibleSelection
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] != null && items[i].Hoverable)
                    {
                        return i;
                    }
                }

                return 0;
            }
        }

        public int LastPossibleSelection
        {
            get
            {
                for (int num = items.Count - 1; num >= 0; num--)
                {
                    if (items[num] != null && items[num].Hoverable)
                    {
                        return num;
                    }
                }

                return 0;
            }
        }

        public float ScrollTargetY
        {
            get
            {
                float min = (float)(Graphics.Height - 150) - Height * Justify.Y;
                float max = 150f + Height * Justify.Y;
                return Clamp((float)(Graphics.Height / 2) + Height * Justify.Y - GetYOffsetOf(Current), min, max);
            }
        }

        public TextMenuPresentation(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            Tags = ((ITextMenuProcessEnvironment)engine).TextMenuTags;
            drawing = new TextMenuDrawing(Resources);
            Position = new Vector2(Graphics.Width, Graphics.Height) / 2f;
            Justify = new Vector2(0.5f, 0.5f);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (AutoScroll)
            {
                if (Height > ScrollableMinSize)
                {
                    Position = new Vector2(Position.X, ScrollTargetY);
                }
                else
                {
                    Position = new Vector2(Position.X, 540f);
                }
            }
        }

        public global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation Add(Item item)
        {
            items.Add(item);
            item.Container = this;
            OwnedComponents.Add(item.ValueWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            OwnedComponents.Add(item.SelectWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            item.ValueWiggler.UseRawDeltaTime = (item.SelectWiggler.UseRawDeltaTime = true);
            if (Selection == -1)
            {
                FirstSelection();
            }

            if (!BatchMode) RecalculateSize();
            item.Added();
            return this;
        }

        public void Clear()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// Everest's indexed Add: retains the numeric Selection, binds item resources,
        /// creates wigglers and invokes Added in the same order as Add.
        /// </summary>
        public TextMenuPresentation Insert(int index, Item item)
        {
            items.Insert(index, item);

            // Everything `Add` does after the list insert, in the same order.
            item.Container = this;
            OwnedComponents.Add(item.ValueWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            OwnedComponents.Add(item.SelectWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            item.ValueWiggler.UseRawDeltaTime = (item.SelectWiggler.UseRawDeltaTime = true);
            if (Selection == -1) FirstSelection();
            if (!BatchMode) RecalculateSize();
            item.Added();
            return this;
        }

        public TextMenuPresentation Remove(Item item)
        {
            int index = items.IndexOf(item);
            if (index == -1) return this;
            items.RemoveAt(index);
            item.Container = null;
            OwnedComponents.Remove(item.ValueWiggler);
            OwnedComponents.Remove(item.SelectWiggler);
            if (!BatchMode) RecalculateSize();
            return this;
        }

        public int IndexOf(Item item)
        {
            return items.IndexOf(item);
        }

        public void FirstSelection()
        {
            Selection = -1;
            MoveSelection(1);
        }

        public void MoveSelection(int direction, bool wiggle = false)
        {
            int selection = Selection;
            direction = Math.Sign(direction);
            int num = 0;
            foreach (Item item in items)
            {
                if (item.Hoverable)
                {
                    num++;
                }
            }

            bool flag = num > 2;
            do
            {
                Selection += direction;
                if (flag)
                {
                    if (Selection < 0)
                    {
                        Selection = items.Count - 1;
                    }
                    else if (Selection >= items.Count)
                    {
                        Selection = 0;
                    }
                }
                else if (Selection < 0 || Selection > items.Count - 1)
                {
                    Selection = Clamp(Selection, 0, items.Count - 1);
                    break;
                }
            } while (!Current.Hoverable);

            if (!Current.Hoverable)
            {
                Selection = selection;
            }

            if (Selection != selection && Current != null)
            {
                if (selection >= 0 && items[selection] != null && items[selection].OnLeave != null)
                {
                    items[selection].OnLeave();
                }

                if (Current.OnEnter != null)
                {
                    Current.OnEnter();
                }

                if (wiggle)
                {
                    PlaySound((direction > 0) ? "event:/ui/main/rollover_down" : "event:/ui/main/rollover_up");
                    Current.SelectWiggler.Start();
                }
            }
        }

        public void RecalculateSize()
        {
            if (BatchMode) recalculatingSizeInBatchMode = true;
            try
            {
                if (CompactWidthMode)
                {
                    LeftColumnWidth = RightColumnWidth = Height = 0f;
                    float sectionLeft = 0f, sectionRight = 0f;
                    foreach (Item item in items)
                    {
                        if (item is SubHeader subHeader && subHeader.CompactSectionStart)
                        {
                            LeftColumnWidth = Math.Max(LeftColumnWidth, sectionLeft + sectionRight);
                            sectionLeft = sectionRight = 0f;
                        }

                        if (item.Visible) Height += item.Height() + ItemSpacing;
                        if (item.IncludeWidthInMeasurement)
                        {
                            sectionLeft = Math.Max(sectionLeft, item.LeftWidth());
                            sectionRight = Math.Max(sectionRight, item.RightWidth());
                        }
                    }

                    Height -= ItemSpacing;
                    LeftColumnWidth = Math.Max(LeftColumnWidth, sectionLeft + sectionRight);
                    Width = Math.Max(MinWidth, LeftColumnWidth);
                    return;
                }

                float num = (Height = 0f);
                float leftColumnWidth = (RightColumnWidth = num);
                LeftColumnWidth = leftColumnWidth;
                foreach (Item item in items)
                {
                    if (item.IncludeWidthInMeasurement)
                    {
                        LeftColumnWidth = Math.Max(LeftColumnWidth, item.LeftWidth());
                    }
                }

                foreach (Item item2 in items)
                {
                    if (item2.IncludeWidthInMeasurement)
                    {
                        RightColumnWidth = Math.Max(RightColumnWidth, item2.RightWidth());
                    }
                }

                foreach (Item item3 in items)
                {
                    if (item3.Visible)
                    {
                        Height += item3.Height() + ItemSpacing;
                    }
                }

                Height -= ItemSpacing;
                Width = Math.Max(MinWidth, LeftColumnWidth + RightColumnWidth);
            }
            finally
            {
                if (BatchMode) recalculatingSizeInBatchMode = false;
            }
        }

        public float GetYOffsetOf(Item item)
        {
            if (item == null)
            {
                return 0f;
            }

            float num = 0f;
            foreach (Item item2 in items)
            {
                if (item2.Visible)
                {
                    num += item2.Height() + ItemSpacing;
                }

                if (item2 == item)
                {
                    break;
                }
            }

            return num - item.Height() * 0.5f - ItemSpacing;
        }

        public void Close()
        {
            if (Current != null && Current.OnLeave != null)
            {
                Current.OnLeave();
            }

            if (OnClose != null)
            {
                OnClose();
            }

            RemoveSelf();
        }

        public void CloseAndRun(IEnumerator routine, Action onClose)
        {
            Focused = false;
            Visible = false;
            AddCoroutine(CloseAndRunRoutine(routine, onClose));
        }

        private IEnumerator CloseAndRunRoutine(IEnumerator routine, Action onClose)
        {
            yield return routine;
            onClose?.Invoke();
            Close();
        }

        public override void Update()
        {
            base.Update();
            if (OnUpdate != null)
            {
                OnUpdate();
            }

            if (Focused)
            {
                if (Input.MenuDown.Pressed)
                {
                    if (!Input.MenuDown.Repeating || Selection != LastPossibleSelection)
                    {
                        MoveSelection(1, wiggle: true);
                    }
                }
                else if (Input.MenuUp.Pressed && (!Input.MenuUp.Repeating || Selection != FirstPossibleSelection))
                {
                    MoveSelection(-1, wiggle: true);
                }

                if (Current != null)
                {
                    if (Input.MenuLeft.Pressed)
                    {
                        Current.LeftPressed();
                    }

                    if (Input.MenuRight.Pressed)
                    {
                        Current.RightPressed();
                    }

                    if (Input.MenuConfirm.Pressed)
                    {
                        Current.ConfirmPressed();
                        if (Current.OnPressed != null)
                        {
                            Current.OnPressed();
                        }
                    }

                    if (Input.MenuJournal.Pressed && Current.OnAltPressed != null)
                    {
                        Current.OnAltPressed();
                    }
                }

                if (!Input.MenuConfirm.Pressed)
                {
                    if (Input.MenuCancel.Pressed && OnCancel != null)
                    {
                        OnCancel();
                    }
                    else if (Input.ESC.Pressed && OnESC != null)
                    {
                        Input.ESC.ConsumeBuffer();
                        OnESC();
                    }
                    else if (Input.Pause.Pressed && OnPause != null)
                    {
                        Input.Pause.ConsumeBuffer();
                        OnPause();
                    }
                }
            }

            foreach (Item item in items)
            {
                if (item.OnUpdate != null)
                {
                    item.OnUpdate();
                }

                item.Update();
            }

            if (!Process.AllowTextHighlight)
            {
                HighlightColor = HighlightColorA;
            }
            else if (((global::Celeste.Scene.Tracking.ISourceScene)EngineContext.Frame.Scenes.CurrentScene).SourceScene
                     .Clock.OnRawInterval(0.1f, EngineContext))
            {
                if (HighlightColor == HighlightColorA)
                {
                    HighlightColor = HighlightColorB;
                }
                else
                {
                    HighlightColor = HighlightColorA;
                }
            }

            if (AutoScroll)
            {
                if (Height > ScrollableMinSize)
                {
                    Position += Vector2.UnitY * ((ScrollTargetY - Position.Y) *
                                                 (1f - (float)Math.Pow(0.009999999776482582,
                                                     EngineContext.RawDeltaTime)));
                }
                else
                {
                    Position = new Vector2(Position.X, 540f);
                }
            }

            // Everest patches after the original TextMenu.Update. A page binding
            // advances by item Y until it crosses one 1080-pixel screen.
            if (Focused && items.Exists(item => item.Hoverable))
            {
                if (Process.MenuPageDownPressed && Selection != LastPossibleSelection)
                {
                    Current.OnLeave?.Invoke();
                    float startY = GetYOffsetOf(Current);
                    while (GetYOffsetOf(Current) < startY + 1080f && Selection < LastPossibleSelection)
                        MoveSelection(1);
                    PlaySound("event:/ui/main/rollover_down");
                    Current.OnEnter?.Invoke();
                }
                else if (Process.MenuPageUpPressed && Selection != FirstPossibleSelection)
                {
                    Current.OnLeave?.Invoke();
                    float startY = GetYOffsetOf(Current);
                    while (GetYOffsetOf(Current) > startY - 1080f && Selection > FirstPossibleSelection)
                        MoveSelection(-1);
                    PlaySound("event:/ui/main/rollover_up");
                    Current.OnEnter?.Invoke();
                }
            }
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
            => Process.TextMenuPolicy.Render(this, context);
    }
}
