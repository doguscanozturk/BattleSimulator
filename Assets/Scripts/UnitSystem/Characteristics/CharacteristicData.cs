using System;

namespace UnitSystem.Characteristics
{
    [Serializable]
    public struct CharacteristicData
    {
        public int healthPoint;
        public int attackPoint;

        public CharacteristicData(int healthPoint, int attackPoint)
        {
            this.healthPoint = healthPoint;
            this.attackPoint = attackPoint;
        }

        public static CharacteristicData operator +(CharacteristicData a, CharacteristicData b)
        {
            var sumHealth = a.healthPoint + b.healthPoint;
            var sumAttack = a.attackPoint + b.attackPoint;
            return new CharacteristicData(sumHealth, sumAttack);
        }
    }
}