using System.Collections.Generic;
using System.IO;
using System.Xml;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public sealed class OriginalFontRegistry
    {
        internal readonly IOriginalFontRegistryProcess engine;

        public OriginalFontRegistry(IOriginalFontRegistryProcess engine)
        {
            this.engine = engine;
        }

        internal Dictionary<string, List<string>> paths = new();

        internal Dictionary<string, SourcePixelFont> loadedFonts = new();

        public bool ContainsFace(string face)
        {
            return paths.ContainsKey(face);
        }

        public SourcePixelFont Load(string face)
        {
            return engine.FontRegistryPolicy.Load(this, face);
        }

        public SourcePixelFont LoadOriginal(string face)
        {
            if (!loadedFonts.TryGetValue(face, out var value) && paths.TryGetValue(face, out var value2))
            {
                loadedFonts.Add(face, value = engine.PixelFontFactory.Create(face, engine));
                foreach (var item in value2) value.AddFontSize(item, engine.GuiAtlas);
            }

            return value;
        }

        public SourcePixelFont Get(string face)
        {
            return loadedFonts.TryGetValue(face, out var value) ? value : null;
        }

        public void Unload(string face)
        {
            if (loadedFonts.TryGetValue(face, out var value))
            {
                value.Dispose();
                loadedFonts.Remove(face);
            }
        }

        public void Reload()
        {
            engine.FontRegistryPolicy.Reload(this);
        }

        public void Prepare()
        {
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.CloseInput = true;
            var files = engine.FontRegistryContentPolicy.GetFiles(engine,
                Path.Combine(engine.ContentDirectory, "Dialog"), "*.fnt", SearchOption.AllDirectories);
            foreach (var text in files)
            {
                string text2 = null;
                using (var xmlReader = XmlReader.Create(engine.FontRegistryContentPolicy.OpenRead(engine, text),
                           xmlReaderSettings))
                {
                    while (xmlReader.Read())
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "info")
                            text2 = xmlReader.GetAttribute("face");
                }

                if (text2 != null)
                {
                    if (!paths.TryGetValue(text2, out var value)) paths.Add(text2, value = []);

                    value.Add(text);
                }
            }
        }

        public void Log()
        {
            engine.Commands.Log("EXISTING FONTS:");
            foreach (var path in paths)
            {
                engine.Commands.Log(" - " + path.Key);
                foreach (var item in path.Value) engine.Commands.Log(" - > " + item);
            }

            engine.Commands.Log("LOADED:");
            foreach (var loadedFont in loadedFonts) engine.Commands.Log(" - " + loadedFont.Key);
        }
    }
}
