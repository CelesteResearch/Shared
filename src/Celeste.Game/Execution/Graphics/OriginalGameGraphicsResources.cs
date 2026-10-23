using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Game.Execution.Graphics
{
// GFX.Game belongs to the game engine resource lifetime, not an individual Scene.
// Source rendering reads the current reference, including after an asset replacement.
    public sealed partial class OriginalGameGraphicsResources :
        global::Celeste.Graphics.Content.ISourceGameGraphicsResources,
        global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilingResources,
        global::Celeste.Game.Presentation.Particles.IOriginalParticleResources
    {
        public readonly OriginalGameplayBuffers Buffers = new();
        public AtlasData GameAtlas { get; set; }
        public AtlasData GuiAtlas { get; set; }
        public AtlasData MiscAtlas { get; set; }
        public AtlasData PortraitsAtlas { get; set; }
        public global::Celeste.Formats.Graphics.Sprites.SpriteBank GuiSpriteBank { get; set; }
        public global::Celeste.Formats.Graphics.Sprites.SpriteBank PortraitsSpriteBank { get; set; }
        public global::Celeste.Formats.Graphics.Sprites.SpriteBank SpriteBank { get; set; }
        public global::Celeste.Graphics.Animation.ISpriteFactory SpriteFactory => SpriteBank;
        public global::Celeste.Graphics.Content.Tiles.Autotiling.Autotiler BackgroundAutotiler { get; set; }
        public global::Celeste.Graphics.Content.Tiles.Autotiling.Autotiler ForegroundAutotiler { get; set; }
        public global::Celeste.Graphics.Content.Tiles.Tileset SceneryTiles { get; set; }

        public global::Celeste.Simulation.Gameplay.Player.Presentation.PlayerFramesMetadata
            PlayerMetadata { get; set; } =
            new();

        public global::Celeste.Graphics.Content.Tiles.AnimatedTileBank AnimatedTilesBank { get; set; }
        public global::System.Xml.XmlDocument CompleteScreensXml { get; set; }
        public bool DataLoaded { get; private set; }
        public AtlasEntry Pixel;
        public AtlasEntry Particle;
        public AtlasEntry DefaultParticleSource => Particle;
        public AtlasEntry GetGameParticleSource(string path) => GameAtlas.Entries[path];

        // The caller is the original guarded GFX.Load path, after Gui atlas loading.
        // All scenes borrow this bank; a menu resource lease does not recreate it.
        public void LoadGuiSpriteBank(global::System.Xml.XmlDocument spritesGui,
            global::Celeste.Core.Randomness.ISourceRandom random,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            GuiSpriteBank = new global::Celeste.Formats.Graphics.Sprites.SpriteBank(engine, GuiAtlas, spritesGui);
        }

        // This method owns original GFX.LoadData policy. readXml is pure content IO,
        // invoked only at the source construction point, after prior publication.
        public void LoadGraphicsData(global::System.Func<string, global::System.Xml.XmlDocument> readXml,
            global::Celeste.Core.Randomness.ISourceRandom random,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            if (!DataLoaded)
            {
                var stopwatch = global::System.Diagnostics.Stopwatch.StartNew();
                PortraitsSpriteBank = new global::Celeste.Formats.Graphics.Sprites.SpriteBank(engine, PortraitsAtlas,
                    readXml(global::System.IO.Path.Combine("Graphics", "Portraits.xml")));
                SpriteBank = new global::Celeste.Formats.Graphics.Sprites.SpriteBank(engine, GameAtlas,
                    readXml(global::System.IO.Path.Combine("Graphics", "Sprites.xml")));
                string backgroundFilename = global::System.IO.Path.Combine("Graphics", "BackgroundTiles.xml");
                BackgroundAutotiler =
                    ((global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilerConstructionEnvironment)engine)
                    .AutotilerConstruction.Create(engine, backgroundFilename, readXml(backgroundFilename), this);
                string foregroundFilename = global::System.IO.Path.Combine("Graphics", "ForegroundTiles.xml");
                ForegroundAutotiler =
                    ((global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilerConstructionEnvironment)engine)
                    .AutotilerConstruction.Create(engine, foregroundFilename, readXml(foregroundFilename), this);
                SceneryTiles =
                    new global::Celeste.Graphics.Content.Tiles.Tileset(GameAtlas.Entries["tilesets/scenery"], 8, 8);
                ClearFramesMetadata();
                CreateFramesMetadata("player");
                CreateFramesMetadata("player_no_backpack");
                CreateFramesMetadata("badeline");
                CreateFramesMetadata("player_badeline");
                CreateFramesMetadata("player_playback");
                CompleteScreensXml = readXml(global::System.IO.Path.Combine("Graphics", "CompleteScreens.xml"));
                var animations = new global::Celeste.Graphics.Content.Tiles.AnimatedTileBank();
                AnimatedTilesBank = animations;
                global::Celeste.Formats.Graphics.Tiles.AnimatedTileDefinitions.Append(animations,
                    readXml(global::System.IO.Path.Combine("Graphics", "AnimatedTiles.xml")), GameAtlas);
                global::System.Console.WriteLine(" - GFX DATA LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            DataLoaded = true;
        }

        public void PublishDrawingTextures()
        {
            var particle = GameAtlas.Entries["util/particle"];
            Particle = particle;
            Pixel = GameAtlas.Entries["util/pixel"].GetSubtexture(1, 1, 1, 1);
        }
    }
}
