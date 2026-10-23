namespace Celeste.Simulation.UI.Menus.Text
{
    public readonly struct TextMenuBindingValue
    {
        public readonly int Code;
        public readonly string Name;

        public TextMenuBindingValue(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
