using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Localization.Languages;
using Celeste.Game.Content.Dialogs;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Dialogs;

namespace Celeste.Everest.Content.Dialogs
{
    public sealed partial class EverestDialogLevelSetProcess
    {
        private DialogLanguage LoadingLanguage;
        private bool LoadOrigLanguage = true, LoadModLanguage = true;
        private EverestContentRegistry Content => ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry;
        private IOriginalLanguageTextureFactory Textures => (IOriginalLanguageTextureFactory)engine;
        private static readonly Regex WholeLineCommands = new Regex(@"^(?:\{[^}]*\}\s*)*$");
        private static readonly Regex Commands = new Regex(@"\{(.*?)\}", RegexOptions.RightToLeft);

        private static readonly Regex Portraits =
            new Regex(@"\[(?<content>[^\[\\]*(?:\\.[^\]\\]*)*)\]", RegexOptions.IgnoreCase);

        private static readonly Regex Variables = new Regex(@"^\w+\=.*");
        private static readonly Regex Inserts = new Regex(@"\{\+\s*(.*?)\}");
        private static Regex WholeLineIsCommandsRegex() => WholeLineCommands;
        private static Regex CommandRegex() => Commands;
        private static Regex PortraitRegex() => Portraits;
        private static Regex VariableRegex() => Variables;
        private static Regex InsertRegex() => Inserts;

        public List<string> GetVanillaLanguageFileList(string root, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(root, searchPattern, searchOption)
                .Select(f => f.Substring(Content.PathContentOrig.Length + 1).Replace('\\', '/')).ToList();
        }

        private DialogLanguage LoadOriginalLanguage(string filename)
        {
            DialogLanguage language;
            if (File.Exists(filename + ".export"))
            {
                language = OriginalDialogLanguageCodec.FromExport(filename + ".export", Textures);
                language.FilePath = Path.GetFileNameWithoutExtension(filename + ".export");
            }
            else language = FromInstalledTxt(filename);

            if (language != null) Text.Dialog.Languages[language.Id] = language;
            return language;
        }

        private void _SetItem(Dictionary<string, string> dict, string key, string value, DialogLanguage language)
        {
            if (language.Dialog == dict && language.ReadCount != null &&
                !string.IsNullOrEmpty(language.CurrentlyReadingFrom) && key != "EVEREST_SPLIT_BETWEEN_FILES")
            {
                if (!language.ReadCount.TryGetValue(key, out int count))
                    count = language.Dialog.ContainsKey(key) ? 1 : 0;
                language.ReadCount[key] = ++count;
                string previous = language.LineSources.TryGetValue(key, out string source) ? source : "?!?!?!";
                language.LineSources[key] = language.CurrentlyReadingFrom;
                if (count >= 2)
                {
                    var message = Logger.BeginEnabledMessage("Language", global::Celeste.Everest.EverestLogLevel.Warn);
                    if (message.ShouldLog)
                        message.Write(
                            $"Conflict for dialog key {language.Id}/{key} ({previous} vs {language.CurrentlyReadingFrom})");
                }
            }

            dict[key] = value;
        }

        public DialogLanguage LoadLanguage(string filename)
        {
            LoadingLanguage = null;
            LoadOrigLanguage = true;
            LoadModLanguage = false;
            DialogLanguage language = LoadOriginalLanguage(filename);
            LoadingLanguage = null;
            Text.Dialog.Languages.Remove(language.Id);
            string pathExp = filename.Substring(Content.PathContentOrig.Length + 1).Replace('\\', '/');
            foreach (var item in from mod in Content.Mods
                     select (!mod.Map.TryGetValue(pathExp, out var value)) ? null : value
                     into asset
                     where asset != null && asset.Type == typeof(AssetTypeDialogExport)
                     select asset)
            {
                language = MergeDialogLanguages(language, FromModExport(item));
            }

            DialogLanguage language2 = (LoadingLanguage = new DialogLanguage());
            language2.LineSources = new Dictionary<string, string>();
            language2.ReadCount = new Dictionary<string, int>();
            if (language != null)
            {
                foreach (KeyValuePair<string, string> item2 in language.Dialog)
                {
                    language2.Dialog[item2.Key] = item2.Value;
                }
            }

            LoadOrigLanguage = false;
            LoadModLanguage = true;
            language = MergeDialogLanguages(language, FromInstalledTxt(filename));
            LoadingLanguage = null;
            if (language != null)
            {
                language.Dialog.Remove("EVEREST_SPLIT_BETWEEN_FILES");
                language.Cleaned.Remove("EVEREST_SPLIT_BETWEEN_FILES");
                if (language.Dialog.Count > 0)
                {
                    Text.Dialog.Languages[language.Id] = language;
                }
            }

            return language;
        }

