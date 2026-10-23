using System;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceDrawState sourceDraw;

        public SourceDrawState Draw => sourceDraw ??
                                       throw new InvalidOperationException(
                                           "The source Draw static fields have not been born.");

        internal void ConstructSourceDrawState()
        {
            if (sourceDraw != null)
                throw new InvalidOperationException("The source Draw static fields are already born.");
            sourceDraw = new();
        }
    }
}
