using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Clutter.Cabinets
{
    public class OriginalClutterCabinetState : SceneEntityState
    {
        private readonly Sprite sprite;
        public bool Opened { get; private set; }

        public OriginalClutterCabinetState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("clutterCabinet"));
            sprite.Position = new(8f);
            sprite.Play("idle");
            Depth = -10001;
        }

        public OriginalClutterCabinetState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public void Open()
        {
            sprite.Play("open");
            Opened = true;
        }

        public void Close()
        {
            sprite.Play("close");
            Opened = false;
        }
    }
}
