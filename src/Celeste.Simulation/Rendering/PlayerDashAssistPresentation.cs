using Celeste.Core.Display;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Rendering
{
    public sealed class PlayerDashAssistPresentation : global::Celeste.Scene.Entities.SceneEntityState
    {
        private readonly List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> images;
        public float Direction, Scale;
        public Vector2 Offset;
        public float Timer { get; private set; }
        public bool Paused { get; private set; }
        public int LastIndex { get; private set; }

        public PlayerDashAssistPresentation(global::Celeste.Core.Scheduling.ISourceEngineContext engine, int globalTag,
            global::Celeste.Graphics.Content.Atlas.AtlasData atlas)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Tags = new global::Celeste.Scene.Scheduling.SceneTagSet(globalTag);
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
                ActualScene.Scheduler.Entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession)
                    .FullName);
            return entities.Count == 0 ? null : (RoomPlayerSession)entities[0];
        }

        private static Vector2 PlayerCenter(RoomPlayerSession player)
        {
            var collider = player.Collider;
            return player.Body.Position +
                   (collider == null ? Vector2.Zero : new Vector2(collider.CenterX, collider.CenterY));
        }

        public override void Update()
        {
            var scene = ActualScene;
            var engine = scene.EngineContext;
            bool freeze = engine.Effects.DashAssistFreeze;
            bool scenePaused = scene.Paused;
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
            Vector2 aim = player.Input.GetAimVector(player.Data.Facing);
            float target = (float)Math.Atan2(aim.Y, aim.X);
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

            Scale = global::Celeste.Core.Mathematics.ScalarMath.Approach(Scale, 1f, dt * 4f);
            int index = 1 + (8 + (int)Math.Round(target / ((float)Math.PI / 4f))) % 8;
            if (LastIndex != 0 && LastIndex != index) scene.PlayDashAssistAim(PlayerCenter(player), index);
            LastIndex = index;
        }

        // Level.Render calls this explicitly even though Entity.Visible is false.
        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var player = FirstPlayer();
            if (player == null || !ActualScene.EngineContext.Effects.DashAssistFreeze) return;
            float difference = float.MaxValue;
            global::Celeste.Graphics.Content.Atlas.AtlasEntry texture = null;
            for (int i = 0; i < 8; i++)
            {
                float angle = AngleDiff((float)Math.PI * 2f * ((float)i / 8f), Direction);
                if (Math.Abs(angle) < Math.Abs(difference))
                {
                    difference = angle;
                    texture = images[i];
                }
            }

            if (texture == null) return;
            if (Math.Abs(difference) < .05f) difference = 0;
            Vector2 at = PlayerCenter(player) + Offset +
                         new Vector2((float)Math.Cos(Direction) * 20f, (float)Math.Sin(Direction) * 20f);
            at.X = (float)Math.Round(at.X);
            at.Y = (float)Math.Round(at.Y);
            float scale = ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)ActualScene.EngineContext)
                .EasingArithmetic.BounceOut(Scale);
            texture.DrawOutline((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context,
                at, new Vector2(texture.FrameWidth / 2f, texture.FrameHeight / 2f),
                global::Celeste.Core.Display.PackedColor.White, scale, difference);
        }

        private static float AngleDiff(float from, float to)
        {
            float difference = to - from;
            while (difference > (float)Math.PI) difference -= (float)Math.PI * 2f;
            while (difference <= -(float)Math.PI) difference += (float)Math.PI * 2f;
            return difference;
        }
    }
}
