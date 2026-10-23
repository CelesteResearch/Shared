namespace Celeste.Scene.Tagging
{
    public class SourceBitTag
    {
        public int ID;
        public int Value;
        public string Name;

        public SourceBitTag(string name, SourceBitTagProcessState sameProcess)
        {
            ID = sameProcess.TotalTags;
            Value = 1 << sameProcess.TotalTags;
            Name = name;
            sameProcess.ByID[ID] = this;
            sameProcess.PublishName(name, this);
            sameProcess.TotalTags++;
        }

        public static implicit operator int(SourceBitTag tag)
        {
            return tag.Value;
        }
    }
}
