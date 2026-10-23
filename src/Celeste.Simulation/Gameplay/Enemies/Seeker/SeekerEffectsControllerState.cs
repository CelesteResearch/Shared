using Celeste.Scene.Scheduling;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public sealed class SeekerEffectsControllerState : global::Celeste.Scene.Tracking.ISceneEntityAssociation,
        global::Celeste.Scene.Tracking.ISceneEntityDepth
    {
        public readonly global::Celeste.Simulation.Gameplay.Enemies.Seeker.ISeekerEffectsWorld World;
        public bool Enabled = true, Active = true, Visible = true, Collidable = true;

        public global::Celeste.Scene.Tracking.SceneEntityDepthState DepthState { get; } =
            new global::Celeste.Scene.Tracking.SceneEntityDepthState(0);

        public int Depth
        {
            get => DepthState.RawDepth;
            set => DepthState.SetDepth(value, Scene, this);
        }

        public SceneTagSet Tags = OriginalSceneTags.Global;
        public float RandomAnxietyOffset { get; private set; }
        public object Scene { get; private set; }

        object global::Celeste.Scene.Tracking.ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        public SeekerEffectsControllerState(
            global::Celeste.Simulation.Gameplay.Enemies.Seeker.ISeekerEffectsWorld world)
        {
            World = world;
        }

        public void Added(object scene)
        {
            Scene = scene;
            World.SetMusicLayer(3, 0f);
            World.ApplyAudio();
        }

        public void Removed() => Scene = null;

        public void SceneEnd()
        {
        }

        public void Update(float dt)
        {
            if (!Enabled)
            {
                if (World.SeekerCount > 0) Enabled = true;
                return;
            }

            if (World.OnInterval(.05f)) RandomAnxietyOffset = -.2f + (float)World.Random.NextDouble() * .4f;
            var camera = World.CameraPosition;
            var player = World.FirstPlayer;
            float target, intensity;
            if (player != null && !player.Dead)
            {
                float nearest = -1, attacking = -1;
                foreach (var seeker in World.Seekers)
                {
                    float dx = player.Center.X - seeker.Center.X, dy = player.Center.Y - seeker.Center.Y;
                    float distance = dx * dx + dy * dy;
                    if (!seeker.Regenerating) nearest = nearest < 0 ? distance : Math.Min(nearest, distance);
                    if (seeker.Attacking) attacking = attacking < 0 ? distance : Math.Min(attacking, distance);
                }

                target = attacking >= 0 ? ClampedMap(attacking, 256, 4096, .5f, 1) : 1;
                World.AnxietyOrigin =
                    new Vector2((player.Center.X - camera.X) / 320f, (player.Center.Y - camera.Y) / 180f);
                intensity = nearest >= 0 ? ClampedMap(nearest, 256, 16384, 1, 0) : 0;
            }
            else
            {
                target = 1;
                intensity = 0;
            }

            World.TimeRate = global::Celeste.Core.Mathematics.ScalarMath.Approach(World.TimeRate, target, 4 * dt);
            World.GameRate = global::Celeste.Core.Mathematics.ScalarMath.Approach(World.GameRate,
                (World.TimeRate - .5f) / (1f - .5f) * (1f - 0f) + 0f,
                dt * 2);
            World.Anxiety = global::Celeste.Core.Mathematics.ScalarMath.Approach(World.Anxiety,
                (.5f + RandomAnxietyOffset) * intensity, 8 * dt);
            if (World.TimeRate == 1 && World.GameRate == 1 && World.Anxiety == 0 && World.SeekerCount == 0)
                Enabled = false;
        }

        static float ClampedMap(float value, float min, float max, float from, float to)
            => Math.Max(0, Math.Min(1, (value - min) / (max - min))) * (to - from) + from;
    }
}
