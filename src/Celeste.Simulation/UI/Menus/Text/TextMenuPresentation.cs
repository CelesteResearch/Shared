using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display.Colors;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation : IPausableMenu
    {
        public enum InnerContentMode
        {
            OneColumn,
            TwoColumn,
        }

        public bool Focused = true;
        public bool RenderAsFocused;

        public InnerContentMode InnerContent;

        private List<Item> items = [];

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public List<Item> Items => items;
        public int Selection = -1;

        public Vector2 Justify;

        public float ItemSpacing = 4f;

        public float MinWidth;
        public bool CompactWidthMode;

        public bool BatchMode
        {
            get => WatchRawBatchMode;
            set
            {
                WatchRawBatchMode = value;
                if (!value) RecalculateSize();
            }
        }

        public bool WatchRawBatchMode { get; set; }

        public float Alpha = 1f;

        public PackedColor HighlightColor =
            PackedColor.White;

        public static readonly PackedColor HighlightColorA =
            SourceHexColor.HexToColor("84FF54");

        public static readonly PackedColor HighlightColorB =
            SourceHexColor.HexToColor("FCFF59");

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
                if (Items.Count <= 0 || Selection < 0) return null;

                return Items[Selection];
            }
            set => Selection = Items.IndexOf(value);
        }

        // TextMenu.GetWidth/GetHeight recalculate while BatchMode is active, with a
        // reentrancy guard because item measurements can themselves read menu size.
        // Keep the raw fields separate: the original Watch All exposes both each
        // field and its property, and the values can differ until that getter runs.

        public new float Width
        {
            get
            {
                if (WatchRawBatchMode && !WatchRecalculatingSizeInBatchMode) RecalculateSize();
                return WatchRawWidth;
            }
            private set => WatchRawWidth = value;
        }

        public new float Height
        {
            get
            {
                if (WatchRawBatchMode && !WatchRecalculatingSizeInBatchMode) RecalculateSize();
                return WatchRawHeight;
            }
            private set => WatchRawHeight = value;
        }

        public float LeftColumnWidth
        {
            get
            {
                if (WatchRawBatchMode && !WatchRecalculatingSizeInBatchMode) RecalculateSize();
                return WatchRawLeftColumnWidth;
            }
            private set => WatchRawLeftColumnWidth = value;
        }

        public float RightColumnWidth
        {
            get
            {
                if (WatchRawBatchMode && !WatchRecalculatingSizeInBatchMode) RecalculateSize();
                return WatchRawRightColumnWidth;
            }
            private set => WatchRawRightColumnWidth = value;
        }

        public bool WatchRecalculatingSizeInBatchMode { get; set; }

        public float WatchRawWidth { get; set; }

        public float WatchRawHeight { get; set; }

        public float WatchRawLeftColumnWidth { get; set; }

        public float WatchRawRightColumnWidth { get; set; }

        public float ScrollableMinSize => Graphics.Height - 300;

        public int FirstPossibleSelection
        {
            get
            {
                for (var i = 0; i < Items.Count; i++)
                    if (Items[i] != null && Items[i].Hoverable)
                        return i;

                return 0;
            }
        }

        public int LastPossibleSelection
        {
            get
            {
                for (var num = Items.Count - 1; num >= 0; num--)
                    if (Items[num] != null && Items[num].Hoverable)
                        return num;

                return 0;
            }
        }

        public float ScrollTargetY
        {
            get
            {
                var min = Graphics.Height - 150 - Height * Justify.Y;
                var max = 150f + Height * Justify.Y;
                return Clamp(Graphics.Height / 2 + Height * Justify.Y - GetYOffsetOf(Current), min, max);
            }
        }

        public TextMenuPresentation(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            Tags = ((ITextMenuProcessEnvironment)engine).TextMenuTags;
            drawing = new(Resources);
            Position = new Vector2(Graphics.Width, Graphics.Height) / 2f;
            Justify = new(0.5f, 0.5f);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (AutoScroll)
            {
                if (Height > ScrollableMinSize)
                    Position = new(Position.X, ScrollTargetY);
                else
                    Position = new(Position.X, 540f);
            }
        }

        public TextMenuPresentation Add(Item item)
        {
            Items.Add(item);
            item.Container = this;
            OwnedComponents.Add(item.ValueWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            OwnedComponents.Add(item.SelectWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            item.ValueWiggler.UseRawDeltaTime = item.SelectWiggler.UseRawDeltaTime = true;
            if (Selection == -1) FirstSelection();

            if (!BatchMode) RecalculateSize();
            item.Added();
            return this;
        }

        public void Clear()
        {
            items = [];
        }

        /// <summary>
        ///     Everest's indexed Add: retains the numeric Selection, binds item resources,
        ///     creates wigglers and invokes Added in the same order as Add.
        /// </summary>
        public TextMenuPresentation Insert(int index, Item item)
        {
            Items.Insert(index, item);

            // Everything `Add` does after the list insert, in the same order.
            item.Container = this;
            OwnedComponents.Add(item.ValueWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            OwnedComponents.Add(item.SelectWiggler =
                ((ISourceWigglerPoolScope)EngineContext).WigglerPool.Create(0.25f, 3f));
            item.ValueWiggler.UseRawDeltaTime = item.SelectWiggler.UseRawDeltaTime = true;
            if (Selection == -1) FirstSelection();
            if (!BatchMode) RecalculateSize();
            item.Added();
            return this;
        }

        public TextMenuPresentation Remove(Item item)
        {
            var index = Items.IndexOf(item);
            if (index == -1) return this;
            Items.RemoveAt(index);
            item.Container = null;
            OwnedComponents.Remove(item.ValueWiggler);
            OwnedComponents.Remove(item.SelectWiggler);
            if (!BatchMode) RecalculateSize();
            return this;
        }

        public int IndexOf(Item item)
        {
            return Items.IndexOf(item);
        }

        public void FirstSelection()
        {
            Selection = -1;
            MoveSelection(1);
        }

        public void MoveSelection(int direction, bool wiggle = false)
        {
            var selection = Selection;
            direction = Math.Sign(direction);
            var num = 0;
            foreach (var item in Items)
                if (item.Hoverable)
                    num++;

            var flag = num > 2;
            do
            {
                Selection += direction;
                if (flag)
                {
                    if (Selection < 0)
                        Selection = Items.Count - 1;
                    else if (Selection >= Items.Count) Selection = 0;
                }
                else if (Selection < 0 || Selection > Items.Count - 1)
                {
                    Selection = Clamp(Selection, 0, Items.Count - 1);
                    break;
                }
            } while (!Current.Hoverable);

            if (!Current.Hoverable) Selection = selection;

            if (Selection != selection && Current != null)
            {
                if (selection >= 0 && Items[selection] != null && Items[selection].OnLeave != null)
                    Items[selection].OnLeave();

                if (Current.OnEnter != null) Current.OnEnter();

                if (wiggle)
                {
                    PlaySound(direction > 0 ? "event:/ui/main/rollover_down" : "event:/ui/main/rollover_up");
                    Current.SelectWiggler.Start();
                }
            }
        }

        public void RecalculateSize()
        {
            if (BatchMode) WatchRecalculatingSizeInBatchMode = true;
            try
            {
                if (CompactWidthMode)
                {
                    LeftColumnWidth = RightColumnWidth = Height = 0f;
                    float sectionLeft = 0f, sectionRight = 0f;
                    foreach (var item in Items)
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

                var num = Height = 0f;
                var leftColumnWidth = RightColumnWidth = num;
                LeftColumnWidth = leftColumnWidth;
                foreach (var item in Items)
                    if (item.IncludeWidthInMeasurement)
                        LeftColumnWidth = Math.Max(LeftColumnWidth, item.LeftWidth());

                foreach (var item2 in Items)
                    if (item2.IncludeWidthInMeasurement)
                        RightColumnWidth = Math.Max(RightColumnWidth, item2.RightWidth());

                foreach (var item3 in Items)
                    if (item3.Visible)
                        Height += item3.Height() + ItemSpacing;

                Height -= ItemSpacing;
                Width = Math.Max(MinWidth, LeftColumnWidth + RightColumnWidth);
            }
            finally
            {
                if (BatchMode) WatchRecalculatingSizeInBatchMode = false;
            }
        }

        public float GetYOffsetOf(Item item)
        {
            if (item == null) return 0f;

            var num = 0f;
            foreach (var item2 in Items)
            {
                if (item2.Visible) num += item2.Height() + ItemSpacing;

                if (item2 == item) break;
            }

            return num - item.Height() * 0.5f - ItemSpacing;
        }

        public void Close()
        {
            if (Current != null && Current.OnLeave != null) Current.OnLeave();

            if (OnClose != null) OnClose();

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
            if (OnUpdate != null) OnUpdate();

            if (Focused)
            {
                if (Input.MenuDown.Pressed)
                {
                    if (!Input.MenuDown.Repeating || Selection != LastPossibleSelection) MoveSelection(1, true);
                }
                else if (Input.MenuUp.Pressed && (!Input.MenuUp.Repeating || Selection != FirstPossibleSelection))
                {
                    MoveSelection(-1, true);
                }

                if (Current != null)
                {
                    if (Input.MenuLeft.Pressed) Current.LeftPressed();

                    if (Input.MenuRight.Pressed) Current.RightPressed();

                    if (Input.MenuConfirm.Pressed)
                    {
                        Current.ConfirmPressed();
                        if (Current.OnPressed != null) Current.OnPressed();
                    }

                    if (Input.MenuJournal.Pressed && Current.OnAltPressed != null) Current.OnAltPressed();
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

            foreach (var item in Items)
            {
                if (item.OnUpdate != null) item.OnUpdate();

                item.Update();
            }

            if (!Process.AllowTextHighlight)
            {
                HighlightColor = HighlightColorA;
            }
            else if (((ISourceScene)EngineContext.Frame.Scenes.CurrentScene).SourceScene
                     .Clock.OnRawInterval(0.1f, EngineContext))
            {
                if (HighlightColor == HighlightColorA)
                    HighlightColor = HighlightColorB;
                else
                    HighlightColor = HighlightColorA;
            }

            if (AutoScroll)
            {
                if (Height > ScrollableMinSize)
                    Position += Vector2.UnitY * ((ScrollTargetY - Position.Y) *
                                                 (1f - (float)Math.Pow(0.009999999776482582,
                                                     EngineContext.RawDeltaTime)));
                else
                    Position = new(Position.X, 540f);
            }

            // Everest patches after the original TextMenu.Update. A page binding
            // advances by item Y until it crosses one 1080-pixel screen.
            if (Focused && Items.Exists(item => item.Hoverable))
            {
                if (Process.MenuPageDownPressed && Selection != LastPossibleSelection)
                {
                    Current.OnLeave?.Invoke();
                    var startY = GetYOffsetOf(Current);
                    while (GetYOffsetOf(Current) < startY + 1080f && Selection < LastPossibleSelection)
                        MoveSelection(1);
                    PlaySound("event:/ui/main/rollover_down");
                    Current.OnEnter?.Invoke();
                }
                else if (Process.MenuPageUpPressed && Selection != FirstPossibleSelection)
                {
                    Current.OnLeave?.Invoke();
                    var startY = GetYOffsetOf(Current);
                    while (GetYOffsetOf(Current) > startY - 1080f && Selection > FirstPossibleSelection)
                        MoveSelection(-1);
                    PlaySound("event:/ui/main/rollover_up");
                    Current.OnEnter?.Invoke();
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Process.TextMenuPolicy.Render(this, context);
        }
    }
}
