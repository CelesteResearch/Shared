using System;

namespace Celeste.Core.Framework.Components
{
    public class SourceGameComponentState : ISourceGameComponent, ISourceUpdateable,
        IDisposable, IComparable<SourceGameComponentState>
    {
        private bool enabled = true;
        private int updateOrder;
        public SourceGameFrameworkState Game { get; private set; }
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled
        {
            get => enabled;
            set
            {
                if (enabled == value) return;
                enabled = value;
                if (EnabledChanged != null) EnabledChanged(this, EventArgs.Empty);
                OnEnabledChanged(this, null);
            }
        }

        public int UpdateOrder
        {
            get => updateOrder;
            set
            {
                if (updateOrder == value) return;
                updateOrder = value;
                if (UpdateOrderChanged != null) UpdateOrderChanged(this, EventArgs.Empty);
                OnUpdateOrderChanged(this, null);
            }
        }

        public SourceGameComponentState(SourceGameFrameworkState game) => Game = game;
        ~SourceGameComponentState() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Initialize()
        {
        }

        public virtual void Update(SourceGameTime gameTime)
        {
        }

        protected virtual void OnUpdateOrderChanged(object sender, EventArgs args)
        {
        }

        protected virtual void OnEnabledChanged(object sender, EventArgs args)
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Disposed != null) Disposed(this, EventArgs.Empty);
        }

        int IComparable<SourceGameComponentState>.CompareTo(SourceGameComponentState other) =>
            unchecked(other.UpdateOrder - UpdateOrder);
    }
}
