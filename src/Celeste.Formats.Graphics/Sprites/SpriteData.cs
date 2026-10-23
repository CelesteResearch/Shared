using Celeste.Core.Randomness;
using Celeste.Graphics.Content.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Formats.Graphics.Xml;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Numerics;

namespace Celeste.Formats.Graphics.Sprites
{
    public class SpriteData
    {
        public List<global::Celeste.Formats.Graphics.Sprites.SpriteDataSource> Sources =
            new List<global::Celeste.Formats.Graphics.Sprites.SpriteDataSource>();

        public readonly global::Celeste.Graphics.Animation.Sprite Sprite;

        public global::Celeste.Graphics.Content.Atlas.AtlasData Atlas;

        public SpriteData(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            global::Celeste.Graphics.Content.Atlas.AtlasData atlas)
        {
            Sprite = global::Celeste.Graphics.Animation.AtlasSpriteFactory.Create(engine, atlas, "");
            Atlas = atlas;
        }

        public void Add(XmlElement xml, string overridePath = null)
        {
            global::Celeste.Formats.Graphics.Sprites.SpriteDataSource spriteDataSource =
                new global::Celeste.Formats.Graphics.Sprites.SpriteDataSource();
            spriteDataSource.XML = xml;
            spriteDataSource.Path = spriteDataSource.XML.Attr("path");
            spriteDataSource.OverridePath = overridePath;
            string text = "Sprite '" + spriteDataSource.XML.Name + "': ";
            if (!spriteDataSource.XML.HasAttr("path") && string.IsNullOrEmpty(overridePath))
            {
                throw new Exception(text + "'path' is missing!");
            }

            HashSet<string> hashSet = new HashSet<string>();
            foreach (XmlElement item in spriteDataSource.XML.GetElementsByTagName("Anim"))
            {
                CheckAnimXML(item, text, hashSet);
            }

            foreach (XmlElement item2 in spriteDataSource.XML.GetElementsByTagName("Loop"))
            {
                CheckAnimXML(item2, text, hashSet);
            }

            if (spriteDataSource.XML.HasAttr("start") && !hashSet.Contains(spriteDataSource.XML.Attr("start")))
            {
                throw new Exception(
                    text + "starting animation '" + spriteDataSource.XML.Attr("start") + "' is missing!");
            }

            if (spriteDataSource.XML.HasChild("Justify") && spriteDataSource.XML.HasChild("Origin"))
            {
                throw new Exception(text + "has both Origin and Justify tags!");
            }

            string text2 = spriteDataSource.XML.Attr("path", "");
            float defaultValue = spriteDataSource.XML.AttrFloat("delay", 0f);
            foreach (XmlElement item3 in spriteDataSource.XML.GetElementsByTagName("Anim"))
            {
                global::Celeste.Core.Randomness.Chooser<string> chooser = ((!item3.HasAttr("goto"))
                    ? null
                    : global::Celeste.Formats.Graphics.Sprites.SpriteTransitionCodec.Parse<string>(
                        item3.Attr("goto")));
                string id = item3.Attr("id");
                string text3 = item3.Attr("path", "");
                int[] frames =
                    global::Celeste.Formats.Graphics.Xml.SpriteXml.ReadFrames(item3.Attr("frames", ""));
                text3 = ((string.IsNullOrEmpty(overridePath) || !HasFrames(Atlas, overridePath + text3, frames))
                    ? (text2 + text3)
                    : (overridePath + text3));
                Sprite.Add(id, text3, item3.AttrFloat("delay", defaultValue), chooser, frames);
            }

            foreach (XmlElement item4 in spriteDataSource.XML.GetElementsByTagName("Loop"))
            {
                string id2 = item4.Attr("id");
                string text4 = item4.Attr("path", "");
                int[] frames2 =
                    global::Celeste.Formats.Graphics.Xml.SpriteXml.ReadFrames(item4.Attr("frames", ""));
                text4 = ((string.IsNullOrEmpty(overridePath) || !HasFrames(Atlas, overridePath + text4, frames2))
                    ? (text2 + text4)
                    : (overridePath + text4));
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
            {
                Sprite.Position = spriteDataSource.XML.ChildPosition("Position");
            }

            if (spriteDataSource.XML.HasAttr("start"))
            {
                Sprite.Play(spriteDataSource.XML.Attr("start"));
            }

            Sources.Add(spriteDataSource);
        }

        private bool HasFrames(global::Celeste.Graphics.Content.Atlas.AtlasData atlas, string path,
            int[] frames = null)
        {
            if (frames == null || frames.Length == 0)
            {
                return atlas.HasAtlasSubtexturesAt(path, 0);
            }

            for (int i = 0; i < frames.Length; i++)
            {
                if (!atlas.HasAtlasSubtexturesAt(path, frames[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void CheckAnimXML(XmlElement xml, string prefix, HashSet<string> ids)
        {
            if (!xml.HasAttr("id"))
            {
                throw new Exception(prefix + "'id' is missing on " + xml.Name + "!");
            }

            if (ids.Contains(xml.Attr("id")))
            {
                throw new Exception(prefix + "multiple animations with id '" + xml.Attr("id") + "'!");
            }

            ids.Add(xml.Attr("id"));
        }
    }
}
