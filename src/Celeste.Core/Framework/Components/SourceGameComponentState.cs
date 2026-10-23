using System;

namespace Celeste.Core.Framework.Components
{
    public class SourceGameComponentState(SourceGameFrameworkState game) : ISourceGameComponent, ISourceUpdateable,
        IDisposable, IComparable<SourceGameComponentState>
    {
        private bool _enabled = true;
        private int _updateOrder;
        public SourceGameFrameworkState Game { get; private set; } = game;

        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value)
                    return;
                _enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
                OnEnabledChanged(this, null);
            }
        }

        public int UpdateOrder
        {
            get => _updateOrder;
            set
            {
                if (_updateOrder == value)
                    return;
                _updateOrder = value;
                if (UpdateOrderChanged != null)
                    UpdateOrderChanged(this, EventArgs.Empty);
                OnUpdateOrderChanged(this, null);
            }
        }

        ~SourceGameComponentState()
        {
            Dispose(false);
        }

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
            if (disposing && Disposed != null)
                Disposed(this, EventArgs.Empty);
        }

        int IComparable<SourceGameComponentState>.CompareTo(SourceGameComponentState other)
        {
            return unchecked(other.UpdateOrder - UpdateOrder);
        }
    }
}
