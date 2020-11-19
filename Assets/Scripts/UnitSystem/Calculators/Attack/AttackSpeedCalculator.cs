using System;
using UnityEngine;

namespace UnitSystem.Calculators.Attack
{
    public class AttackSpeedCalculator : IBasicCalculator
    {
        private readonly Settings settings;

        public AttackSpeedCalculator(Settings settings)
        {
            this.settings = settings;
        }
        
        public float Calculate(int unitAttackPoint)
        {
            var t = Mathf.InverseLerp(settings.minAttackPoint, settings.maxAttackPoint, unitAttackPoint);
            var result = Mathf.Lerp(settings.minAttackSpeed, settings.maxAttackSpeed, t);
            return result;
        }
        
        [Serializable]
        public struct Settings
        {
            public int minAttackPoint;
            public int maxAttackPoint;
            public float minAttackSpeed;
            public float maxAttackSpeed;
        }
    }
}