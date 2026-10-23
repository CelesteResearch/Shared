using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Everest.Content.Textures;
using Celeste.Game.Content.Fonts;


namespace Celeste.Everest.Text.BitmapFonts
{
    public class SourceEverestEmojiState : IOriginalFontRegistryAugmentation
    {
        private readonly IEverestEmojiProcess process;

        public SourceEverestEmojiState(IEverestEmojiProcess process)
        {
            this.process = process;
            cachedApplies = new SourceEmojiApplyCache(this, process);
            Queue = new Queue<KeyValuePair<string, EverestAtlasEntry>>();
        }


        public const char Start = '\ue000';

        public const char End = '\uf8ff';

        private List<string> _Registered = new List<string>();

        internal Dictionary<string, int> _IDs = new Dictionary<string, int>();

        private List<bool> _IsMonochrome = new List<bool>();

        private List<SourcePixelFontCharacter> _Chars = new List<SourcePixelFontCharacter>();

        private readonly SourceEmojiApplyCache cachedApplies;

        private bool Initialized = false;

        private Queue<KeyValuePair<string, EverestAtlasEntry>> Queue;

        private XmlElement _FakeXML;

        /// <summary>
        ///       A list of all registered emoji names, in order of their IDs.
        ///       </summary>
        public ReadOnlyCollection<string> Registered => new ReadOnlyCollection<string>(_Registered);

        public char Last => (char)(57344 + _Registered.Count - 1);

        public XmlElement FakeXML
        {
            get
            {
                if (_FakeXML != null)
                {
                    return _FakeXML;
                }

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
            if (Initialized)
            {
                return;
            }

            Initialized = true;
            foreach (KeyValuePair<string, AtlasEntry> texture in process.GuiAtlas.Entries)
            {
                if (texture.Key.StartsWith("emoji/"))
                {
                    Register(texture.Key.Substring(6), (EverestAtlasEntry)texture.Value);
                }
            }

            foreach (KeyValuePair<string, EverestAtlasEntry> item in Queue)
            {
                Register(item.Key, item.Value);
            }
        }

        /// <summary>
        ///       Register an emoji.
        ///       </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="emoji">The emoji texture.</param>
        public void Register(string name, EverestAtlasEntry emoji)
        {
            Register(name, emoji, emoji?.ScaleFix ?? 1f);
        }

        /// <summary>
        ///       Register an emoji with scaling constraints.
        ///       </summary>
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

            float num = ((targetWidth <= 0) ? 1f : ((float)targetWidth / (float)emoji.FrameWidth));
            float num2 = ((targetHeight <= 0) ? 1f : ((float)targetHeight / (float)emoji.FrameHeight));
            if (targetWidth <= 0)
            {
                emoji.ScaleFix = num2;
            }
            else if (targetHeight <= 0)
            {
                emoji.ScaleFix = num;
            }
            else
            {
                emoji.ScaleFix = Math.Min(num, num2);
            }

            Register(name, emoji);
        }

        /// <summary>
        ///       Register an emoji.
        ///       </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="emoji">The emoji texture.</param>
        /// <param name="scale">Scaling factor for the emoji spacing. Defaults to emoji.ScaleFix.</param>
        public void Register(string name, EverestAtlasEntry emoji, float scale)
        {
            if (!Initialized)
            {
                Queue.Enqueue(new KeyValuePair<string, EverestAtlasEntry>(name, emoji));
                return;
            }

            bool flag;
            if (flag = name.EndsWith(".m"))
            {
                name = name.Substring(0, name.Length - 2);
            }

            XmlElement fakeXML = FakeXML;
            fakeXML.SetAttr("x", 0);
            fakeXML.SetAttr("y", 0);
            fakeXML.SetAttr("width", emoji.FrameWidth);
            fakeXML.SetAttr("height", emoji.FrameHeight);
            fakeXML.SetAttr("xoffset", 0);
            fakeXML.SetAttr("yoffset", 0);
            fakeXML.SetAttr("xadvance", (int)((float)emoji.FrameWidth * scale));
            int num = _Registered.IndexOf(name);
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

            _Chars.Add(new SourcePixelFontCharacter(57344 + num, emoji, fakeXML));
            cachedApplies.Clear();
        }

        /// <summary>
        ///       Fill a font with emoji.
        ///       </summary>
        /// <param name="font">The font to fill.</param>
        public void Fill(SourcePixelFont font)
        {
            Auto();
            foreach (SourcePixelFontSize size in font.Sizes)
            {
                foreach (SourcePixelFontCharacter @char in _Chars)
                {
                    size.Characters[@char.Character] = @char;
                }
            }
        }

        /// <summary>
        ///       Gets the char for the specified emoji.
        ///       </summary>
        /// <param name="name">The emoji name.</param>
        /// <returns>The emoji char.</returns>
        public int Get(string name)
        {
            return _IDs[name];
        }

        /// <summary>
        ///       Gets the char for the specified emoji.
        ///       </summary>
        /// <param name="name">The emoji name.</param>
        /// <param name="c">The emoji char.</param>
        /// <returns>Whether the emoji was registered or not.</returns>
        public bool TryGet(string name, out char c)
        {
            c = '\0';
            if (!_IDs.TryGetValue(name, out var value))
            {
                return false;
            }

            c = (char)(57344 + value);
            return true;
        }

        /// <summary>
        ///       Gets whether the emoji is monochrome or not.
        ///       </summary>
        /// <param name="c">The emoji char.</param>
        /// <returns>Whether the emoji is monochrome or not.</returns>
        public bool IsMonochrome(char c)
        {
            return _IsMonochrome[c - 57344];
        }

        /// <summary>
        ///       Transforms all instances of :emojiname: to \uSTART+ID
        ///       </summary>
        /// <param name="text" />
        /// <returns />
        public string Apply(string text)
        {
            if (text == null)
            {
                return null;
            }

            return cachedApplies.GetCached(text);
        }
    }
}
