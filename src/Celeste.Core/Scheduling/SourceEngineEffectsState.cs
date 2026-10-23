using System;
using System.Numerics;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineEffectsState
    {
        public float TimeRate = 1f;
        public float TimeRateB = 1f;
        public float EffectiveTimeRate = 1f;
        public float FreezeTimer;
        public bool DashAssistFreeze;
        public bool DashAssistFreezePress;
        public float Glitch;
        private ISourceEngineDistortionOutput distortion;
        private float anxiety;
        private Vector2 anxietyOrigin;
        private float gameRate = 1f;
        private float waterSine;
        public float WaterSineDirection = 1f;
        private float waterCameraY;
        private float waterAlpha = 1f;

        public void BindDistortionOutput(ISourceEngineDistortionOutput output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (distortion != null) throw new InvalidOperationException("The distortion output is already bound.");
            distortion = output;
            SynchronizeDistortionOutput();
        }

        public void SynchronizeDistortionOutput()
        {
            var output = distortion ?? throw new InvalidOperationException("The distortion output is not bound.");
            output.AnxietyOrigin.SetValue(anxietyOrigin);
            output.Anxiety.SetValue(!output.DisableFlashes ? anxiety : 0f);
            output.GameRate.SetValue(gameRate);
            output.WaterSine.SetValue(waterSine);
            output.WaterCameraY.SetValue(waterCameraY);
            output.WaterAlpha.SetValue(waterAlpha);
        }

        public Vector2 AnxietyOrigin
        {
            get => anxietyOrigin;
            set
            {
                anxietyOrigin = value;
                if (distortion != null) distortion.AnxietyOrigin.SetValue(anxietyOrigin);
            }
        }

        public float Anxiety
        {
            get => anxiety;
            set
            {
                anxiety = value;
                if (distortion != null) distortion.Anxiety.SetValue(!distortion.DisableFlashes ? anxiety : 0f);
            }
        }

        public float GameRate
        {
            get => gameRate;
            set
            {
                gameRate = value;
                if (distortion != null) distortion.GameRate.SetValue(gameRate);
            }
        }

        public float WaterSine
        {
            get => waterSine;
            set
            {
                waterSine = WaterSineDirection * value;
                if (distortion != null) distortion.WaterSine.SetValue(waterSine);
            }
        }

        public float WaterCameraY
        {
            get => waterCameraY;
            set
            {
                waterCameraY = value;
                if (distortion != null) distortion.WaterCameraY.SetValue(waterCameraY);
            }
        }

        public float WaterAlpha
        {
            get => waterAlpha;
            set
            {
                waterAlpha = value;
                if (distortion != null) distortion.WaterAlpha.SetValue(waterAlpha);
            }
        }
    }
}
