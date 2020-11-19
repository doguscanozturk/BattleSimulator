namespace UnitSystem.Calculators
{
    public class UnitCalculators
    {
        public readonly IBasicCalculator attackSpeedCalculator;
        public readonly IBasicCalculator movementSpeedCalculator;
        public readonly IUnitCharacteristicsCalculator unitCharacteristicsCalculator;

        public UnitCalculators(IBasicCalculator attackSpeedCalculator, IBasicCalculator movementSpeedCalculator, IUnitCharacteristicsCalculator unitCharacteristicsCalculator)
        {
            this.attackSpeedCalculator = attackSpeedCalculator;
            this.movementSpeedCalculator = movementSpeedCalculator;
            this.unitCharacteristicsCalculator = unitCharacteristicsCalculator;
        }
    }
}