using UnitSystem.Characteristics;

namespace UnitSystem.Calculators
{
    public interface IUnitCharacteristicsCalculator
    {
        CharacteristicData Calculate(UnitInfo unitInfo);
    }
}