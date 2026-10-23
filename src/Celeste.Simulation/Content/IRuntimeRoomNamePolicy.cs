namespace Celeste.Simulation.Content
{
    // Converts a content-format room name to the name read by runtime states.
    public interface IRuntimeRoomNamePolicy
    {
        string RuntimeRoomName(string name);
    }
}
