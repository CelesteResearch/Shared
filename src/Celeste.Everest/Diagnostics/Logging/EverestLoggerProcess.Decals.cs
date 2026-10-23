using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Extensions.Decals;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void DecalLoadingRegistry(EverestContentAsset asset)
        {
            var message =
                new LogInterpolatedStringHandler(21, 1, this, EverestLogLevel.Debug, "Decal Registry",
                    out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Loading registry for ");
                message.AppendFormatted(asset.Source.Name);
            }

            Log(EverestLogLevel.Debug, "Decal Registry", message);
        }

        public void DecalNoMatch(EverestContentAsset asset, string key)
        {
            var message =
                new LogInterpolatedStringHandler(41, 2, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Could not find any decals in ");
                message.AppendFormatted(asset.Source.Name);
                message.AppendLiteral(" under path ");
                message.AppendFormatted(key);
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalMissingTag(EverestContentAsset asset)
        {
            var message =
                new LogInterpolatedStringHandler(51, 1, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Could not parse the 'decals' tag for the ");
                message.AppendFormatted(asset.Source.Name);
                message.AppendLiteral(" registry.");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalMissingPath(EverestContentAsset asset)
        {
            var message =
                new LogInterpolatedStringHandler(53, 1, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Decal in the ");
                message.AppendFormatted(asset.Source.Name);
                message.AppendLiteral(" registry is missing a 'path' attribute!");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalUnknownProperty(string property, string path)
        {
            var message =
                new LogInterpolatedStringHandler(27, 2, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Unknown property ");
                message.AppendFormatted(property);
                message.AppendLiteral(" in decal ");
                message.AppendFormatted(path);
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalApplyFailed(EverestDecalPropertyHandler handler,
            string path)
        {
            var message =
                new LogInterpolatedStringHandler(31, 2, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Failed to apply property '");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral("' to ");
                message.AppendFormatted(path);
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalLegacyHandler(string assemblyName, string property)
        {
            var message =
                new LogInterpolatedStringHandler(131, 2, this, EverestLogLevel.Warn, "Decal Registry",
                    out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Assembly ");
                message.AppendFormatted(assemblyName);
                message.AppendLiteral(
                    " is using the legacy DecalRegistry.AddPropertyHandler(string, Action<Decal, XmlAttributeCollection>) method for property ");
                message.AppendFormatted(property);
                message.AppendLiteral("!");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalHandlerConflict(string property, string assemblyName)
        {
            var message =
                new LogInterpolatedStringHandler(73, 2, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Property handler for '");
                message.AppendFormatted(property);
                message.AppendLiteral("' already exists! Replacing with new handler from ");
                message.AppendFormatted(assemblyName);
                message.AppendLiteral(".");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalRegistered(string path, bool replaced)
        {
            var message = new LogInterpolatedStringHandler(replaced ? 15 : 17, 1, this,
                EverestLogLevel.Verbose, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral(replaced ? "Replaced decal " : "Registered decal ");
                message.AppendFormatted(path);
            }

            Log(EverestLogLevel.Verbose, "Decal Registry", message);
        }
    }
}
