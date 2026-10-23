using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Rendering
{
    public sealed class PlayerDashAssistPresentation : SceneEntityState
    {
        private readonly List<AtlasEntry> images;
        public float Direction, Scale;
        public Vector2 Offset;
        public float Timer { get; private set; }
        public bool Paused { get; private set; }
        public int LastIndex { get; private set; }

        public PlayerDashAssistPresentation(ISourceEngineContext engine, int globalTag,
            AtlasData atlas)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Tags = new(globalTag);
            Depth = -1000000;
            Visible = false;
            images = atlas.Frames("util/dasharrow/dasharrow");
        }

        // Player.DashAssistInit leaves timer, paused and lastIndex intact on re-entry.
        public void Initialize(float direction, Vector2 offset)
        {
            Direction = direction;
            Scale = 0;
            Offset = offset;
        }

        private IPlayerDashAssistScene ActualScene => (IPlayerDashAssistScene)Scene;

        private RoomPlayerSession FirstPlayer()
        {
            var entities =
                ActualScene.Scheduler.Entities.GetTrackedEntities(typeof(RoomPlayerSession)
                    .FullName);
            return entities.Count == 0 ? null : (RoomPlayerSession)entities[0];
        }

        private static Vector2 PlayerCenter(RoomPlayerSession player)
        {
            var collider = player.Collider;
            return player.Body.Position +
                   (collider == null ? Vector2.Zero : new(collider.CenterX, collider.CenterY));
        }

        public override void Update()
        {
            var scene = ActualScene;
            var engine = scene.EngineContext;
            var freeze = engine.Effects.DashAssistFreeze;
            var scenePaused = scene.Paused;
            float dt = engine.DeltaTime, rawDt = engine.RawDeltaTime;
            if (!freeze)
            {
                if (Paused)
                {
                    if (!scenePaused) scene.PauseGameplaySfx(false);
                    Timer = 0;
                    Paused = false;
                }

                return;
            }

            Paused = true;
            scene.PauseGameplaySfx(true);
            Timer += rawDt;
            // Original EnableSnapshot is empty, including when Timer > .2f.
            var player = FirstPlayer();
            if (player == null) return;
            var aim = player.Input.GetAimVector(player.Data.Facing);
            var target = (float)Math.Atan2(aim.Y, aim.X);
            if (Math.Abs(AngleDiff(target, Direction)) >= 1.5807964f)
            {
                Direction = target;
                Scale = 0;
            }
            else
            {
                float difference = AngleDiff(Direction, target), maximum = (float)Math.PI * 6f * rawDt;
                Direction = Math.Abs(difference) < maximum
                    ? target
                    : Direction + Math.Max(-maximum, Math.Min(maximum, difference));
            }

            Scale = ScalarMath.Approach(Scale, 1f, dt * 4f);
            var index = 1 + (8 + (int)Math.Round(target / ((float)Math.PI / 4f))) % 8;
            if (LastIndex != 0 && LastIndex != index) scene.PlayDashAssistAim(PlayerCenter(player), index);
            LastIndex = index;
        }

        // Level.Render calls this explicitly even though Entity.Visible is false.
        public override void Render(ISourceRenderContext context)
        {
            var player = FirstPlayer();
            if (player == null || !ActualScene.EngineContext.Effects.DashAssistFreeze) return;
            var difference = float.MaxValue;
            AtlasEntry texture = null;
            for (var i = 0; i < 8; i++)
            {
                var angle = AngleDiff((float)Math.PI * 2f * (i / 8f), Direction);
                if (Math.Abs(angle) < Math.Abs(difference))
                {
                    difference = angle;
                    texture = images[i];
                }
            }

            if (texture == null) return;
            if (Math.Abs(difference) < .05f) difference = 0;
            var at = PlayerCenter(player) + Offset +
                     new Vector2((float)Math.Cos(Direction) * 20f, (float)Math.Sin(Direction) * 20f);
            at.X = (float)Math.Round(at.X);
            at.Y = (float)Math.Round(at.Y);
            var scale = ((ISourceEasingEnvironment)ActualScene.EngineContext)
                .EasingArithmetic.BounceOut(Scale);
            texture.DrawOutline((ISourceDrawScope)context,
                at, new(texture.FrameWidth / 2f, texture.FrameHeight / 2f),
                PackedColor.White, scale, difference);
        }

        private static float AngleDiff(float from, float to)
        {
            var difference = to - from;
            while (difference > (float)Math.PI) difference -= (float)Math.PI * 2f;
            while (difference <= -(float)Math.PI) difference += (float)Math.PI * 2f;
            return difference;
        }
    }
}
