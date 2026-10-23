using System.Collections;
using System.Collections.Generic;
using Celeste.Input.Bindings;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Simulation.Rendering
{
    // The UI reads the actual mutable binding lists; it does not own or copy them.
    public sealed class ControlBindingMenuAdapter : ITextMenuBinding
    {
        private readonly View keyboardView, controllerView;

        public ControlBindingMenuAdapter(SourceInputBinding binding)
        {
            keyboardView = new(binding, false);
            controllerView = new(binding, true);
        }

        public IReadOnlyList<TextMenuBindingValue> Keyboard => keyboardView;

        public IReadOnlyList<TextMenuBindingValue> Controller =>
            controllerView;

        private sealed class View : IReadOnlyList<TextMenuBindingValue>
        {
            private readonly SourceInputBinding owner;
            private readonly bool controller;

            public View(SourceInputBinding owner, bool controller)
            {
                this.owner = owner;
                this.controller = controller;
            }

            private int ValueCount => controller ? owner.Controller.Count : owner.Keyboard.Count;

            private int ValueCode(int index)
            {
                return controller ? (int)owner.Controller[index] : (int)owner.Keyboard[index];
            }

            private string ValueName(int index)
            {
                return controller ? owner.Controller[index].ToString() : owner.Keyboard[index].ToString();
            }

            public int Count => ValueCount;

            public TextMenuBindingValue this[int index] =>
                new(ValueCode(index), ValueName(index));

            public IEnumerator<TextMenuBindingValue> GetEnumerator()
            {
                for (var i = 0; i < Count; i++) yield return this[i];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
