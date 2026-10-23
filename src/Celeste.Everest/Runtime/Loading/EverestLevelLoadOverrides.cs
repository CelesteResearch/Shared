using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Everest.Runtime.Loading
{
    public static class EverestLevelLoadOverrides
    {
        private static readonly ConditionalWeakTable<OriginalLevelSceneRoot, EverestLevelLoadOverride>
            overrides = new();

        public static RoomPlayerSession NextLoadedPlayer;
        public static int SkipScreenWipes;
        public static bool ShouldAutoPause;
        private static RoomPlayerSession playerOverride;

        public static void Register(OriginalLevelSceneRoot level, EverestLevelLoadOverride value)
        {
            if (value.HasOverrides) overrides.Add(level, value);
        }

        private static RoomPlayerSession LoadNewPlayer(Vector2 position, PlayerSpriteMode mode,
            OriginalLevelSceneRoot level)
        {
            if (playerOverride != null) return playerOverride;
            var next = NextLoadedPlayer;
            if (next != null)
            {
                NextLoadedPlayer = null;
                return next;
            }

            return level.CreateOriginalPlayer(position, mode);
        }

        public static RoomPlayerSession LoadNewPlayerForLevel(Vector2 position, PlayerSpriteMode mode,
            OriginalLevelSceneRoot level)
        {
            if (overrides.TryGetValue(level, out var value))
            {
                var next = value.NextLoadedPlayer;
                if (next is { Dead: false })
                {
                    var selected = value.NextLoadedPlayer;
                    try
                    {
                        playerOverride = selected;
                        var player = LoadNewPlayer(position, mode, level);
                        if (player != selected) return player;
                    }
                    finally
                    {
                        playerOverride = null;
                    }

                    value.NextLoadedPlayer = null;
                    if (!value.HasOverrides) overrides.Remove(level);
                    return selected;
                }
            }

            return LoadNewPlayer(position, mode, level);
        }

        public static bool SkipWipe(OriginalLevelSceneRoot level, Action onComplete, bool hiresSnow)
        {
            if (onComplete == null && !hiresSnow)
            {
                if (SkipScreenWipes > 0)
                {
                    SkipScreenWipes--;
                    return true;
                }

                if (overrides.TryGetValue(level, out var value) && value.SkipScreenWipes > 0)
                {
                    value.SkipScreenWipes--;
                    if (!value.HasOverrides) overrides.Remove(level);
                    return true;
                }
            }

            return false;
        }

        public static bool TakeAutoPause(OriginalLevelSceneRoot level)
        {
            if (!overrides.TryGetValue(level, out var value) || !value.ShouldAutoPause) return false;
            value.ShouldAutoPause = false;
            if (!value.HasOverrides) overrides.Remove(level);
            return true;
        }
    }
}
