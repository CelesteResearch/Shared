using System;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private static string FormatFileScreenShake(FileScreenShake value)
        {
            switch (value)
            {
                case FileScreenShake.Off: return "false";
                case FileScreenShake.Half: return "true";
                case FileScreenShake.On: return "On";
                default: throw new InvalidOperationException("Invalid FileScreenShake value.");
            }
        }

        private static FileScreenShake ParseFileScreenShake(string value)
        {
            switch (value)
            {
                case "false": return FileScreenShake.Off;
                case "true": return FileScreenShake.Half;
                case "On": return FileScreenShake.On;
                default: throw new InvalidOperationException("Invalid FileScreenShake XML token: " + value);
            }
        }

        private static string FormatFileRumble(FileRumble value)
        {
            switch (value)
            {
                case FileRumble.Off: return "false";
                case FileRumble.Half: return "Half";
                case FileRumble.On: return "true";
                default: throw new InvalidOperationException("Invalid FileRumble value.");
            }
        }

        private static FileRumble ParseFileRumble(string value)
        {
            switch (value)
            {
                case "false": return FileRumble.Off;
                case "Half": return FileRumble.Half;
                case "true": return FileRumble.On;
                default: throw new InvalidOperationException("Invalid FileRumble XML token: " + value);
            }
        }

        private static string FormatFileGrabMode(FileGrabMode value)
        {
            switch (value)
            {
                case FileGrabMode.Hold: return "Hold";
                case FileGrabMode.Invert: return "Invert";
                case FileGrabMode.Toggle: return "Toggle";
                default: throw new InvalidOperationException("Invalid FileGrabMode value.");
            }
        }

        private static FileGrabMode ParseFileGrabMode(string value)
        {
            switch (value)
            {
                case "Hold": return FileGrabMode.Hold;
                case "Invert": return FileGrabMode.Invert;
                case "Toggle": return FileGrabMode.Toggle;
                default: throw new InvalidOperationException("Invalid FileGrabMode XML token: " + value);
            }
        }

        private static string FormatFileCrouchDashMode(FileCrouchDashMode value)
        {
            switch (value)
            {
                case FileCrouchDashMode.Press: return "Press";
                case FileCrouchDashMode.Hold: return "Hold";
                default: throw new InvalidOperationException("Invalid FileCrouchDashMode value.");
            }
        }

        private static FileCrouchDashMode ParseFileCrouchDashMode(string value)
        {
            switch (value)
            {
                case "Press": return FileCrouchDashMode.Press;
                case "Hold": return FileCrouchDashMode.Hold;
                default: throw new InvalidOperationException("Invalid FileCrouchDashMode XML token: " + value);
            }
        }

        private static string FormatFileSpeedrunClock(FileSpeedrunClock value)
        {
            switch (value)
            {
                case FileSpeedrunClock.Off: return "false";
                case FileSpeedrunClock.Chapter: return "true";
                case FileSpeedrunClock.File: return "File";
                default: throw new InvalidOperationException("Invalid FileSpeedrunClock value.");
            }
        }

        private static FileSpeedrunClock ParseFileSpeedrunClock(string value)
        {
            switch (value)
            {
                case "false": return FileSpeedrunClock.Off;
                case "true": return FileSpeedrunClock.Chapter;
                case "File": return FileSpeedrunClock.File;
                default: throw new InvalidOperationException("Invalid FileSpeedrunClock XML token: " + value);
            }
        }

        private static string FormatFileSettingsKey(FileSettingsKey value)
        {
            switch (value)
            {
                case FileSettingsKey.A: return "A";
                case FileSettingsKey.Add: return "Add";
                case FileSettingsKey.Apps: return "Apps";
                case FileSettingsKey.Attn: return "Attn";
                case FileSettingsKey.B: return "B";
                case FileSettingsKey.Back: return "Back";
                case FileSettingsKey.BrowserBack: return "BrowserBack";
                case FileSettingsKey.BrowserFavorites: return "BrowserFavorites";
                case FileSettingsKey.BrowserForward: return "BrowserForward";
                case FileSettingsKey.BrowserHome: return "BrowserHome";
                case FileSettingsKey.BrowserRefresh: return "BrowserRefresh";
                case FileSettingsKey.BrowserSearch: return "BrowserSearch";
                case FileSettingsKey.BrowserStop: return "BrowserStop";
                case FileSettingsKey.C: return "C";
                case FileSettingsKey.CapsLock: return "CapsLock";
                case FileSettingsKey.Crsel: return "Crsel";
                case FileSettingsKey.D: return "D";
                case FileSettingsKey.D0: return "D0";
                case FileSettingsKey.D1: return "D1";
                case FileSettingsKey.D2: return "D2";
                case FileSettingsKey.D3: return "D3";
                case FileSettingsKey.D4: return "D4";
                case FileSettingsKey.D5: return "D5";
                case FileSettingsKey.D6: return "D6";
                case FileSettingsKey.D7: return "D7";
                case FileSettingsKey.D8: return "D8";
                case FileSettingsKey.D9: return "D9";
                case FileSettingsKey.Decimal: return "Decimal";
                case FileSettingsKey.Delete: return "Delete";
                case FileSettingsKey.Divide: return "Divide";
                case FileSettingsKey.Down: return "Down";
                case FileSettingsKey.E: return "E";
                case FileSettingsKey.End: return "End";
                case FileSettingsKey.Enter: return "Enter";
                case FileSettingsKey.EraseEof: return "EraseEof";
                case FileSettingsKey.Escape: return "Escape";
                case FileSettingsKey.Execute: return "Execute";
                case FileSettingsKey.Exsel: return "Exsel";
                case FileSettingsKey.F: return "F";
                case FileSettingsKey.F1: return "F1";
                case FileSettingsKey.F10: return "F10";
                case FileSettingsKey.F11: return "F11";
                case FileSettingsKey.F12: return "F12";
                case FileSettingsKey.F13: return "F13";
                case FileSettingsKey.F14: return "F14";
                case FileSettingsKey.F15: return "F15";
                case FileSettingsKey.F16: return "F16";
                case FileSettingsKey.F17: return "F17";
                case FileSettingsKey.F18: return "F18";
                case FileSettingsKey.F19: return "F19";
                case FileSettingsKey.F2: return "F2";
                case FileSettingsKey.F20: return "F20";
                case FileSettingsKey.F21: return "F21";
                case FileSettingsKey.F22: return "F22";
                case FileSettingsKey.F23: return "F23";
                case FileSettingsKey.F24: return "F24";
                case FileSettingsKey.F3: return "F3";
                case FileSettingsKey.F4: return "F4";
                case FileSettingsKey.F5: return "F5";
                case FileSettingsKey.F6: return "F6";
                case FileSettingsKey.F7: return "F7";
                case FileSettingsKey.F8: return "F8";
                case FileSettingsKey.F9: return "F9";
                case FileSettingsKey.G: return "G";
                case FileSettingsKey.H: return "H";
                case FileSettingsKey.Help: return "Help";
                case FileSettingsKey.Home: return "Home";
                case FileSettingsKey.I: return "I";
                case FileSettingsKey.ImeConvert: return "ImeConvert";
                case FileSettingsKey.ImeNoConvert: return "ImeNoConvert";
                case FileSettingsKey.Insert: return "Insert";
                case FileSettingsKey.J: return "J";
                case FileSettingsKey.K: return "K";
                case FileSettingsKey.Kana: return "Kana";
                case FileSettingsKey.Kanji: return "Kanji";
                case FileSettingsKey.L: return "L";
                case FileSettingsKey.LaunchApplication1: return "LaunchApplication1";
                case FileSettingsKey.LaunchApplication2: return "LaunchApplication2";
                case FileSettingsKey.LaunchMail: return "LaunchMail";
                case FileSettingsKey.LeftControl: return "LeftControl";
                case FileSettingsKey.Left: return "Left";
                case FileSettingsKey.LeftAlt: return "LeftAlt";
                case FileSettingsKey.LeftShift: return "LeftShift";
                case FileSettingsKey.LeftWindows: return "LeftWindows";
                case FileSettingsKey.M: return "M";
                case FileSettingsKey.MediaNextTrack: return "MediaNextTrack";
                case FileSettingsKey.MediaPlayPause: return "MediaPlayPause";
                case FileSettingsKey.MediaPreviousTrack: return "MediaPreviousTrack";
                case FileSettingsKey.MediaStop: return "MediaStop";
                case FileSettingsKey.Multiply: return "Multiply";
                case FileSettingsKey.N: return "N";
                case FileSettingsKey.None: return "None";
                case FileSettingsKey.NumLock: return "NumLock";
                case FileSettingsKey.NumPad0: return "NumPad0";
                case FileSettingsKey.NumPad1: return "NumPad1";
                case FileSettingsKey.NumPad2: return "NumPad2";
                case FileSettingsKey.NumPad3: return "NumPad3";
                case FileSettingsKey.NumPad4: return "NumPad4";
                case FileSettingsKey.NumPad5: return "NumPad5";
                case FileSettingsKey.NumPad6: return "NumPad6";
                case FileSettingsKey.NumPad7: return "NumPad7";
                case FileSettingsKey.NumPad8: return "NumPad8";
                case FileSettingsKey.NumPad9: return "NumPad9";
                case FileSettingsKey.O: return "O";
                case FileSettingsKey.OemAuto: return "OemAuto";
                case FileSettingsKey.OemCopy: return "OemCopy";
                case FileSettingsKey.OemEnlW: return "OemEnlW";
                case FileSettingsKey.OemSemicolon: return "OemSemicolon";
                case FileSettingsKey.OemBackslash: return "OemBackslash";
                case FileSettingsKey.OemQuestion: return "OemQuestion";
                case FileSettingsKey.OemTilde: return "OemTilde";
                case FileSettingsKey.OemOpenBrackets: return "OemOpenBrackets";
                case FileSettingsKey.OemPipe: return "OemPipe";
                case FileSettingsKey.OemCloseBrackets: return "OemCloseBrackets";
                case FileSettingsKey.OemQuotes: return "OemQuotes";
                case FileSettingsKey.Oem8: return "Oem8";
                case FileSettingsKey.OemClear: return "OemClear";
                case FileSettingsKey.OemComma: return "OemComma";
                case FileSettingsKey.OemMinus: return "OemMinus";
                case FileSettingsKey.OemPeriod: return "OemPeriod";
                case FileSettingsKey.OemPlus: return "OemPlus";
                case FileSettingsKey.P: return "P";
                case FileSettingsKey.Pa1: return "Pa1";
                case FileSettingsKey.PageDown: return "PageDown";
                case FileSettingsKey.PageUp: return "PageUp";
                case FileSettingsKey.Pause: return "Pause";
                case FileSettingsKey.Play: return "Play";
                case FileSettingsKey.Print: return "Print";
                case FileSettingsKey.PrintScreen: return "PrintScreen";
                case FileSettingsKey.ProcessKey: return "ProcessKey";
                case FileSettingsKey.Q: return "Q";
                case FileSettingsKey.R: return "R";
                case FileSettingsKey.RightControl: return "RightControl";
                case FileSettingsKey.Right: return "Right";
                case FileSettingsKey.RightAlt: return "RightAlt";
                case FileSettingsKey.RightShift: return "RightShift";
                case FileSettingsKey.RightWindows: return "RightWindows";
                case FileSettingsKey.S: return "S";
                case FileSettingsKey.Scroll: return "Scroll";
                case FileSettingsKey.Select: return "Select";
                case FileSettingsKey.SelectMedia: return "SelectMedia";
                case FileSettingsKey.Separator: return "Separator";
                case FileSettingsKey.Sleep: return "Sleep";
                case FileSettingsKey.Space: return "Space";
                case FileSettingsKey.Subtract: return "Subtract";
                case FileSettingsKey.T: return "T";
                case FileSettingsKey.Tab: return "Tab";
                case FileSettingsKey.U: return "U";
                case FileSettingsKey.Up: return "Up";
                case FileSettingsKey.V: return "V";
                case FileSettingsKey.VolumeDown: return "VolumeDown";
                case FileSettingsKey.VolumeMute: return "VolumeMute";
                case FileSettingsKey.VolumeUp: return "VolumeUp";
                case FileSettingsKey.W: return "W";
                case FileSettingsKey.X: return "X";
                case FileSettingsKey.Y: return "Y";
                case FileSettingsKey.Z: return "Z";
                case FileSettingsKey.Zoom: return "Zoom";
                case FileSettingsKey.ChatPadGreen: return "ChatPadGreen";
                case FileSettingsKey.ChatPadOrange: return "ChatPadOrange";
                default: throw new InvalidOperationException("Invalid FileSettingsKey value.");
            }
        }

        private static FileSettingsKey ParseFileSettingsKey(string value)
        {
            switch (value)
            {
                case "A": return FileSettingsKey.A;
                case "Add": return FileSettingsKey.Add;
                case "Apps": return FileSettingsKey.Apps;
                case "Attn": return FileSettingsKey.Attn;
                case "B": return FileSettingsKey.B;
                case "Back": return FileSettingsKey.Back;
                case "BrowserBack": return FileSettingsKey.BrowserBack;
                case "BrowserFavorites": return FileSettingsKey.BrowserFavorites;
                case "BrowserForward": return FileSettingsKey.BrowserForward;
                case "BrowserHome": return FileSettingsKey.BrowserHome;
                case "BrowserRefresh": return FileSettingsKey.BrowserRefresh;
                case "BrowserSearch": return FileSettingsKey.BrowserSearch;
                case "BrowserStop": return FileSettingsKey.BrowserStop;
                case "C": return FileSettingsKey.C;
                case "CapsLock": return FileSettingsKey.CapsLock;
                case "Crsel": return FileSettingsKey.Crsel;
                case "D": return FileSettingsKey.D;
                case "D0": return FileSettingsKey.D0;
                case "D1": return FileSettingsKey.D1;
                case "D2": return FileSettingsKey.D2;
                case "D3": return FileSettingsKey.D3;
                case "D4": return FileSettingsKey.D4;
                case "D5": return FileSettingsKey.D5;
                case "D6": return FileSettingsKey.D6;
                case "D7": return FileSettingsKey.D7;
                case "D8": return FileSettingsKey.D8;
                case "D9": return FileSettingsKey.D9;
                case "Decimal": return FileSettingsKey.Decimal;
                case "Delete": return FileSettingsKey.Delete;
                case "Divide": return FileSettingsKey.Divide;
                case "Down": return FileSettingsKey.Down;
                case "E": return FileSettingsKey.E;
                case "End": return FileSettingsKey.End;
                case "Enter": return FileSettingsKey.Enter;
                case "EraseEof": return FileSettingsKey.EraseEof;
                case "Escape": return FileSettingsKey.Escape;
                case "Execute": return FileSettingsKey.Execute;
                case "Exsel": return FileSettingsKey.Exsel;
                case "F": return FileSettingsKey.F;
                case "F1": return FileSettingsKey.F1;
                case "F10": return FileSettingsKey.F10;
                case "F11": return FileSettingsKey.F11;
                case "F12": return FileSettingsKey.F12;
                case "F13": return FileSettingsKey.F13;
                case "F14": return FileSettingsKey.F14;
                case "F15": return FileSettingsKey.F15;
                case "F16": return FileSettingsKey.F16;
                case "F17": return FileSettingsKey.F17;
                case "F18": return FileSettingsKey.F18;
                case "F19": return FileSettingsKey.F19;
                case "F2": return FileSettingsKey.F2;
                case "F20": return FileSettingsKey.F20;
                case "F21": return FileSettingsKey.F21;
                case "F22": return FileSettingsKey.F22;
                case "F23": return FileSettingsKey.F23;
                case "F24": return FileSettingsKey.F24;
                case "F3": return FileSettingsKey.F3;
                case "F4": return FileSettingsKey.F4;
                case "F5": return FileSettingsKey.F5;
                case "F6": return FileSettingsKey.F6;
                case "F7": return FileSettingsKey.F7;
                case "F8": return FileSettingsKey.F8;
                case "F9": return FileSettingsKey.F9;
                case "G": return FileSettingsKey.G;
                case "H": return FileSettingsKey.H;
                case "Help": return FileSettingsKey.Help;
                case "Home": return FileSettingsKey.Home;
                case "I": return FileSettingsKey.I;
                case "ImeConvert": return FileSettingsKey.ImeConvert;
                case "ImeNoConvert": return FileSettingsKey.ImeNoConvert;
                case "Insert": return FileSettingsKey.Insert;
                case "J": return FileSettingsKey.J;
                case "K": return FileSettingsKey.K;
                case "Kana": return FileSettingsKey.Kana;
                case "Kanji": return FileSettingsKey.Kanji;
                case "L": return FileSettingsKey.L;
                case "LaunchApplication1": return FileSettingsKey.LaunchApplication1;
                case "LaunchApplication2": return FileSettingsKey.LaunchApplication2;
                case "LaunchMail": return FileSettingsKey.LaunchMail;
                case "LeftControl": return FileSettingsKey.LeftControl;
                case "Left": return FileSettingsKey.Left;
                case "LeftAlt": return FileSettingsKey.LeftAlt;
                case "LeftShift": return FileSettingsKey.LeftShift;
                case "LeftWindows": return FileSettingsKey.LeftWindows;
                case "M": return FileSettingsKey.M;
                case "MediaNextTrack": return FileSettingsKey.MediaNextTrack;
                case "MediaPlayPause": return FileSettingsKey.MediaPlayPause;
                case "MediaPreviousTrack": return FileSettingsKey.MediaPreviousTrack;
                case "MediaStop": return FileSettingsKey.MediaStop;
                case "Multiply": return FileSettingsKey.Multiply;
                case "N": return FileSettingsKey.N;
                case "None": return FileSettingsKey.None;
                case "NumLock": return FileSettingsKey.NumLock;
                case "NumPad0": return FileSettingsKey.NumPad0;
                case "NumPad1": return FileSettingsKey.NumPad1;
                case "NumPad2": return FileSettingsKey.NumPad2;
                case "NumPad3": return FileSettingsKey.NumPad3;
                case "NumPad4": return FileSettingsKey.NumPad4;
                case "NumPad5": return FileSettingsKey.NumPad5;
                case "NumPad6": return FileSettingsKey.NumPad6;
                case "NumPad7": return FileSettingsKey.NumPad7;
                case "NumPad8": return FileSettingsKey.NumPad8;
                case "NumPad9": return FileSettingsKey.NumPad9;
                case "O": return FileSettingsKey.O;
                case "OemAuto": return FileSettingsKey.OemAuto;
                case "OemCopy": return FileSettingsKey.OemCopy;
                case "OemEnlW": return FileSettingsKey.OemEnlW;
                case "OemSemicolon": return FileSettingsKey.OemSemicolon;
                case "OemBackslash": return FileSettingsKey.OemBackslash;
                case "OemQuestion": return FileSettingsKey.OemQuestion;
                case "OemTilde": return FileSettingsKey.OemTilde;
                case "OemOpenBrackets": return FileSettingsKey.OemOpenBrackets;
                case "OemPipe": return FileSettingsKey.OemPipe;
                case "OemCloseBrackets": return FileSettingsKey.OemCloseBrackets;
                case "OemQuotes": return FileSettingsKey.OemQuotes;
                case "Oem8": return FileSettingsKey.Oem8;
                case "OemClear": return FileSettingsKey.OemClear;
                case "OemComma": return FileSettingsKey.OemComma;
                case "OemMinus": return FileSettingsKey.OemMinus;
                case "OemPeriod": return FileSettingsKey.OemPeriod;
                case "OemPlus": return FileSettingsKey.OemPlus;
                case "P": return FileSettingsKey.P;
                case "Pa1": return FileSettingsKey.Pa1;
                case "PageDown": return FileSettingsKey.PageDown;
                case "PageUp": return FileSettingsKey.PageUp;
                case "Pause": return FileSettingsKey.Pause;
                case "Play": return FileSettingsKey.Play;
                case "Print": return FileSettingsKey.Print;
                case "PrintScreen": return FileSettingsKey.PrintScreen;
                case "ProcessKey": return FileSettingsKey.ProcessKey;
                case "Q": return FileSettingsKey.Q;
                case "R": return FileSettingsKey.R;
                case "RightControl": return FileSettingsKey.RightControl;
                case "Right": return FileSettingsKey.Right;
                case "RightAlt": return FileSettingsKey.RightAlt;
                case "RightShift": return FileSettingsKey.RightShift;
                case "RightWindows": return FileSettingsKey.RightWindows;
                case "S": return FileSettingsKey.S;
                case "Scroll": return FileSettingsKey.Scroll;
                case "Select": return FileSettingsKey.Select;
                case "SelectMedia": return FileSettingsKey.SelectMedia;
                case "Separator": return FileSettingsKey.Separator;
                case "Sleep": return FileSettingsKey.Sleep;
                case "Space": return FileSettingsKey.Space;
                case "Subtract": return FileSettingsKey.Subtract;
                case "T": return FileSettingsKey.T;
                case "Tab": return FileSettingsKey.Tab;
                case "U": return FileSettingsKey.U;
                case "Up": return FileSettingsKey.Up;
                case "V": return FileSettingsKey.V;
                case "VolumeDown": return FileSettingsKey.VolumeDown;
                case "VolumeMute": return FileSettingsKey.VolumeMute;
                case "VolumeUp": return FileSettingsKey.VolumeUp;
                case "W": return FileSettingsKey.W;
                case "X": return FileSettingsKey.X;
                case "Y": return FileSettingsKey.Y;
                case "Z": return FileSettingsKey.Z;
                case "Zoom": return FileSettingsKey.Zoom;
                case "ChatPadGreen": return FileSettingsKey.ChatPadGreen;
                case "ChatPadOrange": return FileSettingsKey.ChatPadOrange;
                default: throw new InvalidOperationException("Invalid FileSettingsKey XML token: " + value);
            }
        }
    }
}
