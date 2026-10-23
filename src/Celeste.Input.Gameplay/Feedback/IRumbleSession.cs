namespace Celeste.Input.Gameplay.Feedback
{
    public interface IRumbleSession
    {
        void Rumble(int strength, int length);
        void RumbleSpecific(float strength, float time);
        void StopRumble();
    }
}
