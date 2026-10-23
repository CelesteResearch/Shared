using System.Numerics;
using System.Xml;
using Celeste.Formats.Graphics.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Canvas;

namespace Celeste.Formats.Graphics.Completion
{
    public static class CompleteCanvasCompiler
    {
        public static CanvasDefinition Compile(XmlElement xml,
            AtlasData atlas)
        {
            var result = new CanvasDefinition();
            if (xml != null)
            {
                if (xml["start"] != null) result.StartScroll = xml.ChildPosition("start");
                if (xml["center"] != null) result.CenterScroll = xml.ChildPosition("center");
                if (xml["offset"] != null) result.Offset = xml.ChildPosition("offset");
                foreach (XmlNode node in xml["layers"])
                    if (node is XmlElement element)
                    {
                        if (element.Name == "layer")
                        {
                            var definition =
                                new CanvasImageLayerDefinition();
                            ReadPlacement(definition, element);
                            foreach (var id in element.GetAttribute("img").Split(','))
                            {
                                atlas.Entries.TryGetValue(id, out var image);
                                definition.Images.Add(image);
                            }

                            definition.FrameRate = element.AttrFloat("fps", 6);
                            definition.Alpha = element.AttrFloat("alpha", 1);
                            definition.Speed = new(element.AttrFloat("speedx"), element.AttrFloat("speedy"));
                            definition.Scale = element.AttrFloat("scale", 1);
                            result.Layers.Add(definition);
                        }
                        else if (element.Name == "ui")
                        {
                            var definition =
                                new CanvasOverlayLayerDefinition();
                            ReadPlacement(definition, element);
                            result.Layers.Add(definition);
                        }
                    }
            }

            return result;
        }

        private static void ReadPlacement(CanvasLayerDefinition definition,
            XmlElement xml)
        {
            definition.Position = new(xml.AttrFloat("x"), xml.AttrFloat("y"));
            definition.ScrollFactor = xml.HasAttribute("scroll")
                ? new(xml.AttrFloat("scroll"))
                : new Vector2(xml.AttrFloat("scrollX"), xml.AttrFloat("scrollY"));
        }
    }
}
