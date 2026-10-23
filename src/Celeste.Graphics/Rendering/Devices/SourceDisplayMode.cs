using Celeste.Core.Framework.Graphics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;
using System;

namespace Celeste.Graphics.Rendering.Devices
{
    [Serializable]
    public class SourceDisplayMode : ISourceScreenDisplayMode
    {
        public float AspectRatio => (float)Width / (float)Height;

        public SourceSurfaceFormat Format { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public IntRect TitleSafeArea => new IntRect(0, 0, Width, Height);

        internal SourceDisplayMode(int width, int height, SourceSurfaceFormat format)
        {
            Width = width;
            Height = height;
            Format = format;
        }

        public static bool operator !=(SourceDisplayMode left, SourceDisplayMode right)
        {
            return !(left == right);
        }

        public static bool operator ==(SourceDisplayMode left, SourceDisplayMode right)
        {
            if ((object)left == right)
            {
                return true;
            }

            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            if (left.Format == right.Format && left.Height == right.Height)
            {
                return left.Width == right.Width;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return obj as SourceDisplayMode == this;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode() ^ Format.GetHashCode();
        }

        public override string ToString()
        {
            return "{{Width:" + Width + " Height:" + Height + " Format:" + Format.ToString() + "}}";
        }
    }
}
