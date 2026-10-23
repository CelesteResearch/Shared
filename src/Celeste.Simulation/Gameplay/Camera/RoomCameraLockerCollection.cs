using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Scene.Components;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraLockerCollection : IReadOnlyList<RoomCameraLocker>
    {
        private readonly SceneComponentTracker components;

        public RoomCameraLockerCollection(SceneComponentTracker components)
        {
            this.components = components ?? throw new ArgumentNullException(nameof(components));
        }

        public int Count => components.GetTrackedComponents("Celeste.CameraLocker").Count;

        public RoomCameraLocker this[int index] =>
            (RoomCameraLocker)components.GetTrackedComponents("Celeste.CameraLocker")[index];

        public IEnumerator<RoomCameraLocker> GetEnumerator()
        {
            for (var i = 0; i < Count; i++) yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
