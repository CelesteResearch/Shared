using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public sealed class TrailSnapshotState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public TrailManagerState Manager;
        public SpriteImage Sprite;
        public Vector2 SpriteScale;
        public PlayerHair Hair;
        public int Index;
        public PackedColor Color;
        public float Percent, Duration;
        public bool Drawn, UseRawDeltaTime;

        public TrailSnapshotState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            var reflection = new MirrorReflectionState();
            OwnedComponents.Add(reflection);
        }

        public void Init(TrailManagerState manager, int index, Vector2 position, SpriteImage sprite,
            PlayerHair hair, Vector2 scale, PackedColor color, float duration, int depth,
            bool frozenUpdate, bool useRawDeltaTime)
        {
            Tags = ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                .GlobalFrozenExecutionTags.Global.Value;
            if (frozenUpdate)
                Tags |=
                    ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                    .GlobalFrozenExecutionTags.FrozenUpdate.Value;
            Manager = manager;
            Index = index;
            Position = position;
            Sprite = sprite;
            SpriteScale = scale;
            Hair = hair;
            Color = color;
            Percent = 0f;
            Duration = duration;
            Depth = depth;
            Drawn = false;
            UseRawDeltaTime = useRawDeltaTime;
        }

        public override void Update()
        {
            // Source Snapshot.Update does not call base.Update.
            if (Duration <= 0f)
            {
                if (Drawn) RemoveSelf();
                return;
            }

            if (Percent >= 1f) RemoveSelf();
            Percent += (UseRawDeltaTime ? engine.RawDeltaTime : engine.DeltaTime) / Duration;
        }

        public override void Render(ISourceRenderContext context)
            => Manager.RenderSnapshot(context, this);

        public override void Removed(object actualScene)
        {
            if (Manager != null) Manager.Release(Index);
            base.Removed(actualScene);
        }
    }
}
