namespace Celeste.Everest.Modules.Updating
{
    public class EverestUpdateEntry
    {
        public readonly string Name;

        public string Description;

        public readonly string URL;

        public readonly int Build;

        public readonly EverestUpdateSource Source;

        public bool? IsNativeBuild;

        public EverestUpdateEntry(string name, string url, int version, EverestUpdateSource source)
        {
            Name = name;
            URL = url;
            Build = version;
            Source = source;
        }
    }
}
