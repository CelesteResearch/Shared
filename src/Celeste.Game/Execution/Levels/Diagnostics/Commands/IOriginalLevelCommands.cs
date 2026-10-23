using System.Numerics;
using Celeste.Core.Rendering.Cameras;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Execution.Levels.Diagnostics.Commands
{
    public interface IOriginalLevelCommands
    {
        string LevelName { get; }
        OriginalAreaKey Area { get; }
        Vector2 LevelOffset { get; }
        ISourceCommandsCamera Camera { get; }
        Vector2 ScreenToWorld(Vector2 screen);
        Vector2 WorldToScreen(Vector2 world);
    }
}
