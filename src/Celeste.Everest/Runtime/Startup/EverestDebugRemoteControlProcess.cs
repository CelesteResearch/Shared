using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Runtime.Threading;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestDebugRemoteControlProcess

    {
        private readonly ISourceEngineContext engine;

        private readonly Action<IntPtr> sdlRaiseWindow;

        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        private EverestCoreSettings Settings => ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;

        private List<SourceEverestModule> Modules => ((ISourceEverestModulesEnvironment)engine).Modules;

        private EverestContentRegistry Content => ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry;

        private IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;

        private OriginalSessionFactory Sessions => ((IOriginalSessionEnvironment)engine).Sessions;

        private IOriginalLevelLoaderFactory LevelLoaders => ((IOriginalLevelLoaderEnvironment)engine).LevelLoaders;

        private SourceEverestCommands Commands =>
            (SourceEverestCommands)((ISourceCommandsProcessEnvironment)engine).Commands;

        private IEverestDebugRemoteControlPhysicalEnvironment Physical =>
            (IEverestDebugRemoteControlPhysicalEnvironment)engine;

        private string GetCurrentSceneAreaSid()

        {
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;

            return level?.Session == null ? null : AreaKeys.GetSID(AreaKeys.GetSessionArea(level.Session));
        }


        private HttpListener Listener;


        public List<EverestDebugRemoteControlEndpoint> EndPoints;
        public Func<string, HttpListenerContext, bool> ConsoleLineInterception;

        public EverestDebugRemoteControlProcess(ISourceEngineContext engine)

        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

            EndPoints =
            [
                new()
                {
                    Path = "/",

                    Name = "Info",

                    InfoHTML = "Basic game info.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        var stringBuilder = new StringBuilder();

                        WriteHTMLStart(c, stringBuilder);

                        stringBuilder.AppendLine("<ul>");

                        stringBuilder.AppendLine("<h2>Game</h2>");

                        var stringBuilder2 = stringBuilder;

                        var stringBuilder3 = stringBuilder2;

                        stringBuilder2.Append("<li><b>Celeste</b> v.");

                        stringBuilder2.Append(((IEverestCelesteVersionEnvironment)engine).CelesteVersion);

                        stringBuilder2.Append("</li>");

                        stringBuilder3.AppendLine();

                        foreach (var module in Modules)

                        {
                            stringBuilder2 = stringBuilder;

                            var stringBuilder4 = stringBuilder2;

                            stringBuilder2.Append("<li><b>");

                            stringBuilder2.Append(module.Metadata.Name);

                            stringBuilder2.Append("</b> v.");

                            stringBuilder2.Append(module.Metadata.VersionString);

                            stringBuilder2.Append("</li>");

                            stringBuilder4.AppendLine();
                        }

                        stringBuilder.AppendLine("</ul>");

                        stringBuilder.AppendLine("<ul id=\"endpoints\">");

                        stringBuilder.AppendLine("<h2>Endpoints</h2>");

                        foreach (var endPoint in EndPoints)

                        {
                            stringBuilder.AppendLine("<li>");

                            stringBuilder2 = stringBuilder;

                            var stringBuilder5 = stringBuilder2;

                            stringBuilder2.Append("<h3>");

                            stringBuilder2.Append(endPoint.Name);

                            stringBuilder2.Append("</h3>");

                            stringBuilder5.AppendLine();

                            stringBuilder2 = stringBuilder;

                            var stringBuilder6 = stringBuilder2;

                            stringBuilder2.Append("<p><a href=\"");

                            stringBuilder2.Append(endPoint.PathExample ?? endPoint.Path);

                            stringBuilder2.Append("\"><code>");

                            stringBuilder2.Append(endPoint.PathHelp ?? endPoint.Path);

                            stringBuilder2.Append("</code></a><br>");

                            stringBuilder2.Append(endPoint.InfoHTML);

                            stringBuilder2.Append("</p>");

                            stringBuilder6.AppendLine();

                            stringBuilder.AppendLine("</li>");
                        }

                        stringBuilder.AppendLine("</ul>");

                        WriteHTMLEnd(c, stringBuilder);

                        Write(c, stringBuilder.ToString());
                    },
                },

                new()
                {
                    Path = "/404",

                    Name = "404",

                    InfoHTML = "Basic 404.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        c.Response.StatusCode = 404;

                        Write(c, "ERROR: Endpoint not found.");
                    },
                },

                new()
                {
                    Path = "/hotswap",

                    Name = "Hotswap",

                    InfoHTML = "Restart the entire game AppDomain real quick.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        Write(c, "OK.");

                        ((IEverestRestartEnvironment)engine).Restart.QuickFullRestart();
                    },
                },

                new()
                {
                    Path = "/coldswap",

                    Name = "Coldswap",

                    InfoHTML = "Restart the entire game process real quick.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        Write(c, "OK.");

                        ((IEverestRestartEnvironment)engine).Restart.SlowFullRestart();
                    },
                },

                new()
                {
                    Path = "/list",

                    PathHelp = "/list?type={mods|modcontent} (Example: ?type=mods)",

                    PathExample = "/list?type=mods",

                    Name = "List Info",

                    InfoHTML = "List some basic info.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        var stringBuilder = new StringBuilder();

                        var nameValueCollection = ParseQueryString(c.Request.RawUrl);

                        var text = nameValueCollection["type"];

                        if (!(text == "mods"))

                        {
                            if (text == "modcontent")

                            {
                                lock (Content.Map)

                                {
                                    foreach (var value in Content.Map.Values)
                                        stringBuilder.AppendLine(value.PathVirtual);
                                }
                            }

                            else

                            {
                                c.Response.StatusCode = 400;

                                var stringBuilder2 = stringBuilder;

                                stringBuilder2.Append("ERROR: Invalid type: ");

                                stringBuilder2.Append(nameValueCollection["type"] ?? "NULL");
                            }
                        }

                        else

                        {
                            lock (Modules)

                            {
                                foreach (var module2 in Modules) stringBuilder.AppendLine(module2.Metadata.Name);
                            }
                        }

                        Write(c, stringBuilder.ToString());
                    },
                },

                new()
                {
                    Path = "/session",

                    Name = "Session Info",

                    InfoHTML = "Basic player session info.",

                    Handle = delegate(HttpListenerContext c)
                    {
                        Write(c,
                            ((IEverestYamlEnvironment)engine).Yaml.Serializer.Serialize(
                                new EverestDebugRemoteControlSessionInfo(engine,
                                    engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)));
                    },
                },

                new()
                {
                    Path = "/focus",

                    Name = "Focus Game",

                    InfoHTML = "Refocus the game window. Doesn't work on Windows 10.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        if (sdlRaiseWindow != null)
                            sdlRaiseWindow(Physical.Window.Handle);

                        else
                            Physical.WindowFocus.SetForegroundWindow(Physical.Window.Handle);

                        Write(c, "OK");
                    },
                },

                new()
                {
                    Path = "/respawn",

                    Name = "Respawn",

                    InfoHTML = "Restart the current screen, respawning the player.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        if (!(engine.Frame.Scenes.CurrentScene is OriginalLevelSceneRoot level))

                        {
                            c.Response.StatusCode = 400;

                            Write(c, "ERROR: Player not in a level.");
                        }

                        else

                        {
                            engine.Frame.Scenes.NextScene =
                                LevelLoaders.CreateLevelLoader(level.Session, level.Session.RespawnPoint);

                            Write(c, "OK");
                        }
                    },
                },

                new()
                {
                    Path = "/reloadmap",

                    PathHelp =
                        "/reloadmap?area={none|SID}&side={none|A|B|C} (Example: ?sid=Celeste/1-ForsakenCity&side=A)",

                    PathExample = "/reloadmap?area=Celeste/1-ForsakenCity&side=A",

                    Name = "Reload Map",

                    InfoHTML = "Reload the map binary. Passing no side will reload all side binaries.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        var nameValueCollection = ParseQueryString(c.Request.RawUrl);

                        var text = WebUtility.UrlDecode(nameValueCollection["area"]);

                        if (string.IsNullOrEmpty(text)) text = GetCurrentSceneAreaSid();

                        if (string.IsNullOrEmpty(text))

                        {
                            c.Response.StatusCode = 400;

                            Write(c, "ERROR: No SID given.");
                        }

                        else

                        {
                            var areaData = AreaKeys.GetAreaBySID(text);

                            if (areaData == null)

                            {
                                c.Response.StatusCode = 400;

                                Write(c, "ERROR: Chapter not found: " + text);
                            }

                            else

                            {
                                var text2 = nameValueCollection["side"];

                                if (string.IsNullOrEmpty(text2))

                                {
                                    var mode = areaData.Mode;

                                    for (var i = 0; i < mode.Length; i++) mode[i]?.MapData?.Reload();

                                    Write(c, "OK");
                                }

                                else

                                {
                                    var num = text2.Length != 1 ? -1 : text2.ToLowerInvariant()[0] - 97;

                                    if (num < 0 || areaData.Mode.Length <= num)

                                    {
                                        c.Response.StatusCode = 400;

                                        Write(c, "ERROR: Invalid side value.");
                                    }

                                    else if (areaData.Mode[num] == null)

                                    {
                                        c.Response.StatusCode = 400;

                                        Write(c, $"ERROR: Area {text} doesn't have side {(char)(ushort)(65 + num)}.");
                                    }

                                    else

                                    {
                                        areaData.Mode[num].MapData.Reload();

                                        Write(c, "OK");
                                    }
                                }
                            }
                        }
                    },
                },

                new()
                {
                    Path = "/tp",

                    PathHelp =
                        "/tp?area={none|SID}&side={none|A|B|C}&level={LVL}&x={none|X}&y={none|Y}&forcenew={*|true} (Example: ?area=Celeste/1-ForsakenCity&side=A&level=8zb)",

                    PathExample = "/tp?area=Celeste/1-ForsakenCity&side=A&level=8zb",

                    Name = "Teleport To Map",

                    InfoHTML =
                        "Teleport the player to the given level, reusing the session if possible. Set <code>forcenew=true</code> to start a new session.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        var nameValueCollection = ParseQueryString(c.Request.RawUrl);

                        if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave == null)
                            ((IOriginalSaveDebugEnvironment)engine).SaveDebug.InitializeDebugMode(
                                ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage,
                                (IOriginalSaveInitializationServices)engine);

                        var session =
                            (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Session;

                        var result = 0f;

                        var result2 = 0f;

                        var flag =
                            float.TryParse(nameValueCollection["x"], NumberStyles.Float, CultureInfo.InvariantCulture,
                                out result) && float.TryParse(nameValueCollection["y"], NumberStyles.Float,
                                CultureInfo.InvariantCulture, out result2);

                        var levelName = nameValueCollection["level"];

                        if (levelName != null && levelName.StartsWith("lvl_")) levelName = levelName.Substring(4);

                        if (string.IsNullOrEmpty(nameValueCollection["area"]) &&
                            string.IsNullOrEmpty(nameValueCollection["side"]) && flag)

                        {
                            if (session == null)

                            {
                                c.Response.StatusCode = 400;

                                Write(c, "ERROR: In-level (x-y-only) tp outside of level.");
                            }

                            else

                            {
                                var player =
                                    ((ISourceScene)(engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot))
                                    ?.SourceScene.Entities
                                    .GetTrackedEntity<RoomPlayerSession>(
                                        typeof(RoomPlayerSession).FullName);

                                var flag2 = false;

                                if (!string.IsNullOrEmpty(levelName) && session.Level != levelName)

                                {
                                    if (((OriginalChapterMapData)session.MapData).Levels.FirstOrDefault(lvl =>
                                            lvl.Name == levelName) == null)

                                    {
                                        c.Response.StatusCode = 400;

                                        Write(c,
                                            $"ERROR: Area {AreaKeys.GetSID(AreaKeys.GetSessionArea(session))} side {(char)(ushort)(65 + AreaKeys.GetSessionArea(session).Mode)} doesn't have level {levelName}");

                                        return;
                                    }

                                    session.Level = levelName;

                                    flag2 = true;
                                }

                                var vector = ((OriginalLevelRoomData)session.LevelData).Position +
                                             new Vector2(result, result2);

                                session.RespawnPoint = vector;

                                player.Position = vector;

                                if (flag2)

                                {
                                    ((SourceSceneState)engine.Frame.Scenes.CurrentScene).Paused = true;

                                    engine.Frame.Scenes.NextScene = LevelLoaders.CreateLevelLoader(session, vector);
                                }

                                Write(c, "OK");
                            }
                        }

                        else

                        {
                            var text = WebUtility.UrlDecode(nameValueCollection["area"]);

                            if (string.IsNullOrEmpty(text)) text = AreaKeys.GetSID(AreaKeys.GetSessionArea(session));

                            if (string.IsNullOrEmpty(text))

                            {
                                c.Response.StatusCode = 400;

                                Write(c, "ERROR: No SID given.");
                            }

                            else

                            {
                                var areaData = AreaKeys.GetAreaBySID(text);

                                if (areaData == null)

                                {
                                    c.Response.StatusCode = 400;

                                    Write(c, "ERROR: Chapter not found: " + text);
                                }

                                else

                                {
                                    var text2 = nameValueCollection["side"];

                                    int num;

                                    if (!string.IsNullOrEmpty(text2))

                                    {
                                        num = text2.Length != 1 ? -1 : text2.ToLowerInvariant()[0] - 97;

                                        if (num < 0 || areaData.Mode.Length <= num)

                                        {
                                            c.Response.StatusCode = 400;

                                            Write(c, "ERROR: Invalid side value.");

                                            return;
                                        }
                                    }

                                    else

                                    {
                                        if (session == null)

                                        {
                                            c.Response.StatusCode = 400;

                                            Write(c, "ERROR: No side given.");

                                            return;
                                        }

                                        num = AreaKeys.GetSessionArea(session).Mode;
                                    }

                                    if (string.IsNullOrEmpty(levelName))

                                    {
                                        c.Response.StatusCode = 400;

                                        Write(c, "ERROR: No level given.");
                                    }

                                    else

                                    {
                                        var modeProperties = areaData.Mode[num];

                                        if (modeProperties == null)

                                        {
                                            c.Response.StatusCode = 400;

                                            Write(c,
                                                $"ERROR: Area {text} doesn't have side {(char)(ushort)(65 + num)}.");
                                        }

                                        else

                                        {
                                            var levelData =
                                                modeProperties.MapData.Levels
                                                    .FirstOrDefault(lvl =>
                                                        lvl.Name == levelName);

                                            if (levelData == null)

                                            {
                                                c.Response.StatusCode = 400;

                                                Write(c,
                                                    $"ERROR: Area {text} side {(char)(ushort)(65 + num)} doesn't have level {levelName}");
                                            }

                                            else

                                            {
                                                if (session == null ||
                                                    AreaKeys.GetSID(AreaKeys.GetSessionArea(session)) != text ||
                                                    AreaKeys.GetSessionArea(session).Mode != num ||
                                                    nameValueCollection["forcenew"]?.ToLowerInvariant() == "true")
                                                    session = Sessions.CreateSession(AreaKeys.ToKey(areaData, num),
                                                        levelData.Name);

                                                session.Level = levelName;

                                                if (flag)
                                                    session.RespawnPoint =
                                                        levelData.Position + new Vector2(result, result2);

                                                else
                                                    session.RespawnPoint = null;

                                                engine.Frame.Scenes.NextScene =
                                                    LevelLoaders.CreateLevelLoader(session, session.RespawnPoint);

                                                Write(c, "OK");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                },

                new()
                {
                    Path = "/console",

                    Name = "Console",

                    PathHelp = "/console?command={*|COMMAND} (Example: ?command=berries)",

                    PathExample = "/console?command=berries",

                    InfoHTML =
                        "Execute a console command and show the output. If no command is given, list the available commands.",

                    Handle = delegate(HttpListenerContext c)

                    {
                        var text = WebUtility.UrlDecode(ParseQueryString(c.Request.RawUrl)["command"]);

                        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text.Replace(",", "")))

                        {
                            var stringBuilder = new StringBuilder();

                            WriteHTMLStart(c, stringBuilder);

                            stringBuilder.AppendLine("<ul>");

                            stringBuilder.AppendLine("<h2>Commands</h2>");

                            foreach (var item in from comm in Commands.GetCommands()
                                     orderby comm.Name
                                     select comm)

                            {
                                stringBuilder.AppendLine("<li>");

                                var stringBuilder2 = stringBuilder;

                                var stringBuilder3 = stringBuilder2;

                                stringBuilder2.Append("<h3>");

                                stringBuilder2.Append(item.Name);

                                stringBuilder2.Append("</h3>");

                                stringBuilder3.AppendLine();

                                stringBuilder.AppendLine("<p>");

                                if (string.IsNullOrEmpty(item.Usage))

                                {
                                    stringBuilder2 = stringBuilder;

                                    var stringBuilder4 = stringBuilder2;

                                    stringBuilder2.Append("<a href=\"");

                                    stringBuilder2.Append(Listener.Prefixes.First());

                                    stringBuilder2.Append("console?command=");

                                    stringBuilder2.Append(item.Name);

                                    stringBuilder2.Append("\"><code>/console?command=");

                                    stringBuilder2.Append(item.Name);

                                    stringBuilder2.Append("</code></a>");

                                    stringBuilder4.AppendLine();
                                }

                                else

                                {
                                    stringBuilder2 = stringBuilder;

                                    var stringBuilder5 = stringBuilder2;

                                    stringBuilder2.Append("<code>Usage: ");

                                    stringBuilder2.Append(item.Usage);

                                    stringBuilder2.Append("</code>");

                                    stringBuilder5.AppendLine();
                                }

                                stringBuilder.AppendLine("<br>");

                                stringBuilder.AppendLine(item.Help);

                                stringBuilder.AppendLine("</p>");

                                stringBuilder.AppendLine("</li>");
                            }

                            stringBuilder.AppendLine("</ul>");

                            WriteHTMLEnd(c, stringBuilder);

                            Write(c, stringBuilder.ToString());
                        }

                        else

                        {
                            if (ConsoleLineInterception?.Invoke(text, c) == true) return;
                            var commandAndArgs =
                                text.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);

                            var args = new string[commandAndArgs.Length - 1];

                            Array.Copy(commandAndArgs, 1, args, 0, args.Length);

                            var output = new StringBuilder();

                            ((ISourceEverestMainThreadEnvironment)engine).MainThreadProcess.Schedule(delegate

                            {
                                try

                                {
                                    Commands.debugRClog = output;

                                    Commands.ExecuteCommand(commandAndArgs[0].ToLower(), args);
                                }

                                finally

                                {
                                    Commands.debugRClog = null;
                                }
                            }).AsTask().Wait();

                            Write(c, output.ToString());
                        }
                    },
                },
            ];


            sdlRaiseWindow = Physical.WindowFocus.SdlRaiseWindow;
        }


        public void Initialize()

        {
            if (Listener != null ||
                ((IOriginalGamePlayModeEnvironment)engine).PlayMode != GameRuntime.PlayModes.Debug ||
                Settings.DebugRCPort <= 0)
                return;

            try

            {
                Listener = new();

                Listener.Prefixes.Add($"http://localhost:{Settings.DebugRCPort}/");

                Listener.Start();
            }

            catch (Exception e)

            {
                Logger.LogDetailed(e);

                try

                {
                    Listener?.Stop();

                    return;
                }

                catch

                {
                    return;
                }
            }

            ThreadPool.QueueUserWorkItem(delegate

            {
                var text = "debugrc";

                var tag = text;

#pragma warning disable CS0168, CS0219
                bool shouldLog;

#pragma warning restore CS0168, CS0219
                var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Info);

                if (sourceLog1.ShouldLog)
                    sourceLog1.Write("Started DebugRC thread, available via http://localhost:" +
                                     Settings.DebugRCPort +
                                     "/");

                try

                {
                    while (Listener.IsListening)
                        ThreadPool.QueueUserWorkItem(delegate(object c)

                        {
                            var httpListenerContext = c as HttpListenerContext;

                            try

                            {
                                using (httpListenerContext.Request.InputStream)

                                {
                                    using (httpListenerContext.Response)

                                    {
                                        HandleRequest(httpListenerContext);
                                    }
                                }
                            }

                            catch (ThreadAbortException)

                            {
                                throw;
                            }

                            catch (ThreadInterruptedException)

                            {
                                throw;
                            }

                            catch (Exception value2)

                            {
                                const string tag4 = "debugrc";

#pragma warning disable CS0168, CS0219
                                bool shouldLog2;

#pragma warning restore CS0168, CS0219
                                var sourceLog2 = Logger.BeginEnabledMessage(tag4, EverestLogLevel.Error);

                                if (sourceLog2.ShouldLog) sourceLog2.Write("DebugRC failed responding: " + value2);
                            }
                        }, Listener.GetContext());
                }

                catch (ThreadAbortException)

                {
                    throw;
                }

                catch (ThreadInterruptedException)

                {
                    throw;
                }

                catch (HttpListenerException ex3)

                {
                    if (ex3.ErrorCode != 500 && ex3.ErrorCode != 995)

                    {
                        text = "debugrc";

                        var tag2 = text;

                        var sourceLog3 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Error);

                        if (sourceLog3.ShouldLog)
                            sourceLog3.Write("DebugRC failed listening (" + ex3.ErrorCode + "): " + ex3);
                    }
                }

                catch (Exception value)

                {
                    text = "debugrc";

                    var tag3 = text;

                    var sourceLog4 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Error);

                    if (sourceLog4.ShouldLog) sourceLog4.Write("DebugRC failed listening: " + value);
                }
            });
        }


        public void Shutdown()

        {
            Listener?.Abort();

            Listener = null;
        }


        private void HandleRequest(HttpListenerContext c)

        {
            const string tag = "debugrc";

#pragma warning disable CS0168, CS0219
            bool shouldLog;

#pragma warning restore CS0168, CS0219
            var sourceLog5 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Verbose);

            if (sourceLog5.ShouldLog) sourceLog5.Write("Requested: " + c.Request.RawUrl);

            var url = c.Request.RawUrl;

            var num = url.IndexOf('?');

            if (num != -1) url = url.Substring(0, num);

            (EndPoints.FirstOrDefault(ep => ep.Path == c.Request.RawUrl) ??
             EndPoints.FirstOrDefault(ep => ep.Path == url) ??
             EndPoints.FirstOrDefault(ep =>
                 ep.Path.ToLowerInvariant() == c.Request.RawUrl.ToLowerInvariant()) ??
             EndPoints.FirstOrDefault(ep =>
                 ep.Path.ToLowerInvariant() == url.ToLowerInvariant()) ??
             EndPoints.FirstOrDefault(ep => ep.Path == "/404")).Handle(c);
        }


        public NameValueCollection ParseQueryString(string url)

        {
            var nameValueCollection = new NameValueCollection();

            var num = url.IndexOf('?');

            if (num == -1) return nameValueCollection;

            url = url.Substring(num + 1);

            var array = url.Split('&');

            foreach (var text in array)

            {
                num = text.IndexOf('=');

                if (num != -1) nameValueCollection[text.Substring(0, num)] = text.Substring(num + 1);
            }

            return nameValueCollection;
        }


        public void WriteHTMLStart(HttpListenerContext c, StringBuilder builder)

        {
            builder.Append(
                "<!DOCTYPE html>\n<html>\n    <head>\n        <meta charset=\"utf-8\" />\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, user-scalable=no\" />\n        <title>Everest DebugRC</title>\n        <style>\n\n@font-face {\n    font-family: Renogare;\n    src:\n    url(\"https://everestapi.github.io/fonts/Renogare-Regular.woff\") format(\"woff\"),\n    url(\"https://everestapi.github.io/fonts/Renogare-Regular.otf\") format(\"opentype\");\n}\n\nbody {\n    color: rgba(0, 0, 0, 0.87);\n    font-family: sans-serif;\n    padding: 0;\n    margin: 0;\n    line-height: 1.5em;\n}\n\nheader {\n    background: #3b2d4a;\n    color: white;\n    font-family: Renogare, sans-serif;\n    font-size: 32px;\n    position: sticky;\n    top: 0;\n    left: 0;\n    right: 0;\n    height: 64px;\n    line-height: 64px;\n    padding: 8px 48px;\n    z-index: 100;\n}\n\n#main {\n    position: relative;\n    margin: 8px;\n    min-height: 100vh;\n}\n\n#endpoints li h3 {\n    margin-bottom: 0;\n}\n#endpoints li p {\n    margin-top: 0;\n}\n\n        </style>\n    </head>\n    <body>\n\n\n");

            builder.AppendLine("<header>Everest DebugRC Server</header>");

            builder.AppendLine("<div id=\"main\">");
        }


        public void WriteHTMLEnd(HttpListenerContext c, StringBuilder builder)

        {
            builder.AppendLine("</div>");

            builder.Append("\n\n    </body>\n</html>\n");
        }


        public void Write(HttpListenerContext c, string str)

        {
            var bytes = Encoding.UTF8.GetBytes(str);

            c.Response.ContentLength64 = bytes.Length;

            c.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
    }
}