        private void PostLanguageLoad()
        {
            DialogLanguage[] array = Text.Dialog.Languages.Values.Distinct().ToArray();
            Text.Dialog.Languages.Clear();
            DialogLanguage[] array2 = array;
            foreach (DialogLanguage language in array2)
            {
                if (language.Dialog.Count == 0 || (string.IsNullOrEmpty(language.Label) &&
                                                   string.IsNullOrEmpty(language.FontFace) &&
                                                   string.IsNullOrEmpty(language.IconPath)))
                {
                    if (language.Icon != null)
                    {
                        language.Dispose();
                    }

                    continue;
                }

                if (string.IsNullOrEmpty(language.FontFace))
                {
                    language.FontFace = "Renogare";
                    language.FontFaceSize = 64f;
                }

                if (language.Icon == null)
                {
                    language.Icon =
                        Textures.CreateTexture(Path.Combine("Graphics", "Atlases", "Gui", "menu", "langnoicon"));
                }

                Text.Dialog.Languages[language.Id] = language;
                if (language.Id.Equals("english", StringComparison.InvariantCultureIgnoreCase))
                {
                    Text.Dialog.FallbackLanguage = language;
                }
            }

            Text.Dialog.OrderedLanguages = new List<DialogLanguage>();
            foreach (KeyValuePair<string, DialogLanguage> language2 in Text.Dialog.Languages)
            {
                Text.Dialog.OrderedLanguages.Add(language2.Value);
            }

            Text.Dialog.OrderedLanguages.Sort((DialogLanguage a, DialogLanguage b) =>
                (a.Order == b.Order) ? a.Id.CompareTo(b.Id) : (a.Order - b.Order));
        }

        public void RefreshLanguages()
        {
            PostLanguageLoad();
            MissingDialogIds.Clear();
            InvalidDialogIds.Clear();
            Text.Dialog.Language = Text.Dialog.Languages[Text.Dialog.Language.Id];
        }

        private DialogLanguage FromModExport(global::Celeste.Everest.Content.Assets.EverestContentAsset asset)
        {
            DialogLanguage language = new DialogLanguage();
            using (BinaryReader binaryReader = new BinaryReader(asset.Stream))
            {
                language.Id = binaryReader.ReadString();
                language.Label = binaryReader.ReadString();
                language.IconPath = binaryReader.ReadString();
                language.Icon = Textures.CreateTexture(Path.Combine("Dialog", language.IconPath));
                language.Order = binaryReader.ReadInt32();
                language.FontFace = binaryReader.ReadString();
                language.FontFaceSize = binaryReader.ReadSingle();
                language.SplitRegex = binaryReader.ReadString();
                language.CommaCharacters = binaryReader.ReadString();
                language.PeriodCharacters = binaryReader.ReadString();
                language.Lines = binaryReader.ReadInt32();
                language.Words = binaryReader.ReadInt32();
                int num = binaryReader.ReadInt32();
                for (int i = 0; i < num; i++)
                {
                    string key = binaryReader.ReadString();
                    language.Dialog[key] = binaryReader.ReadString();
                    language.Cleaned[key] = binaryReader.ReadString();
                }
            }

            language.FilePath = Path.GetFileNameWithoutExtension(asset.PathVirtual);
            return language;
        }

