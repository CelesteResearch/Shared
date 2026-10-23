using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Scene.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Platforms.Cassette;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Geometry.ThreeD.Camera;

namespace Celeste.Game.Execution.Areas
{
    public class OriginalAreaData : IOriginalAreaData,
        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionAreaData
    {
        public string Name;
        public string Icon;
        public int ID;
        public bool Interlude;
        public bool CanFullClear;
        public bool IsFinal;
        public string CompleteScreenName;
        public OriginalAreaModeData[] Mode;
        public int CassetteCheckpointIndex = -1;
        public PackedColor TitleBaseColor = PackedColor.White;
        public PackedColor TitleAccentColor = PackedColor.Gray;
        public PackedColor TitleTextColor = PackedColor.White;
        public PlayerIntroType IntroType;
        public bool Dreaming;
        public string ColorGrade;
        public Action<ISourceRendererScene, bool, Action> Wipe;
        public float DarknessAlpha = .05f;
        public float BloomBase;
        public float BloomStrength = 1f;
        public Action<OriginalLevelSceneRoot> OnLevelBegin;
        public string Jumpthru = "wood";
        public string Spike = "default";
        public string CrumbleBlock = "default";
        public string WoodPlatform = "default";
        public PackedColor CassseteNoteColor = PackedColor.White;
        public PackedColor[] CobwebColor = new PackedColor[] { SourceHexColor.HexToColor("696a6a") };
        public string CassetteSong = "event:/music/cassette/01_forsaken_city";
        public RoomCoreMode CoreMode;
        public int MountainState;
        public MountainCameraState MountainIdle;
        public MountainCameraState MountainSelect;
        public MountainCameraState MountainZoom;
        public Vector3 MountainCursor;
        public float MountainCursorScale;

        protected virtual string GetSID() => null;
        public virtual string LevelSet => "Celeste";
        public int ModeCount => Mode.Length;
        public bool HasMode(int mode) => Mode.Length > mode && Mode[mode] != null && Mode[mode].Path != null;
        public OriginalAreaModeData GetOriginalMode(int mode) => Mode[mode];

        string global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionAreaData.ColorGrade => ColorGrade;
        int IOriginalAreaData.ID => ID;
        string IOriginalAreaData.Name => Name;
        string IOriginalAreaData.Icon => Icon;
        string IOriginalAreaData.CompleteScreenName => CompleteScreenName;
        string IOriginalAreaData.ColorGrade => ColorGrade;
        string IOriginalAreaData.SID => GetSID();
        PackedColor IOriginalAreaData.TitleBaseColor => TitleBaseColor;
        PackedColor IOriginalAreaData.TitleAccentColor => TitleAccentColor;
        PackedColor IOriginalAreaData.TitleTextColor => TitleTextColor;
        bool IOriginalAreaData.IsFinal => IsFinal;
        int IOriginalAreaData.CassetteCheckpointIndex => CassetteCheckpointIndex;
        bool IOriginalAreaData.Dreaming => Dreaming;
        RoomCoreMode IOriginalAreaData.CoreMode => CoreMode;
        bool IOriginalAreaData.Interlude => Interlude;
        bool IOriginalAreaData.CanFullClear => CanFullClear;
        Action<ISourceRendererScene, bool, Action> IOriginalAreaData.Wipe => Wipe;
        PlayerIntroType IOriginalAreaData.IntroType => IntroType;
        string IOriginalAreaData.Spike => Spike;
        string IOriginalAreaData.Jumpthru => Jumpthru;

        string IOriginalAreaData.CrumbleBlock
        {
            get => CrumbleBlock;
            set => CrumbleBlock = value;
        }

        string IOriginalAreaData.WoodPlatform => WoodPlatform;
        float IOriginalAreaData.DarknessAlpha => DarknessAlpha;
        float IOriginalAreaData.BloomBase => BloomBase;
        float IOriginalAreaData.BloomStrength => BloomStrength;

        string IOriginalAreaData.CassetteSong
        {
            get => CassetteSong;
            set => CassetteSong = value;
        }

        Action<OriginalLevelSceneRoot> IOriginalAreaData.OnLevelBegin => OnLevelBegin;

        PackedColor[] IOriginalAreaData.CobwebColor
        {
            get => CobwebColor;
            set => CobwebColor = value;
        }

        OriginalAreaModeData[] IOriginalAreaData.Mode => Mode;

        int IOriginalAreaData.MountainState
        {
            get => MountainState;
            set => MountainState = value;
        }

        Vector3 IOriginalAreaData.MountainCursor
        {
            get => MountainCursor;
            set => MountainCursor = value;
        }

        MountainCameraState IOriginalAreaData.MountainIdle
        {
            get => MountainIdle;
            set => MountainIdle = value;
        }

        MountainCameraState IOriginalAreaData.MountainSelect
        {
            get => MountainSelect;
            set => MountainSelect = value;
        }

        MountainCameraState IOriginalAreaData.MountainZoom
        {
            get => MountainZoom;
            set => MountainZoom = value;
        }
    }
}
