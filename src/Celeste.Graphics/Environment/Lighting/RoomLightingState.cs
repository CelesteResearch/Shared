namespace Celeste.Graphics.Environment.Lighting
{
    public sealed class RoomLightingState : IRoomLightingParameters
    {
        public float BaseLightingAlpha { get; set; }
        public readonly ILightingParameters LightingParameters;
        public readonly global::Celeste.Graphics.Effects.Bloom.IBloomParameters BloomParameters;

        public float LightingAlpha
        {
            get => LightingParameters.Alpha;
            set => LightingParameters.Alpha = value;
        }

        public float LightingAlphaAdd { get; set; }
        public float AreaBloomBase { get; set; }

        public float BloomBase
        {
            get => BloomParameters.Base;
            set => BloomParameters.Base = value;
        }

        public float BloomStrength
        {
            get => BloomParameters.Strength;
            set => BloomParameters.Strength = value;
        }

        public float BloomBaseAdd { get; set; }
        public float DarkRoomAlpha { get; set; } = .75f;
        public bool DarkRoom { get; set; }

        public RoomLightingState(float darkness, float bloomBase, ILightingParameters lighting,
            global::Celeste.Graphics.Effects.Bloom.IBloomParameters bloom)
        {
            LightingParameters = lighting ?? throw new System.ArgumentNullException(nameof(lighting));
            BloomParameters = bloom ?? throw new System.ArgumentNullException(nameof(bloom));
            BaseLightingAlpha = darkness;
            AreaBloomBase = bloomBase;
        }
    }
}
