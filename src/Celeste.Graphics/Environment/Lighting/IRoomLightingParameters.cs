namespace Celeste.Graphics.Environment.Lighting
{
    public interface IRoomLightingParameters
    {
        float BaseLightingAlpha { get; }
        float LightingAlpha { get; set; }
        float LightingAlphaAdd { get; set; }
        float AreaBloomBase { get; }
        float BloomBase { get; set; }
        float BloomBaseAdd { get; set; }
    }
}
