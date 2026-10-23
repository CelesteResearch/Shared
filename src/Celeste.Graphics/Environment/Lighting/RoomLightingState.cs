using System;
using Celeste.Graphics.Effects.Bloom;

namespace Celeste.Graphics.Environment.Lighting
{
    public sealed class RoomLightingState : IRoomLightingParameters
    {
        public float BaseLightingAlpha { get; set; }

        public readonly ILightingParameters LightingParameters;
        public readonly IBloomParameters BloomParameters;

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

        // ReSharper disable once ConvertToPrimaryConstructor
        public RoomLightingState(float darkness, float bloomBase, ILightingParameters lighting, IBloomParameters bloom)
        {
            LightingParameters = lighting ?? throw new ArgumentNullException(nameof(lighting));
            BloomParameters = bloom ?? throw new ArgumentNullException(nameof(bloom));
            BaseLightingAlpha = darkness;
            AreaBloomBase = bloomBase;
        }
    }
}
