using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        public global::Celeste.Localization.Languages.DialogLanguage ReadLanguageText(string filename)
            => OriginalDialogLanguageCodec.FromTxt(filename, languageTextures);

        public void CheckCharacters()
        {
            string[] files =
                Directory.GetFiles(
                    Path.Combine(global::Celeste.Game.Execution.EngineRuntime.ContentDirectory,
                        "Dialog"), "*.txt", SearchOption.AllDirectories);
            foreach (string text in files)
            {
                HashSet<int> hashSet = new HashSet<int>();
                foreach (string item in File.ReadLines(text, Encoding.UTF8))
                {
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (!hashSet.Contains(item[j]))
                        {
                            hashSet.Add(item[j]);
                        }
                    }
                }

                List<int> list = new List<int>();
                foreach (int item2 in hashSet)
                {
                    list.Add(item2);
                }

                list.Sort();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("chars=");
                int num = 0;
                Console.WriteLine("Characters of : " + text);
                int num2;
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    bool flag = false;
                    int k;
                    for (k = num2 + 1; k < list.Count && list[k] == list[k - 1] + 1; k++)
                    {
                        flag = true;
                    }

                    if (flag)
                    {
                        stringBuilder.Append(list[num2] + "-" + list[k - 1] + ",");
                    }
                    else
                    {
                        stringBuilder.Append(list[num2] + ",");
                    }

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
            global::Celeste.Localization.Languages.DialogLanguage language = Dialog.Languages[a];
            bool result = true;
            HashSet<int> hashSet = new HashSet<int>();
            foreach (KeyValuePair<string, string> item in language.Dialog)
            {
                for (int i = 0; i < item.Value.Length; i++)
                {
                    int num = item.Value[i];
                    if (!hashSet.Contains(num) &&
                        !Fonts.Get(language.FontFace).Get(language.FontFaceSize).Characters.ContainsKey(num))
                    {
                        hashSet.Add(num);
                        result = false;
                    }
                }
            }

            Console.WriteLine("FONT: " + a);
            if (hashSet.Count > 0)
            {
                Console.WriteLine(" - Missing Characters: " + string.Join(",", hashSet));
            }

            Console.WriteLine(" - OK: " + result);
            Console.WriteLine();
            if (hashSet.Count > 0)
            {
                string text = "";
                foreach (int item2 in hashSet)
                {
                    text += (char)item2;
                }

                File.WriteAllText(a + "-missing-debug.txt", text);
            }

            return result;
        }

        public bool CompareLanguages(string a, string b, bool compareContent)
        {
            Console.WriteLine("COMPARE: " + a + " -> " + b);
            global::Celeste.Localization.Languages.DialogLanguage language = Dialog.Languages[a];
            global::Celeste.Localization.Languages.DialogLanguage language2 = Dialog.Languages[b];
            bool result = true;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            foreach (KeyValuePair<string, string> item in language.Dialog)
            {
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
            }

            foreach (KeyValuePair<string, string> item2 in language2.Dialog)
            {
                if (!language.Dialog.ContainsKey(item2.Key))
                {
                    list.Add(item2.Key);
                    result = false;
                }
            }

            if (list.Count > 0)
            {
                Console.WriteLine(" - Missing from " + a + ": " + string.Join(", ", list));
            }

            if (list2.Count > 0)
            {
                Console.WriteLine(" - Missing from " + b + ": " + string.Join(", ", list2));
            }

            if (list3.Count > 0)
            {
                Console.WriteLine(" - Diff. Content: " + string.Join(", ", list3));
            }

            Func<string, List<List<string>>> func = delegate(string input)
            {
                List<List<string>> list6 = new List<List<string>>();
                foreach (Match item3 in Regex.Matches(input, "\\{([^}]*)\\}"))
                {
                    string[] array = Regex.Split(item3.Value, "(\\{|\\}|\\s)");
                    List<string> list7 = new List<string>();
                    string[] array2 = array;
                    foreach (string text2 in array2)
                    {
                        if (!string.IsNullOrWhiteSpace(text2) && text2.Length > 0 && text2 != "{" && text2 != "}")
                        {
                            list7.Add(text2);
                        }
                    }

                    list6.Add(list7);
                }

                return list6;
            };
            foreach (KeyValuePair<string, string> item4 in language.Dialog)
            {
                if (!language2.Dialog.ContainsKey(item4.Key))
                {
                    continue;
                }

                List<List<string>> list4 = func(item4.Value);
                List<List<string>> list5 = func(language2.Dialog[item4.Key]);
                int num = 0;
                int num2 = 0;
                for (; num < list4.Count; num++)
                {
                    string text = list4[num][0];
                    if (!(text == "portrait") && !(text == "trigger"))
                    {
                        continue;
                    }

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
                        for (int num3 = 0; num3 < list4[num].Count; num3++)
                        {
                            if (list4[num][num3] != list5[num2][num3])
                            {
                                Console.WriteLine(" - Portrait in " + item4.Key + " is incorrect in " + b + " ({" +
                                                  string.Join(" ", list4[num]) + "} vs {" +
                                                  string.Join(" ", list5[num2]) +
                                                  "})");
                                result = false;
                            }
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
