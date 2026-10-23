namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public interface ICassetteRhythmBlock
    {
        int Index { get; }
        string Room { get; }
        bool Activated { get; set; }
        void WillToggle();
        void SetActivatedSilently(bool activated);
        void Finish();
    }
}
