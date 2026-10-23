using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Game.Execution;
using Celeste.Localization.Languages;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        public DialogLanguage ReadLanguageText(string filename)
        {
            return OriginalDialogLanguageCodec.FromTxt(filename, languageTextures);
        }

        public void CheckCharacters()
        {
            var files =
                Directory.GetFiles(
                    Path.Combine(EngineRuntime.ContentDirectory,
                        "Dialog"), "*.txt", SearchOption.AllDirectories);
            foreach (var text in files)
            {
                var hashSet = new HashSet<int>();
                foreach (var item in File.ReadLines(text, Encoding.UTF8))
                    for (var j = 0; j < item.Length; j++)
                        if (!hashSet.Contains(item[j]))
                            hashSet.Add(item[j]);

                var list = new List<int>();
                foreach (var item2 in hashSet) list.Add(item2);

                list.Sort();
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("chars=");
                var num = 0;
                Console.WriteLine("Characters of : " + text);
                int num2;
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    var flag = false;
                    int k;
                    for (k = num2 + 1; k < list.Count && list[k] == list[k - 1] + 1; k++) flag = true;

                    if (flag)
                        stringBuilder.Append(list[num2] + "-" + list[k - 1] + ",");
                    else
                        stringBuilder.Append(list[num2] + ",");

                    num2 = k - 1;
                    num++;
                    if (num >= 10)
                    {
                        num = 0;
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        Console.WriteLine(stringBuilder.ToString());
                        stringBuilder.Clear();
                        stringBuilder.Append("chars=");
                    }
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                Console.WriteLine(stringBuilder.ToString());
                Console.WriteLine();
            }
        }

        public bool CheckLanguageFontCharacters(string a)
        {
            var language = Dialog.Languages[a];
            var result = true;
            var hashSet = new HashSet<int>();
            foreach (var item in language.Dialog)
                for (var i = 0; i < item.Value.Length; i++)
                {
                    int num = item.Value[i];
                    if (!hashSet.Contains(num) &&
                        !Fonts.Get(language.FontFace).Get(language.FontFaceSize).Characters.ContainsKey(num))
                    {
                        hashSet.Add(num);
                        result = false;
                    }
                }

            Console.WriteLine("FONT: " + a);
            if (hashSet.Count > 0) Console.WriteLine(" - Missing Characters: " + string.Join(",", hashSet));

            Console.WriteLine(" - OK: " + result);
            Console.WriteLine();
            if (hashSet.Count > 0)
            {
                var text = "";
                foreach (var item2 in hashSet) text += (char)item2;

                File.WriteAllText(a + "-missing-debug.txt", text);
            }

            return result;
        }

        public bool CompareLanguages(string a, string b, bool compareContent)
        {
            Console.WriteLine("COMPARE: " + a + " -> " + b);
            var language = Dialog.Languages[a];
            var language2 = Dialog.Languages[b];
            var result = true;
            var list = new List<string>();
            var list2 = new List<string>();
            var list3 = new List<string>();
            foreach (var item in language.Dialog)
                if (!language2.Dialog.ContainsKey(item.Key))
                {
                    list2.Add(item.Key);
                    result = false;
                }
                else if (compareContent && language2.Dialog[item.Key] != language.Dialog[item.Key])
                {
                    list3.Add(item.Key);
                    result = false;
                }

            foreach (var item2 in language2.Dialog)
                if (!language.Dialog.ContainsKey(item2.Key))
                {
                    list.Add(item2.Key);
                    result = false;
                }

            if (list.Count > 0) Console.WriteLine(" - Missing from " + a + ": " + string.Join(", ", list));

            if (list2.Count > 0) Console.WriteLine(" - Missing from " + b + ": " + string.Join(", ", list2));

            if (list3.Count > 0) Console.WriteLine(" - Diff. Content: " + string.Join(", ", list3));

            var func = delegate(string input)
            {
                var list6 = new List<List<string>>();
                foreach (Match item3 in Regex.Matches(input, "\\{([^}]*)\\}"))
                {
                    var array = Regex.Split(item3.Value, "(\\{|\\}|\\s)");
                    var list7 = new List<string>();
                    var array2 = array;
                    foreach (var text2 in array2)
                        if (!string.IsNullOrWhiteSpace(text2) && text2.Length > 0 && text2 != "{" && text2 != "}")
                            list7.Add(text2);

                    list6.Add(list7);
                }

                return list6;
            };
            foreach (var item4 in language.Dialog)
            {
                if (!language2.Dialog.ContainsKey(item4.Key)) continue;

                var list4 = func(item4.Value);
                var list5 = func(language2.Dialog[item4.Key]);
                var num = 0;
                var num2 = 0;
                for (; num < list4.Count; num++)
                {
                    var text = list4[num][0];
                    if (!(text == "portrait") && !(text == "trigger")) continue;

                    for (; num2 < list5.Count && list5[num2][0] != text; num2++)
                    {
                    }

                    if (num2 >= list5.Count)
                    {
                        Console.WriteLine(" - Command number mismatch in " + item4.Key + " in " + b);
                        result = false;
                        num = list4.Count;
                        continue;
                    }

                    if (text == "portrait")
                    {
                        for (var num3 = 0; num3 < list4[num].Count; num3++)
                            if (list4[num][num3] != list5[num2][num3])
                            {
                                Console.WriteLine(" - Portrait in " + item4.Key + " is incorrect in " + b + " ({" +
                                                  string.Join(" ", list4[num]) + "} vs {" +
                                                  string.Join(" ", list5[num2]) +
                                                  "})");
                                result = false;
                            }
                    }
                    else if (text == "trigger" && list4[num][1] != list5[num2][1])
                    {
                        Console.WriteLine(" - Trigger in " + item4.Key + " is incorrect in " + b + " (" +
                                          list4[num][1] +
                                          " vs " + list5[num2][1] + ")");
                        result = false;
                    }

                    num2++;
                }
            }

            Console.WriteLine(" - OK: " + result);
            Console.WriteLine();
            return result;
        }
    }
}
