using System.Collections;
using System.Numerics;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator SetupLevel()
        {
            Level.SnapColorGrade("credits");
            player = null;
            while ((player = ((ISourceScene)Scene).SourceScene.Entities
                       .GetTrackedEntity<
                           RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)) == null)

                yield return null;
            badeline = BadelineDummyPresentation.Create(Level, player.Position + new Vector2(16f, -16f));
            ((ISourceScene)Level).SourceScene.QueueSourceEntity(badeline);
            badeline.Floatness = 4f;
            badelineAutoFloat = true;
            badelineAutoWalk = false;
            badelineWalkApproach = 0f;
            Level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            player.Machine.State = 11;
            player.Dummy.Friction = false;
            player.Dummy.Maxspeed = false;
            player.Data.Facing = -1;
            autoWalk = true;
            autoUpdateCamera = true;
            Level.CameraOffset.X = 70f;
            Level.CameraOffset.Y = -24f;
            Level.Camera.Position = player.CameraTarget;
        }

        private IEnumerator NextLevel(string name)
        {
            if (player != null)
                player.RemoveSelf();
            player = null;
            Level.OnEndOfFrame += () =>
            {
                Level.UnloadLevel();
                Level.Session.Level = name;
                Level.Session.RespawnPoint = Level.GetSpawnPoint(
                    new Vector2(Level.Bounds.Left, Level.Bounds.Top));
                Level.LoadLevel(PlayerIntroType.None);
                Level.Wipe.Cancel();
            };
            yield return null;
            yield return null;
        }
    }
}
