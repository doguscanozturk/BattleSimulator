using ArmySystem;
using BattleSystem;
using UnitSystem.Calculators.Attack;
using UnitSystem.Calculators.Movement;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game/GameData")]
    public class GameData : ScriptableObject
    {
        public MovementSpeedCalculator.Settings movementSpeedCalculationSettings;
        public AttackSpeedCalculator.Settings attackSpeedCalculationSettings;
        public AttackRangeSettings attackRangeSettings;
        public ArmyLineupCalculator.Settings armyLineupCalculatorSettings;
        public BattleScenarioData battleScenarioData;
    }
}