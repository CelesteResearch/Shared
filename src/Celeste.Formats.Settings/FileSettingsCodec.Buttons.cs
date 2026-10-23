using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private static readonly string[] ButtonNames =
        {
            "DPadUp",
            "DPadDown",
            "DPadLeft",
            "DPadRight",
            "Start",
            "Back",
            "LeftStick",
            "RightStick",
            "LeftShoulder",
            "RightShoulder",
            "Misc1EXT",
            "BigButton",
            "A",
            "B",
            "X",
            "Y",
            "Paddle1EXT",
            "Paddle2EXT",
            "Paddle3EXT",
            "Paddle4EXT",
            "TouchPadEXT",
            "LeftThumbstickLeft",
            "RightTrigger",
            "LeftTrigger",
            "RightThumbstickUp",
            "RightThumbstickDown",
            "RightThumbstickRight",
            "RightThumbstickLeft",
            "LeftThumbstickUp",
            "LeftThumbstickDown",
            "LeftThumbstickRight",
        };

        private static string FormatFileSettingsButton(FileSettingsButton value)
        {
            var bits = (int)value;
            if (bits == 0) return "None";
            if (bits < 0) throw new InvalidOperationException("Invalid FileSettingsButton value.");
            var text = new StringBuilder();
            for (var bit = 0; bit < ButtonNames.Length; bit++)
            {
                if ((bits & (1 << bit)) == 0) continue;
                if (text.Length != 0) text.Append(' ');
                text.Append(ButtonNames[bit]);
            }

            return text.ToString();
        }

        private static FileSettingsButton ParseFileSettingsButton(string value)
        {
            var result = FileSettingsButton.None;
            foreach (var token in value.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (token == "None") continue;
                var bit = Array.IndexOf(ButtonNames, token);
                if (bit < 0) throw new InvalidOperationException("Invalid FileSettingsButton XML token: " + token);
                result |= (FileSettingsButton)(1 << bit);
            }

            return result;
        }
    }
}
