using System;
using UnityEngine;

namespace UnitSystem.Components.Movement
{
    public class Movement
    {
        private const float LerpSpeed = 8f;

        private readonly float movementSpeed;
        private readonly IMovementUser movementUser;

        private State currentState;
        private Transform target;
        private Vector3 movementDirection;

        public Movement(IMovementUser movementUser, float movementSpeed)
        {
            this.movementUser = movementUser;
            this.movementSpeed = movementSpeed;
            SetState(State.Stopping);
        }

        public void SetDirection(Vector3 direction)
        {
            movementDirection = direction;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void SetState(State state)
        {
            currentState = state;
        }

        public void UpdateFrame(float deltaTime)
        {
            switch (currentState)
            {
                case State.Stopping:
                    movementUser.UserRigidbody.velocity = Vector3.zero;
                    break;
                case State.MovingToDirection:
                    SetVelocity(movementDirection * movementSpeed);
                    LerpLookDirection(movementDirection, LerpSpeed * deltaTime);
                    break;
                case State.MovingToTarget:
                    var dir = (target.position - movementUser.UserTransform.position).normalized;
                    SetVelocity(dir * movementSpeed);
                    LerpLookDirection(dir, LerpSpeed * deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetVelocity(Vector3 velocity)
        {
            movementUser.UserRigidbody.velocity = velocity;
        }

        private void LerpLookDirection(Vector3 lookDir, float lerpSpeed)
        {
            var targetRotation = Quaternion.Euler(lookDir);
            movementUser.UserTransform.rotation = Quaternion.Lerp(movementUser.UserTransform.rotation, targetRotation, lerpSpeed);
        }

        public enum State
        {
            Stopping,
            MovingToDirection,
            MovingToTarget
        }
    }
}