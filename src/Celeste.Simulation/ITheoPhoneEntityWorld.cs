namespace Celeste.Simulation
{
    // Original Celeste.TheoPhone, spawned by InteractTrigger.Added when the next event is
    // ch5_theo_phone (position + (width/2 - 8, height - 1)). It owns one Image of
    // GFX.Game["characters/theo/phone"] justified (0.5, 1) and one blinking VertexLight
    // (Color.LawnGreen, alpha 1, 8..16) toggled by Scene.OnInterval(0.5f).
    public interface ITheoPhoneEntityWorld
    {
        bool OnInterval(float interval);
    }
}
