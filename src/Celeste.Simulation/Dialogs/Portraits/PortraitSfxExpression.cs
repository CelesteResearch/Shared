namespace Celeste.Simulation.Dialogs.Portraits
{
    public sealed class PortraitSfxExpression
    {
        public string Animation { get; }
        public string Index { get; }

        public PortraitSfxExpression(string animation, string index)
        {
            Animation = animation;
            Index = index;
        }
    }
}
