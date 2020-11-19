namespace UnitSystem.Characteristics
{
    public abstract class Characteristic
    {
        public CharacteristicData BonusCharacteristics => new CharacteristicData(BonusHealthPoint, BonusAttackPoint);
        
        protected abstract int BonusHealthPoint { get; }
        protected abstract int BonusAttackPoint { get; }
    }
}