using UnitSystem;
using UnitSystem.Generators;
using UnityEngine;

namespace ArmySystem
{
    public class ArmyGenerator
    {
        private readonly ArmyLineupCalculator armyLineupCalculator;
        private readonly IUnitGenerator unitGenerator;

        public ArmyGenerator(ArmyLineupCalculator.Settings armyLineupCalculatorSettings, IUnitGenerator unitGenerator)
        {
            this.unitGenerator = unitGenerator;
            armyLineupCalculator = new ArmyLineupCalculator(armyLineupCalculatorSettings);
        }

        public Army GenerateArmy(ArmyLineupData armyLineupData)
        {
            var result = new Army();
            result.units = new Unit[armyLineupData.unitCount];
            result.sceneRoot = new GameObject("Army").transform;

            var unitPositions = armyLineupCalculator.CalculateStartLineup(armyLineupData);
            var lookDir = Quaternion.Euler(armyLineupData.startDirection);

            for (int i = 0; i < armyLineupData.unitCount; i++)
            {
                var newUnit = unitGenerator.GenerateUnit(unitPositions[i], lookDir, result.sceneRoot);
                result.units[i] = newUnit;
            }

            return result;
        }
    }
}