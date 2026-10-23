namespace Celeste.Localization.Lookup
{
    // Lookup behavior is explicit; a catalog need not use original key syntax
    // or missing-text markers to serve another application.
    public abstract class DialogLookupPolicy
    {
        public abstract string NormalizeKey(string name);
        public abstract string MissingText(string normalizedName, bool cleaned);
    }
}
