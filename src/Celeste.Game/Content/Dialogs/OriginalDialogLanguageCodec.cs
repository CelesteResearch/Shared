using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Localization.Languages;

namespace Celeste.Game.Content.Dialogs
{
    // Original .txt declarations/commands and .export wire layout. Runtime
    // language data contains no parser, file discovery or original folder policy.
    public static class OriginalDialogLanguageCodec
    {
        private static readonly Regex Command = new("\\{(.*?)\\}", RegexOptions.RightToLeft);
        private static readonly Regex Insert = new("\\{\\+\\s*(.*?)\\}");
        private static readonly Regex Variable = new("^\\w+\\=.*");

        private static readonly Regex Portrait =
            new("\\[(?<content>[^\\[\\\\]*(?:\\\\.[^\\]\\\\]*)*)\\]", RegexOptions.IgnoreCase);

        public static void Export(DialogLanguage language, string path)
        {
            using (var writer = new BinaryWriter(File.OpenWrite(path)))
            {
                writer.Write(language.Id);
                writer.Write(language.Label);
                writer.Write(language.IconPath);
                writer.Write(language.Order);
                writer.Write(language.FontFace);
                writer.Write(language.FontFaceSize);
                writer.Write(language.SplitRegex);
                writer.Write(language.CommaCharacters);
                writer.Write(language.PeriodCharacters);
                writer.Write(language.Lines);
                writer.Write(language.Words);
                writer.Write(language.Dialog.Count);
                foreach (var item in language.Dialog)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                    writer.Write(language.Cleaned[item.Key]);
                }
            }
        }

        public static DialogLanguage FromExport(string path,
            IOriginalLanguageTextureFactory textures)
        {
            return FromExport(File.OpenRead(path), textures);
        }

        public static DialogLanguage FromExport(Stream input,
            IOriginalLanguageTextureFactory textures)
        {
            var language = new DialogLanguage();
            using (var reader = new BinaryReader(input))
            {
                language.Id = reader.ReadString();
                language.Label = reader.ReadString();
                language.IconPath = reader.ReadString();
                language.Icon = textures.CreateTexture(Path.Combine("Dialog", language.IconPath));
                language.Order = reader.ReadInt32();
                language.FontFace = reader.ReadString();
                language.FontFaceSize = reader.ReadSingle();
                language.SplitRegex = reader.ReadString();
                language.CommaCharacters = reader.ReadString();
                language.PeriodCharacters = reader.ReadString();
                language.Lines = reader.ReadInt32();
                language.Words = reader.ReadInt32();
                var count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var key = reader.ReadString();
                    language.Dialog[key] = reader.ReadString();
                    language.Cleaned[key] = reader.ReadString();
                }
            }

