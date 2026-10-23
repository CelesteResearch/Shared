using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalTheoPhoneState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly VertexLightState light;

        public OriginalTheoPhoneState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            OwnedComponents.Add(light = new(engine, PackedColor.LawnGreen, 1f, 8, 16));
            OwnedComponents.Add(
                new SpriteImage(
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["characters/theo/phone"])
                    .JustifyOrigin(0.5f, 1f));
        }

        public override void Update()
        {
            if (((SourceSceneState)Scene).OnInterval(0.5f)) light.Visible = !light.Visible;

            base.Update();
        }
    }
}
