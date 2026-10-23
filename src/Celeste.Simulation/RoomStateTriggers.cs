using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed class RoomStateTriggers
    {
        public enum Kind
        {
            NoRefill,
            Music,
            AltMusic,
            MusicFade,
            AmbienceParameter,
            LightFade,
            BloomFade,
            StopBoost
        }

        public enum PositionModes
        {
            NoEffect,
            HorizontalCenter,
            VerticalCenter,
            TopToBottom,
            BottomToTop,
            LeftToRight,
            RightToLeft
        }

        public sealed class Entry
        {
            public readonly global::Celeste.Core.Maps.MapElement Room, Source;
            public readonly Kind Type;
            public readonly global::Celeste.Core.Geometry.Bounds Bounds;
            public bool Collidable = true, Active = true;
            public bool Triggered { get; internal set; }
            public bool PlayerIsInside { get; private set; }
            public bool Removed { get; internal set; }
            public readonly bool State, ResetOnLeave, LeftToRight;
            public readonly string Track, Parameter;
            public readonly int Progress;
            public readonly float From, To;
            public readonly PositionModes PositionMode;
            public string OldTrack { get; private set; }

            public SceneTagSet Tags =>
                Type == Kind.LightFade ? OriginalSceneTags.TransitionUpdate : OriginalSceneTags.None;

            private readonly IRoomStateTriggerWorld world;

            internal Entry(global::Celeste.Core.Maps.MapElement room, global::Celeste.Core.Maps.MapElement source,
                Kind type, IRoomStateTriggerWorld world)
            {
                Room = room;
                Source = source;
                Type = type;
                this.world = world;
                Bounds = new global::Celeste.Core.Geometry.Bounds(room.Int("x") + source.Float("x"),
                    room.Int("y") + source.Float("y"),
                    source.Int("width"), source.Int("height"));
                State = ReadBool(source, "state", false);
                ResetOnLeave = ReadBool(source, "resetOnLeave", true);
                Track = source.Text("track");
                Progress = source.Int("progress");
                Parameter = source.Text("parameter");
                LeftToRight = source.Text("direction", "leftToRight") == "leftToRight";
                PositionMode =
                    Enum.TryParse(source.Text(type == Kind.AmbienceParameter ? "direction" : "positionMode"), true,
                        out PositionModes mode)
                        ? mode
                        : PositionModes.NoEffect;
                switch (type)
                {
                    case Kind.MusicFade:
                        From = source.Float("fadeA");
                        To = source.Float("fadeB", 1);
                        break;
                    case Kind.LightFade:
                        From = source.Float("lightAddFrom");
                        To = source.Float("lightAddTo");
                        break;
                    case Kind.BloomFade:
                        From = source.Float("bloomAddFrom");
                        To = source.Float("bloomAddTo");
                        break;
                    default:
                        From = source.Float("from");
                        To = source.Float("to");
                        break;
                }
            }

            public void OnEnter()
            {
                // Music/AltMusic override OnEnter without calling Trigger.OnEnter.
                switch (Type)
                {
                    case Kind.Music:
                        if (ResetOnLeave) OldTrack = world.CurrentMusic;
                        world.AudioSession.SetMusicHandle(Track, Progress);
                        break;
                    case Kind.AltMusic:
                        world.AudioSession.SetAltMusicHandle(Track); break;
                    default:
                        PlayerIsInside = true;
                        if (Type == Kind.NoRefill) world.NoRefills = State;
                        break;
                }
            }

            public void OnStay(Vector2 playerCenter)
            {
                switch (Type)
                {
                    case Kind.MusicFade:
                        float fade = LeftToRight
                            ? ClampedMap(playerCenter.X, Bounds.X, Bounds.Right, From, To)
                            : ClampedMap(playerCenter.Y, Bounds.Y, Bounds.Bottom, From, To);
                        world.AudioSession.SetMusicFade(Parameter, fade);
                        break;
                    case Kind.AmbienceParameter:
                        world.AudioSession.SetAmbienceParameter(Parameter,
                            ClampedMap(PositionLerp(playerCenter), 0, 1, From, To));
                        break;
                    case Kind.LightFade:
                        float light = From + (To - From) * Clamp(PositionLerp(playerCenter));
                        world.Environment.LightingAlphaAdd = light;
                        world.Environment.LightingAlpha = world.Environment.BaseLightingAlpha + light;
                        break;
                    case Kind.BloomFade:
                        float bloom = From + (To - From) * Clamp(PositionLerp(playerCenter));
                        world.Environment.BloomBaseAdd = bloom;
                        world.Environment.BloomBase = world.Environment.AreaBloomBase + bloom;
                        break;
                }
            }

            public void OnLeave()
            {
                switch (Type)
                {
                    case Kind.Music:
                        if (ResetOnLeave)
                        {
                            world.AudioSession.State.Music.Event = OldTrack;
                            ApplyAudio();
                        }

                        break;
                    case Kind.AltMusic:
                        if (ResetOnLeave) world.AudioSession.SetAltMusicHandle(null);
                        break;
                    default: PlayerIsInside = false; break;
                }
            }

            public float PositionLerp(Vector2 center)
            {
                switch (PositionMode)
                {
                    case PositionModes.LeftToRight: return ClampedMap(center.X, Bounds.X, Bounds.Right);
                    case PositionModes.RightToLeft: return ClampedMap(center.X, Bounds.Right, Bounds.X);
                    case PositionModes.TopToBottom: return ClampedMap(center.Y, Bounds.Y, Bounds.Bottom);
                    case PositionModes.BottomToTop: return ClampedMap(center.Y, Bounds.Bottom, Bounds.Y);
                    case PositionModes.HorizontalCenter:
                        return Math.Min(ClampedMap(center.X, Bounds.X, Bounds.X + Bounds.Width / 2),
                            ClampedMap(center.X, Bounds.Right, Bounds.X + Bounds.Width / 2));
                    case PositionModes.VerticalCenter:
                        return Math.Min(ClampedMap(center.Y, Bounds.Y, Bounds.Y + Bounds.Height / 2),
                            ClampedMap(center.Y, Bounds.Bottom, Bounds.Y + Bounds.Height / 2));
                    default: return 1;
                }
            }

            private void ApplyAudio()
            {
                world.AudioSession.Apply();
            }

            private static bool ReadBool(global::Celeste.Core.Maps.MapElement source, string name, bool fallback) =>
                bool.TryParse(source.Text(name), out bool value) ? value : fallback;
        }

        public readonly List<Entry> Entries = new List<Entry>();
        private readonly HashSet<Entry> inside = new HashSet<Entry>();

        private readonly IRoomStateTriggerWorld world;

        // Level.cs:1254-1256 constructs StopBoostTrigger for the "stopBoostTrigger" map entity, and
        // StopBoostTrigger.cs:12-19 is `OnEnter(Player player) { if (player.StateMachine.State == 10)
        // player.StopSummitLaunch(); }`; Player.cs:5082-5088 then sets State = 0, Speed.Y = -140 and
        // AutoJump. Without it a Summit Launch (state 10) cannot be cancelled by the map at all, which is
        // the "port stricter than the original" direction. The effect belongs to the player, so it is
        // handed in as a delegate instead of widening IRoomStateTriggerWorld, which every differential
        // fixture implements. `UpdatePlayer` already receives the player's state machine state.
        public Action StopSummitLaunch;

        public RoomStateTriggers(IRoomStateTriggerWorld world)
        {
            this.world = world ?? throw new ArgumentNullException(nameof(world));
        }

        public static bool TryGetKind(string name, out Kind kind)
        {
            switch (name)
            {
                case "noRefillTrigger":
                    kind = Kind.NoRefill;
                    return true;
                case "musicTrigger":
                    kind = Kind.Music;
                    return true;
                case "altMusicTrigger":
                    kind = Kind.AltMusic;
                    return true;
                case "musicFadeTrigger":
                    kind = Kind.MusicFade;
                    return true;
                case "ambienceParamTrigger":
                    kind = Kind.AmbienceParameter;
                    return true;
                case "lightFadeTrigger":
                    kind = Kind.LightFade;
                    return true;
                case "bloomFadeTrigger":
                    kind = Kind.BloomFade;
                    return true;
                // Level.cs:1254-1256 `case "stopBoostTrigger": Add(new StopBoostTrigger(trigger, vector));`
                case "stopBoostTrigger":
                    kind = Kind.StopBoost;
                    return true;
                default:
                    kind = default;
                    return false;
            }
        }

        public void AddRoom(global::Celeste.Core.Maps.MapElement room,
            Predicate<global::Celeste.Core.Maps.MapElement> shouldLoad = null)
        {
            foreach (global::Celeste.Core.Maps.MapElement source in room.Child("triggers")?.Children ??
                                                                    new List<global::Celeste.Core.Maps.MapElement>())
                if (TryGetKind(source.Name, out Kind kind) && (shouldLoad == null || shouldLoad(source)))
                    Entries.Add(new Entry(room, source, kind, world));
        }

        public void UpdatePlayer(global::Celeste.Core.Geometry.Bounds playerBounds, int state,
            global::Celeste.Core.Maps.MapElement source = null)
        {
            if (state == 18) return;
            var center = new Vector2(playerBounds.X + playerBounds.Width / 2, playerBounds.Y + playerBounds.Height / 2);
            foreach (var entry in Entries)
            {
                if (entry.Removed || source != null && !ReferenceEquals(source, entry.Source)) continue;
                if (entry.Collidable && entry.Bounds.Intersects(playerBounds))
                {
                    if (!entry.Triggered)
                    {
                        entry.Triggered = true;
                        inside.Add(entry);
                        entry.OnEnter();
                        // StopBoostTrigger.cs:12-19 - the check is on the state at the moment of entry.
                        if (entry.Type == Kind.StopBoost && state == 10) StopSummitLaunch?.Invoke();
                    }

                    entry.OnStay(center);
                }
                else if (entry.Triggered)
                {
                    inside.Remove(entry);
                    entry.Triggered = false;
                    entry.OnLeave();
                }
            }
        }

        public void CleanUpTriggers()
        {
            foreach (var entry in inside)
            {
                entry.OnLeave();
                entry.Triggered = false;
            }

            inside.Clear();
        }

        public void UnloadRoom(global::Celeste.Core.Maps.MapElement room)
        {
            foreach (var entry in Entries)
                if (ReferenceEquals(entry.Room, room))
                    entry.Removed = true;
            Entries.RemoveAll(e => e.Removed);
            // Player retains removed Trigger references until CleanUpTriggers.
        }

        public void Clear(bool sceneEnd = false)
        {
            if (!sceneEnd) CleanUpTriggers();
            else inside.Clear();
            foreach (var entry in Entries) entry.Removed = true;
            Entries.Clear();
        }

        private static float Clamp(float value) => value > 1 ? 1 : value < 0 ? 0 : value;

        private static float ClampedMap(float value, float min, float max, float newMin = 0, float newMax = 1) =>
            Clamp((value - min) / (max - min)) * (newMax - newMin) + newMin;
    }
}
