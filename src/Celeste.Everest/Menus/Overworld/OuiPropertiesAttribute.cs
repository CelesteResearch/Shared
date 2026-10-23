using System;

namespace Celeste.Everest.Menus.Overworld
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OuiPropertiesAttribute : Attribute
    {
        public bool PlayCustomMusic { get; }

        public OuiPropertiesAttribute(bool playCustomMusic = false)
        {
            PlayCustomMusic = playCustomMusic;
        }
    }
}
