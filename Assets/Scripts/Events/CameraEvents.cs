using System;
using Camera;

namespace Events
{
    public static class CameraEvents
    {
        public static event Action<CameraDirector.State> CameraStateUpdated;

        public static void TriggerCameraStateUpdated(CameraDirector.State state)
        {
            CameraStateUpdated?.Invoke(state);
        }
    }
}