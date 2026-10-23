using System.Xml;
using Celeste.Everest.Content.Extensions.Decals;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void DecalInvalidInt32(EverestDecalPropertyHandler handler, XmlAttribute value, string attribute,
            int fallback)
        {
            var message =
                new LogInterpolatedStringHandler(68, 5, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid '");
                message.AppendFormatted(typeof(int).Name);
                message.AppendLiteral("' value '");
                message.AppendFormatted(value.Value);
                message.AppendLiteral("' for attribute '");
                message.AppendFormatted(attribute);
                message.AppendLiteral("' in property '");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral("'. Defaulting to ");
                message.AppendFormatted(fallback);
                message.AppendLiteral(".");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalInvalidSingle(EverestDecalPropertyHandler handler, XmlAttribute value, string attribute,
            float fallback)
        {
            var message =
                new LogInterpolatedStringHandler(68, 5, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid '");
                message.AppendFormatted(typeof(float).Name);
                message.AppendLiteral("' value '");
                message.AppendFormatted(value.Value);
                message.AppendLiteral("' for attribute '");
                message.AppendFormatted(attribute);
                message.AppendLiteral("' in property '");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral("'. Defaulting to ");
                message.AppendFormatted(fallback);
                message.AppendLiteral(".");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalInvalidNullableInt32(EverestDecalPropertyHandler handler, XmlAttribute value, string attribute)
        {
            var message =
                new LogInterpolatedStringHandler(64, 4, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid ");
                message.AppendFormatted(typeof(int).Name);
                message.AppendLiteral(" value ");
                message.AppendFormatted(value.Value);
                message.AppendLiteral(" for attribute ");
                message.AppendFormatted(attribute);
                message.AppendLiteral(" in property ");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral(". Defaulting to null.");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalInvalidNullableSingle(EverestDecalPropertyHandler handler, XmlAttribute value,
            string attribute)
        {
            var message =
                new LogInterpolatedStringHandler(64, 4, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid ");
                message.AppendFormatted(typeof(float).Name);
                message.AppendLiteral(" value ");
                message.AppendFormatted(value.Value);
                message.AppendLiteral(" for attribute ");
                message.AppendFormatted(attribute);
                message.AppendLiteral(" in property ");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral(". Defaulting to null.");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalInvalidBoolean(EverestDecalPropertyHandler handler, XmlAttribute value, string attribute,
            bool fallback)
        {
            var message =
                new LogInterpolatedStringHandler(64, 4, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid Bool value ");
                message.AppendFormatted(value.Value);
                message.AppendLiteral(" for attribute ");
                message.AppendFormatted(attribute);
                message.AppendLiteral(" in property ");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral(". Defaulting to ");
                message.AppendFormatted(fallback);
                message.AppendLiteral(".");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }

        public void DecalInvalidCsvInt(EverestDecalPropertyHandler handler, XmlAttribute value, string attribute,
            string fallback)
        {
            var message =
                new LogInterpolatedStringHandler(66, 4, this, EverestLogLevel.Warn, "Decal Registry", out var enabled);
            if (enabled)
            {
                message.AppendLiteral("Invalid CSVInt value ");
                message.AppendFormatted(value.Value);
                message.AppendLiteral(" for attribute ");
                message.AppendFormatted(attribute);
                message.AppendLiteral(" in property ");
                message.AppendFormatted(handler.Name);
                message.AppendLiteral(". Defaulting to ");
                message.AppendFormatted(fallback);
                message.AppendLiteral(".");
            }

            Log(EverestLogLevel.Warn, "Decal Registry", message);
        }
    }
}
