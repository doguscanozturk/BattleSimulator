using UnitSystem.Characteristics;
using UnitSystem.GameDesign;

namespace UnitSystem.Calculators.Characteristic
{
    public class UnitCharacteristicsCalculator : IUnitCharacteristicsCalculator
    {
        private readonly CharacteristicData basicUnitCharacteristic;

        public UnitCharacteristicsCalculator()
        {
            basicUnitCharacteristic = GameDesignVariables.BasicUnit;
        }

        public CharacteristicData Calculate(UnitInfo unitInfo)
        {
            var result = basicUnitCharacteristic;

            result += unitInfo.shape.BonusCharacteristics;
            result += unitInfo.size.BonusCharacteristics;
            result += unitInfo.color.BonusCharacteristics;

            return result;
        }
    }
}