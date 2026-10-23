using System.Collections.Generic;

namespace Celeste.Simulation.Dialogs.Portraits
{
    public sealed class PortraitMetadataSource
    {
        // Null means an absent XML attribute. Empty attribute values remain empty.
        public string Size { get; }
        public string Textbox { get; }
        public string PhoneStatic { get; }
        public string Sfx { get; }

        public string Glitchy { get; }

        // Null means no sfxs element; an empty list means a present empty element.
        public IReadOnlyList<PortraitSfxExpression> SfxExpressions { get; }

        public PortraitMetadataSource(string size, string textbox, string phoneStatic, string sfx,
            string glitchy, IReadOnlyList<PortraitSfxExpression> sfxExpressions)
        {
            Size = size;
            Textbox = textbox;
            PhoneStatic = phoneStatic;
            Sfx = sfx;
            Glitchy = glitchy;
            SfxExpressions = sfxExpressions;
        }
    }
}
