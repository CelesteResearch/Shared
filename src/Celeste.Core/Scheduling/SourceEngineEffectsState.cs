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
        private ISourceEngineDistortionOutput _distortion;
        private float _anxiety;
        private Vector2 _anxietyOrigin;
        private float _gameRate = 1f;
        private float _waterSine;
        public float WaterSineDirection = 1f;
        private float _waterCameraY;
        private float _waterAlpha = 1f;

        public void BindDistortionOutput(ISourceEngineDistortionOutput output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (_distortion != null) throw new InvalidOperationException("The distortion output is already bound.");
            _distortion = output;
            SynchronizeDistortionOutput();
        }

        public void SynchronizeDistortionOutput()
        {
            var output = _distortion ?? throw new InvalidOperationException("The distortion output is not bound.");
            output.AnxietyOrigin.SetValue(_anxietyOrigin);
            output.Anxiety.SetValue(!output.DisableFlashes ? _anxiety : 0f);
            output.GameRate.SetValue(_gameRate);
            output.WaterSine.SetValue(_waterSine);
            output.WaterCameraY.SetValue(_waterCameraY);
            output.WaterAlpha.SetValue(_waterAlpha);
        }

        public Vector2 AnxietyOrigin
        {
            get => _anxietyOrigin;
            set
            {
                _anxietyOrigin = value;
                if (_distortion != null) _distortion.AnxietyOrigin.SetValue(_anxietyOrigin);
            }
        }

        public float Anxiety
        {
            get => _anxiety;
            set
            {
                _anxiety = value;
                if (_distortion != null) _distortion.Anxiety.SetValue(!_distortion.DisableFlashes ? _anxiety : 0f);
            }
        }

        public float GameRate
        {
            get => _gameRate;
            set
            {
                _gameRate = value;
                if (_distortion != null) _distortion.GameRate.SetValue(_gameRate);
            }
        }

        public float WaterSine
        {
            get => _waterSine;
            set
            {
                _waterSine = WaterSineDirection * value;
                if (_distortion != null) _distortion.WaterSine.SetValue(_waterSine);
            }
        }

        public float WaterCameraY
        {
            get => _waterCameraY;
            set
            {
                _waterCameraY = value;
                if (_distortion != null) _distortion.WaterCameraY.SetValue(_waterCameraY);
            }
        }

        public float WaterAlpha
        {
            get => _waterAlpha;
            set
            {
                _waterAlpha = value;
                if (_distortion != null) _distortion.WaterAlpha.SetValue(_waterAlpha);
            }
        }
    }
}
