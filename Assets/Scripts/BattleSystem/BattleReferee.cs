using Events;
using UnitSystem;

namespace BattleSystem
{
    public class BattleReferee
    {
        private bool isWatching;
        private Unit[] armyA;
        private Unit[] armyB;

        public void Initialize(Unit[] armyA, Unit[] armyB)
        {
            this.armyA = armyA;
            this.armyB = armyB;
        }

        public void Uninitialize()
        {
            armyA = null;
            armyB = null;
        }

        public void StartWatching()
        {
            isWatching = true;
        }

        public void StopWatching()
        {
            isWatching = false;
        }

        public void UpdateFrame(float deltaTime)
        {
            if (!isWatching) return;

            var isEveryoneInArmyADead = CheckIsEveryoneDead(armyA);
            var isEveryoneInArmyBDead = CheckIsEveryoneDead(armyB);

            if (isEveryoneInArmyADead && isEveryoneInArmyBDead)
            {
                DecideResultOfTheBattle(BattleResult.Draw);
                return;
            }

            if (isEveryoneInArmyADead)
            {
                DecideResultOfTheBattle(BattleResult.ArmyBWon);
                return;
            }

            if (isEveryoneInArmyBDead)
            {
                DecideResultOfTheBattle(BattleResult.ArmyAWon);
            }
        }

        private void DecideResultOfTheBattle(BattleResult battleResult)
        {
            GameEvents.TriggerBattleResulted(battleResult);
            StopWatching();
        }

        private bool CheckIsEveryoneDead(Unit[] units)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (!units[i].Health.IsDead)
                {
                    return false;
                }
            }

            return true;
        }
    }
}