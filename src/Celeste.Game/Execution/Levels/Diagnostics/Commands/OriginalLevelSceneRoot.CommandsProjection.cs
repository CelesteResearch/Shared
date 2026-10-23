using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering.Cameras;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels.Diagnostics.Commands;
using Celeste.Simulation.Save.Runtime;

// ReSharper disable once CheckNamespace
namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalLevelCommands
    {
        string IOriginalLevelCommands.LevelName => Session.Level;
        Vector2 IOriginalLevelCommands.LevelOffset => new(Bounds.Left, Bounds.Top);

        OriginalAreaKey IOriginalLevelCommands.Area
            => ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(Session);

        ISourceCommandsCamera IOriginalLevelCommands.Camera => Camera;

        public Vector2 ScreenToWorld(Vector2 position)
        {
            var arithmetic = ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;
            var vector = new Vector2(320f, 180f);
            var vector2 = arithmetic.Divide(vector, ZoomTarget);
            var vector3 = ZoomTarget != 1f
                ? Vector2ComponentDivision.Divide(ZoomFocusPoint - arithmetic.Divide(vector2, 2f), vector - vector2) *
                  vector
                : Vector2.Zero;
            var num = Zoom * ((320f - ScreenPadding * 2f) / 320f);
            var vector4 = new Vector2(ScreenPadding, ScreenPadding * 9f / 16f);
            var instance = ((ISourceCurrentSaveEnvironment)EngineContext).CurrentSave;
            if (instance != null && instance.MirrorMode)
                position.X = 1920f - position.X;
            position = arithmetic.Divide(position, 6f);
            position -= vector4;
            position = arithmetic.Divide(position - vector3, num) + vector3;
            position = Camera.ScreenToCamera(position);
            return position;
        }

        public Vector2 WorldToScreen(Vector2 position)
        {
            var arithmetic = ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;
            var vector = new Vector2(320f, 180f);
            var vector2 = arithmetic.Divide(vector, ZoomTarget);
            var vector3 = ZoomTarget != 1f
                ? Vector2ComponentDivision.Divide(ZoomFocusPoint - arithmetic.Divide(vector2, 2f), vector - vector2) *
                  vector
                : Vector2.Zero;
            var num = Zoom * ((320f - ScreenPadding * 2f) / 320f);
            var vector4 = new Vector2(ScreenPadding, ScreenPadding * 9f / 16f);
            position = Camera.CameraToScreen(position);
            position = (position - vector3) * num + vector3;
            position += vector4;
            position *= 6f;
            var instance = ((ISourceCurrentSaveEnvironment)EngineContext).CurrentSave;
            if (instance != null && instance.MirrorMode)
                position.X = 1920f - position.X;
            return position;
        }
    }
}
