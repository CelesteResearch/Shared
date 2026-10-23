using System;

namespace Celeste.Core.Framework.Components
{
    public interface ISourceUpdateable
    {
        bool Enabled { get; }
        int UpdateOrder { get; }
        event EventHandler<EventArgs> EnabledChanged;
        event EventHandler<EventArgs> UpdateOrderChanged;
        void Update(SourceGameTime gameTime);
    }
}
