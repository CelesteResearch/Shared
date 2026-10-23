using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Content.Textures;
using Celeste.Game.Content.Fonts;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Everest.Text.BitmapFonts
{
    public class SourceEverestEmojiState : IOriginalFontRegistryAugmentation
    {
        private readonly IEverestEmojiProcess process;

        public SourceEverestEmojiState(IEverestEmojiProcess process)
        {
            this.process = process;
            cachedApplies = new(this, process);
            Queue = new();
        }


        public const char Start = '\ue000';

        public const char End = '\uf8ff';

        private readonly List<string> _Registered = [];

        internal Dictionary<string, int> _IDs = new();

        private readonly List<bool> _IsMonochrome = [];

        private readonly List<SourcePixelFontCharacter> _Chars = [];

        private readonly SourceEmojiApplyCache cachedApplies;

        private bool Initialized;

        private readonly Queue<KeyValuePair<string, EverestAtlasEntry>> Queue;

        private XmlElement _FakeXML;

        /// <summary>
        ///     A list of all registered emoji names, in order of their IDs.
        /// </summary>
        public ReadOnlyCollection<string> Registered => new(_Registered);

        public char Last => (char)(57344 + _Registered.Count - 1);

        public XmlElement FakeXML
        {
            get
            {
                if (_FakeXML != null) return _FakeXML;

                _FakeXML = new XmlDocument().CreateElement("emoji");
                return _FakeXML;
            }
        }

        internal bool IsInitialized()
        {
            return Initialized;
        }

        internal void Auto()
        {
            if (Initialized) return;

            Initialized = true;
            foreach (var texture in process.GuiAtlas.Entries)
                if (texture.Key.StartsWith("emoji/"))
                    Register(texture.Key.Substring(6), (EverestAtlasEntry)texture.Value);

            foreach (var item in Queue) Register(item.Key, item.Value);
        }

        /// <summary>
        ///     Register an emoji.
        /// </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="emoji">The emoji texture.</param>
        public void Register(string name, EverestAtlasEntry emoji)
        {
            Register(name, emoji, emoji?.ScaleFix ?? 1f);
        }

        /// <summary>
        ///     Register an emoji with scaling constraints.
        /// </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="emoji">The emoji texture.</param>
        /// <param name="targetWidth">The width to render this emoji as. Adjusts the EverestAtlasEntry.ScaleFix as side-effect!</param>
        /// <param name="targetHeight">The height to render this emoji as. Adjusts the EverestAtlasEntry.ScaleFix as side-effect!</param>
        public void Register(string name, EverestAtlasEntry emoji, int targetWidth = 0, int targetHeight = 0)
        {
            if (emoji == null)
            {
                Register(name, emoji);
                return;
            }

            var num = targetWidth <= 0 ? 1f : targetWidth / (float)emoji.FrameWidth;
            var num2 = targetHeight <= 0 ? 1f : targetHeight / (float)emoji.FrameHeight;
            if (targetWidth <= 0)
                emoji.ScaleFix = num2;
            else if (targetHeight <= 0)
                emoji.ScaleFix = num;
            else
                emoji.ScaleFix = Math.Min(num, num2);

            Register(name, emoji);
        }

        /// <summary>
        ///     Register an emoji.
        /// </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="emoji">The emoji texture.</param>
        /// <param name="scale">Scaling factor for the emoji spacing. Defaults to emoji.ScaleFix.</param>
        public void Register(string name, EverestAtlasEntry emoji, float scale)
        {
            if (!Initialized)
            {
                Queue.Enqueue(new(name, emoji));
                return;
            }

            bool flag;
            if (flag = name.EndsWith(".m")) name = name.Substring(0, name.Length - 2);

            var fakeXml = FakeXML;
            fakeXml.SetAttr("x", 0);
            fakeXml.SetAttr("y", 0);
            fakeXml.SetAttr("width", emoji.FrameWidth);
            fakeXml.SetAttr("height", emoji.FrameHeight);
            fakeXml.SetAttr("xoffset", 0);
            fakeXml.SetAttr("yoffset", 0);
            fakeXml.SetAttr("xadvance", (int)(emoji.FrameWidth * scale));
            var num = _Registered.IndexOf(name);
            if (num < 0)
            {
                num = _Registered.Count;
                _Registered.Add(name);
                lock (_IDs)
                {
                    _IDs[name] = num;
                }

                _IsMonochrome.Add(flag);
            }
            else
            {
                _IsMonochrome[num] = flag;
            }

            _Chars.Add(new(57344 + num, emoji, fakeXml));
            cachedApplies.Clear();
        }

        /// <summary>
        ///     Fill a font with emoji.
        /// </summary>
        /// <param name="font">The font to fill.</param>
        public void Fill(SourcePixelFont font)
        {
            Auto();
            foreach (var size in font.Sizes)
            foreach (var @char in _Chars)
                size.Characters[@char.Character] = @char;
        }

        /// <summary>
        ///     Gets the char for the specified emoji.
        /// </summary>
        /// <param name="name">The emoji name.</param>
        /// <returns>The emoji char.</returns>
        public int Get(string name)
        {
            return _IDs[name];
        }

        /// <summary>
        ///     Gets the char for the specified emoji.
        /// </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="c">The emoji char.</param>
        /// <returns>Whether the emoji was registered or not.</returns>
        public bool TryGet(string name, out char c)
        {
            c = '\0';
            if (!_IDs.TryGetValue(name, out var value)) return false;

            c = (char)(57344 + value);
            return true;
        }

        /// <summary>
        ///     Gets whether the emoji is monochrome or not.
        /// </summary>
        /// <param name="c">The emoji char.</param>
        /// <returns>Whether the emoji is monochrome or not.</returns>
        public bool IsMonochrome(char c)
        {
            return _IsMonochrome[c - 57344];
        }

        /// <summary>
        ///     Transforms all instances of :emojiname: to \uSTART+ID
        /// </summary>
        /// <param name="text" />
        /// <returns />
        public string Apply(string text)
        {
            if (text == null) return null;

            return cachedApplies.GetCached(text);
        }
    }
}
