using System;
using UnityEngine;

namespace UnitSystem.Calculators.Movement
{
    public class MovementSpeedCalculator : IBasicCalculator
    {
        private readonly Settings settings;

        public MovementSpeedCalculator(Settings settings)
        {
            this.settings = settings;
        }

        public float Calculate(int unitHealth)
        {
            var t = Mathf.InverseLerp(settings.minHealthPoint, settings.maxHealthPoint, unitHealth);
            var result = Mathf.Lerp(settings.maxMovementSpeed, settings.minMovementSpeed, t);
            return result;
        }
        
        [Serializable]
        public struct Settings
        {
            public int minHealthPoint;
            public int maxHealthPoint;
            public int minMovementSpeed;
            public int maxMovementSpeed;
        }
    }
}