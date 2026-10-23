namespace Celeste.Simulation.Story.Farewell.GoldenRoom
{
    // EventTrigger.cs:216-219 / 225-235: the trigger owns one snapshot instance and
    // releases it from Removed and SceneEnd.
    public interface IFarewellGoldenSnapshotWorld
    {
        void SnapColorGrade(string name);
        object CreateSnapshot(string name);
        void ReleaseSnapshot(object snapshot);
    }
}
