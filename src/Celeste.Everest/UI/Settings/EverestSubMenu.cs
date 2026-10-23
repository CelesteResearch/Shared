using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestSubMenu : TextMenuPresentation.Item
    {
        public string Label;

        private readonly AtlasEntry Icon;

        private readonly List<TextMenuPresentation.Item> delayedAddItems;

        /// <inheritdoc cref="F:Celeste.TextMenuPresentation.Selection" />
        public int Selection;

        /// <inheritdoc cref="F:Celeste.TextMenuPresentation.ItemSpacing" />
        public float ItemSpacing;

        public float ItemIndent;

        /// <inheritdoc cref="F:Celeste.TextMenuPresentation.HighlightColor" />
        private PackedColor HighlightColor;

        public string ConfirmSfx;

        public bool AlwaysCenter;

        public float LeftColumnWidth;

        public float RightColumnWidth;

        public bool Focused;

        public bool AutoScroll;

        public bool ItemsVisible;

        public EverestSubMenu Parent;

        private readonly bool enterOnSelect;

        private bool entering;

        private float ease;

        /// <inheritdoc cref="P:Celeste.TextMenuPresentation.Items" />
        public List<TextMenuPresentation.Item> Items { get; private set; }

        /// <inheritdoc cref="P:Celeste.TextMenuPresentation.Current" />
        public TextMenuPresentation.Item Current
        {
            get
            {
                if (Items.Count <= 0 || Selection < 0 || Selection >= Items.Count) return null;

                return Items[Selection];
            }
            set => Selection = Items.IndexOf(value);
        }

        /// <inheritdoc cref="P:Celeste.TextMenuPresentation.FirstPossibleSelection" />
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

        /// <inheritdoc cref="P:Celeste.TextMenuPresentation.LastPossibleSelection" />
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

        /// <inheritdoc cref="P:Celeste.TextMenuPresentation.ScrollTargetY" />
        public float ScrollTargetY
        {
            get
            {
                var min = EngineRuntime.Height - 150f - Container.Height * Container.Justify.Y;
                var max = 150f + Container.Height * Container.Justify.Y;
                var num = Current != null
                    ? GetYOffsetOf(Current)
                    : GetYOffsetOf(Items[Math.Min(Math.Max(Selection, 0), Items.Count - 1)]);
                return ScalarMath.Clamp(
                    EngineRuntime.Height / 2 + Container.Height * Container.Justify.Y - num, min, max,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
            }
        }

        public float TitleHeight { get; private set; }

        public float MenuHeight { get; private set; }

        /// <summary>
        ///     Create a new EverestSubMenu.
        /// </summary>
        /// <param name="label" />
        /// <param name="enterOnSelect">Expand submenu when selected</param>
        public EverestSubMenu(TextMenuResources resources, string label, bool enterOnSelect)
        {
            Resources = resources;
            ConfirmSfx = "event:/ui/main/button_select";
            Label = label;
            Icon = ResourceSet.Gui("downarrow");
            Selectable = true;
            IncludeWidthInMeasurement = true;
            this.enterOnSelect = enterOnSelect;
            OnEnter = delegate
            {
                if (this.enterOnSelect) ConfirmPressed();
            };
            Items = [];
            delayedAddItems = [];
            Selection = -1;
            ItemSpacing = 4f;
            ItemIndent = 20f;
            HighlightColor = PackedColor.White;
            RecalculateSize();
        }

        /// <summary>
        ///     Add any non-submenu <see cref="T:Celeste.TextMenuPresentation.Item" /> to the Submenu
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <returns />
        public EverestSubMenu Add(TextMenuPresentation.Item item)
        {
            if (Container != null)
            {
                Items.Add(item);
                item.Container = Container;
                if (item is EverestSubMenu subMenu) subMenu.Parent = this;

                Container.OwnedComponents.Add(item.ValueWiggler =
                    ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                Container.OwnedComponents.Add(item.SelectWiggler =
                    ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                item.ValueWiggler.UseRawDeltaTime = item.SelectWiggler.UseRawDeltaTime = true;
                RecalculateSize();
                item.Added();
                return this;
            }

            delayedAddItems.Add(item);
            return this;
        }

        /// <summary>
        ///     Insert any non-submenu <see cref="T:Celeste.TextMenuPresentation.Item" /> into the Submenu at
        ///     <paramref name="index" />
        /// </summary>
        /// <param name="index" />
        /// <param name="item">Item to be inserted</param>
        /// <returns />
        /// v
        public EverestSubMenu Insert(int index, TextMenuPresentation.Item item)
        {
            if (Container != null)
            {
                Items.Insert(index, item);
                item.Container = Container;
                if (item is EverestSubMenu subMenu) subMenu.Parent = this;

                Container.OwnedComponents.Add(item.ValueWiggler =
                    ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                Container.OwnedComponents.Add(item.SelectWiggler =
                    ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                item.ValueWiggler.UseRawDeltaTime = item.SelectWiggler.UseRawDeltaTime = true;
                RecalculateSize();
                item.Added();
                return this;
            }

            delayedAddItems.Insert(index, item);
            return this;
        }

        public bool ContainsDelayedAddItem(TextMenuPresentation.Item item)
        {
            return Container == null ? delayedAddItems.Contains(item) : false;
        }

        public EverestSubMenu InsertDelayedAddItem(TextMenuPresentation.Item item, TextMenuPresentation.Item after)
        {
            if (Container == null && delayedAddItems.Contains(after))
                delayedAddItems.Insert(delayedAddItems.IndexOf(after) + 1, item);

            return this;
        }

        /// <summary>
        ///     Remove any non-submenu <see cref="T:Celeste.TextMenuPresentation.Item" /> from the Submenu
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns />
        /// v
        public EverestSubMenu Remove(TextMenuPresentation.Item item)
        {
            if (Container != null)
            {
                if (!Items.Remove(item)) return this;

                item.Container = null;
                if (item is EverestSubMenu subMenu) subMenu.Parent = null;

                Container.OwnedComponents.Remove(item.ValueWiggler);
                Container.OwnedComponents.Remove(item.SelectWiggler);
                RecalculateSize();
                return this;
            }

            delayedAddItems.Remove(item);
            return this;
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.Clear" />
        public void Clear()
        {
            Items = [];
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.IndexOf(Celeste.TextMenuPresentation.Item)" />
        public int IndexOf(TextMenuPresentation.Item item)
        {
            return Items.IndexOf(item);
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.FirstSelection" />
        public void FirstSelection()
        {
            Selection = -1;
            MoveSelection(1);
        }

        /// <summary>
        ///     Set the selection to the last possible <see cref="T:Celeste.TextMenuPresentation.Item" />.
        /// </summary>
        public void LastSelection()
        {
            Selection = Items.Count;
            MoveSelection(-1);
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.MoveSelection(System.Int32,System.Boolean)" />
        public void MoveSelection(int direction, bool wiggle = false)
        {
            var selection = Selection;
            direction = Math.Sign(direction);
            var num = 0;
            foreach (var item in Items)
                if (item.Hoverable)
                    num++;

            do
            {
                Selection += direction;
                if (enterOnSelect && !entering && (Selection < 0 || Selection >= Items.Count))
                {
                    Selection = selection;
                    Exit();
                    if (Parent == null)
                        Container.MoveSelection(direction, true);
                    else
                        Parent.MoveSelection(direction, true);

                    return;
                }

                if (num > 2)
                {
                    if (Selection < 0)
                        Selection = Items.Count - 1;
                    else if (Selection >= Items.Count) Selection = 0;
                }
                else if (Selection < 0 || Selection > Items.Count - 1)
                {
                    Selection = Math.Min(Math.Max(Selection, 0), Items.Count - 1);
                    break;
                }
            } while (!Current.Hoverable);

            if (!Current.Hoverable) Selection = selection;

            if (Selection != selection && Current != null)
            {
                if (selection >= 0 && selection < Items.Count && Items[selection] != null &&
                    Items[selection].OnLeave != null)
                    Items[selection].OnLeave();

                Current.OnEnter?.Invoke();
                if (wiggle)
                {
                    ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(direction > 0
                        ? "event:/ui/main/rollover_down"
                        : "event:/ui/main/rollover_up");
                    Current.SelectWiggler.Start();
                }
            }
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.RecalculateSize" />
        public void RecalculateSize()
        {
            TitleHeight = ActiveFont.LineHeight;
            if (Items.Count < 1) return;

            var rightColumnWidth = MenuHeight = 0f;
            LeftColumnWidth = RightColumnWidth = rightColumnWidth;
            foreach (var item in Items)
                if (item.IncludeWidthInMeasurement)
                    LeftColumnWidth = Math.Max(LeftColumnWidth, item.LeftWidth());

            foreach (var item2 in Items)
                if (item2.IncludeWidthInMeasurement)
                    RightColumnWidth = Math.Max(RightColumnWidth, item2.RightWidth());

            foreach (var item3 in Items)
                if (item3.Visible)
                {
                    if (item3 is EverestSubMenu subMenu) subMenu.RecalculateSize();

                    MenuHeight += item3.Height() + Container.ItemSpacing;
                }

            MenuHeight -= Container.ItemSpacing;
        }

        /// <inheritdoc cref="M:Celeste.TextMenuPresentation.GetYOffsetOf(Celeste.TextMenuPresentation.Item)" />
        public float GetYOffsetOf(TextMenuPresentation.Item item)
        {
            var num = (Parent != null ? Parent.GetYOffsetOf(this) : Container.GetYOffsetOf(this)) - Height() * 0.5f;
            if (item == null) return num + TitleHeight * 0.5f;

            num += TitleHeight;
            foreach (var item2 in Items)
            {
                if (item2.Visible) num += item2.Height() + ItemSpacing;

                if (item2 == item) break;
            }

            return num - item.Height() * 0.5f - ItemSpacing;
        }

        public void Exit()
        {
            Current?.OnLeave?.Invoke();
            Focused = false;
            ItemsVisible = false;
            if (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp.Repeating &&
                !((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuDown.Repeating)
                ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play("event:/ui/main/button_back");

            if (Parent == null)
            {
                Container.AutoScroll = AutoScroll;
                Container.Focused = true;
            }
            else
            {
                Parent.AutoScroll = AutoScroll;
                Parent.Focused = true;
            }
        }

        public override string SearchLabel()
        {
            return Label;
        }

        public override void ConfirmPressed()
        {
            if (Items.Count > 0)
            {
                if (Parent == null)
                    Container.Focused = false;
                else
                    Parent.Focused = false;

                Focused = true;
                ItemsVisible = true;
                if (Parent == null)
                {
                    AutoScroll = Container.AutoScroll;
                    Container.AutoScroll = false;
                }
                else
                {
                    AutoScroll = Parent.AutoScroll;
                    Parent.AutoScroll = false;
                }

                entering = true;
                if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp.Pressed)
                    LastSelection();
                else
                    FirstSelection();

                entering = false;
                if (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp.Repeating &&
                    !((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuDown.Repeating)
                    ((IOriginalGameplayProcess)ResourceSet.EngineContext).AudioSession.Play(ConfirmSfx);

                base.ConfirmPressed();
            }
        }

        public override float LeftWidth()
        {
            return ActiveFont.Measure(Label).X;
        }

        public override float RightWidth()
        {
            return Icon.FrameWidth;
        }

        public override float Height()
        {
            if (Items.Count > 0)
                return TitleHeight + MenuHeight *
                    ((ISourceEasingEnvironment)ResourceSet.EngineContext)
                    .EasingArithmetic.QuadOut(ease);

            return TitleHeight;
        }

        public override void Added()
        {
            base.Added();
            foreach (var delayedAddItem in delayedAddItems) Add(delayedAddItem);
        }

        public override void Update()
        {
            if (ItemsVisible)
                ease = ScalarMath.Approach(ease, 1f, ResourceSet.EngineContext.RawDeltaTime * 4f,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
            else
                ease = ScalarMath.Approach(ease, 0f, ResourceSet.EngineContext.RawDeltaTime * 4f,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);

            base.Update();
            if (Focused && ease > 0.9f)
            {
                if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuDown.Pressed &&
                    (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuDown
                         .Repeating ||
                     Selection != LastPossibleSelection || enterOnSelect))
                    MoveSelection(1, true);
                else if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp.Pressed &&
                         (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuUp
                              .Repeating ||
                          Selection != FirstPossibleSelection || enterOnSelect))
                    MoveSelection(-1, true);

                if (Current != null)
                {
                    if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuLeft.Pressed)
                        Current.LeftPressed();

                    if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuRight.Pressed)
                        Current.RightPressed();

                    if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuConfirm
                        .Pressed)
                    {
                        Current.ConfirmPressed();
                        Current.OnPressed?.Invoke();
                    }

                    if (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuJournal
                        .Pressed &&
                        Current.OnAltPressed != null)
                        Current.OnAltPressed();
                }

                if (!((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuConfirm
                        .Pressed &&
                    (((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.MenuCancel.Pressed ||
                     ((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.ESC.Pressed ||
                     ((IOriginalGameInputProcessEnvironment)ResourceSet.EngineContext).InputSource.Pause.Pressed))
                    Exit();
            }

            foreach (var item in Items)
            {
                item.OnUpdate?.Invoke();
                item.Update();
            }

            if (!((ITextMenuProcessEnvironment)ResourceSet.EngineContext).AllowTextHighlight)
            {
                HighlightColor = TextMenuPresentation.HighlightColorA;
            }
            else if (((ISourceScene)ResourceSet.EngineContext.Frame.Scenes.CurrentScene).SourceScene.Clock
                     .OnRawInterval(
                         0.1f, ResourceSet.EngineContext))
            {
                if (HighlightColor == TextMenuPresentation.HighlightColorA)
                    HighlightColor = TextMenuPresentation.HighlightColorB;
                else
                    HighlightColor = TextMenuPresentation.HighlightColorA;
            }

            if (Focused && AutoScroll)
            {
                if (Container.Height > Container.ScrollableMinSize)
                {
                    var currentPosition = Container.Position;
                    currentPosition.Y += (ScrollTargetY - Container.Position.Y) *
                                         (1f - (float)Math.Pow(0.009999999776482582,
                                             ResourceSet.EngineContext.RawDeltaTime));
                    Container.Position = currentPosition;
                }
                else
                {
                    var currentPosition = Container.Position;
                    currentPosition.Y = 540f;
                    Container.Position = currentPosition;
                }
            }
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            var vector = new Vector2(position.X, position.Y - Height() / 2f);
            var alpha = Container.Alpha;
            var color = Disabled
                ? PackedColor.DarkSlateGray
                : (highlighted ? Container.HighlightColor : PackedColor.White) * alpha;
            var strokeColor = PackedColor.Black * (alpha * alpha * alpha);
            var flag = Container.InnerContent == TextMenuPresentation.InnerContentMode.TwoColumn && !AlwaysCenter;
            var position2 =
                SourceVector2Math.Add(
                    SourceVector2Math.Add(vector,
                        SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, TitleHeight), 1f / 2f)),
                    flag ? Vector2.Zero : new(Container.Width * 0.5f, 0f));
            var justify = flag ? new Vector2(0f, 0.5f) : new Vector2(0.5f, 0.5f);
            var justify2 = flag
                ? new Vector2(ActiveFont.Measure(Label).X + Icon.FrameWidth, 5f)
                : new Vector2(ActiveFont.Measure(Label).X / 2f + Icon.FrameWidth, 5f);
            DrawIcon(context, position2, Icon, justify2, true,
                (Disabled || Items.Count < 1
                    ? PackedColor.DarkSlateGray
                    : Focused
                        ? Container.HighlightColor
                        : PackedColor.White) * alpha, 0.8f);
            ActiveFont.DrawOutline(context, Container, Label, position2, justify, Vector2.One, color, 2f, strokeColor);
            if (!ItemsVisible || !(ease > 0.9f)) return;

            var vector2 = new Vector2(vector.X + ItemIndent, vector.Y + TitleHeight + ItemSpacing);
            RecalculateSize();
            foreach (var item in Items)
                if (item.Visible)
                {
                    var num = item.Height();
                    var position3 =
                        SourceVector2Math.Add(vector2, new(0f, num * 0.5f + item.SelectWiggler.Value * 8f));
                    if (position3.Y + num * 0.5f > 0f && position3.Y - num * 0.5f < EngineRuntime.Height)
                        item.Render(context, position3, Focused && Current == item);

                    vector2.Y += num + ItemSpacing;
                }
        }

        private void DrawIcon(ISourceRenderContext context, Vector2 position, AtlasEntry icon,
            Vector2 justify, bool outline, PackedColor color, float scale)
        {
            if (outline)
                SourceAtlasDrawing.DrawOutline(context, Container, icon,
                    SourceVector2Math.Add(position, justify), icon.Center, color);
            else
                SourceAtlasDrawing.DrawCentered(context, Container, icon,
                    SourceVector2Math.Add(position, justify), color, scale);
        }
    }
}