        private DialogLanguage FromInstalledTxt(string path)
        {
            DialogLanguage language = null;
            string text = "";
            StringBuilder stringBuilder = new StringBuilder();
            string input = "";
            ReadOnlySpan<char> readOnlySpan = "";
            foreach (string item in _GetLanguageText(path, Encoding.UTF8))
            {
                string text2 = item.Trim();
                if (text2.Length <= 0 || text2[0] == '#')
                {
                    continue;
                }

                if (text2.IndexOf('[') >= 0)
                {
                    text2 = PortraitRegex().Replace(text2, "{portrait ${content}}");
                }

                text2 = text2.Replace("\\#", "#", StringComparison.Ordinal);
                if (text2.Length <= 0)
                {
                    continue;
                }

                if (VariableRegex().IsMatch(text2))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        _SetItem(language.Dialog, text, stringBuilder.ToString(), language);
                    }

                    SplitPair(text2, '=', out var left, out var right);
                    if (MemoryExtensions.Equals(left, "language", StringComparison.OrdinalIgnoreCase))
                    {
                        language = _NewLanguage();
                        language.FontFace = null;
                        language.FilePath = Path.GetFileName(path);
                        if (SplitPair(right, ',', out var left2, out var right2))
                        {
                            language.Id = left2.ToString();
                            language.Label = right2.ToString();
                        }
                        else
                        {
                            language.Id = right.ToString();
                        }
                    }
                    else if (MemoryExtensions.Equals(left, "icon", StringComparison.OrdinalIgnoreCase))
                    {
                        string text3 = right.ToString();
                        var texture = Textures.CreateTexture(Path.Combine("Dialog", text3));
                        language.IconPath = text3;
                        language.Icon = texture;
                    }
                    else if (MemoryExtensions.Equals(left, "order", StringComparison.OrdinalIgnoreCase))
                    {
                        language.Order = int.Parse(right);
                    }
                    else if (MemoryExtensions.Equals(left, "font", StringComparison.OrdinalIgnoreCase))
                    {
                        if (SplitPair(right, ',', out var left3, out var right3))
                        {
                            language.FontFace = left3.ToString();
                            language.FontFaceSize = float.Parse(right3,
                                NumberStyles.Float | NumberStyles.AllowThousands,
                                CultureInfo.InvariantCulture);
                        }
                    }
                    else if (MemoryExtensions.Equals(left, "SPLIT_REGEX", StringComparison.OrdinalIgnoreCase))
                    {
                        language.SplitRegex = right.ToString();
                    }
                    else if (MemoryExtensions.Equals(left, "commas", StringComparison.OrdinalIgnoreCase))
                    {
                        language.CommaCharacters = right.ToString();
                    }
                    else if (MemoryExtensions.Equals(left, "periods", StringComparison.OrdinalIgnoreCase))
                    {
                        language.PeriodCharacters = right.ToString();
                    }
                    else
                    {
                        text = left.ToString();
                        stringBuilder.Clear();
                        stringBuilder.Append(right);
                        readOnlySpan = right;
                    }
                }
                else
                {
                    if (stringBuilder.Length > 0 && !readOnlySpan.EndsWith("{break}", StringComparison.Ordinal) &&
                        !readOnlySpan.EndsWith("{n}", StringComparison.Ordinal) &&
                        !WholeLineIsCommandsRegex().IsMatch(input))
                    {
                        stringBuilder.Append("{break}");
                        readOnlySpan = "{break}";
                    }

                    stringBuilder.Append(text2);
                    readOnlySpan = ((text2.Length > 0) ? ((ReadOnlySpan<char>)text2) : readOnlySpan);
                }

                input = text2;
            }

            if (!string.IsNullOrEmpty(text))
            {
                _SetItem(language.Dialog, text, stringBuilder.ToString(), language);
            }

            string[] keys = language.Dialog.Keys.ToArray();
            foreach (string item2 in keys)
            {
                string value = GetDialogWithResolvedInserts(language, language.Dialog[item2]);
                _SetItem(language.Dialog, item2, value, language);
            }

