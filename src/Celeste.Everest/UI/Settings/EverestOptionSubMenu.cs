using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Reflection.Runtime;
using Celeste.Core.Rendering;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    [RuntimeTypeAlias("Celeste.TextMenuExt+OptionSubMenu")]
    public partial class EverestOptionSubMenu : TextMenuPresentation.Item
    {
        public string Label;

        private AtlasEntry Icon;

        private List<Tuple<string, List<TextMenuPresentation.Item>>> delayedAddMenus;

        public int MenuIndex;

        private int initialSelection;

        /// <inheritdoc cref="F:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Selection" />
        public int Selection;

        private int lastDir;

        private float sine;

        /// <summary>
        ///       Invoked when the selected menu is changed.
        ///       </summary>
        public Action<int> OnValueChange;

        /// <inheritdoc cref="F:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.ItemSpacing" />
        public float ItemSpacing;

        public float ItemIndent;

        private PackedColor HighlightColor;

        public string ConfirmSfx;

        public bool AlwaysCenter;

        public float LeftColumnWidth;

        public float RightColumnWidth;

        private float targetMenuHeight;

        public bool Focused;

        private bool wasFocused;

        private bool containerAutoScroll;

        public List<Tuple<string, List<TextMenuPresentation.Item>>> Menus { get; private set; }

        /// <summary>
        ///       The selected set of <see cref="T:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Item" />s.
        ///       </summary>
        public List<TextMenuPresentation.Item> CurrentMenu
        {
            get
            {
                if (Menus.Count <= 0)
                {
                    return null;
                }

                return Menus[MenuIndex].Item2;
            }
        }

        /// <inheritdoc cref="P:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Current" />
        public TextMenuPresentation.Item Current
        {
            get
            {
                if (CurrentMenu.Count <= 0 || Selection < 0)
                {
                    return null;
                }

                return CurrentMenu[Selection];
            }
        }

        /// <inheritdoc cref="P:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.FirstPossibleSelection" />
        public int FirstPossibleSelection
        {
            get
            {
                for (int i = 0; i < CurrentMenu.Count; i++)
                {
                    if (CurrentMenu[i] != null && CurrentMenu[i].Hoverable)
                    {
                        return i;
                    }
                }

                return 0;
            }
        }

        /// <inheritdoc cref="P:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.LastPossibleSelection" />
        public int LastPossibleSelection
        {
            get
            {
                for (int num = CurrentMenu.Count - 1; num >= 0; num--)
                {
                    if (CurrentMenu[num] != null && CurrentMenu[num].Hoverable)
                    {
                        return num;
                    }
                }

                return 0;
            }
        }

        /// <inheritdoc cref="P:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.ScrollTargetY" />
        public float ScrollTargetY
        {
            get
            {
                float min = (float)(EngineRuntime.Height - 150) - Container.Height * Container.Justify.Y;
                float max = 150f + Container.Height * Container.Justify.Y;
                return ScalarMath.Clamp(
                    (float)(EngineRuntime.Height / 2) + Container.Height * Container.Justify.Y - GetYOffsetOf(Current),
                    min, max, ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
            }
        }

        public float TitleHeight { get; private set; }

        public float MenuHeight { get; private set; }

        public EverestOptionSubMenu(TextMenuResources resources, string label)
        {
            Resources = resources;
            ConfirmSfx = "event:/ui/main/button_select";
            Label = label;
            Icon = ResourceSet.Gui("downarrow");
            Selectable = true;
            IncludeWidthInMeasurement = true;
            MenuIndex = 0;
            Menus = new List<Tuple<string, List<TextMenuPresentation.Item>>>();
            delayedAddMenus = new List<Tuple<string, List<TextMenuPresentation.Item>>>();
            Selection = -1;
            ItemSpacing = 4f;
            ItemIndent = 20f;
            HighlightColor = PackedColor.White;
            RecalculateSize();
        }

        /// <summary>
        ///       Add a list of non-submenu <see cref="T:Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Item" />s to the Submenu
        ///       </summary>
        /// <param name="label">Displayed submenu label</param>
        /// <param name="items">Items to be added to the submenu</param>
        /// <returns />
        public EverestOptionSubMenu Add(string label, List<TextMenuPresentation.Item> items)
        {
            if (Container != null)
            {
                if (items != null)
                {
                    foreach (TextMenuPresentation.Item item in items)
                    {
                        item.Container = Container;
                        Container.OwnedComponents.Add(item.ValueWiggler =
                            ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                        Container.OwnedComponents.Add(item.SelectWiggler =
                            ((ISourceWigglerPoolScope)ResourceSet.EngineContext).WigglerPool.Create(0.25f, 3f));
                        item.ValueWiggler.UseRawDeltaTime = (item.SelectWiggler.UseRawDeltaTime = true);
                        item.Added();
                    }

                    Menus.Add(new Tuple<string, List<TextMenuPresentation.Item>>(label, items));
                }
                else
                {
                    Menus.Add(new Tuple<string, List<TextMenuPresentation.Item>>(label,
                        new List<TextMenuPresentation.Item>()));
                }

                if (Selection == -1)
                {
                    FirstSelection();
                }

                RecalculateSize();
                return this;
            }

            delayedAddMenus.Add(new Tuple<string, List<TextMenuPresentation.Item>>(label, items));
            return this;
        }

        public EverestOptionSubMenu SetInitialSelection(int index)
        {
            initialSelection = index;
            return this;
        }

        public void Clear()
        {
            Menus = new List<Tuple<string, List<TextMenuPresentation.Item>>>();
        }

        public void RecalculateSize()
        {
            TitleHeight = ActiveFont.LineHeight;
            LeftColumnWidth = (RightColumnWidth = (targetMenuHeight = 0f));
            if (Menus.Count < 1 || CurrentMenu == null)
            {
                return;
            }

            foreach (TextMenuPresentation.Item item in CurrentMenu)
            {
                if (item.IncludeWidthInMeasurement)
                {
                    LeftColumnWidth = Math.Max(LeftColumnWidth, item.LeftWidth());
                }
            }

            foreach (TextMenuPresentation.Item item2 in CurrentMenu)
            {
                if (item2.IncludeWidthInMeasurement)
                {
                    RightColumnWidth = Math.Max(RightColumnWidth, item2.RightWidth());
                }
            }

            foreach (TextMenuPresentation.Item item3 in CurrentMenu)
            {
                if (item3.Visible)
                {
                    targetMenuHeight += item3.Height() + Container.ItemSpacing;
                }
            }

            targetMenuHeight -= Container.ItemSpacing;
        }

        public float GetYOffsetOf(TextMenuPresentation.Item item)
        {
            float num = Container.GetYOffsetOf(this) - Height() * 0.5f;
            if (item == null)
            {
                return num + TitleHeight * 0.5f;
            }

            num += TitleHeight;
            foreach (TextMenuPresentation.Item item2 in CurrentMenu)
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

        public override string SearchLabel()
        {
            return Label;
        }

        /// <summary>
        ///       Set the action to be invoked when the selected menu is changed.
        ///       </summary>
        public EverestOptionSubMenu Change(Action<int> onValueChange)
        {
            OnValueChange = onValueChange;
            return this;
        }


        public override float LeftWidth()
        {
            return ActiveFont.Measure(Label).X;
        }

        public override float RightWidth()
        {
            float num = 0f;
            foreach (string item in Menus.Select((Tuple<string, List<TextMenuPresentation.Item>> tuple) => tuple.Item1))
            {
                num = Math.Max(num, ActiveFont.Measure(item).X);
            }

            return num + 120f;
        }

        public override float Height()
        {
            return TitleHeight + Math.Max(MenuHeight, 0f);
        }

        public override void Added()
        {
            base.Added();
            foreach (Tuple<string, List<TextMenuPresentation.Item>> delayedAddMenu in delayedAddMenus)
            {
                Add(delayedAddMenu.Item1, delayedAddMenu.Item2);
            }

            MenuIndex = initialSelection;
        }
    }
}
