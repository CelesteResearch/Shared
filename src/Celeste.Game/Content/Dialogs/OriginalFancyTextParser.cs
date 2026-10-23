using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using Celeste.Core.Display;
using Celeste.Formats.Graphics.Xml;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Content.Xml;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Localization.Languages;
using static Celeste.Game.Content.Dialogs.OriginalFancyTextDefaults;
using Char = Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph;
using Wait = Celeste.Graphics.Text.RichText.Nodes.RichTextPause;
using NewLine = Celeste.Graphics.Text.RichText.Nodes.RichTextLineBreak;
using NewPage = Celeste.Graphics.Text.RichText.Nodes.RichTextPageBreak;
using Anchors = Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition;
using Anchor = Celeste.Graphics.Text.RichText.Nodes.RichTextAnchor;
using Text = Celeste.Graphics.Text.RichText.Layout.RichTextLayout;
using Portrait = Celeste.Simulation.Dialogs.Nodes.DialogPortrait;
using Trigger = Celeste.Simulation.Dialogs.Nodes.DialogTrigger;

namespace Celeste.Game.Content.Dialogs
{
    public sealed class OriginalFancyTextParser
    {
        private readonly DialogLanguage language;
        private readonly OriginalFancyTextContext context;

        private readonly string text;

        private readonly Text group = new();

        private readonly int maxLineWidth;

        private readonly int linesPerPage;

        private readonly SourcePixelFont font;

        private readonly SourcePixelFontSize size;

        private readonly PackedColor defaultColor;

        private readonly float startFade;

        private int currentLine;

        private int currentPage;

        private float currentPosition;

        private PackedColor currentColor;

        private float currentScale = 1f;

        private float currentDelay = 0.01f;

        private bool currentShake;

        private bool currentWave;

        private bool currentImpact;

        private bool currentMessedUp;

        private int currentCharIndex;

        public static Text Parse(string text, int maxLineWidth, int linesPerPage, float startFade = 1f,
            PackedColor? defaultColor = null, OriginalFancyTextContext context = null)
        {
            return new OriginalFancyTextParser(text, maxLineWidth, linesPerPage, startFade,
                defaultColor.HasValue ? defaultColor.Value : DefaultColor, context).Parse();
        }

        private OriginalFancyTextParser(string text, int maxLineWidth, int linesPerPage, float startFade,
            PackedColor defaultColor,
            OriginalFancyTextContext context)
        {
            this.text = text;
            this.maxLineWidth = maxLineWidth;
            this.linesPerPage = linesPerPage < 0 ? int.MaxValue : linesPerPage;
            this.startFade = startFade;
            this.defaultColor = currentColor = defaultColor;
            DialogLanguage language;
            this.context = context;
            language = context.Language;
            if (language == null)
                language = context.Text.Dialog.Language;
            this.language = language;
            group.Nodes = [];
            group.Font = font = context.Text.Fonts.Get(context.FontFaceOverride ?? language.FontFace);
            group.BaseSize = language.FontFaceSize;
            size = font.Get(group.BaseSize);
        }

