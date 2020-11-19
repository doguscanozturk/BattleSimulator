using Data;
using UnitSystem.Calculators;
using UnitSystem.Calculators.Attack;
using UnitSystem.Calculators.Characteristic;
using UnitSystem.Calculators.Movement;
using UnityEngine;

namespace UnitSystem.Generators
{
    public class UnitGenerator : IUnitGenerator
    {
        private readonly GameData gameData;
        private readonly AssetData assetData;
        private readonly UnitCalculators unitCalculators;

        public UnitGenerator(GameData gameData, AssetData assetData)
        {
            this.gameData = gameData;
            this.assetData = assetData;

            var attackSpeedCalculator = new AttackSpeedCalculator(gameData.attackSpeedCalculationSettings);
            var movementSpeedCalculator = new MovementSpeedCalculator(gameData.movementSpeedCalculationSettings);
            var unitCharacteristicsCalculator = new UnitCharacteristicsCalculator();
            unitCalculators = new UnitCalculators(attackSpeedCalculator, movementSpeedCalculator, unitCharacteristicsCalculator);
        }

        public Unit GenerateUnit(Vector3 position, Quaternion rotation, Transform parent)
        {
            var newUnit = Object.Instantiate(assetData.unitPrefab, position, rotation, parent).GetComponent<Unit>();
            newUnit.Initialize(gameData, assetData, unitCalculators);
            return newUnit;
        }
    }
}