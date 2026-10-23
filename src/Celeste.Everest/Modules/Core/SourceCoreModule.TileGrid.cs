using System;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.Tiles;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private ILHook tileGridRenderClipHook;

        private void InstallSourceTileGridRenderClipHook()
        {
            tileGridRenderClipHook = new ILHook(typeof(TileGrid).GetMethod(nameof(TileGrid.RenderAt)),
                PatchSourceTileGridRenderClip);
        }

        private void PatchSourceTileGridRenderClip(ILContext il)
        {
            var cursor = new ILCursor(il);
            cursor.GotoNext(MoveType.Before,
                instruction => instruction.MatchCall<TileGrid>(nameof(TileGrid.GetClippedRenderTiles)) ||
                               instruction.MatchCallvirt<TileGrid>(nameof(TileGrid.GetClippedRenderTiles)));
            cursor.Emit(OpCodes.Dup);
            cursor.EmitDelegate<Action<TileGrid>>(InitializeSourceTileGridRenderClip);
        }

        private void InitializeSourceTileGridRenderClip(TileGrid grid)
        {
            if (grid.ClipCamera == null && grid.Scene is OriginalLevelSceneRoot level &&
                ReferenceEquals(level.EngineContext, SourceEngine))
                grid.ClipCamera = level.Camera;
        }
    }
}
