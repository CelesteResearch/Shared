using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Celeste.Simulation.Diagnostics.Console
{
    // =============================================================================================
    // Port of Monocle.Commands (Artifacts/Reference/Original/Monocle/Commands.cs), the console the
    // original opens with ` or OEM8 and drives from Engine.Update (Monocle/Engine.cs:270-277).
    //
    // Structure is kept 1:1 - same fields, same order of operations, same quirks - with the four
    // ambient XNA/Monocle dependencies replaced by injected ones:
    //
    //   Monocle                                   here
    //   ---------------------------------------   --------------------------------------------------
    //   Keyboard.GetState() / Keys enum           Update(IReadOnlyCollection<int>, dt) with XNA key
    //                                             codes, the code space this repo already uses
    //                                             (Assets/Runtime/ModernControls.Keys.cs:11-173)
    //   Engine.DeltaTime                          dt parameter
    //   Draw.DefaultFont.MeasureString            MeasureText delegate (host font)
    //   Engine.Instance.Window.ClientBounds       ViewWidth / ViewHeight
    //   Engine.Commands.Log                       DebugConsole.Console ambient static
    //   Engine.Scene / SaveData.Instance          IDebugConsoleWorld (see DebugConsoleWorld.cs)
    //
    // The command table itself is DebugConsoleCommands.cs, scanned exactly like
    // Monocle/Commands.cs:603-740 ProcessMethod does it.
    // =============================================================================================
    public sealed class DebugConsole
    {
        // Monocle/Commands.cs:41-47.
        public const float UnderScoreTime = 0.5f;
        public const float RepeatDelay = 0.5f;
        public const float RepeatEvery = 1f / 30f;
        public const float Opacity = 0.8f;

        // XNA Keys values this port needs (ModernControls.Keys.cs key table).
        public const int KeyBack = 8, KeyTab = 9, KeyEnter = 13, KeySpace = 32, KeyDelete = 46;
        public const int KeyUp = 38, KeyDown = 40;
        public const int KeyD0 = 48, KeyD9 = 57;
        public const int KeyF1 = 112, KeyF12 = 123;
        public const int KeyLeftShift = 160, KeyRightShift = 161;
        public const int KeyOemSemicolon = 186, KeyOemPlus = 187, KeyOemComma = 188, KeyOemMinus = 189;
        public const int KeyOemPeriod = 190, KeyOemQuestion = 191, KeyOemTilde = 192;
        public const int KeyOemOpenBrackets = 219, KeyOemBackslash = 226, KeyOemCloseBrackets = 221;
        public const int KeyOemQuotes = 222, KeyOem8 = 223;

        private struct CommandInfo
        {
            public Action<string[]> Action;
            public string Help;
            public string Usage;
        }

        // Monocle/Commands.cs:49-83.
        public bool Enabled = true;
        public bool Open;

        // The console owns its own instance here instead of the original's Engine.Commands static;
        // the ambient static that the command table logs through is Console below.
        private readonly Dictionary<string, CommandInfo> commands = new(StringComparer.Ordinal);

        private readonly List<string> sorted = [];
        private HashSet<int> currentKeys = [];

        private string currentText = "";

        private readonly List<DebugConsoleLine> drawCommands = [];

        private bool underscore;

        private float underscoreCounter;
        private readonly List<string> commandHistory = [];

        private string executingEnteredLine;
        private int seekIndex = -1;
        private int tabIndex = -1;
        private string tabSearch;
        private float repeatCounter;
        private int? repeatKey;
        private bool canOpen;

        public Action[] FunctionKeyActions { get; } = new Action[12];

        // Everest's Commands patch reads Core ButtonBinding edges to open, and
        // the ToggleDebugConsole keyboard list to close while accepting text.
        public Func<bool> OpenBindingPressed;
        public Func<int, bool> ToggleKeyContains;

        // Host-supplied ambience (the Draw.DefaultFont / Engine.Instance.Window analogues).
        public Func<string, float> MeasureText;
        public int ViewWidth = 1920;
        public int ViewHeight = 1080;

        // Engine.Commands (used by Celeste/Commands.cs to log) and the world the commands act on.
        public static DebugConsole Console { get; private set; }
        public static event Action<DebugConsole> Created;
        public IDebugConsoleWorld World { get; private set; }

        public DebugConsole(IDebugConsoleWorld world = null)
        {
            World = world;
            Console = this;
            BuildCommandsList();
            Created?.Invoke(this);
        }

        public IReadOnlyList<DebugConsoleLine> Lines => drawCommands;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public string CurrentText => currentText;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool UnderscoreVisible => underscore;
        public IReadOnlyList<string> CommandNames => sorted;

        // Monocle command extensions (CelesteTAS playtas/EvalLua/Invoke/Set) read
        // commandHistory[0], preserving separators and paths containing spaces.
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public string EnteredCommandLine => executingEnteredLine;

        // ---------------------------------------------------------------------------------------
        // Logging and wrapping - Monocle/Commands.cs:95-140.
        // ---------------------------------------------------------------------------------------
        public void Log(object obj, Vector4 color)
        {
            var text = obj == null ? "" : obj.ToString();
            if (text.Contains("\n"))
            {
                foreach (var part in text.Split('\n')) Log(part, color);
                return;
            }

            // Draw.DefaultFont.MeasureString(text).X against Window.ClientBounds.Width - 40.
            var limit = ViewWidth - 40;
            if (MeasureText != null)
                while (MeasureText(text) > limit)
                {
                    var breakAt = -1;
                    for (var j = 0; j < text.Length; j++)
                    {
                        if (text[j] != ' ') continue;
                        if (!(MeasureText(text.Substring(0, j)) <= limit)) break;
                        breakAt = j;
                    }

                    if (breakAt == -1) break;
                    drawCommands.Insert(0,
                        new(text.Substring(0, breakAt),
                            color));
                    text = text.Substring(breakAt + 1);
                }

            drawCommands.Insert(0, new(text, color));
            var maxLines = (ViewHeight - 100) / 30;
            while (drawCommands.Count > maxLines) drawCommands.RemoveAt(drawCommands.Count - 1);
        }

        public void Log(object obj)
        {
            Log(obj, DebugConsoleColors.White);
        }

        public void Clear()
        {
            drawCommands.Clear();
        }

        // ---------------------------------------------------------------------------------------
        // Per-frame entry point. Monocle/Engine.cs:270-277 chose between UpdateOpen/UpdateClosed;
        // the edge state (oldState/currentState) is derived here because the host hands over the
        // frame's held-key set instead of an XNA KeyboardState.
        // ---------------------------------------------------------------------------------------
        public void Update(IReadOnlyCollection<int> heldKeys, float deltaTime)
        {
            var held = heldKeys == null || heldKeys.Count == 0 ? new HashSet<int>() : new HashSet<int>(heldKeys);
            // `oldState = currentState; currentState = Keyboard.GetState();` (Monocle/Commands.cs:164-165):
            // the edge test compares against the frame that just ended.
            var previous = currentKeys;
            currentKeys = held;
            // Monocle/Commands.cs:151 sets currentState at the moment the console opens, so the
            // opening keystroke is not replayed into the command line on the next frame.
            if (Open) UpdateOpen(previous, deltaTime);
            else if (Enabled) UpdateClosed(previous);
        }

        private static bool Pressed(HashSet<int> previous, HashSet<int> current, int key)
        {
            return current.Contains(key) && !previous.Contains(key);
        }

        // Monocle/Commands.cs:142-160.
        private void UpdateClosed(HashSet<int> previous)
        {
            if (!canOpen) canOpen = true;
            else if (OpenBindingPressed?.Invoke() ??
                     (Pressed(previous, currentKeys, KeyOemTilde) || Pressed(previous, currentKeys, KeyOem8)))
                Open = true;

            for (var i = 0; i < FunctionKeyActions.Length; i++)
                if (Pressed(previous, currentKeys, KeyF1 + i))
                    ExecuteFunctionKeyAction(i);
        }

        // Monocle/Commands.cs:162-197.
        private void UpdateOpen(HashSet<int> previous, float deltaTime)
        {
            underscoreCounter += deltaTime;
            while (underscoreCounter >= UnderScoreTime)
            {
                underscoreCounter -= UnderScoreTime;
                underscore = !UnderscoreVisible;
            }

            if (repeatKey.HasValue)
            {
                if (currentKeys.Contains(repeatKey.Value))
                {
                    repeatCounter += deltaTime;
                    while (repeatCounter >= RepeatDelay)
                    {
                        HandleKey(repeatKey.Value);
                        repeatCounter -= RepeatEvery;
                    }
                }
                else
                {
                    repeatKey = null;
                }
            }

            // `foreach (Keys key in currentState.GetPressedKeys()) if (oldState[key] == Up) { HandleKey(key); break; }`
            foreach (var key in currentKeys.OrderBy(k => k))
                if (!previous.Contains(key))
                {
                    HandleKey(key);
                    break;
                }
        }

        // Monocle/Commands.cs:199-514. The XNA Keys switch is reproduced with the same key codes;
        // the single-character fallback (`key.ToString().Length == 1`, i.e. the letters) is the
        // 65..90 range.
        private void HandleKey(int key)
        {
            if (key == 27 || (ToggleKeyContains?.Invoke(key) ??
                              (key == KeyOemTilde || key == KeyOem8)))
            {
                Open = canOpen = false;
                return;
            }

            var shift = currentKeys.Contains(KeyLeftShift) || currentKeys.Contains(KeyRightShift);
            if (key != KeyTab && key != KeyLeftShift && key != KeyRightShift && key != 164 && key != 165 &&
                key != 162 && key != 163)
                tabIndex = -1;
            if (key != KeyOemTilde && key != KeyOem8 && key != KeyEnter && repeatKey != key)
            {
                repeatKey = key;
                repeatCounter = 0f;
            }

            switch (key)
            {
                case 49:
                    currentText += shift ? "!" : "1";
                    return;
                case 50:
                    currentText += shift ? "@" : "2";
                    return;
                case 51:
                    currentText += shift ? "#" : "3";
                    return;
                case 52:
                    currentText += shift ? "$" : "4";
                    return;
                case 53:
                    currentText += shift ? "%" : "5";
                    return;
                case 54:
                    currentText += shift ? "^" : "6";
                    return;
                case 55:
                    currentText += shift ? "&" : "7";
                    return;
                case 56:
                    currentText += shift ? "*" : "8";
                    return;
                case 57:
                    currentText += shift ? "(" : "9";
                    return;
                case 48:
                    currentText += shift ? ")" : "0";
                    return;
                case KeyOemComma:
                    currentText += shift ? "<" : ",";
                    return;
                case KeyOemPeriod:
                    currentText += shift ? ">" : ".";
                    return;
                case KeyOemQuestion:
                    currentText += shift ? "?" : "/";
                    return;
                case KeyOemSemicolon:
                    currentText += shift ? ":" : ";";
                    return;
                case KeyOemQuotes:
                    currentText += shift ? "\"" : "'";
                    return;
                case KeyOemBackslash:
                    currentText += shift ? "|" : "\\";
                    return;
                case KeyOemOpenBrackets:
                    currentText += shift ? "{" : "[";
                    return;
                case KeyOemCloseBrackets:
                    currentText += shift ? "}" : "]";
                    return;
                case KeyOemMinus:
                    currentText += shift ? "_" : "-";
                    return;
                case KeyOemPlus:
                    currentText += shift ? "+" : "=";
                    return;
                case KeySpace:
                    currentText += " ";
                    return;
                case KeyBack:
                    if (CurrentText.Length > 0) currentText = CurrentText.Substring(0, CurrentText.Length - 1);
                    return;
                case KeyDelete:
                    currentText = "";
                    return;
                case KeyUp:
                    if (seekIndex < commandHistory.Count - 1)
                    {
                        seekIndex++;
                        currentText = commandHistory[seekIndex];
                    }

                    return;
                case KeyDown:
                    if (seekIndex > -1)
                    {
                        seekIndex--;
                        if (seekIndex == -1)
                        {
                            currentText = "";
                            return;
                        }

                        currentText = commandHistory[seekIndex];
                    }

                    return;
                case KeyTab:
                    HandleTab(shift);
                    return;
                case 112:
                case 113:
                case 114:
                case 115:
                case 116:
                case 117:
                case 118:
                case 119:
                case 120:
                case 121:
                case 122:
                case 123:
                    ExecuteFunctionKeyAction(key - KeyF1);
                    return;
                case KeyEnter:
                    if (CurrentText.Length > 0) EnterCommand();
                    return;
            }

            // `if (key.ToString().Length == 1)` - the only one-character XNA Keys names are A..Z.
            if (key >= 65 && key <= 90) currentText += shift ? ((char)key).ToString() : ((char)(key + 32)).ToString();
        }

        // Monocle/Commands.cs:443-477.
        private void HandleTab(bool shift)
        {
            if (shift)
            {
                if (tabIndex == -1)
                {
                    tabSearch = CurrentText;
                    FindLastTab();
                }
                else
                {
                    tabIndex--;
                    if (tabIndex < 0 || (tabSearch != "" &&
                                         sorted[tabIndex].IndexOf(tabSearch, StringComparison.Ordinal) != 0))
                        FindLastTab();
                }
            }
            else if (tabIndex == -1)
            {
                tabSearch = CurrentText;
                FindFirstTab();
            }
            else
            {
                tabIndex++;
                if (tabIndex >= sorted.Count ||
                    (tabSearch != "" && sorted[tabIndex].IndexOf(tabSearch, StringComparison.Ordinal) != 0))
                    FindFirstTab();
            }

            if (tabIndex != -1) currentText = sorted[tabIndex];
        }

        // Monocle/Commands.cs:534-555.
        private void FindFirstTab()
        {
            for (var i = 0; i < sorted.Count; i++)
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch, StringComparison.Ordinal) == 0)
                {
                    tabIndex = i;
                    break;
                }
        }

        private void FindLastTab()
        {
            for (var i = 0; i < sorted.Count; i++)
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch, StringComparison.Ordinal) == 0)
                    tabIndex = i;
        }

        // Monocle/Commands.cs:516-532.
        public void EnterCommand()
        {
            var parts = CurrentText.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
            if (commandHistory.Count == 0 || commandHistory[0] != CurrentText) commandHistory.Insert(0, CurrentText);
            drawCommands.Insert(0,
                new(CurrentText,
                    DebugConsoleColors.Aqua));
            currentText = "";
            seekIndex = -1;
            if (parts.Length == 0) return;
            var args = new string[parts.Length - 1];
            for (var i = 1; i < parts.Length; i++) args[i - 1] = parts[i];
            executingEnteredLine = commandHistory[0];
            try
            {
                ExecuteCommand(parts[0].ToLowerInvariant(), args);
            }
            finally
            {
                executingEnteredLine = null;
            }
        }

        // Monocle/Commands.cs:583-593.
        public void ExecuteCommand(string command, string[] args)
        {
            // Command methods use the original ambient Engine.Commands shape. Bind it to the
            // actual caller, not whichever menu/preview console happened to be constructed last.
            var previous = Console;
            Console = this;
            try
            {
                if (commands.TryGetValue(command, out var info)) info.Action(args);
                else
                    Log("Command '" + command + "' not found! Type 'help' for list of commands",
                        DebugConsoleColors.Yellow);
            }
            finally
            {
                Console = previous;
            }
        }

        public void ExecuteCommand(string command, string[] args,
            IDebugConsoleWorld world)
        {
            var previous = World;
            World = world;
            try
            {
                ExecuteCommand(command, args);
            }
            finally
            {
                World = previous;
            }
        }

        // Monocle/Commands.cs:595-601.
        public void ExecuteFunctionKeyAction(int num)
        {
            if (num >= 0 && num < FunctionKeyActions.Length && FunctionKeyActions[num] != null)
                FunctionKeyActions[num]();
        }

        public bool HasCommand(string name)
        {
            return commands.ContainsKey(name);
        }

        public void Register(string name, string help, string usage, Action<string[]> action)
        {
            commands[name] = new() { Action = action, Help = help, Usage = usage };
            RefreshNames();
        }

        // Host modules need the same override shape Monocle gets by scanning an additional assembly,
        // but they must also be able to detach without leaving the base game's command table changed.
        // The returned restore action is ownership-aware: if another override replaced this one in
        // the meantime, disposing the older registration must not clobber the newer command.
        public Action RegisterOverride(string name, string help, string usage, Action<string[]> action)
        {
            var hadPrevious = commands.TryGetValue(name, out var previous);
            Action<string[]> ownedAction = args => action(args);
            var replacement = new CommandInfo { Action = ownedAction, Help = help, Usage = usage };
            commands[name] = replacement;
            RefreshNames();
            return () =>
            {
                if (!commands.TryGetValue(name, out var current) ||
                    !ReferenceEquals(current.Action, ownedAction)) return;
                if (hadPrevious) commands[name] = previous;
                else commands.Remove(name);
                RefreshNames();
            };
        }

        // ---------------------------------------------------------------------------------------
        // Registration - Monocle/Commands.cs:603-628 BuildCommandsList + :630-740 ProcessMethod.
        // The original scans Assembly.GetCallingAssembly() and Assembly.GetEntryAssembly(); here the
        // console and the table share Celeste.Simulation, so one scan covers both (plus anything
        // registered through Register above).
        // ---------------------------------------------------------------------------------------
        private void BuildCommandsList()
        {
            foreach (var type in typeof(DebugConsole).Assembly
                         .GetTypes())
            {
                MethodInfo[] methods;
                try
                {
                    methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception)
                {
                    continue;
                }

                foreach (var method in methods) ProcessMethod(method);
            }

            RefreshNames();
        }

        private void RefreshNames()
        {
            sorted.Clear();
            foreach (var command in commands.Keys) sorted.Add(command);
            sorted.Sort(StringComparer.Ordinal);
        }

        private void ProcessMethod(MethodInfo method)
        {
            var attributes =
                method.GetCustomAttributes(
                    typeof(DebugConsoleCommandAttribute), false);
            if (attributes.Length == 0) return;
            var command = attributes[0] as DebugConsoleCommandAttribute;
            if (command == null) return;
            if (!method.IsStatic)
                throw new(method.DeclaringType.Name + "." + method.Name +
                          " is marked as a command, but is not static");
            var value = new CommandInfo { Help = command.Help };
            var parameters = method.GetParameters();
            var defaults = new object[parameters.Length];
            var usage = new string[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                usage[i] = parameter.Name + ":";
                if (parameter.ParameterType == typeof(string)) usage[i] += "string";
                else if (parameter.ParameterType == typeof(int)) usage[i] += "int";
                else if (parameter.ParameterType == typeof(float)) usage[i] += "float";
                else if (parameter.ParameterType == typeof(bool)) usage[i] += "bool";
                else
                    throw new(method.DeclaringType.Name + "." + method.Name
                              + " is marked as a command, but has an invalid parameter type. Allowed types are: string, int, float, and bool");
                if (parameter.DefaultValue == DBNull.Value)
                {
                    defaults[i] = null;
                }
                else if (parameter.DefaultValue != null)
                {
                    defaults[i] = parameter.DefaultValue;
                    usage[i] += parameter.ParameterType == typeof(string)
                        ? "=\"" + parameter.DefaultValue + "\""
                        : "=" + Convert.ToString(parameter.DefaultValue, CultureInfo.InvariantCulture);
                }
                else
                {
                    defaults[i] = null;
                }
            }

            value.Usage = usage.Length == 0 ? "" : "[" + string.Join(" ", usage) + "]";
            var target = method;
            var signature = parameters;
            var fallbacks = defaults;
            value.Action = args =>
            {
                if (signature.Length == 0)
                {
                    InvokeMethod(target, null);
                    return;
                }

                var values = (object[])fallbacks.Clone();
                for (var j = 0; j < values.Length && j < args.Length; j++)
                    if (signature[j].ParameterType == typeof(string)) values[j] = ArgString(args[j]);
                    else if (signature[j].ParameterType == typeof(int)) values[j] = ArgInt(args[j]);
                    else if (signature[j].ParameterType == typeof(float)) values[j] = ArgFloat(args[j]);
                    else if (signature[j].ParameterType == typeof(bool)) values[j] = ArgBool(args[j]);

                InvokeMethod(target, values);
            };
            commands[command.Name] = value;
        }

        // Monocle/Commands.cs:742-753. The original dereferences InnerException without a null
        // check after a TargetInvocationException; a command that throws without an inner exception
        // would take the console down with a NullReferenceException, so the null case is reported
        // instead (the only behavioural difference in the port, called out in SUMMARY.md).
        private void InvokeMethod(MethodInfo method, object[] param)
        {
            try
            {
                method.Invoke(null, param);
            }
            catch (TargetInvocationException exception) when (exception.InnerException != null)
            {
                Log(exception.InnerException.Message,
                    DebugConsoleColors.Yellow);
                LogStackTrace(exception.InnerException.StackTrace);
            }
            catch (Exception exception)
            {
                Log(exception.Message, DebugConsoleColors.Yellow);
                LogStackTrace(exception.StackTrace);
            }
        }

        // Monocle/Commands.cs:755-782.
        public void LogStackTrace(string stackTrace)
        {
            if (string.IsNullOrEmpty(stackTrace)) return;
            foreach (var frame in stackTrace.Split('\n'))
            {
                var text = frame;
                var afterIn = text.LastIndexOf(" in ", StringComparison.Ordinal) + 4;
                var afterSlash = text.LastIndexOf('\\') + 1;
                if (afterIn != -1 && afterSlash != -1) text = text.Substring(0, afterIn) + text.Substring(afterSlash);
                var open = text.IndexOf('(') + 1;
                var close = text.IndexOf(')');
                if (open != -1 && close != -1) text = text.Substring(0, open) + text.Substring(close);
                var lastColon = text.LastIndexOf(':');
                if (lastColon != -1) text = text.Insert(lastColon + 1, " ").Insert(lastColon, " ");
                Log("-> " + text.TrimStart(), DebugConsoleColors.White);
            }
        }

        // Monocle/Commands.cs:784-828.
        private static string ArgString(string arg)
        {
            return arg ?? "";
        }

        private static bool ArgBool(string arg)
        {
            if (arg == null) return false;
            if (arg == "0" || arg.ToLowerInvariant() == "false") return false;
            return arg.ToLowerInvariant() != "f";
        }

        private static int ArgInt(string arg)
        {
            try
            {
                return Convert.ToInt32(arg, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }

        private static float ArgFloat(string arg)
        {
            try
            {
                return Convert.ToSingle(arg, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0f;
            }
        }

        // ---------------------------------------------------------------------------------------
        // Rendering primitives - Monocle/Commands.cs:557-581 Render.
        //   Draw.Rect(10, viewHeight - 50, viewWidth - 20, 40, Color.Black * 0.8f)
        //   DrawString(">" + currentText + "_", (20, viewHeight - 42), White)
        //   for i in drawCommands: Draw.Rect(10, viewHeight - num - 60, viewWidth - 20, num) with
        //                          num = 10 + 30 * count, then the line at (20, viewHeight - 92 - 30*i)
        // ---------------------------------------------------------------------------------------
        public void Layout(ICollection<DebugConsoleElement> target)
        {
            if (!Open) return;
            var black = new Vector4(DebugConsoleColors.Black.X,
                DebugConsoleColors.Black.Y,
                DebugConsoleColors.Black.Z, Opacity);
            target.Add(new(10f, ViewHeight - 50,
                ViewWidth - 20, 40f, black));
            target.Add(new(
                ">" + CurrentText + (UnderscoreVisible ? "_" : ""), 20f, ViewHeight - 42,
                DebugConsoleColors.White));
            if (drawCommands.Count > 0)
            {
                var height = 10 + 30 * drawCommands.Count;
                target.Add(new(10f,
                    ViewHeight - height - 60, ViewWidth - 20, height, black));
                for (var i = 0; i < drawCommands.Count; i++)
                    target.Add(new(
                        drawCommands[i].Text, 20f, ViewHeight - 92 - 30 * i,
                        drawCommands[i].Color));
            }
        }

        // ---------------------------------------------------------------------------------------
        // Monocle/Commands.cs:830-944 - the console's own command set. `clear`, `help` and `count`
        // are real; the window/graphics/Pooler/Tracker ones are reported as unsupported with the
        // missing facility named, never faked.
        // ---------------------------------------------------------------------------------------
        [DebugConsoleCommand("clear", "Clears the terminal")]
        public static void CmdClear()
        {
            RequireConsole().Clear();
        }

        [DebugConsoleCommand("help", "Shows usage help for a given command")]
        public static void CmdHelp(string command)
        {
            var console = RequireConsole();
            if (!string.IsNullOrEmpty(command) && console.commands.TryGetValue(command, out var info))
            {
                var builder = new StringBuilder();
                builder.Append(":: ").Append(command);
                if (!string.IsNullOrEmpty(info.Usage)) builder.Append(' ').Append(info.Usage);
                console.Log(builder.ToString());
                console.Log(string.IsNullOrEmpty(info.Help) ? "No help info set" : info.Help);
                return;
            }

            console.Log("Commands list: " + string.Join(", ", console.sorted));
            console.Log("Type 'help command' for more info on that command!");
        }

        [DebugConsoleCommand("count",
            "Logs amount of Entities in the Scene. Pass a tagIndex to count only Entities with that tag")]
        public static void CmdCount(int tagIndex = -1)
        {
            var console = RequireConsole();
            var world = console.World;
            if (world == null)
            {
                console.Log("Current Scene is null!",
                    DebugConsoleColors.Yellow);
                return;
            }

            var snapshot = world.Snapshot();
            if (!snapshot.InLevel)
            {
                console.Log("Current Scene is null!",
                    DebugConsoleColors.Yellow);
                return;
            }

            if (tagIndex >= 0)
            {
                // Monocle/Commands.cs:863 counts Engine.Scene.TagLists[tagIndex]; this repo's entity
                // list is not tag-indexed, so the tagged form is reported instead of invented.
                console.Log(
                    "count <tagIndex> is unsupported: entity visuals carry SceneTagSet, not Monocle tag lists",
                    DebugConsoleColors.Yellow);
                world.Trace("unsupported: count " + tagIndex);
                return;
            }

            console.Log(snapshot.EntityCount.ToString(CultureInfo.InvariantCulture));
        }

        [DebugConsoleCommand("tracker",
            "Logs all tracked objects in the scene. Set mode to 'e' for just entities, or 'c' for just components")]
        public static void CmdTracker(string mode = "e")
        {
            var console = RequireConsole();
            console.Log(
                "tracker is unsupported: this repo has no Monocle Tracker registry (see 'entities' for the loaded entity list)",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: tracker " + mode);
        }

        [DebugConsoleCommand("pooler", "Logs the pooled Entity counts")]
        public static void CmdPooler()
        {
            var console = RequireConsole();
            console.Log("pooler is unsupported: this repo has no Monocle Pooler (there is no pooled-Entity factory)",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: pooler");
        }

        [DebugConsoleCommand("vsync", "Enables or disables vertical sync")]
        public static void CmdVsync(bool enabled = true)
        {
            var console = RequireConsole();
            console.Log(
                "vsync is unsupported: Unity owns the swap chain (Project Settings / GameDisplaySettings), not this console",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: vsync " + enabled);
        }

        [DebugConsoleCommand("fullscreen", "Switches to fullscreen mode")]
        public static void CmdFullscreen()
        {
            var console = RequireConsole();
            console.Log(
                "fullscreen is unsupported: the original called Engine.SetFullscreen; this repo routes display changes through GameDisplaySettings",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: fullscreen");
        }

        [DebugConsoleCommand("window", "Switches to window mode")]
        public static void CmdWindow(int scale = 1)
        {
            var console = RequireConsole();
            console.Log(
                "window is unsupported: the original called Engine.SetWindowed(320*scale, 180*scale); this repo routes display changes through GameDisplaySettings",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: window " + scale);
        }

        [DebugConsoleCommand("exit", "Exits the game")]
        public static void CmdExit()
        {
            var console = RequireConsole();
            console.Log(
                "exit is unsupported by the console: quitting the player is a game-flow decision, not a console action",
                DebugConsoleColors.Yellow);
            console.World?.Trace("unsupported: exit");
        }

        private static DebugConsole RequireConsole()
        {
            return Console ?? throw new InvalidOperationException("The debug console has not been constructed.");
        }
    }
}
