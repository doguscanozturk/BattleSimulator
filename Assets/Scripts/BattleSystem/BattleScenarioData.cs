using System;
using ArmySystem;

namespace BattleSystem
{
    [Serializable]
    public struct BattleScenarioData
    {
        public ArmyLineupData armyA;
        public ArmyLineupData armyB;
    }
}