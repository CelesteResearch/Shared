using System;
using System.Numerics;
using Celeste.Audio.Interop;

namespace Celeste.Audio.Sound
{
    public class SourceAudioListener
    {
        internal SourceFAudioLayout.F3DAUDIO_LISTENER listenerData;

        public Vector3 Forward
        {
            get =>
                new(listenerData.OrientFront.x, listenerData.OrientFront.y,
                    0f - listenerData.OrientFront.z);
            set
            {
                listenerData.OrientFront.x = value.X;
                listenerData.OrientFront.y = value.Y;
                listenerData.OrientFront.z = 0f - value.Z;
            }
        }

        public Vector3 Position
        {
            get => new(listenerData.Position.x, listenerData.Position.y, 0f - listenerData.Position.z);
            set
            {
                listenerData.Position.x = value.X;
                listenerData.Position.y = value.Y;
                listenerData.Position.z = 0f - value.Z;
            }
        }

        public Vector3 Up
        {
            get => new(listenerData.OrientTop.x, listenerData.OrientTop.y, 0f - listenerData.OrientTop.z);
            set
            {
                listenerData.OrientTop.x = value.X;
                listenerData.OrientTop.y = value.Y;
                listenerData.OrientTop.z = 0f - value.Z;
            }
        }

        public Vector3 Velocity
        {
            get => new(listenerData.Velocity.x, listenerData.Velocity.y, 0f - listenerData.Velocity.z);
            set
            {
                listenerData.Velocity.x = value.X;
                listenerData.Velocity.y = value.Y;
                listenerData.Velocity.z = 0f - value.Z;
            }
        }

        public SourceAudioListener()
        {
            listenerData = default;
            Forward = new(0f, 0f, -1f);
            Position = Vector3.Zero;
            Up = new(0f, 1f, 0f);
            Velocity = Vector3.Zero;
            listenerData.pCone = IntPtr.Zero;
        }
    }
}
