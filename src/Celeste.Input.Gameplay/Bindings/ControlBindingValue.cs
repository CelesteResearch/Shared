namespace Celeste.Input.Gameplay.Bindings
{
    public struct ControlBindingValue
    {
        public int Code;
        public string Name;

        public ControlBindingValue(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
