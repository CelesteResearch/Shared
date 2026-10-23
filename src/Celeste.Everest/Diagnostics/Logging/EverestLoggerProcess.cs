using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        private readonly IEverestLoggerEnvironment Environment;
        internal TextWriter outWriter;
        internal TextWriter logWriter;
        public bool EarlyBootColorizedLogging;
        private readonly Dictionary<string, EverestLogLevel> minimumLevels = new();
        private readonly Dictionary<string, EverestLogLevel> minimumLevelsFromEverestSettings = new();
        private readonly Dictionary<string, EverestLogLevel> minimumLevelsCache = new();
        private readonly object locker = new();

        public EverestLoggerProcess(IEverestLoggerEnvironment environment)
        {
            Environment = environment;
        }

        private bool ColorizedLogging
        {
            get
            {
                if ((Environment.Settings?.ColorizedLogging ?? EarlyBootColorizedLogging) && outWriter != null)
                    return logWriter != null;
                return false;
            }
        }

        public void PublishColorizedWriters(TextWriter output, TextWriter log)
        {
            outWriter = output;
            logWriter = log;
        }

        public void SetLogLevel(string tagPrefix, EverestLogLevel minimumLevel)
        {
            lock (minimumLevels)
            {
                minimumLevels[tagPrefix] = minimumLevel;
            }

            lock (minimumLevelsCache)
            {
                minimumLevelsCache.Clear();
            }
        }

        internal void SetLogLevelFromSettings(string tagPrefix, EverestLogLevel minimumLevel)
        {
            minimumLevelsFromEverestSettings[tagPrefix] = minimumLevel;
            lock (minimumLevelsCache)
            {
                minimumLevelsCache.Clear();
            }
        }

        public EverestLogLevel GetLogLevel(string tag)
        {
            lock (minimumLevelsCache)
            {
                if (minimumLevelsCache.TryGetValue(tag, out var value)) return value;

                var logLevel = findMatchingLogLevel(minimumLevelsFromEverestSettings, tag);
                if (!logLevel.HasValue)
                    lock (minimumLevels)
                    {
                        logLevel = findMatchingLogLevel(minimumLevels, tag);
                    }

                minimumLevelsCache[tag] = logLevel ?? EverestLogLevel.Info;
                return logLevel ?? EverestLogLevel.Info;
            }
        }

        private EverestLogLevel? findMatchingLogLevel(Dictionary<string, EverestLogLevel> rules, string tag)
        {
            var list = rules.Keys.ToList();
            list.Sort((a, b) => b.CompareTo(a));
            foreach (var item in list)
                if (tag.StartsWith(item))
                    return rules[item];

            return null;
        }

        private bool shouldLog(string tag, EverestLogLevel level)
        {
            return GetLogLevel(tag) <= level;
        }

        public void Log(EverestLogLevel level, string tag, string str)
        {
            if (shouldLog(tag, level)) LogUnchecked(level, tag, str);
        }

        private void LogUnchecked(EverestLogLevel level, string tag, string str)
        {
            lock (locker)
            {
                var value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                var value2 = level.FastToString();
                if (!ColorizedLogging)
                {
                    Environment.ConsoleWriter.WriteLine($"({value}) [Everest] [{value2}] [{tag}] {str}");
                    return;
                }

                var ansiEscapeCodeForLevel = level.GetAnsiEscapeCodeForLevel();
                var ansiEscapeCodeForText = level.GetAnsiEscapeCodeForText();
                outWriter.WriteLine(
                    $"{"\u001b[2m"}({value}) [Everest] {"\u001b[0m"}{ansiEscapeCodeForLevel}[{value2}] [{tag}] {ansiEscapeCodeForText}{str}{"\u001b[0m"}");
                logWriter.WriteLine($"({value}) [Everest] [{value2}] [{tag}] {str}");
                logWriter.Flush();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LogDetailed(EverestLogLevel level, string tag, string str)
        {
            if (!shouldLog(tag, level)) return;

            lock (locker)
            {
                Log(level, tag, str);
                if (!ColorizedLogging)
                {
                    Environment.ConsoleWriter.WriteLine(new StackTrace(1, true).ToString());
                    return;
                }

                var ansiEscapeCodeForText = level.GetAnsiEscapeCodeForText();
                outWriter.WriteLine($"{ansiEscapeCodeForText}{new StackTrace(1, true)}{"\u001b[0m"}");
                logWriter.WriteLine(new StackTrace(1, true).ToString());
                logWriter.Flush();
            }
        }

        public void LogDetailed(Exception e, string tag = null)
        {
            lock (locker)
            {
                if (ColorizedLogging)
                {
                    var ansiEscapeCodeForText = EverestLogLevel.Error.GetAnsiEscapeCodeForText();
                    outWriter.Write(ansiEscapeCodeForText);
                }

                if (tag == null)
                {
                    Environment.ConsoleWriter.WriteLine("--------------------------------");
                    Environment.ConsoleWriter.WriteLine("Detailed exception log:");
                }

                for (var ex = e; ex != null; ex = ex.InnerException)
                {
                    Environment.ConsoleWriter.WriteLine("--------------------------------");
                    Environment.ConsoleWriter.WriteLine(
                        ex.GetType().FullName + ": " + ex.Message + "\n" + ex.StackTrace);
                    if (ex is ReflectionTypeLoadException ex2)
                    {
                        for (var i = 0; i < ex2.Types.Length; i++)
                            Environment.ConsoleWriter.WriteLine("ReflectionTypeLoadException.Types[" + i + "]: " +
                                                                ex2.Types[i]);

                        for (var j = 0; j < ex2.LoaderExceptions.Length; j++)
                            LogDetailed(ex2.LoaderExceptions[j], tag + (tag == null ? "" : ", ") + "rtle:" + j);
                    }

                    if (ex is TypeLoadException)
                        Environment.ConsoleWriter.WriteLine("TypeLoadException.TypeName: " +
                                                            ((TypeLoadException)ex).TypeName);

                    if (ex is BadImageFormatException)
                        Environment.ConsoleWriter.WriteLine("BadImageFormatException.FileName: " +
                                                            ((BadImageFormatException)ex).FileName);
                }

                if (ColorizedLogging) outWriter.Write("\u001b[0m");
            }
        }
    }
}
