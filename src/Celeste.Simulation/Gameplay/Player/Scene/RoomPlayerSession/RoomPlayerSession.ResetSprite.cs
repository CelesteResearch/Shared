using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Runtime;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    // Port of Celeste.Player.ResetSpriteNextFrame / ResetSprite
    // (Artifacts/Reference/Original/Celeste/Player.cs:1255-1275, applied from Player.Update
    // at Player.cs:1432-1436).
    //
    // The original swaps in a brand new PlayerSprite instance and re-establishes only what the
    // new instance cannot carry: Hair.Sprite (Player.cs:1274). Player's constructor installs
    // callbacks onto its first Sprite instance; ResetSprite never copies them. Player.Update,
    // Player.Dummy*, Player.Play and every intro coroutine read the `Sprite` field at call time,
    // so they follow the swap automatically through their actual player owner.
    public sealed partial class RoomPlayerSession
    {
        /// <summary>Player.cs:1257 - `nextSpriteMode = mode;`, applied on the next Player.Update.</summary>
        private PlayerSpriteMode? nextSpriteMode;

        /// <summary>Player.cs:1256-1258.</summary>
        public void ResetSpriteNextFrame(
            PlayerSpriteMode mode)
        {
            nextSpriteMode = mode;
        }

        /// <summary>
        ///     Player.cs:1432-1436. The original applies the request before the state machine and the
        ///     component list run, and Level never runs Player.Update while FrozenOrPaused
        ///     (Level.cs:1836-1867 only updates Tags.FrozenUpdate / Tags.PauseUpdate), so a request
        ///     made while paused or frozen survives until the first ordinary player frame.
        /// </summary>
        internal void FlushSpriteReset()
        {
            if (!nextSpriteMode.HasValue) return;
            var mode = nextSpriteMode.Value;
            ResetSprite(mode);
            nextSpriteMode = null;
        }

        /// <summary>
        ///     Player.cs:1260-1275.
        ///     <code>
        /// string currentAnimationID = Sprite.CurrentAnimationID;
        /// int currentAnimationFrame = Sprite.CurrentAnimationFrame;
        /// Sprite.RemoveSelf();
        /// Add(Sprite = new PlayerSprite(mode));
        /// if (Sprite.Has(currentAnimationID)) {
        ///     Sprite.Play(currentAnimationID);
        ///     if (currentAnimationFrame &lt; Sprite.CurrentAnimationTotalFrames) Sprite.SetAnimationFrame(currentAnimationFrame);
        /// }
        /// Hair.Sprite = Sprite;
        /// </code>
        /// </summary>
        public void ResetSprite(PlayerSpriteMode mode)
        {
            ((ISourcePlayerRuntimeEnvironment)EngineContext)
                .PlayerRuntimePolicy.ResetSprite(this, mode);
        }

        public void ResetSpriteSourceBody(
            PlayerSpriteMode mode)
        {
            var currentAnimationId = Sprite.CurrentAnimationID;
            var currentAnimationFrame = Sprite.CurrentAnimationFrame;

            Sprite.RemoveSelf();

            // Add(Sprite = new PlayerSprite(mode)): a genuinely new instance, so Position, Color,
            // Visible, Scale, Rate, Animating and the current animation restart from the
            // constructor defaults instead of leaking out of the outgoing mode (PlayerSprite.cs:
            // 197-222 -> Monocle Sprite(Atlas,path) -> SpriteData.Create, which is where a real
            // Sprite gets Color=White/Position=Zero/Visible=true). That is exactly why an in-place
            // PlayerSprite.SetMode swap cannot be equivalent.
            Sprite =
                ((ISourcePlayerSpriteEnvironment)
                    EngineContext)
                .CreatePlayerSprite(mode);
            Components.Add(Sprite);
            if (Sprite.Has(currentAnimationId))
            {
                Sprite.Play(currentAnimationId);
                if (currentAnimationFrame < Sprite.CurrentAnimationTotalFrames)
                    Sprite.SetAnimationFrame(currentAnimationFrame);
            }

            Hair.Sprite = Sprite;
        }

        // The original ResetSprite body does NOT restore
        // Sprite.OnFrameChange / OnLastFrame / OnChange. They are constructor-time bindings
        // (Player.cs:1183/1218/1245) onto the instance that Player.cs:1127 created, and Monocle's
        // Sprite.CloneInto (Reference/Original/Monocle/Sprite.cs:475-491) copies animation state
        // but no callbacks. After a ResetSprite the new PlayerSprite therefore has all five
        // callback fields null, and footstep / handhold / campfire / summit_sit audio and the push
        // dust stop firing on the player until the level is reloaded. The port reproduces that
        // exactly. The installed Everest wrapper restores its three original callback fields.
    }
}
