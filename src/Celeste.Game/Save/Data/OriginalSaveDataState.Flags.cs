namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        public bool HasFlag(string flag)
        {
            return Flags.Contains(flag);
        }

        public void SetFlag(string flag)
        {
            if (!HasFlag(flag))
                Flags.Add(flag);
        }
    }
}
