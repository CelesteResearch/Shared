namespace Celeste.Everest.Content.Maps.Registry
{
    public static class InstalledDialogKeySource
    {
        public static string Keyify(string input)
        {
            return input.Replace('/', '_').Replace('-', '_')
                .Replace('+', '_').Replace(' ', '_');
        }
    }
}
