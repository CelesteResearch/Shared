using System;
using System.IO;
using System.Xml;

namespace Celeste.Formats.Graphics.Tiles
{
    // The content host owns Everest's virtual asset lookup. The simulation only
    // consumes the three XML documents selected by AreaData.Meta at LevelLoader.
    public sealed class TileDefinitionSources
    {
        public XmlDocument Background { get; }
        public XmlDocument Foreground { get; }
        public XmlDocument Animated { get; }

        private TileDefinitionSources(XmlDocument background, XmlDocument foreground, XmlDocument animated)
        {
            Background = background;
            Foreground = foreground;
            Animated = animated;
        }

        public static TileDefinitionSources Load(Func<string, Stream> open,
            string backgroundPath = null, string foregroundPath = null, string animatedPath = null)
        {
            if (open == null) throw new ArgumentNullException(nameof(open));

            XmlDocument Read(string path)
            {
                var xml = new XmlDocument();
                using (var stream = open(path))
                    if (stream != null)
                        xml.Load(stream);
                return xml;
            }

            // Installed LevelLoader loads BG, FG, then animated definitions. XML
            // parsing here consumes no gameplay RNG; map tile generation follows.
            return new TileDefinitionSources(
                Read(string.IsNullOrEmpty(backgroundPath)
                    ? Path.Combine("Graphics", "BackgroundTiles.xml")
                    : backgroundPath),
                Read(string.IsNullOrEmpty(foregroundPath)
                    ? Path.Combine("Graphics", "ForegroundTiles.xml")
                    : foregroundPath),
                Read(string.IsNullOrEmpty(animatedPath)
                    ? Path.Combine("Graphics", "AnimatedTiles.xml")
                    : animatedPath));
        }
    }
}
