using Events;
using UnityEngine;

namespace Camera
{
    public class CameraDirector : MonoBehaviour
    {
        private const float LerpSpeed = 2f;

        [SerializeField] private Transform cameraTransform;
        [SerializeField] private CameraData preBattleCamera;
        [SerializeField] private CameraData battleCamera;
        private State state;

        private void Awake()
        {
            CameraEvents.CameraStateUpdated += OnCameraStateUpdated;
        }

        private void Update()
        {
            var targetPosition = state == State.Battle ? battleCamera.position : preBattleCamera.position;
            var targetRotation = state == State.Battle ? battleCamera.rotation : preBattleCamera.rotation;

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, LerpSpeed * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.Euler(targetRotation),
                LerpSpeed * Time.deltaTime);
        }

        private void OnCameraStateUpdated(State state)
        {
            this.state = state;
        }

        public enum State
        {
            PreBattle,
            Battle
        }
    }
}