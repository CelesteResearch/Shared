using System;
using System.Xml;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private static FileSettingsXml ReadSettings(XmlReader reader, out bool fullscreenPresent)
        {
            reader.MoveToContent();
            if (reader.LocalName != "Settings" || reader.NamespaceURI.Length != 0)
                throw new InvalidOperationException("Expected Settings XML root in the empty namespace.");
            ValidateXmlType(reader, "FileSettingsXml");
            var nil = reader.GetAttribute("nil", SchemaInstanceNamespace);
            var settings = nil != null && XmlConvert.ToBoolean(nil) ? null : new FileSettingsXml();
            fullscreenPresent = false;
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return settings;
            }

            reader.ReadStartElement();
            ulong seen = 0;
            while (MoveToElementOrEnd(reader))
            {
                if (reader.Name == "Fullscreen") fullscreenPresent = true;
                if (settings == null || reader.NamespaceURI.Length != 0)
                {
                    reader.Skip();
                    continue;
                }

                switch (reader.LocalName)
                {
                    case "Version" when (seen & (1UL << 0)) == 0:
                        seen |= 1UL << 0;
                        settings.Version = reader.ReadElementContentAsString();
                        break;
                    case "DefaultFileName" when (seen & (1UL << 1)) == 0:
                        seen |= 1UL << 1;
                        settings.DefaultFileName = reader.ReadElementContentAsString();
                        break;
                    case "Fullscreen" when (seen & (1UL << 2)) == 0:
                        seen |= 1UL << 2;
                        settings.Fullscreen = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "WindowScale" when (seen & (1UL << 3)) == 0:
                        seen |= 1UL << 3;
                        settings.WindowScale = XmlConvert.ToInt32(reader.ReadElementContentAsString().Trim());
                        break;
                    case "ViewportPadding" when (seen & (1UL << 4)) == 0:
                        seen |= 1UL << 4;
                        settings.ViewportPadding = XmlConvert.ToInt32(reader.ReadElementContentAsString().Trim());
                        break;
                    case "VSync" when (seen & (1UL << 5)) == 0:
                        seen |= 1UL << 5;
                        settings.VSync = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "DisableFlashes" when (seen & (1UL << 6)) == 0:
                        seen |= 1UL << 6;
                        settings.DisableFlashes = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "ScreenShake" when (seen & (1UL << 7)) == 0:
                        seen |= 1UL << 7;
                        settings.ScreenShake = ParseFileScreenShake(reader.ReadElementContentAsString());
                        break;
                    case "Rumble" when (seen & (1UL << 8)) == 0:
                        seen |= 1UL << 8;
                        settings.Rumble = ParseFileRumble(reader.ReadElementContentAsString());
                        break;
                    case "GrabMode" when (seen & (1UL << 9)) == 0:
                        seen |= 1UL << 9;
                        settings.GrabMode = ParseFileGrabMode(reader.ReadElementContentAsString());
                        break;
                    case "CrouchDashMode" when (seen & (1UL << 10)) == 0:
                        seen |= 1UL << 10;
                        settings.CrouchDashMode = ParseFileCrouchDashMode(reader.ReadElementContentAsString());
                        break;
                    case "MusicVolume" when (seen & (1UL << 11)) == 0:
                        seen |= 1UL << 11;
                        settings.MusicVolume = XmlConvert.ToInt32(reader.ReadElementContentAsString().Trim());
                        break;
                    case "SFXVolume" when (seen & (1UL << 12)) == 0:
                        seen |= 1UL << 12;
                        settings.SFXVolume = XmlConvert.ToInt32(reader.ReadElementContentAsString().Trim());
                        break;
                    case "SpeedrunClock" when (seen & (1UL << 13)) == 0:
                        seen |= 1UL << 13;
                        settings.SpeedrunClock = ParseFileSpeedrunClock(reader.ReadElementContentAsString());
                        break;
                    case "LastSaveFile" when (seen & (1UL << 14)) == 0:
                        seen |= 1UL << 14;
                        settings.LastSaveFile = XmlConvert.ToInt32(reader.ReadElementContentAsString().Trim());
                        break;
                    case "Language" when (seen & (1UL << 15)) == 0:
                        seen |= 1UL << 15;
                        settings.Language = reader.ReadElementContentAsString();
                        break;
                    case "Pico8OnMainMenu" when (seen & (1UL << 16)) == 0:
                        seen |= 1UL << 16;
                        settings.Pico8OnMainMenu = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "SetViewportOnce" when (seen & (1UL << 17)) == 0:
                        seen |= 1UL << 17;
                        settings.SetViewportOnce = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "VariantsUnlocked" when (seen & (1UL << 18)) == 0:
                        seen |= 1UL << 18;
                        settings.VariantsUnlocked = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "Left" when (seen & (1UL << 19)) == 0:
                        seen |= 1UL << 19;
                        settings.Left = ReadBinding(reader);
                        break;
                    case "Right" when (seen & (1UL << 20)) == 0:
                        seen |= 1UL << 20;
                        settings.Right = ReadBinding(reader);
                        break;
                    case "Down" when (seen & (1UL << 21)) == 0:
                        seen |= 1UL << 21;
                        settings.Down = ReadBinding(reader);
                        break;
                    case "Up" when (seen & (1UL << 22)) == 0:
                        seen |= 1UL << 22;
                        settings.Up = ReadBinding(reader);
                        break;
                    case "MenuLeft" when (seen & (1UL << 23)) == 0:
                        seen |= 1UL << 23;
                        settings.MenuLeft = ReadBinding(reader);
                        break;
                    case "MenuRight" when (seen & (1UL << 24)) == 0:
                        seen |= 1UL << 24;
                        settings.MenuRight = ReadBinding(reader);
                        break;
                    case "MenuDown" when (seen & (1UL << 25)) == 0:
                        seen |= 1UL << 25;
                        settings.MenuDown = ReadBinding(reader);
                        break;
                    case "MenuUp" when (seen & (1UL << 26)) == 0:
                        seen |= 1UL << 26;
                        settings.MenuUp = ReadBinding(reader);
                        break;
                    case "Grab" when (seen & (1UL << 27)) == 0:
                        seen |= 1UL << 27;
                        settings.Grab = ReadBinding(reader);
                        break;
                    case "Jump" when (seen & (1UL << 28)) == 0:
                        seen |= 1UL << 28;
                        settings.Jump = ReadBinding(reader);
                        break;
                    case "Dash" when (seen & (1UL << 29)) == 0:
                        seen |= 1UL << 29;
                        settings.Dash = ReadBinding(reader);
                        break;
                    case "Talk" when (seen & (1UL << 30)) == 0:
                        seen |= 1UL << 30;
                        settings.Talk = ReadBinding(reader);
                        break;
                    case "Pause" when (seen & (1UL << 31)) == 0:
                        seen |= 1UL << 31;
                        settings.Pause = ReadBinding(reader);
                        break;
                    case "Confirm" when (seen & (1UL << 32)) == 0:
                        seen |= 1UL << 32;
                        settings.Confirm = ReadBinding(reader);
                        break;
                    case "Cancel" when (seen & (1UL << 33)) == 0:
                        seen |= 1UL << 33;
                        settings.Cancel = ReadBinding(reader);
                        break;
                    case "Journal" when (seen & (1UL << 34)) == 0:
                        seen |= 1UL << 34;
                        settings.Journal = ReadBinding(reader);
                        break;
                    case "QuickRestart" when (seen & (1UL << 35)) == 0:
                        seen |= 1UL << 35;
                        settings.QuickRestart = ReadBinding(reader);
                        break;
                    case "DemoDash" when (seen & (1UL << 36)) == 0:
                        seen |= 1UL << 36;
                        settings.DemoDash = ReadBinding(reader);
                        break;
                    case "RightMoveOnly" when (seen & (1UL << 37)) == 0:
                        seen |= 1UL << 37;
                        settings.RightMoveOnly = ReadBinding(reader);
                        break;
                    case "LeftMoveOnly" when (seen & (1UL << 38)) == 0:
                        seen |= 1UL << 38;
                        settings.LeftMoveOnly = ReadBinding(reader);
                        break;
                    case "UpMoveOnly" when (seen & (1UL << 39)) == 0:
                        seen |= 1UL << 39;
                        settings.UpMoveOnly = ReadBinding(reader);
                        break;
                    case "DownMoveOnly" when (seen & (1UL << 40)) == 0:
                        seen |= 1UL << 40;
                        settings.DownMoveOnly = ReadBinding(reader);
                        break;
                    case "RightDashOnly" when (seen & (1UL << 41)) == 0:
                        seen |= 1UL << 41;
                        settings.RightDashOnly = ReadBinding(reader);
                        break;
                    case "LeftDashOnly" when (seen & (1UL << 42)) == 0:
                        seen |= 1UL << 42;
                        settings.LeftDashOnly = ReadBinding(reader);
                        break;
                    case "UpDashOnly" when (seen & (1UL << 43)) == 0:
                        seen |= 1UL << 43;
                        settings.UpDashOnly = ReadBinding(reader);
                        break;
                    case "DownDashOnly" when (seen & (1UL << 44)) == 0:
                        seen |= 1UL << 44;
                        settings.DownDashOnly = ReadBinding(reader);
                        break;
                    case "LaunchWithFMODLiveUpdate" when (seen & (1UL << 45)) == 0:
                        seen |= 1UL << 45;
                        settings.LaunchWithFMODLiveUpdate =
                            XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "LaunchInDebugMode" when (seen & (1UL << 46)) == 0:
                        seen |= 1UL << 46;
                        settings.LaunchInDebugMode = XmlConvert.ToBoolean(reader.ReadElementContentAsString().Trim());
                        break;
                    case "LaunchInDebugModeComment":
                        // This schema member is an XML comment, never an element.
                        throw new InvalidOperationException("LaunchInDebugModeComment must not be an XML element.");
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.ReadEndElement();
            return settings;
        }

        private static bool MoveToElementOrEnd(XmlReader reader)
        {
            while (true)
            {
                var type = reader.MoveToContent();
                if (type == XmlNodeType.Element) return true;
                if (type == XmlNodeType.EndElement) return false;
                if (!reader.Read()) throw new XmlException("Unexpected end of Settings XML.");
            }
        }

        private static void ValidateXmlType(XmlReader reader, string expected)
        {
            var type = reader.GetAttribute("type", SchemaInstanceNamespace);
            if (type == null) return;
            type = type.Trim();
            var colon = type.IndexOf(':');
            var prefix = colon < 0 ? "" : type.Substring(0, colon);
            var name = colon < 0 ? type : type.Substring(colon + 1);
            if (name != expected || reader.LookupNamespace(prefix) != "")
                throw new InvalidOperationException("Unexpected Settings XML type: " + type);
        }
    }
}
