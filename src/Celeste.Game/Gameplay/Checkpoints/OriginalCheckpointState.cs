using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Campaigns;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Checkpoints
{
    public class OriginalCheckpointState : SceneEntityState
    {
        private readonly IOriginalCheckpointProcess process;

        private const float LightAlpha = 0.8f;

        private const float BloomAlpha = 0.5f;

        private const float TargetFade = 0.5f;

        private SpriteImage image;

        private Sprite sprite;

        private Sprite flash;

        private VertexLightState light;

        private BloomPointState bloom;

        private bool triggered;

        private float sine = (float)Math.PI / 2f;

        private float fade = 1f;

        private readonly string bg;

        public Vector2 SpawnOffset;

        public OriginalCheckpointState(Vector2 position, IOriginalCheckpointProcess process, string bg = "",
            Vector2? spawnTarget = null)
            : base(
                ((ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                position)
        {
            this.process = process;
            Depth = 9990;
            SpawnOffset = spawnTarget.HasValue ? spawnTarget.Value - Position : Vector2.Zero;
            this.bg = bg;
        }

        public OriginalCheckpointState(EntityData data, Vector2 offset, IOriginalCheckpointProcess process)
            : this(data.Position + offset, process, EntityAttributeReader.Attr(data.Values, "bg"),
                data.Nodes != null && data.Nodes.Length > 0 ? data.Nodes[0] + offset : null)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var level = (OriginalLevelSceneRoot)Scene;
            var iD = process.AreaKeys.GetSessionArea(level.Session).ID;
            var text = "";
            text = !string.IsNullOrWhiteSpace(bg)
                ? "objects/checkpoint/bg/" + bg
                : "objects/checkpoint/bg/" + iD;
            if (process.GameGraphics.GameAtlas.Entries.ContainsKey(text))
            {
                image = new(process.GameGraphics.GameAtlas.Entries[text]);
                OwnedComponents.Add(image);
                image.JustifyOrigin(0.5f, 1f);
            }

            sprite = process.GameGraphics.SpriteFactory.Create("checkpoint_highlight");
            OwnedComponents.Add(sprite);
            sprite.Play("off");
            flash = process.GameGraphics.SpriteFactory.Create("checkpoint_flash");
            OwnedComponents.Add(flash);
            flash.Visible = false;
            flash.Color = PackedColor.White * .6f;
            if (process.SaveContext.HasCheckpoint(ToSaveArea(process.AreaKeys.GetSessionArea(level.Session)),
                    level.Session.Level))
                TurnOn(false);
        }

        public override void Update()
        {
            if (!triggered)
            {
                var level = (OriginalLevelSceneRoot)Scene;
                var entity =
                    level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null && !level.Transitioning)
                {
                    if (!SourceTrackedEntityCollision.Check(level.SourceScene.Entities,
                            "Celeste.CheckpointBlockerTrigger",
                            entity) && process.SaveContext.SetCheckpoint(
                            ToSaveArea(process.AreaKeys.GetSessionArea(level.Session)), level.Session.Level))
                    {
                        level.AutoSave();
                        TurnOn(true);
                    }

                    triggered = true;
                }
            }

            if (triggered && sprite.CurrentAnimationID == "on")
            {
                sine += process.DeltaTime * 2f;
                fade = ScalarMath.Approach(fade, 0.5f, process.DeltaTime, process.ExtremaArithmetic);
                var num = (float)(1.0 + Math.Sin(sine)) / 2f;
                sprite.Color = PackedColor.White * (.5f + num * .5f) * fade;
            }

            base.Update();
        }

        private static CampaignAreaKey ToSaveArea(OriginalAreaKey area)
        {
            return new(area.ID, area.Mode);
        }

        private void TurnOn(bool animate)
        {
            triggered = true;
            light = new(process, PackedColor.White, 0f, 16, 32);
            OwnedComponents.Add(light);
            bloom = new(0f, 16f);
            OwnedComponents.Add(bloom);
            light.Position = new(0f, -8f);
            bloom.Position = new(0f, -8f);
            flash.Visible = true;
            flash.Play("flash", true);
            if (animate)
            {
                sprite.Play("turnOn");
                OwnedComponents.Add(new SimulationCoroutine(process, EaseLightsOn()));
                fade = 1f;
            }
            else
            {
                fade = 0.5f;
                sprite.Play("on");
                sprite.Color = PackedColor.White * .5f;
                light.Alpha = 0.8f;
                bloom.Alpha = 0.5f;
            }
        }

        private IEnumerator EaseLightsOn()
        {
            var lightStartRadius = light.StartRadius;
            var lightEndRadius = light.EndRadius;
            for (var p = 0f; p < 1f; p += process.DeltaTime * 0.5f)
            {
                var num = process.EasingArithmetic.BigBackOut(p);
                light.Alpha = 0.8f * num;
                light.StartRadius = (int)(lightStartRadius + ScalarMath.YoYo(p) * 8f);
                light.EndRadius = (int)(lightEndRadius + ScalarMath.YoYo(p) * 16f);
                bloom.Alpha = 0.5f * num;
                yield return null;
            }
        }
    }
}