        private Text Parse()
        {
            var array = Regex.Split(this.text, language.SplitRegex);
            var array2 = new string[array.Length];
            var num = 0;
            for (var i = 0; i < array.Length; i++)
                if (!string.IsNullOrEmpty(array[i]))
                    array2[num++] = array[i];

            var stack = new Stack<PackedColor>();
            var array3 = new Portrait[2];
            for (var j = 0; j < num; j++)
                if (array2[j] == "{")
                {
                    j++;
                    var text = array2[j++];
                    var list = new List<string>();
                    for (; j < array2.Length && array2[j] != "}"; j++)
                        if (!string.IsNullOrWhiteSpace(array2[j]))
                            list.Add(array2[j]);

                    var result = 0f;
                    if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
                    {
                        group.Nodes.Add(new Wait
                        {
                            Duration = result,
                        });
                        continue;
                    }

                    if (text[0] == '#')
                    {
                        var text2 = "";
                        if (text.Length > 1)
                            text2 = text.Substring(1);
                        else if (list.Count > 0) text2 = list[0];

                        if (string.IsNullOrEmpty(text2))
                        {
                            if (stack.Count > 0)
                                currentColor = stack.Pop();
                            else
                                currentColor = defaultColor;

                            continue;
                        }

                        stack.Push(currentColor);
                        switch (text2)
                        {
                            case "red":
                                currentColor = PackedColor.Red;
                                break;
                            case "green":
                                currentColor = PackedColor.Green;
                                break;
                            case "blue":
                                currentColor = PackedColor.Blue;
                                break;
                            default:
                                currentColor =
                                    SourceHexColor.HexToColor(text2);
                                break;
                        }

                        continue;
                    }

                    switch (text)
                    {
                        case "break":
                            CalcLineWidth();
                            currentPage++;
                            group.Pages++;
                            currentLine = 0;
                            currentPosition = 0f;
                            group.Nodes.Add(new NewPage());
                            continue;
                        case "n":
                            AddNewLine();
                            continue;
                        case ">>":
                        {
                            if (list.Count > 0 && float.TryParse(list[0], NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out var result2))
                                currentDelay = 0.01f / result2;
                            else
                                currentDelay = 0.01f;

                            continue;
                        }
                    }

                    if (text.Equals("/>>"))
                    {
                        currentDelay = 0.01f;
                        continue;
                    }

                    if (text.Equals("anchor"))
                    {
                        if (Enum.TryParse<Anchors>(list[0], true, out var result3))
                            group.Nodes.Add(new Anchor
                            {
                                Position = result3,
                            });

                        continue;
                    }

                    if (text.Equals("portrait") || text.Equals("left") || text.Equals("right"))
                    {
                        Portrait item;
                        if (text.Equals("portrait") && list.Count > 0 && list[0].Equals("none"))
                        {
                            item = new();
                            group.Nodes.Add(item);
                            continue;
                        }

                        if (text.Equals("left"))
                        {
                            item = array3[0];
                        }
                        else if (text.Equals("right"))
                        {
                            item = array3[1];
                        }
                        else
                        {
                            item = new();
                            foreach (var item2 in list)
                                if (item2.Equals("upsidedown"))
                                    item.UpsideDown = true;
                                else if (item2.Equals("flip"))
                                    item.Flipped = true;
                                else if (item2.Equals("left"))
                                    item.Side = -1;
                                else if (item2.Equals("right"))
                                    item.Side = 1;
                                else if (item2.Equals("pop"))
                                    item.Pop = true;
                                else if (item.Sprite == null)
                                    item.Sprite = item2;
                                else
                                    item.Animation = item2;
                        }

                        if (context.Portraits.Has(item.SpriteId))
                        {
                            var sources = context.Portraits.SpriteData[item.SpriteId].Sources;
                            for (var num2 = sources.Count - 1; num2 >= 0; num2--)
                            {
                                var xml = sources[num2].XML;
                                if (xml != null)
                                {
                                    if (item.SfxEvent == null)
                                        item.SfxEvent = "event:/char/dialogue/" + xml.Attr("sfx", "");
                                    if (xml.HasAttr("glitchy"))
                                        item.Glitchy = Convert.ToBoolean(xml.Attributes["glitchy"].InnerText);
                                    if (xml.HasChild("sfxs") && item.SfxExpression == 1)
                                        foreach (var expression in xml["sfxs"])
                                            if (expression is XmlElement element && element.Name.Equals(item.Animation,
                                                    StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                item.SfxExpression =
                                                    Convert.ToInt32(element.Attributes["index"].InnerText);
                                                break;
                                            }
                                }
                            }
                        }

                        group.Nodes.Add(item);
                        array3[item.Side > 0 ? 1u : 0u] = item;
                        continue;
                    }

                    if (text.Equals("trigger") || text.Equals("silent_trigger"))
                    {
                        var text3 = "";
                        for (var k = 1; k < list.Count; k++) text3 = text3 + list[k] + " ";

                        if (int.TryParse(list[0], out var result4) && result4 >= 0)
                            group.Nodes.Add(new Trigger
                            {
                                Index = result4,
                                Silent = text.StartsWith("silent"),
                                Label = text3,
                            });

                        continue;
                    }

                    if (text.Equals("*"))
                    {
                        currentShake = true;
                        continue;
                    }

                    if (text.Equals("/*"))
                    {
                        currentShake = false;
                        continue;
                    }

                    if (text.Equals("~"))
                    {
                        currentWave = true;
                        continue;
                    }

                    if (text.Equals("/~"))
                    {
                        currentWave = false;
                        continue;
                    }

                    if (text.Equals("!"))
                    {
                        currentImpact = true;
                        continue;
                    }

                    if (text.Equals("/!"))
                    {
                        currentImpact = false;
                        continue;
                    }

                    if (text.Equals("%"))
                    {
                        currentMessedUp = true;
                        continue;
                    }

                    if (text.Equals("/%"))
                    {
                        currentMessedUp = false;
                        continue;
                    }

                    if (text.Equals("big"))
                    {
                        currentScale = 1.5f;
                        continue;
                    }

                    if (text.Equals("/big"))
                    {
                        currentScale = 1f;
                        continue;
                    }

                    if (text.Equals("s"))
                    {
                        var result5 = 1;
                        if (list.Count > 0) int.TryParse(list[0], out result5);

                        currentPosition += 5 * result5;
                        continue;
                    }

                    if (!text.Equals("savedata")) continue;

                    if (context.SaveData == null)
                    {
                        if (list[0].Equals("name", StringComparison.OrdinalIgnoreCase))
                            AddWord("Madeline");
                        else
                            AddWord("[SD:" + list[0] + "]");
                    }
                    else if (list[0].Equals("name", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!context.CanDisplay(language, context.SaveData.Name))
                            AddWord(context.Text.Dialog.Clean("FILE_DEFAULT", language));
                        else
                            AddWord(context.SaveData.Name);
                    }
                    else
                    {
                        var field =
                            typeof(OriginalSaveDataState).GetField(list[0]);
                        AddWord(field.GetValue(context.SaveData).ToString());
                    }
                }
                else
                {
                    AddWord(array2[j]);
                }

            CalcLineWidth();
            return group;
        }

        private void CalcLineWidth()
        {
            Char obj = null;
            var num = group.Nodes.Count - 1;
            while (num >= 0 && obj == null)
            {
                if (group.Nodes[num] is Char)
                    obj = group.Nodes[num] as Char;
                else if (group.Nodes[num] is NewLine || group.Nodes[num] is NewPage) return;

                num--;
            }

            if (obj == null) return;

            var lineWidth = obj.LineWidth = obj.Position + size.Get(obj.Character).XAdvance * obj.Scale;
            while (num >= 0 && !(group.Nodes[num] is NewLine) && !(group.Nodes[num] is NewPage))
            {
                if (group.Nodes[num] is Char) (group.Nodes[num] as Char).LineWidth = lineWidth;

                num--;
            }
        }

        private void AddNewLine()
        {
            CalcLineWidth();
            currentLine++;
            currentPosition = 0f;
            group.Lines++;
            if (currentLine > linesPerPage)
            {
                group.Pages++;
                currentPage++;
                currentLine = 0;
                group.Nodes.Add(new NewPage());
            }
            else
            {
                group.Nodes.Add(new NewLine());
            }
        }

        private void AddWord(string word)
        {
            var num = size.Measure(word).X * currentScale;
            if (currentPosition + num > maxLineWidth) AddNewLine();

            for (var i = 0; i < word.Length; i++)
            {
                if ((currentPosition == 0f && word[i] == ' ') || word[i] == '\\') continue;

                var pixelFontCharacter =
                    size.Get(word[i]);
                if (pixelFontCharacter == null) continue;

                var num2 = 0f;
                if (i == word.Length - 1 && (i == 0 || word[i - 1] != '\\'))
                {
                    if (Contains(language.CommaCharacters, word[i]))
                        num2 = 0.15f;
                    else if (Contains(language.PeriodCharacters, word[i])) num2 = 0.3f;
                }

                group.Nodes.Add(new Char
                {
                    Index = currentCharIndex++,
                    Character = word[i],
                    Position = currentPosition,
                    Line = currentLine,
                    Page = currentPage,
                    Delay = currentImpact ? 0.0034999999f : currentDelay + num2,
                    Color = currentColor,
                    Scale = currentScale,
                    Rotation = currentMessedUp ? Choose(-1, 1) * Choose(0.17453292f, 0.34906584f) : 0f,
                    YOffset = currentMessedUp ? Choose(-3, -6, 3, 6) : 0f,
                    Fade = startFade,
                    Shake = currentShake,
                    Impact = currentImpact,
                    Wave = currentWave,
                    IsPunctuation = Contains(language.CommaCharacters, word[i]) ||
                                    Contains(language.PeriodCharacters, word[i]),
                });
                currentPosition += pixelFontCharacter.XAdvance * currentScale;
                if (i < word.Length - 1 && pixelFontCharacter.Kerning.TryGetValue(word[i], out var value))
                    currentPosition += value * currentScale;
            }
        }

        private T Choose<T>(params T[] values)
        {
            return values[context.Random.Next(values.Length)];
        }

        private bool Contains(string str, char character)
        {
            for (var i = 0; i < str.Length; i++)
                if (str[i] == character)
                    return true;

            return false;
        }
    }
}
