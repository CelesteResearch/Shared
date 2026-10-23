using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Hahaha
{
    public class OriginalHahahaState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine)
        {
            return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;
        }

        private class Ha
        {
            public readonly Sprite Sprite;

            public float Percent;

            public readonly float Duration;

            public Ha(ISourceEngineContext engine)
            {
                Sprite = new(engine, Graphics(engine).GameAtlas, "characters/oldlady/");
                Sprite.Add("normal", "ha", 0.15f, 0, 1, 0, 1, 0, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
                Sprite.Play("normal");
                Sprite.JustifyOrigin(0.5f, 0.5f);
                Duration = Sprite.CurrentAnimationTotalFrames * 0.15f;
            }
        }

        private bool enabled;

        private readonly string ifSet;

        private float timer;

        private int counter;

        private readonly List<Ha> has = [];

        private readonly bool autoTriggerLaughSfx;

        private readonly Vector2 autoTriggerLaughOrigin;

        public bool Enabled
        {
            get => enabled;
            set
            {
                if (!enabled && value)
                {
                    timer = 0f;
                    counter = 0;
                }

                enabled = value;
            }
        }

        public OriginalHahahaState(ISourceEngineContext engine, Vector2 position, string ifSet = "",
            bool triggerLaughSfx = false, Vector2? triggerLaughSfxOrigin = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = -10001;
            Position = position;
            this.ifSet = ifSet;
            if (triggerLaughSfx)
            {
                autoTriggerLaughSfx = triggerLaughSfx;
                autoTriggerLaughOrigin = triggerLaughSfxOrigin.Value;
            }
        }

        public OriginalHahahaState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset, EntityAttributeReader.Attr(data.Values, "ifset"),
                EntityAttributeReader.Bool(data.Values, "triggerLaughSfx"),
                data.Nodes.Length != 0 ? offset + data.Nodes[0] : Vector2.Zero)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (!string.IsNullOrEmpty(ifSet) && !Level.Session.GetFlag(ifSet)) Enabled = false;
        }

        public override void Update()
        {
            if (Enabled)
            {
                timer -= engine.DeltaTime;
                if (timer <= 0f)
                {
                    has.Add(new(engine));
                    counter++;
                    if (counter >= 3)
                    {
                        counter = 0;
                        timer = 1.5f;
                    }
                    else
                    {
                        timer = 0.6f;
                    }
                }

                if (autoTriggerLaughSfx && Level.OnInterval(0.4f))
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/granny/laugh_oneha",
                        autoTriggerLaughOrigin, ((IOriginalGameplayProcess)engine).SaveContext);
            }

            for (var num = has.Count - 1; num >= 0; num--)
                if (has[num].Percent > 1f)
                {
                    has.RemoveAt(num);
                }
                else
                {
                    has[num].Sprite.Update();
                    has[num].Percent += engine.DeltaTime / has[num].Duration;
                }

            if (!Enabled && !string.IsNullOrEmpty(ifSet) && Level.Session.GetFlag(ifSet)) Enabled = true;

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (var ha in has)
            {
                ha.Sprite.Position = Position + new Vector2(ha.Percent * 60f,
                    -10f + (float)(0.0 - Math.Sin(ha.Percent * 13f)) * 4f + ha.Percent * -16f);
                ha.Sprite.Render(context);
            }
        }
    }
}
