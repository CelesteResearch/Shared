using Celeste.Input.Bindings;
using System.Collections;
using System.Collections.Generic;


namespace Celeste.Simulation.Rendering
{
    // The UI reads the actual mutable binding lists; it does not own or copy them.
    public sealed class ControlBindingMenuAdapter : global::Celeste.Simulation.UI.Menus.Text.ITextMenuBinding
    {
        private readonly View keyboardView, controllerView;

        public ControlBindingMenuAdapter(global::Celeste.Input.Bindings.SourceInputBinding binding)
        {
            keyboardView = new View(binding, false);
            controllerView = new View(binding, true);
        }

        public IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> Keyboard => keyboardView;

        public IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> Controller =>
            controllerView;

        private sealed class View : IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue>
        {
            private readonly global::Celeste.Input.Bindings.SourceInputBinding owner;
            private readonly bool controller;

            public View(global::Celeste.Input.Bindings.SourceInputBinding owner, bool controller)
            {
                this.owner = owner;
                this.controller = controller;
            }

            private int ValueCount => controller ? owner.Controller.Count : owner.Keyboard.Count;
            private int ValueCode(int index) => controller ? (int)owner.Controller[index] : (int)owner.Keyboard[index];

            private string ValueName(int index) =>
                controller ? owner.Controller[index].ToString() : owner.Keyboard[index].ToString();

            public int Count => ValueCount;

            public global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue this[int index] =>
                new global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue(ValueCode(index), ValueName(index));

            public IEnumerator<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> GetEnumerator()
            {
                for (int i = 0; i < Count; i++) yield return this[i];
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
