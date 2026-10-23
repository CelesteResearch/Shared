using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterStoryNpcTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.NPC",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC00_Granny",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC01_Theo",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC02_Theo",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Breakdown",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Cluttter",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Hallway1",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Hallway2",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Lobby",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Rooftop",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Oshiro_Suite",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Theo_Escaping",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Theo_Escaping.Grate",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Theo_Vents",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC03_Theo_Vents.Grate",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC04_Granny",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC04_Theo",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC05_Badeline",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC05_Theo_Entrance",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC05_Theo_Mirror",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Badeline_Crying",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Badeline_Crying.Orb",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Granny",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Granny_Ending",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Theo_Ending",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC06_Theo_Plateau",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC07X_Granny_Ending",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC08_Granny",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC08_Theo",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC09_Granny_Inside",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC09_Granny_Outside",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.NPC10_Gravestone",
                    (string[])["Celeste.NPC", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
