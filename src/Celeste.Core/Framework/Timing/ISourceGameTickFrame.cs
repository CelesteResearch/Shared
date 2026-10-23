using Celeste.Core.Framework.Components;

namespace Celeste.Core.Framework.Timing
{
    public interface ISourceGameTickFrame
    {
        void AssertNotDisposed();
        void Update(SourceGameTime gameTime);
        bool BeginDraw();
        void Draw(SourceGameTime gameTime);
        void EndDraw();
    }
}