            language.IconAssetPath = language.IconPath == null ? null : Path.Combine("Dialog", language.IconPath);
            return language;
        }

        public static DialogLanguage FromTxt(string path,
            IOriginalLanguageTextureFactory textures)
        {
            return FromLines(File.ReadLines(path), Path.GetFileName(path), null, textures);
        }

        public static DialogLanguage FromTxt(Stream input, string path,
            IOriginalLanguageTextureFactory textures)
        {
            using var reader = new StreamReader(input);
            return FromLines(ReadLines(reader), Path.GetFileName(path), null, textures);
        }

        private static IEnumerable<string> ReadLines(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null) yield return line;
        }

        // Everest dialog files are fragments without a `language` declaration. Apply
        // them after vanilla and earlier packages, preserving that source order.
        public static DialogLanguage MergeTxt(string contents,
            DialogLanguage language, IOriginalLanguageTextureFactory textures)
        {
            return language == null
                ? throw new ArgumentNullException(nameof(language))
                : FromLines(contents.Replace("\r\n", "\n").Split('\n'), language.SourceName, language, textures);
        }

        private static DialogLanguage FromLines(IEnumerable<string> lines,
            string filePath, DialogLanguage language,
            IOriginalLanguageTextureFactory textures)
        {
            string key = "", previous = "";
            var builder = new StringBuilder();
            foreach (var line in lines)
            {
                var text = line.Trim();
                if (text.Length <= 0 || text[0] == '#') continue;
                if (text.IndexOf('[') >= 0) text = Portrait.Replace(text, "{portrait ${content}}");
                text = text.Replace("\\#", "#");
                if (text.Length <= 0) continue;
                if (Variable.IsMatch(text))
                {
                    if (!string.IsNullOrEmpty(key)) language.Dialog[key] = builder.ToString();
                    var parts = text.Split('=');
                    string name = parts[0].Trim(), value = parts.Length > 1 ? parts[1].Trim() : "";
                    if (name.Equals("language", StringComparison.OrdinalIgnoreCase))
                    {
                        var values = value.Split(',');
                        language = new()
                        {
                            FontFace = null, Id = values[0], FilePath = Path.GetFileName(filePath),
                            SourceName = filePath,
                            Order = 100, SplitRegex = "(\\s|\\{|\\})", CommaCharacters = ",", PeriodCharacters = ".!?",
                        };
                        if (values.Length > 1) language.Label = values[1];
                    }
                    else if (name.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    {
                        var texture = textures.CreateTexture(Path.Combine("Dialog", value));
                        language.IconPath = value;
                        language.Icon = texture;
                    }
                    else if (name.Equals("order", StringComparison.OrdinalIgnoreCase))
                    {
                        language.Order = int.Parse(value);
                    }
                    else if (name.Equals("font", StringComparison.OrdinalIgnoreCase))
                    {
                        var values = value.Split(',');
                        language.FontFace = values[0];
                        language.FontFaceSize = float.Parse(values[1], CultureInfo.InvariantCulture);
                    }
                    else if (name.Equals("SPLIT_REGEX", StringComparison.OrdinalIgnoreCase))
                    {
                        language.SplitRegex = value;
                    }
                    else if (name.Equals("commas", StringComparison.OrdinalIgnoreCase))
                    {
                        language.CommaCharacters = value;
                    }
                    else if (name.Equals("periods", StringComparison.OrdinalIgnoreCase))
                    {
                        language.PeriodCharacters = value;
                    }
                    else
                    {
                        key = name;
                        builder.Clear();
                        builder.Append(value);
                    }
                }
                else
                {
                    if (builder.Length > 0)
                    {
                        var value = builder.ToString();
                        if (!value.EndsWith("{break}") && !value.EndsWith("{n}") &&
                            Command.Replace(previous, "").Length > 0) builder.Append("{break}");
                    }

                    builder.Append(text);
                }

                previous = text;
            }

            if (!string.IsNullOrEmpty(key)) language.Dialog[key] = builder.ToString();
            var keys = new List<string>(language.Dialog.Keys);
            foreach (var name in keys)
            {
                var text = language.Dialog[name];
                MatchCollection matches = null;
                while (matches == null || matches.Count > 0)
                {
                    matches = Insert.Matches(text);
                    for (var i = 0; i < matches.Count; i++)
                    {
                        var match = matches[i];
                        text = language.Dialog.TryGetValue(match.Groups[1].Value, out var inserted)
                            ? text.Replace(match.Value, inserted)
                            : text.Replace(match.Value, "[XXX]");
                    }
                }

                language.Dialog[name] = text;
            }

            language.Lines = 0;
            language.Words = 0;
            language.Cleaned.Clear();
            foreach (var name in keys)
            {
                var text = language.Dialog[name];
                if (text.IndexOf('{') >= 0)
                    text = Command.Replace(text.Replace("{n}", "\n").Replace("{break}", "\n"), "");
                language.Cleaned.Add(name, text);
            }

            language.IconAssetPath = language.IconPath == null ? null : Path.Combine("Dialog", language.IconPath);
            return language;
        }
    }
}
