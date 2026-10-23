using System;
using System.Numerics;
using Celeste.Audio.Framework;
using Celeste.Audio.Interop;

namespace Celeste.Audio.Sound
{
    public class SourceAudioEmitter
    {
        internal SourceFAudioLayout.F3DAUDIO_EMITTER emitterData;


        public float DopplerScale
        {
            get => emitterData.DopplerScaler;
            set
            {
                if (value < 0f)
                    throw new ArgumentOutOfRangeException(
                        "SourceAudioEmitter.DopplerScale must be greater than or equal to 0.0f");

                emitterData.DopplerScaler = value;
            }
        }

        public Vector3 Forward
        {
            get =>
                new(emitterData.OrientFront.x, emitterData.OrientFront.y,
                    0f - emitterData.OrientFront.z);
            set
            {
                emitterData.OrientFront.x = value.X;
                emitterData.OrientFront.y = value.Y;
                emitterData.OrientFront.z = 0f - value.Z;
            }
        }

        public Vector3 Position
        {
            get => new(emitterData.Position.x, emitterData.Position.y, 0f - emitterData.Position.z);
            set
            {
                emitterData.Position.x = value.X;
                emitterData.Position.y = value.Y;
                emitterData.Position.z = 0f - value.Z;
            }
        }

        public Vector3 Up
        {
            get => new(emitterData.OrientTop.x, emitterData.OrientTop.y, 0f - emitterData.OrientTop.z);
            set
            {
                emitterData.OrientTop.x = value.X;
                emitterData.OrientTop.y = value.Y;
                emitterData.OrientTop.z = 0f - value.Z;
            }
        }

        public Vector3 Velocity
        {
            get => new(emitterData.Velocity.x, emitterData.Velocity.y, 0f - emitterData.Velocity.z);
            set
            {
                emitterData.Velocity.x = value.X;
                emitterData.Velocity.y = value.Y;
                emitterData.Velocity.z = 0f - value.Z;
            }
        }

        public SourceAudioEmitter(SourceAudioProcess process)
        {
            emitterData = default;
            DopplerScale = 1f;
            Forward = new(0f, 0f, -1f);
            Position = Vector3.Zero;
            Up = new(0f, 1f, 0f);
            Velocity = Vector3.Zero;
            emitterData.pCone = IntPtr.Zero;
            emitterData.ChannelCount = 1u;
            emitterData.ChannelRadius = 1f;
            emitterData.pChannelAzimuths = process.StereoAzimuthHandle.AddrOfPinnedObject();
            emitterData.pVolumeCurve = IntPtr.Zero;
            emitterData.pLFECurve = IntPtr.Zero;
            emitterData.pLPFDirectCurve = IntPtr.Zero;
            emitterData.pLPFReverbCurve = IntPtr.Zero;
            emitterData.pReverbCurve = IntPtr.Zero;
            emitterData.CurveDistanceScaler = 1f;
        }
    }
}
