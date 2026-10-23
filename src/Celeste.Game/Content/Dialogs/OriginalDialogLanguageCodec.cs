using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Simulation;

namespace Celeste.Game.Content.Dialogs
{
    // Original .txt declarations/commands and .export wire layout. Runtime
    // language data contains no parser, file discovery or original folder policy.
    public static class OriginalDialogLanguageCodec
    {
        private static readonly Regex Command = new Regex("\\{(.*?)\\}", RegexOptions.RightToLeft);
        private static readonly Regex Insert = new Regex("\\{\\+\\s*(.*?)\\}");
        private static readonly Regex Variable = new Regex("^\\w+\\=.*");

        private static readonly Regex Portrait =
            new Regex("\\[(?<content>[^\\[\\\\]*(?:\\\\.[^\\]\\\\]*)*)\\]", RegexOptions.IgnoreCase);

        public static void Export(global::Celeste.Localization.Languages.DialogLanguage language, string path)
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

        public static global::Celeste.Localization.Languages.DialogLanguage FromExport(string path,
            IOriginalLanguageTextureFactory textures)
            => FromExport(File.OpenRead(path), textures);

        public static global::Celeste.Localization.Languages.DialogLanguage FromExport(Stream input,
            IOriginalLanguageTextureFactory textures)
        {
            var language = new global::Celeste.Localization.Languages.DialogLanguage();
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
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    language.Dialog[key] = reader.ReadString();
                    language.Cleaned[key] = reader.ReadString();
                }
            }

            language.IconAssetPath = language.IconPath == null ? null : Path.Combine("Dialog", language.IconPath);
            return language;
        }

        public static global::Celeste.Localization.Languages.DialogLanguage FromTxt(string path,
            IOriginalLanguageTextureFactory textures) =>
            FromLines(File.ReadLines(path), Path.GetFileName(path), null, textures);

        public static global::Celeste.Localization.Languages.DialogLanguage FromTxt(Stream input, string path,
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
        public static global::Celeste.Localization.Languages.DialogLanguage MergeTxt(string contents,
            global::Celeste.Localization.Languages.DialogLanguage language, IOriginalLanguageTextureFactory textures)
        {
            if (language == null) throw new ArgumentNullException(nameof(language));
            return FromLines(contents.Replace("\r\n", "\n").Split('\n'), language.SourceName, language, textures);
        }

        private static global::Celeste.Localization.Languages.DialogLanguage FromLines(IEnumerable<string> lines,
            string filePath, global::Celeste.Localization.Languages.DialogLanguage language,
            IOriginalLanguageTextureFactory textures)
        {
            string key = "", previous = "";
            var builder = new StringBuilder();
            foreach (string line in lines)
            {
                string text = line.Trim();
                if (text.Length <= 0 || text[0] == '#') continue;
                if (text.IndexOf('[') >= 0) text = Portrait.Replace(text, "{portrait ${content}}");
                text = text.Replace("\\#", "#");
                if (text.Length <= 0) continue;
                if (Variable.IsMatch(text))
                {
                    if (!string.IsNullOrEmpty(key)) language.Dialog[key] = builder.ToString();
                    string[] parts = text.Split('=');
                    string name = parts[0].Trim(), value = parts.Length > 1 ? parts[1].Trim() : "";
                    if (name.Equals("language", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] values = value.Split(',');
                        language = new global::Celeste.Localization.Languages.DialogLanguage
                        {
                            FontFace = null, Id = values[0], FilePath = Path.GetFileName(filePath),
                            SourceName = filePath,
                            Order = 100, SplitRegex = "(\\s|\\{|\\})", CommaCharacters = ",", PeriodCharacters = ".!?"
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
                        language.Order = int.Parse(value);
                    else if (name.Equals("font", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] values = value.Split(',');
                        language.FontFace = values[0];
                        language.FontFaceSize = float.Parse(values[1], CultureInfo.InvariantCulture);
                    }
                    else if (name.Equals("SPLIT_REGEX", StringComparison.OrdinalIgnoreCase))
                        language.SplitRegex = value;
                    else if (name.Equals("commas", StringComparison.OrdinalIgnoreCase))
                        language.CommaCharacters = value;
                    else if (name.Equals("periods", StringComparison.OrdinalIgnoreCase))
                        language.PeriodCharacters = value;
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
                        string value = builder.ToString();
                        if (!value.EndsWith("{break}") && !value.EndsWith("{n}") &&
                            Command.Replace(previous, "").Length > 0) builder.Append("{break}");
                    }

                    builder.Append(text);
                }

                previous = text;
            }

            if (!string.IsNullOrEmpty(key)) language.Dialog[key] = builder.ToString();
            var keys = new List<string>(language.Dialog.Keys);
            foreach (string name in keys)
            {
                string text = language.Dialog[name];
                MatchCollection matches = null;
                while (matches == null || matches.Count > 0)
                {
                    matches = Insert.Matches(text);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match match = matches[i];
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
            foreach (string name in keys)
            {
                string text = language.Dialog[name];
                if (text.IndexOf('{') >= 0)
                    text = Command.Replace(text.Replace("{n}", "\n").Replace("{break}", "\n"), "");
                language.Cleaned.Add(name, text);
            }

            language.IconAssetPath = language.IconPath == null ? null : Path.Combine("Dialog", language.IconPath);
            return language;
        }
    }
}
