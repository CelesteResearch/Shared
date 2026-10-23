using System;

namespace Celeste.Core.Framework.Components
{
    public interface ISourceDrawable
    {
        bool Visible { get; }
        int DrawOrder { get; }
        event EventHandler<EventArgs> VisibleChanged;
        event EventHandler<EventArgs> DrawOrderChanged;
        void Draw(SourceGameTime gameTime);
    }
}
