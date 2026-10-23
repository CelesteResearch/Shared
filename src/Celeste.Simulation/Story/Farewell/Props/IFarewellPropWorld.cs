using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Props
{
    public interface IFarewellPropWorld
    {
        global::Celeste.Simulation.Story.Farewell.Props.IFarewellPropPlayer FirstPlayer { get; }
        global::Celeste.Core.Geometry.Bounds LevelBounds { get; }
        Vector2 CameraPosition { get; set; }
        float SceneTime { get; }

        Random Random { get; }

        // Original `Added` constructs its clones with `GFX.SpriteBank.Create(...)`, so the same
        // shared bank has to be reachable from the state.
        global::Celeste.Graphics.Animation.ISpriteFactory SpriteBank { get; }
        bool GetFlag(string name);
        void SetFlag(string name, bool value = true);
        void AddDoNotLoad(global::Celeste.Core.Maps.MapEntityId entityId);
        bool SolidAt(global::Celeste.Core.Geometry.Bounds bounds);
        bool OnInterval(float interval);
        void PlaySound(string sound, Vector2 position);
        void PlaySound(string sound);
        void Rumble(int strength, int length);
        void Shake(float duration);
        global::Celeste.Simulation.Story.Farewell.Props.IFarewellPropSound CreateSound();

        void AddSpeedRing(Vector2 position, float direction, Vector4 color);

        // AscendManager.cs:263-269 constructs Streaks (always) and Clouds (only when !Dark) at this
        // exact point of the routine, so the host must build them here to keep the shared
        // Calc.Random stream in step. `manager` is the manager the presentations read Dark/Fade from.
        void SpawnAscendContents(int index, bool dark, object manager);
        void AddCutscene(string cutscene, int index, bool dark);
        bool CutsceneRunning(string cutscene);
        void AddFreeBirdEnding();
        void AddHeightDisplay(int index);
        void SetAmbience(string sound);
        void SetSnowAlpha(float alpha);
        void SetBloom(float add);
        void SetParallaxCameraOffsetY(float amount);
        void SetForegroundAlpha(float alpha);
        void SetCanRetry(bool value);
        void SetNextTransitionDuration(float value);
        void BeginFader();
        void SetFader(float fade);
        void BeginMountainWipe();
        void DoAreaWipe(int areaIndex);
        void SetWipeColor(bool dark);
        void SetWipeColorReset();
        void SnapCamera(Vector2 focus);
    }
}
