using UnityEngine;

namespace UnitSystem.Components.Movement
{
    public interface IMovementUser
    {
        Transform UserTransform { get; }

        Rigidbody UserRigidbody { get; }
    }
}