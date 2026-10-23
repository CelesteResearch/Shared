using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Everest.Content.Types.Audio;
using Celeste.Everest.Content.Types.Dialogs;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Content.Types.Graphics;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Content.Types.Modules;
using Celeste.Everest.Content.Types.Playback;
using Celeste.Everest.Content.Types.Text;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public string GuessType(string file, out Type type, out string format)
        {
            type = typeof(object);
            format = Path.GetExtension(file) ?? "";
            if (format.Length < 1) return file;

            var text = format;
            format = text.Substring(1, text.Length - 1);
            var readOnlySpan = file.AsSpan();
            var num = readOnlySpan.LastIndexOf('/') + 1;
            var readOnlySpan2 = readOnlySpan.Slice(0, num);
            ref var reference = ref readOnlySpan;
            var num2 = num;
            var readOnlySpan3 = reference.Slice(num2, reference.Length - num2);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(readOnlySpan3);
            var warningAlreadySent = false;
            if (MatchExtension(readOnlySpan, readOnlySpan3, "dll", ref warningAlreadySent))
            {
                type = typeof(AssetTypeAssembly);
                return readOnlySpan.ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "png", ref warningAlreadySent))
            {
                type = typeof(AssetTypeTexture);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "obj", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeObjModel);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchMultipartExtension(readOnlySpan, readOnlySpan3, "obj.export", ref warningAlreadySent))
            {
                type = typeof(AssetTypeObjModelExport);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 7).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yaml", ref warningAlreadySent, true) &&
                readOnlySpan2.IsEmpty &&
                SpanEqualsAny(fileNameWithoutExtension, "metadata", "multimetadata", "everest"))
            {
                type = typeof(AssetTypeMetadataYaml);
                format = "yml";
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 5).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yml", ref warningAlreadySent, true) &&
                readOnlySpan2.IsEmpty && SpanEquals(fileNameWithoutExtension, "everest"))
            {
                type = typeof(AssetTypeMetadataYaml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "xml", ref warningAlreadySent, true))
            {
                if (readOnlySpan2.IsEmpty && SpanEquals(fileNameWithoutExtension, "DecalRegistry"))
                {
                    type = typeof(AssetTypeDecalRegistry);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }

                if (SpanEquals(readOnlySpan2, "Graphics/") &&
                    SpanEqualsAny(fileNameWithoutExtension, "Sprites", "SpritesGui", "Portraits"))
                {
                    type = typeof(AssetTypeSpriteBank);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }
            }

            if (readOnlySpan2.IsEmpty && fileNameWithoutExtension.IsEmpty && MatchExtension(readOnlySpan, readOnlySpan3,
                    "everestignore", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeEverestIgnore);
                return "";
            }

            if (readOnlySpan2.StartsWith("Dialog/"))
            {
                if (MatchExtension(readOnlySpan, readOnlySpan3, "txt", ref warningAlreadySent, true))
                {
                    type = typeof(AssetTypeDialog);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }

                if (MatchMultipartExtension(readOnlySpan, readOnlySpan3, "txt.export", ref warningAlreadySent))
                {
                    type = typeof(AssetTypeDialogExport);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 7).ToString();
                }

                if (MatchExtension(readOnlySpan, readOnlySpan3, "fnt", ref warningAlreadySent, true))
                {
                    type = typeof(AssetTypeFont);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "bin", ref warningAlreadySent))
            {
                if (readOnlySpan2.StartsWith("Maps/"))
                {
                    type = typeof(AssetTypeMap);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }

                if (readOnlySpan2.StartsWith("Tutorials/"))
                {
                    type = typeof(AssetTypeTutorial);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }
            }

            if (readOnlySpan2.StartsWith("Audio/"))
            {
                if (MatchExtension(readOnlySpan, readOnlySpan3, "bank", ref warningAlreadySent))
                {
                    type = typeof(AssetTypeBank);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 5).ToString();
                }

                if (MatchMultipartExtension(readOnlySpan, readOnlySpan3, "guids.txt", ref warningAlreadySent,
                        true))
                {
                    type = typeof(AssetTypeGUIDs);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }

                if (MatchMultipartExtension(readOnlySpan, readOnlySpan3, "GUIDs.txt", ref warningAlreadySent,
                        true))
                {
                    type = typeof(AssetTypeGUIDs);
                    reference = ref readOnlySpan;
                    Span<char> span = /* ReSharper disable once UseCollectionExpression */
                        reference.Slice(0, reference.Length - 4).ToArray();
                    for (var i = 1; i <= 5; i++)
                    {
                        num2 = i;
                        ref var reference2 = ref span[span.Length - num2];
                        var num3 = i;
                        reference2 = char.ToLower(span[span.Length - num3]);
                    }

                    return span.ToString();
                }
            }

            if (OnGuessType != null)
            {
                var invocationList = OnGuessType.GetInvocationList();
                for (num2 = 0; num2 < invocationList.Length; num2++)
                {
                    Type type2;
                    string format2;
                    var text2 = ((EverestContentTypeGuesser)invocationList[num2])(file, out type2, out format2);
                    if (text2 != null && !(type2 == null) && format2 != null)
                    {
                        file = text2;
                        type = type2;
                        format = format2;
                        return file;
                    }
                }
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "lua", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeLua);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "txt", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeText);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "xml", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeXml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yml", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeYaml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yaml", ref warningAlreadySent, true))
            {
                type = typeof(AssetTypeYaml);
                format = "yml";
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 5).ToString();
            }

            return readOnlySpan.ToString();
        }

        private static bool SpanEqualsAny(ReadOnlySpan<char> left, params string[] right)
        {
            foreach (var text in right)
                if (left.Equals(text, StringComparison.Ordinal))
                    return true;

            return false;
        }

        private static bool SpanEquals(ReadOnlySpan<char> left, string right)
        {
            return left.Equals(right, StringComparison.Ordinal);
        }

        private bool MatchExtension(ReadOnlySpan<char> filePath, ReadOnlySpan<char> fileName,
            ReadOnlySpan<char> expectedExtension, ref bool warningAlreadySent, bool isTextBased = false)
        {
            var span = Path.GetExtension(fileName);
            if (span.IsEmpty) return false;

            ref var reference = ref span;
            span = reference.Slice(1, reference.Length - 1);
            if (span.Equals(expectedExtension, StringComparison.Ordinal))
            {
                span = Path.GetExtension(Path.GetFileNameWithoutExtension(fileName));
                if (!warningAlreadySent && !span.IsEmpty)
                {
                    reference = ref span;
                    if (reference.Slice(1, reference.Length - 1).Equals(expectedExtension, StringComparison.Ordinal))
                    {
                        Diagnostics.Warning("Content",
                            "\"" + filePath.ToString() +
                            "\" has a doubled extension! It may not be handled correctly.");
                        warningAlreadySent = true;
                    }
                }

                return true;
            }

            if (warningAlreadySent) return false;

            if (isTextBased && span.Equals("txt", StringComparison.Ordinal))
            {
                span = Path.GetExtension(Path.GetFileNameWithoutExtension(fileName));
                if (!span.IsEmpty)
                {
                    reference = ref span;
                    if (reference.Slice(1, reference.Length - 1).Equals(expectedExtension, StringComparison.Ordinal))
                    {
                        Diagnostics.Warning("Content",
                            "\"" + filePath.ToString() +
                            "\" has an extra \".txt\" extension! It may not be handled correctly.");
                        warningAlreadySent = true;
                    }
                }
            }

            return false;
        }

        private bool MatchMultipartExtension(ReadOnlySpan<char> filePath, ReadOnlySpan<char> fileName,
            ReadOnlySpan<char> expectedExtension, ref bool warningAlreadySent, bool isTextBased = false)
        {
            if (expectedExtension.IndexOf('.') == -1)
                return MatchExtension(filePath, fileName, expectedExtension, ref warningAlreadySent, isTextBased);

            var list = new List<int>();
            for (var num = expectedExtension.Length - 1; num >= 0; num--)
                if (expectedExtension[num] == '.')
                    list.Add(num);

            var list2 = new List<int>();
            for (var num2 = Path.GetFileName(fileName).Length - 1; num2 >= 0; num2--)
                if (fileName[num2] == '.')
                    list2.Add(num2);

            if (list2.Count - list.Count < 1) return false;

            var num3 = list2[list.Count];
            ref var reference = ref fileName;
            var num4 = num3 + 1;
            if (reference.Slice(num4, reference.Length - num4)
                .Equals(expectedExtension, StringComparison.Ordinal)) return true;

            if (warningAlreadySent) return false;

            if (list2.Count - 1 - list.Count < 1) return false;

            num3 = list2[list.Count + 1];
            var num5 = list2[0];
            num4 = num3 + 1;
            var span = fileName.Slice(num4, num5 - num4);
            reference = ref fileName;
            num4 = num5 + 1;
            var span2 = reference.Slice(num4, reference.Length - num4);
            if (span.Equals(expectedExtension, StringComparison.Ordinal))
            {
                reference = ref expectedExtension;
                num4 = list[0];
                var other = reference.Slice(num4, reference.Length - num4);
                if (span2.Equals(other, StringComparison.Ordinal))
                {
                    Diagnostics.Warning("Content",
                        "\"" + filePath.ToString() + "\" has a doubled extension! It may not be handled correctly.");
                    warningAlreadySent = true;
                }
                else if (span2.Equals("txt", StringComparison.Ordinal))
                {
                    Diagnostics.Warning("Content",
                        "\"" + filePath.ToString() +
                        "\" has an extra \".txt\" extension! It may not be handled correctly.");
                    warningAlreadySent = true;
                }
            }

            return false;
        }
    }
}
