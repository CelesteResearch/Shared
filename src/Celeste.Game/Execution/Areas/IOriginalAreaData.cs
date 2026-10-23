using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaData
    {
        int ID { get; }
        int MountainState { get; set; }
        Vector3 MountainCursor { get; set; }
        global::Celeste.Graphics.Geometry.ThreeD.Camera.MountainCameraState MountainIdle { get; set; }
        global::Celeste.Graphics.Geometry.ThreeD.Camera.MountainCameraState MountainSelect { get; set; }
        global::Celeste.Graphics.Geometry.ThreeD.Camera.MountainCameraState MountainZoom { get; set; }

        string Name { get; }
        string Icon { get; }
        string CompleteScreenName { get; }
        string ColorGrade { get; }
        string SID { get; }
        PackedColor TitleBaseColor { get; }
        PackedColor TitleAccentColor { get; }
        PackedColor TitleTextColor { get; }
        bool IsFinal { get; }
        int CassetteCheckpointIndex { get; }
        bool Dreaming { get; }
        global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode CoreMode { get; }
        bool Interlude { get; }
        bool CanFullClear { get; }
        string LevelSet { get; }
        System.Action<global::Celeste.Scene.Rendering.ISourceRendererScene, bool, System.Action> Wipe { get; }
        global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType IntroType { get; }
        string Spike { get; }
        string WoodPlatform { get; }
        string Jumpthru { get; }
        string CrumbleBlock { get; set; }
        float DarknessAlpha { get; }
        float BloomBase { get; }
        float BloomStrength { get; }
        string CassetteSong { get; set; }
        System.Action<global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot> OnLevelBegin { get; }
        PackedColor[] CobwebColor { get; set; }
        OriginalAreaModeData[] Mode { get; }
        int ModeCount { get; }
        bool HasMode(int mode);
        OriginalAreaModeData GetOriginalMode(int mode);
    }
}
