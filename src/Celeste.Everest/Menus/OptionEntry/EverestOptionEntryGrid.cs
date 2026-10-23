using System;

namespace Celeste.Everest.Menus.OptionEntry
{
    public abstract class EverestOptionEntryGrid
    {
        protected string[] letters;
        protected int index, line, optionsIndex;
        protected bool selectingOptions;
        protected string startingValue, value;
        protected float widestLetter, boxWidth, boxPadding, cancelWidth, spaceWidth, backspaceWidth, acceptWidth;
        public string Value => value;
        public string StartingValue => startingValue;
        public string[] Letters => letters;
        public int Index => index;
        public int Line => line;
        public int OptionsIndex => optionsIndex;
        public bool SelectingOptions => selectingOptions;
        public float BoxWidth => boxWidth;
        public float WidestLetter => widestLetter;
        public bool Focused { get; private set; }
        public Func<char, bool> FontHasGlyph { get; set; } = _ => true;
        public EverestEntrySound LastSound { get; protected set; }
        public event Action<bool> Exited;

        protected void Changed(string next)
        {
            value = next;
            OnValueChanged(next);
        }

        protected abstract void OnValueChanged(string next);

        protected void Exit(bool confirmed)
        {
            Focused = false;
            Exited?.Invoke(confirmed);
        }

        protected void Begin(string initial, string[] rows, float width, float padding, float cancel, float space,
            float backspace, float accept)
        {
            startingValue = value = initial;
            letters = rows;
            widestLetter = width;
            boxPadding = padding;
            cancelWidth = cancel;
            spaceWidth = space;
            backspaceWidth = backspace;
            acceptWidth = accept;
            var count = 0;
            for (var i = 0; i < rows.Length; i++) count = Math.Max(count, rows[i].Length);
            var optionsWidth = cancel + space + backspace + accept + width * 3f;
            boxWidth = Math.Max(count * width, optionsWidth) + padding * 2f;
            index = line = optionsIndex = 0;
            selectingOptions = false;
            Focused = true;
            LastSound = EverestEntrySound.None;
        }

        protected void Roll()
        {
            LastSound = EverestEntrySound.Roll;
        }

        public abstract void Step(EverestEntryInput input,
            bool useKeyboardInput);

        public abstract void TextInput(char input, string clipboard, Func<char, bool> fontHasGlyph);
    }
}
