using Celeste.Everest.Content.Types.Graphics;
using Celeste.Everest.Content.Types.Audio;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Content.Types.Playback;
using Celeste.Everest.Content.Types.Dialogs;
using Celeste.Everest.Content.Types.Modules;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Content.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public string GuessType(string file, out Type type, out string format)
        {
            type = typeof(object);
            format = Path.GetExtension(file) ?? "";
            if (format.Length < 1)
            {
                return file;
            }

            string text = format;
            format = text.Substring(1, text.Length - 1);
            ReadOnlySpan<char> readOnlySpan = file.AsSpan();
            int num = readOnlySpan.LastIndexOf('/') + 1;
            ReadOnlySpan<char> readOnlySpan2 = readOnlySpan.Slice(0, num);
            ref ReadOnlySpan<char> reference = ref readOnlySpan;
            int num2 = num;
            ReadOnlySpan<char> readOnlySpan3 = reference.Slice(num2, reference.Length - num2);
            ReadOnlySpan<char> fileNameWithoutExtension = Path.GetFileNameWithoutExtension(readOnlySpan3);
            bool warningAlreadySent = false;
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

            if (MatchExtension(readOnlySpan, readOnlySpan3, "obj", ref warningAlreadySent, isTextBased: true))
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

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yaml", ref warningAlreadySent, isTextBased: true) &&
                readOnlySpan2.IsEmpty &&
                SpanEqualsAny(fileNameWithoutExtension, "metadata", "multimetadata", "everest"))
            {
                type = typeof(AssetTypeMetadataYaml);
                format = "yml";
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 5).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yml", ref warningAlreadySent, isTextBased: true) &&
                readOnlySpan2.IsEmpty && SpanEquals(fileNameWithoutExtension, "everest"))
            {
                type = typeof(AssetTypeMetadataYaml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "xml", ref warningAlreadySent, isTextBased: true))
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
                    "everestignore", ref warningAlreadySent, isTextBased: true))
            {
                type = typeof(AssetTypeEverestIgnore);
                return "";
            }

            if (readOnlySpan2.StartsWith("Dialog/"))
            {
                if (MatchExtension(readOnlySpan, readOnlySpan3, "txt", ref warningAlreadySent, isTextBased: true))
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

                if (MatchExtension(readOnlySpan, readOnlySpan3, "fnt", ref warningAlreadySent, isTextBased: true))
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
                        isTextBased: true))
                {
                    type = typeof(AssetTypeGUIDs);
                    reference = ref readOnlySpan;
                    return reference.Slice(0, reference.Length - 4).ToString();
                }

                if (MatchMultipartExtension(readOnlySpan, readOnlySpan3, "GUIDs.txt", ref warningAlreadySent,
                        isTextBased: true))
                {
                    type = typeof(AssetTypeGUIDs);
                    reference = ref readOnlySpan;
                    Span<char> span = reference.Slice(0, reference.Length - 4).ToArray();
                    for (int i = 1; i <= 5; i++)
                    {
                        num2 = i;
                        ref char reference2 = ref span[span.Length - num2];
                        int num3 = i;
                        reference2 = char.ToLower(span[span.Length - num3]);
                    }

                    return span.ToString();
                }
            }

            if (OnGuessType != null)
            {
                Delegate[] invocationList = OnGuessType.GetInvocationList();
                for (num2 = 0; num2 < invocationList.Length; num2++)
                {
                    Type type2;
                    string format2;
                    string text2 = ((EverestContentTypeGuesser)invocationList[num2])(file, out type2, out format2);
                    if (text2 != null && !(type2 == null) && format2 != null)
                    {
                        file = text2;
                        type = type2;
                        format = format2;
                        return file;
                    }
                }
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "lua", ref warningAlreadySent, isTextBased: true))
            {
                type = typeof(AssetTypeLua);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "txt", ref warningAlreadySent, isTextBased: true))
            {
                type = typeof(AssetTypeText);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "xml", ref warningAlreadySent, isTextBased: true))
            {
                type = typeof(AssetTypeXml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yml", ref warningAlreadySent, isTextBased: true))
            {
                type = typeof(AssetTypeYaml);
                reference = ref readOnlySpan;
                return reference.Slice(0, reference.Length - 4).ToString();
            }

            if (MatchExtension(readOnlySpan, readOnlySpan3, "yaml", ref warningAlreadySent, isTextBased: true))
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
            foreach (string text in right)
            {
                if (MemoryExtensions.Equals(left, text, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool SpanEquals(ReadOnlySpan<char> left, string right)
        {
            return MemoryExtensions.Equals(left, right, StringComparison.Ordinal);
        }

        private bool MatchExtension(ReadOnlySpan<char> filePath, ReadOnlySpan<char> fileName,
            ReadOnlySpan<char> expectedExtension, ref bool warningAlreadySent, bool isTextBased = false)
        {
            ReadOnlySpan<char> span = Path.GetExtension(fileName);
            if (span.IsEmpty)
            {
                return false;
            }

            ref ReadOnlySpan<char> reference = ref span;
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

            if (warningAlreadySent)
            {
                return false;
            }

            if (isTextBased && MemoryExtensions.Equals(span, "txt", StringComparison.Ordinal))
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
            {
                return MatchExtension(filePath, fileName, expectedExtension, ref warningAlreadySent, isTextBased);
            }

            List<int> list = new List<int>();
            for (int num = expectedExtension.Length - 1; num >= 0; num--)
            {
                if (expectedExtension[num] == '.')
                {
                    list.Add(num);
                }
            }

            List<int> list2 = new List<int>();
            for (int num2 = Path.GetFileName(fileName).Length - 1; num2 >= 0; num2--)
            {
                if (fileName[num2] == '.')
                {
                    list2.Add(num2);
                }
            }

            if (list2.Count - list.Count < 1)
            {
                return false;
            }

            int num3 = list2[list.Count];
            ref ReadOnlySpan<char> reference = ref fileName;
            int num4 = num3 + 1;
            if (reference.Slice(num4, reference.Length - num4).Equals(expectedExtension, StringComparison.Ordinal))
            {
                return true;
            }

            if (warningAlreadySent)
            {
                return false;
            }

            if (list2.Count - 1 - list.Count < 1)
            {
                return false;
            }

            num3 = list2[list.Count + 1];
            int num5 = list2[0];
            num4 = num3 + 1;
            ReadOnlySpan<char> span = fileName.Slice(num4, num5 - num4);
            reference = ref fileName;
            num4 = num5 + 1;
            ReadOnlySpan<char> span2 = reference.Slice(num4, reference.Length - num4);
            if (span.Equals(expectedExtension, StringComparison.Ordinal))
            {
                reference = ref expectedExtension;
                num4 = list[0];
                ReadOnlySpan<char> other = reference.Slice(num4, reference.Length - num4);
                if (span2.Equals(other, StringComparison.Ordinal))
                {
                    Diagnostics.Warning("Content",
                        "\"" + filePath.ToString() + "\" has a doubled extension! It may not be handled correctly.");
                    warningAlreadySent = true;
                }
                else if (MemoryExtensions.Equals(span2, "txt", StringComparison.Ordinal))
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
