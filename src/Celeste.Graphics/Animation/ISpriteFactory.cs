namespace Celeste.Graphics.Animation
{
    public interface ISpriteFactory
    {
        bool Has(string id);
        Sprite Create(string id);
        Sprite CreateOn(Sprite sprite, string id);
    }
}
