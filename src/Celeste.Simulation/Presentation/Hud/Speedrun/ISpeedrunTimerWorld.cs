using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Hud.Speedrun
{
    // Host contract of the SpeedrunTimerDisplay port. Member -> original call site
    // (Artifacts/Reference/Original/Celeste/SpeedrunTimerDisplay.cs):
    //   :52     (scene as Level)                                -> the state IS the level's HUD entity
    //   :53     level.Completed                                 -> LevelCompleted
    //   :59     Engine.DeltaTime                                -> the dt passed to Update
    //   :62     level.Session.Area.ID                           -> AreaId
    //   :62     level.TimerHidden                               -> TimerHidden
    //   :64/:71 Settings.Instance.SpeedrunClock                 -> Clock
    //   :80-107 Render: bg.Draw / Draw.Rect / font glyphs       -> the three draw hooks below
    //   :89/:98 session.Time, SaveData.Instance.Time            -> SessionTimeTicks / SaveTimeTicks
    //   :91/:106 session.StartedFromBeginning, level.Completed,
    //            session.BeatBestTime                           -> StartedFromBeginning/LevelCompleted/BeatBestTime
    public interface ISpeedrunTimerWorld
    {
        // Level.Session.Area.ID (SpeedrunTimerDisplay.cs:62).
        int AreaId { get; }

        // Level.TimerHidden (SpeedrunTimerDisplay.cs:62). Set by BadelineBoost.cs:248,
        // CS10_Farewell.cs:25, CS10_Ending.cs:35/:253/:262; Level.LoadLevel clears it (Level.cs:142).
        bool TimerHidden { get; }

        // Level.Completed (SpeedrunTimerDisplay.cs:53/:91/:106).
        bool LevelCompleted { get; }

        // Settings.Instance.SpeedrunClock (SpeedrunTimerDisplay.cs:64/:71/:87/:93).
        SpeedrunClockMode Clock { get; }

        // Level.Session.Time, in TimeSpan ticks (SpeedrunTimerDisplay.cs:89/:95).
        long SessionTimeTicks { get; }

        // SaveData.Instance.Time, in TimeSpan ticks (SpeedrunTimerDisplay.cs:98).
        long SaveTimeTicks { get; }

        // Level.Session.StartedFromBeginning (SpeedrunTimerDisplay.cs:91/:106).
        bool StartedFromBeginning { get; }

        // Level.Session.BeatBestTime (SpeedrunTimerDisplay.cs:91/:106).
        bool BeatBestTime { get; }

        // GFX.Gui["strawberryCountBG"].Draw(position) / .Draw(position, origin, color, scale)
        // (SpeedrunTimerDisplay.cs:90/:103/:105; Monocle/MTexture.cs:213-234).
        void DrawBackground(ICollection<ImagePlacement> target, Vector2 position,
            Vector2 origin, Vector4 color,
            float scale);

        // Monocle.Draw.Rect (SpeedrunTimerDisplay.cs:102). The original truncates through Draw.rect's
        // int fields (Monocle/Draw.cs:138-145).
        void DrawRect(ICollection<ImagePlacement> target, float x, float y,
            float width, float height, Vector4 color);

        // PixelFont.DrawOutline(fontFaceSize, glyph, position, (0.5f,1f), Vector2.One * num, color3, 2f, Black)
        // (SpeedrunTimerDisplay.cs:145).
        void DrawGlyph(ICollection<ImagePlacement> target, string glyph,
            Vector2 position, Vector2 justify,
            Vector2 scale, Vector4 color);
    }
}
