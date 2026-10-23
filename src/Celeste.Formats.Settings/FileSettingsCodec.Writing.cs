using System.Xml;

namespace Celeste.Formats.Settings
{
    public static partial class FileSettingsCodec
    {
        private static void WriteSettings(XmlWriter writer, FileSettingsXml settings)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Settings");
            writer.WriteAttributeString("xmlns", "xsi", null, SchemaInstanceNamespace);
            writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
            WriteText(writer, "Version", settings.Version);
            WriteText(writer, "DefaultFileName", settings.DefaultFileName);
            WriteText(writer, "Fullscreen", XmlConvert.ToString(settings.Fullscreen));
            WriteText(writer, "WindowScale", XmlConvert.ToString(settings.WindowScale));
            WriteText(writer, "ViewportPadding", XmlConvert.ToString(settings.ViewportPadding));
            WriteText(writer, "VSync", XmlConvert.ToString(settings.VSync));
            WriteText(writer, "DisableFlashes", XmlConvert.ToString(settings.DisableFlashes));
            WriteText(writer, "ScreenShake", FormatFileScreenShake(settings.ScreenShake));
            WriteText(writer, "Rumble", FormatFileRumble(settings.Rumble));
            WriteText(writer, "GrabMode", FormatFileGrabMode(settings.GrabMode));
            WriteText(writer, "CrouchDashMode", FormatFileCrouchDashMode(settings.CrouchDashMode));
            WriteText(writer, "MusicVolume", XmlConvert.ToString(settings.MusicVolume));
            WriteText(writer, "SFXVolume", XmlConvert.ToString(settings.SFXVolume));
            WriteText(writer, "SpeedrunClock", FormatFileSpeedrunClock(settings.SpeedrunClock));
            WriteText(writer, "LastSaveFile", XmlConvert.ToString(settings.LastSaveFile));
            WriteText(writer, "Language", settings.Language);
            WriteText(writer, "Pico8OnMainMenu", XmlConvert.ToString(settings.Pico8OnMainMenu));
            WriteText(writer, "SetViewportOnce", XmlConvert.ToString(settings.SetViewportOnce));
            WriteText(writer, "VariantsUnlocked", XmlConvert.ToString(settings.VariantsUnlocked));
            WriteBinding(writer, "Left", settings.Left);
            WriteBinding(writer, "Right", settings.Right);
            WriteBinding(writer, "Down", settings.Down);
            WriteBinding(writer, "Up", settings.Up);
            WriteBinding(writer, "MenuLeft", settings.MenuLeft);
            WriteBinding(writer, "MenuRight", settings.MenuRight);
            WriteBinding(writer, "MenuDown", settings.MenuDown);
            WriteBinding(writer, "MenuUp", settings.MenuUp);
            WriteBinding(writer, "Grab", settings.Grab);
            WriteBinding(writer, "Jump", settings.Jump);
            WriteBinding(writer, "Dash", settings.Dash);
            WriteBinding(writer, "Talk", settings.Talk);
            WriteBinding(writer, "Pause", settings.Pause);
            WriteBinding(writer, "Confirm", settings.Confirm);
            WriteBinding(writer, "Cancel", settings.Cancel);
            WriteBinding(writer, "Journal", settings.Journal);
            WriteBinding(writer, "QuickRestart", settings.QuickRestart);
            WriteBinding(writer, "DemoDash", settings.DemoDash);
            WriteBinding(writer, "RightMoveOnly", settings.RightMoveOnly);
            WriteBinding(writer, "LeftMoveOnly", settings.LeftMoveOnly);
            WriteBinding(writer, "UpMoveOnly", settings.UpMoveOnly);
            WriteBinding(writer, "DownMoveOnly", settings.DownMoveOnly);
            WriteBinding(writer, "RightDashOnly", settings.RightDashOnly);
            WriteBinding(writer, "LeftDashOnly", settings.LeftDashOnly);
            WriteBinding(writer, "UpDashOnly", settings.UpDashOnly);
            WriteBinding(writer, "DownDashOnly", settings.DownDashOnly);
            WriteText(writer, "LaunchWithFMODLiveUpdate", XmlConvert.ToString(settings.LaunchWithFMODLiveUpdate));
            WriteText(writer, "LaunchInDebugMode", XmlConvert.ToString(settings.LaunchInDebugMode));
            writer.WriteComment(settings.DebugModeComment.Value);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        private static void WriteText(XmlWriter writer, string name, string value)
        {
            if (value != null) writer.WriteElementString(name, value);
        }
    }
}
