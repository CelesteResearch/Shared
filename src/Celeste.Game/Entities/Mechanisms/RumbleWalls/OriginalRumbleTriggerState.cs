using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Identifiers;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Mechanisms.RumbleWalls
{
    public class OriginalRumbleTriggerState : SourceTriggerEntityState
    {
        private bool manualTrigger;
        private bool started;
        private bool persistent;
        private MapEntityId id;
        private float rumble;
        private float left;
        private float right;
        private List<OriginalDecalEntity> decals = new();
        private List<OriginalCrumbleWallOnRumbleState> crumbles = new();
        protected readonly ISourceEngineContext engine;

        public OriginalRumbleTriggerState(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            manualTrigger = EntityAttributeReader.Bool(data.Values, "manualTrigger");
            persistent = EntityAttributeReader.Bool(data.Values, "persistent");
            this.id = id;
            Vector2[] nodes = data.NodesOffset(offset);
            if (nodes.Length >= 2)
            {
                left = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(nodes[0].X, nodes[1].X);
                right = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(nodes[0].X, nodes[1].X);
            }
        }

        public static OriginalRumbleTriggerState CreateFromMapData(EntityData data, Vector2 offset,
            MapEntityId id, OriginalLevelSceneRoot level)
            => ((IOriginalRumbleTriggerConstructionEnvironment)level.EngineContext).RumbleTriggers
                .Create(data, offset, id, level.EngineContext);

        protected virtual bool MatchesHeight(SceneEntityState entity) => true;

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var level = Scene as OriginalLevelSceneRoot;
            bool flag = false;
            if (persistent && level.Session.GetFlag(EntityIdCodec.Format(id))) flag = true;
            foreach (var identity in ((ISourceScene)scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CrumbleWallOnRumble"))
            {
                var entity = (OriginalCrumbleWallOnRumbleState)identity;
                if (MatchesHeight(entity) && entity.X >= left && entity.X <= right)
                {
                    if (flag) entity.RemoveSelf();
                    else crumbles.Add(entity);
                }
            }

            if (!flag)
            {
                foreach (var item in ((ISourceScene)scene).SourceScene.Entities.FindAll<OriginalDecalEntity>())
                {
                    if (item.IsCrack && MatchesHeight(item) && item.X >= left && item.X <= right)
                    {
                        item.Visible = false;
                        decals.Add(item);
                    }
                }

                crumbles.Sort((a, b) => ((ISourceRandomEnvironment)engine).Random.NextDouble() < .5f ? -1 : 1);
            }

            if (flag) RemoveSelf();
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (!manualTrigger) Invoke();
        }

        protected void Invoke(float delay = 0f)
        {
            if (!started)
            {
                started = true;
                if (persistent) (Scene as OriginalLevelSceneRoot).Session.SetFlag(EntityIdCodec.Format(id));
                OwnedComponents.Add(new SimulationCoroutine(engine, RumbleRoutine(delay)));
                OwnedComponents.Add(new DisplacementRenderHookState(RenderDisplacement));
            }
        }

        private IEnumerator RumbleRoutine(float delay)
        {
            yield return delay;
            _ = Scene;
            rumble = 1f;
            var process = (IOriginalGameplayProcess)engine;
            process.AudioSession.Play("event:/new_content/game/10_farewell/quake_onset", Position, process.SaveContext);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            foreach (var decal in decals) decal.Visible = true;
            foreach (var crumble in crumbles)
            {
                crumble.Break();
                yield return .05f;
            }
        }

        public override void Update()
        {
            base.Update();
            rumble = ScalarMath.Approach(rumble, 0f, engine.DeltaTime * .7f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        private void RenderDisplacement()
        {
            if (!(rumble <= 0f) && ((ISettingsContext)engine).Settings.ScreenShake != 0)
            {
                var camera = (Scene as OriginalLevelSceneRoot).Camera;
                int first = (int)(camera.Left / 8f) - 1;
                int last = (int)(camera.Right / 8f) + 1;
                for (int i = first; i <= last; i++)
                {
                    float amount = (float)Math.Sin(((ISourceSceneTime)Scene).TimeActive * 60f + i * .4f) * .06f *
                                   rumble;
                    SourcePrimitiveDrawing.Rect(((ISourceRenderEnvironment)engine).CurrentContext, this,
                        i * 8, camera.Top - 2f, 8f, 184f, new PackedColor(.5f, .5f + amount, 0f, 1f));
                }
            }
        }

        protected bool MatchesManualX(float x) => manualTrigger && x >= left && x <= right;

        // This source extension is consumed only by the installed Vector2 overload.
        public virtual void InvokeAtPosition(Vector2 position, float delay, bool triggerUnconstrained)
        {
            if (MatchesManualX(position.X) && triggerUnconstrained) Invoke(delay);
        }

        public static void ManuallyTrigger(ISourceEngineContext engine, float x, float delay)
        {
            var scene = engine.Frame.Scenes.CurrentScene;
            foreach (var item in ((ISourceScene)scene).SourceScene.Entities.FindAll<OriginalRumbleTriggerState>())
                if (item.manualTrigger && x >= item.left && x <= item.right)
                    item.Invoke(delay);
        }
    }
}
