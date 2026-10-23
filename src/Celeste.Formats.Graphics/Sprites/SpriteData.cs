using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Xml;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Xml;

namespace Celeste.Formats.Graphics.Sprites
{
    public class SpriteData
    {
        public List<SpriteDataSource> Sources = [];

        public readonly Sprite Sprite;

        public AtlasData Atlas;

        public SpriteData(ISourceEngineContext engine,
            AtlasData atlas)
        {
            Sprite = AtlasSpriteFactory.Create(engine, atlas, "");
            Atlas = atlas;
        }

        public void Add(XmlElement xml, string overridePath = null)
        {
            var spriteDataSource =
                new SpriteDataSource();
            spriteDataSource.XML = xml;
            spriteDataSource.Path = spriteDataSource.XML.Attr("path");
            spriteDataSource.OverridePath = overridePath;
            var text = "Sprite '" + spriteDataSource.XML.Name + "': ";
            if (!spriteDataSource.XML.HasAttr("path") && string.IsNullOrEmpty(overridePath))
                throw new(text + "'path' is missing!");

            var hashSet = new HashSet<string>();
            foreach (XmlElement item in spriteDataSource.XML.GetElementsByTagName("Anim"))
                CheckAnimXML(item, text, hashSet);

            foreach (XmlElement item2 in spriteDataSource.XML.GetElementsByTagName("Loop"))
                CheckAnimXML(item2, text, hashSet);

            if (spriteDataSource.XML.HasAttr("start") && !hashSet.Contains(spriteDataSource.XML.Attr("start")))
                throw new(
                    text + "starting animation '" + spriteDataSource.XML.Attr("start") + "' is missing!");

            if (spriteDataSource.XML.HasChild("Justify") && spriteDataSource.XML.HasChild("Origin"))
                throw new(text + "has both Origin and Justify tags!");

            var text2 = spriteDataSource.XML.Attr("path", "");
            var defaultValue = spriteDataSource.XML.AttrFloat("delay");
            foreach (XmlElement item3 in spriteDataSource.XML.GetElementsByTagName("Anim"))
            {
                var chooser = !item3.HasAttr("goto")
                    ? null
                    : SpriteTransitionCodec.Parse<string>(
                        item3.Attr("goto"));
                var id = item3.Attr("id");
                var text3 = item3.Attr("path", "");
                var frames =
                    SpriteXml.ReadFrames(item3.Attr("frames", ""));
                text3 = string.IsNullOrEmpty(overridePath) || !HasFrames(Atlas, overridePath + text3, frames)
                    ? text2 + text3
                    : overridePath + text3;
                Sprite.Add(id, text3, item3.AttrFloat("delay", defaultValue), chooser, frames);
            }

            foreach (XmlElement item4 in spriteDataSource.XML.GetElementsByTagName("Loop"))
            {
                var id2 = item4.Attr("id");
                var text4 = item4.Attr("path", "");
                var frames2 =
                    SpriteXml.ReadFrames(item4.Attr("frames", ""));
                text4 = string.IsNullOrEmpty(overridePath) || !HasFrames(Atlas, overridePath + text4, frames2)
                    ? text2 + text4
                    : overridePath + text4;
                Sprite.AddLoop(id2, text4, item4.AttrFloat("delay", defaultValue), frames2);
            }

            if (spriteDataSource.XML.HasChild("Center"))
            {
                Sprite.CenterOrigin();
                Sprite.Justify = new Vector2(0.5f, 0.5f);
            }
            else if (spriteDataSource.XML.HasChild("Justify"))
            {
                Sprite.JustifyOrigin(spriteDataSource.XML.ChildPosition("Justify"));
                Sprite.Justify = spriteDataSource.XML.ChildPosition("Justify");
            }
            else if (spriteDataSource.XML.HasChild("Origin"))
            {
                Sprite.Origin = spriteDataSource.XML.ChildPosition("Origin");
            }

            if (spriteDataSource.XML.HasChild("Position"))
                Sprite.Position = spriteDataSource.XML.ChildPosition("Position");

            if (spriteDataSource.XML.HasAttr("start")) Sprite.Play(spriteDataSource.XML.Attr("start"));

            Sources.Add(spriteDataSource);
        }

        private bool HasFrames(AtlasData atlas, string path,
            int[] frames = null)
        {
            if (frames == null || frames.Length == 0) return atlas.HasAtlasSubtexturesAt(path, 0);

            for (var i = 0; i < frames.Length; i++)
                if (!atlas.HasAtlasSubtexturesAt(path, frames[i]))
                    return false;

            return true;
        }

        private void CheckAnimXML(XmlElement xml, string prefix, HashSet<string> ids)
        {
            if (!xml.HasAttr("id")) throw new(prefix + "'id' is missing on " + xml.Name + "!");

            if (ids.Contains(xml.Attr("id")))
                throw new(prefix + "multiple animations with id '" + xml.Attr("id") + "'!");

            ids.Add(xml.Attr("id"));
        }
    }
}
