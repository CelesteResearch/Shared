using System.IO;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Formats.Graphics.Tiles;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Localization.Lookup;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Content.Graphics
{
    public static class EverestLevelLoaderGraphicsPolicy
    {
        public static void Apply(ChapterCompletionSession session, IOriginalAreaSourceTable areas,
            OriginalGameGraphicsResources graphics, ISourceEngineContext engine, EverestGraphicsXmlReader content,
            LevelEnterStaticState errors, DialogCatalog dialogs,
            ref string currentPath, ref EverestGraphicsFailureDomain failureDomain)
        {
            currentPath = "";
            failureDomain = EverestGraphicsFailureDomain.General;
            var metadata = ((EverestArea)areas.Areas[session.AreaID]).Metadata;
            var currentGameAtlas = () => graphics.GameAtlas;
            currentPath = metadata?.BackgroundTiles;
            if (string.IsNullOrEmpty(currentPath)) currentPath = Path.Combine("Graphics", "BackgroundTiles.xml");
            failureDomain = EverestGraphicsFailureDomain.Autotiler;
            graphics.BackgroundAutotiler = ((ISourceAutotilerConstructionEnvironment)engine).AutotilerConstruction
                .Create(engine, currentPath, content.LoadContent(currentPath), graphics);

            currentPath = metadata?.ForegroundTiles;
            if (string.IsNullOrEmpty(currentPath)) currentPath = Path.Combine("Graphics", "ForegroundTiles.xml");
            graphics.ForegroundAutotiler = ((ISourceAutotilerConstructionEnvironment)engine).AutotilerConstruction
                .Create(engine, currentPath, content.LoadContent(currentPath), graphics);

            currentPath = metadata?.AnimatedTiles;
            if (string.IsNullOrEmpty(currentPath)) currentPath = Path.Combine("Graphics", "AnimatedTiles.xml");
            failureDomain = EverestGraphicsFailureDomain.General;
            graphics.AnimatedTilesBank = new();
            AnimatedTileDefinitions.Append(graphics.AnimatedTilesBank, content.LoadContent(currentPath),
                graphics.GameAtlas);

            // The diagnostic path deliberately remains the animated XML path here.
            // The current atlas is evaluated before the SpriteBank XML read.
            var gameAtlas = graphics.GameAtlas;
            graphics.SpriteBank = new(engine, gameAtlas,
                content.LoadSpriteBank(Path.Combine("Graphics", "Sprites.xml")));

            currentPath = metadata?.Sprites;
            if (!string.IsNullOrEmpty(currentPath))
            {
                var original = graphics.SpriteBank;
                gameAtlas = graphics.GameAtlas;
                original.MergeMod(content.LoadModdedSprites(currentPath));
            }

            graphics.ClearFramesMetadata();
            graphics.CreateFramesMetadata("player");
            graphics.CreateFramesMetadata("player_no_backpack");
            graphics.CreateFramesMetadata("badeline");
            graphics.CreateFramesMetadata("player_badeline");
            graphics.CreateFramesMetadata("player_playback");

            currentPath = metadata?.Portraits;
            if (string.IsNullOrEmpty(currentPath)) currentPath = Path.Combine("Graphics", "Portraits.xml");
            var portraitsAtlas = graphics.PortraitsAtlas;
            graphics.PortraitsSpriteBank = new(engine, portraitsAtlas, content.LoadSpriteBank(currentPath));
        }
    }
}
