namespace Celeste.Graphics.Content.VirtualAssets
{
    public abstract class VirtualAsset
    {
        public string Name { get; protected internal set; }

        public int Width { get; protected internal set; }

        public int Height { get; protected internal set; }

        public virtual void Unload()
        {
        }

        public virtual void Reload()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
