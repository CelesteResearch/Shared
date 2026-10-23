namespace Celeste.Game.Execution.Areas
{
// Actual source key payload; SIDID records which numeric ID the stored SID belongs to.
// The selected source area resolver owns get_SID/GetLevelSet, not a host static registry.
    public struct OriginalAreaKey
    {
        public int ID;
        public int Mode;
        public string SID;
        public int SIDID;

        public static bool operator ==(OriginalAreaKey a, OriginalAreaKey b)
        {
            if (a.ID == b.ID)
                return a.Mode == b.Mode;
            return false;
        }

        public static bool operator !=(OriginalAreaKey a, OriginalAreaKey b)
        {
            if (a.ID == b.ID)
                return a.Mode != b.Mode;
            return true;
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return ID * 3 + Mode;
        }
    }
}
