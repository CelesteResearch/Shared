using System;
using System.Globalization;
using System.Numerics;
using System.Xml;
using Celeste.Core.Display;
using Celeste.Core.Text.Sequences;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public abstract class EverestDecalPropertyHandler
    {
        protected readonly EverestDecalFeatureContext Context;
        private EverestLoggerProcess logger;

        protected EverestDecalPropertyHandler()
        {
        }

        protected EverestDecalPropertyHandler(EverestDecalFeatureContext context)
        {
            Context = context;
            logger = context.Logger;
        }

        internal void BindSourceLogger(EverestLoggerProcess actualLogger)
        {
            logger = actualLogger;
        }

        public abstract string Name { get; }
        public abstract void Parse(XmlAttributeCollection xml);
        public abstract void ApplyTo(SourceDecalEntityState decal);

        protected Vector2 GetVector2(XmlAttributeCollection xml, string x, string y, Vector2 fallback)
        {
            return new(Get(xml, x, fallback.X), Get(xml, y, fallback.Y));
        }

        protected int Get(XmlAttributeCollection xml, string attribute, int fallback)
        {
            var value = xml[attribute];
            if (value == null) return fallback;
            if (int.TryParse(value.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;
            logger.DecalInvalidInt32(this, value, attribute, fallback);
            return fallback;
        }

        protected float Get(XmlAttributeCollection xml, string attribute, float fallback)
        {
            var value = xml[attribute];
            if (value == null) return fallback;
            if (float.TryParse(value.Value, NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture,
                    out var result)) return result;
            logger.DecalInvalidSingle(this, value, attribute, fallback);
            return fallback;
        }

        protected int? GetNullableInt(XmlAttributeCollection xml, string attribute)
        {
            var value = xml[attribute];
            if (value == null) return null;
            if (int.TryParse(value.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                return result;
            logger.DecalInvalidNullableInt32(this, value, attribute);
            return null;
        }

        protected float? GetNullableFloat(XmlAttributeCollection xml, string attribute)
        {
            var value = xml[attribute];
            if (value == null) return null;
            if (float.TryParse(value.Value, NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture,
                    out var result)) return result;
            logger.DecalInvalidNullableSingle(this, value, attribute);
            return null;
        }

        protected bool GetBool(XmlAttributeCollection xml, string attribute, bool def)
        {
            var value = xml[attribute];
            if (value == null) return def;
            if (bool.TryParse(value.Value, out var result)) return result;
            logger.DecalInvalidBoolean(this, value, attribute, def);
            return def;
        }

        protected string GetString(XmlAttributeCollection xml, string attribute, string fallback)
        {
            return xml[attribute]?.Value ?? fallback;
        }

        protected PackedColor GetHexColor(XmlAttributeCollection xml, string attribute, PackedColor fallback)
        {
            return xml[attribute] == null ? fallback : SourceHexColor.HexToColor(xml[attribute].Value);
        }

        protected int[] GetCSVIntWithTricks(XmlAttributeCollection xml, string attribute, string fallback)
        {
            var value = xml[attribute];
            if (value == null) return SourceIntegerSequenceParsing.ReadCsvWithRangesAndRepetition(fallback);
            try
            {
                return SourceIntegerSequenceParsing.ReadCsvWithRangesAndRepetition(value.Value);
            }
            catch (Exception)
            {
                logger.DecalInvalidCsvInt(this, value, attribute, fallback);
                return SourceIntegerSequenceParsing.ReadCsvWithRangesAndRepetition(fallback);
            }
        }
    }
}
