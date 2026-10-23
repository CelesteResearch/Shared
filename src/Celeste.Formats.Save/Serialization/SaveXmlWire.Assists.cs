using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteAssists(string name, Assists value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(new XElement("GameSpeed", XmlConvert.ToString(value.GameSpeed)));
        element.Add(new XElement("Invincible", XmlConvert.ToString(value.Invincible)));
        element.Add(new XElement("DashMode", WriteDashMode(value.DashMode)));
        element.Add(new XElement("DashAssist", XmlConvert.ToString(value.DashAssist)));
        element.Add(new XElement("InfiniteStamina", XmlConvert.ToString(value.InfiniteStamina)));
        element.Add(new XElement("MirrorMode", XmlConvert.ToString(value.MirrorMode)));
        element.Add(new XElement("ThreeSixtyDashing", XmlConvert.ToString(value.ThreeSixtyDashing)));
        element.Add(new XElement("InvisibleMotion", XmlConvert.ToString(value.InvisibleMotion)));
        element.Add(new XElement("NoGrabbing", XmlConvert.ToString(value.NoGrabbing)));
        element.Add(new XElement("LowFriction", XmlConvert.ToString(value.LowFriction)));
        element.Add(new XElement("SuperDashing", XmlConvert.ToString(value.SuperDashing)));
        element.Add(new XElement("Hiccups", XmlConvert.ToString(value.Hiccups)));
        element.Add(new XElement("PlayAsBadeline", XmlConvert.ToString(value.PlayAsBadeline)));
        return element;
    }

    internal static Assists ReadAssists(XElement element, bool nullable)
    {
        ValidateType(element, "Assists");
        if (nullable && IsNil(element)) return null;
        var value = new Assists();
        var fieldGameSpeed = element.Element("GameSpeed");
        if (fieldGameSpeed != null) value.GameSpeed = XmlConvert.ToInt32(ReadText(fieldGameSpeed));
        var fieldInvincible = element.Element("Invincible");
        if (fieldInvincible != null) value.Invincible = XmlConvert.ToBoolean(ReadText(fieldInvincible));
        var fieldDashMode = element.Element("DashMode");
        if (fieldDashMode != null) value.DashMode = ReadDashMode(ReadText(fieldDashMode));
        var fieldDashAssist = element.Element("DashAssist");
        if (fieldDashAssist != null) value.DashAssist = XmlConvert.ToBoolean(ReadText(fieldDashAssist));
        var fieldInfiniteStamina = element.Element("InfiniteStamina");
        if (fieldInfiniteStamina != null) value.InfiniteStamina = XmlConvert.ToBoolean(ReadText(fieldInfiniteStamina));
        var fieldMirrorMode = element.Element("MirrorMode");
        if (fieldMirrorMode != null) value.MirrorMode = XmlConvert.ToBoolean(ReadText(fieldMirrorMode));
        var fieldThreeSixtyDashing = element.Element("ThreeSixtyDashing");
        if (fieldThreeSixtyDashing != null)
            value.ThreeSixtyDashing = XmlConvert.ToBoolean(ReadText(fieldThreeSixtyDashing));
        var fieldInvisibleMotion = element.Element("InvisibleMotion");
        if (fieldInvisibleMotion != null) value.InvisibleMotion = XmlConvert.ToBoolean(ReadText(fieldInvisibleMotion));
        var fieldNoGrabbing = element.Element("NoGrabbing");
        if (fieldNoGrabbing != null) value.NoGrabbing = XmlConvert.ToBoolean(ReadText(fieldNoGrabbing));
        var fieldLowFriction = element.Element("LowFriction");
        if (fieldLowFriction != null) value.LowFriction = XmlConvert.ToBoolean(ReadText(fieldLowFriction));
        var fieldSuperDashing = element.Element("SuperDashing");
        if (fieldSuperDashing != null) value.SuperDashing = XmlConvert.ToBoolean(ReadText(fieldSuperDashing));
        var fieldHiccups = element.Element("Hiccups");
        if (fieldHiccups != null) value.Hiccups = XmlConvert.ToBoolean(ReadText(fieldHiccups));
        var fieldPlayAsBadeline = element.Element("PlayAsBadeline");
        if (fieldPlayAsBadeline != null) value.PlayAsBadeline = XmlConvert.ToBoolean(ReadText(fieldPlayAsBadeline));
        return value;
    }
}
