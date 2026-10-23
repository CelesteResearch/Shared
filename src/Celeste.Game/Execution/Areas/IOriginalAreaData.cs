using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaData
    {
        int ID { get; }
        int MountainState { get; set; }
        Vector3 MountainCursor { get; set; }
        MountainCameraState MountainIdle { get; set; }
        MountainCameraState MountainSelect { get; set; }
        MountainCameraState MountainZoom { get; set; }

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
        RoomCoreMode CoreMode { get; }
        bool Interlude { get; }
        bool CanFullClear { get; }
        string LevelSet { get; }
        Action<ISourceRendererScene, bool, Action> Wipe { get; }
        PlayerIntroType IntroType { get; }
        string Spike { get; }
        string WoodPlatform { get; }
        string Jumpthru { get; }
        string CrumbleBlock { get; set; }
        float DarknessAlpha { get; }
        float BloomBase { get; }
        float BloomStrength { get; }
        string CassetteSong { get; set; }
        Action<OriginalLevelSceneRoot> OnLevelBegin { get; }
        PackedColor[] CobwebColor { get; set; }
        OriginalAreaModeData[] Mode { get; }
        int ModeCount { get; }
        bool HasMode(int mode);
        OriginalAreaModeData GetOriginalMode(int mode);
    }
}