            language.Lines = 0;
            language.Words = 0;
            foreach (string item3 in keys)
            {
                string text4 = language.Dialog[item3];
                if (text4.Contains('{'))
                {
                    text4 = CommandRegex().Replace(text4, delegate(Match match)
                    {
                        ReadOnlySpan<char> valueSpan = match.Value.AsSpan();
                        return ((!valueSpan.SequenceEqual("{n}".AsSpan()) &&
                                 !valueSpan.SequenceEqual("{break}".AsSpan())) || 1 == 0)
                            ? ""
                            : "\n";
                    });
                }

                language.Cleaned[item3] = text4;
            }

            return language;

            static string GetDialogWithResolvedInserts(DialogLanguage language2, string dialog)
            {
                return InsertRegex().Replace(dialog, delegate(Match match)
                {
                    string value2 = match.Groups[1].Value;
                    return GetDialogWithResolvedInserts(language2,
                        (language2.Dialog.TryGetValue(value2, out var inserted) ? inserted : "[XXX]"));
                });
            }
        }

        private IEnumerable<string> _GetLanguageText(string path, Encoding encoding)
        {
            DialogLanguage lang = _NewLanguage();
            bool ready = LoadOrigLanguage && File.Exists(path);
            if (ready)
            {
                lang.CurrentlyReadingFrom = "Celeste";
                foreach (string item in File.ReadLines(path, encoding))
                {
                    yield return item;
                }
            }

            string text = path;
            int num = Content.PathContentOrig.Length + 1;
            path = text.Substring(num, text.Length - num);
            path = path.Replace('\\', '/');
            text = path;
            num = ".txt".Length;
            path = text.Substring(0, text.Length - num);
            if (!ready)
            {
                text = path;
                num = "Dialog/".Length;
                yield return "LANGUAGE=" + text.Substring(num, text.Length - num).ToLowerInvariant();
            }

            if (!LoadModLanguage)
            {
                yield break;
            }

            foreach (var mod in Content.Mods)
            {
                foreach (var item2 in from entry in mod.Map
                         where entry.Value.Type == typeof(AssetTypeDialog) &&
                               entry.Key.Equals(path, StringComparison.OrdinalIgnoreCase)
                         select entry.Value)
                {
                    lang.CurrentlyReadingFrom = item2.Source?.Name ?? "???";
                    using (StreamReader reader = new StreamReader(item2.Stream, encoding))
                    {
                        while (reader.Peek() != -1)
                        {
                            yield return reader.ReadLine().Trim();
                        }
                    }

                    lang.CurrentlyReadingFrom = null;
                    yield return "EVEREST_SPLIT_BETWEEN_FILES= New file";
                }
            }
        }

        private DialogLanguage _NewLanguage()
        {
            return LoadingLanguage ?? (LoadingLanguage = new DialogLanguage());
        }

        private static bool SplitPair(ReadOnlySpan<char> from, char separator, out ReadOnlySpan<char> left,
            out ReadOnlySpan<char> right)
        {
            int num = from.IndexOf(separator);
            if (num == -1)
            {
                left = from;
                right = Span<char>.Empty;
                return false;
            }

            left = from.Slice(0, num);
            int num2 = num + 1;
            right = from.Slice(num2, from.Length - num2).Trim();
            return true;
        }

        private static DialogLanguage MergeDialogLanguages(DialogLanguage orig, DialogLanguage mod)
        {
            if (orig == null)
            {
                return mod;
            }

            if (string.IsNullOrEmpty(orig.Label) && string.IsNullOrEmpty(orig.IconPath))
            {
                orig.Id = mod.Id;
                orig.FontFace = mod.FontFace;
                orig.FontFaceSize = mod.FontFaceSize;
                orig.FilePath = mod.FilePath;
                orig.Label = mod.Label;
                orig.IconPath = mod.IconPath;
                orig.Icon = mod.Icon;
                orig.Order = mod.Order;
                orig.SplitRegex = mod.SplitRegex;
                orig.CommaCharacters = mod.CommaCharacters;
                orig.PeriodCharacters = mod.PeriodCharacters;
            }

            foreach (KeyValuePair<string, string> item in mod.Dialog)
            {
                orig.Dialog[item.Key] = item.Value;
            }

            foreach (KeyValuePair<string, string> item2 in mod.Cleaned)
            {
                orig.Cleaned[item2.Key] = item2.Value;
            }

            return orig;
        }
    }
}
