using Celeste.Core.Components.Rendering;
using Celeste.Graphics.Content.Tiles;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Tiles;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public partial class SourceDecalEntityState
    {
        public void MakeOverlay()
        {
            var hook = new BeforeRenderCallbackComponentState(CreateOverlay);
            OwnedComponents.Add(hook);
        }

        private void CreateOverlay()
        {
            var tileset = new Tileset(Textures[0], 8, 8);
            for (var x = 0; x < Textures[0].FrameWidth / 8; x++)
            for (var y = 0; y < Textures[0].FrameHeight / 8; y++)
                TileInterceptorState.TileCheck(((ISourceScene)Scene).SourceScene.Components,
                    tileset[x, y], new(Position.X - Textures[0].FrameWidth * .5f + x * 8,
                        Position.Y - Textures[0].FrameHeight * .5f + y * 8));

            RemoveSelf();
        }
    }
}
