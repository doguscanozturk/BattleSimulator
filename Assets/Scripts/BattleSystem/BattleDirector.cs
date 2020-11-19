using Events;
using UnitSystem;
using UnityEngine;

namespace BattleSystem
{
    public class BattleDirector
    {
        private Unit[] armyA;
        private Unit[] armyB;
        private bool isDirecting;

        public BattleDirector()
        {
            GameEvents.BattleResulted += OnBattleResulted;
        }

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

        public void UpdateFrame(float deltaTime)
        {
            if (!isDirecting) return;

            MatchEverybodyToClosest(armyA, armyB);
            MatchEverybodyToClosest(armyB, armyA);
        }

        public void StartDirecting()
        {
            isDirecting = true;
        }

        private void MatchEverybodyToClosest(Unit[] targetingUnits, Unit[] targetUnits)
        {
            for (int i = 0; i < targetingUnits.Length; i++)
            {
                var subjectUnit = targetingUnits[i];
                var (closestUnit, closestUnitDistance, didFindAnyTarget) = FindClosestUnitAndDistance(subjectUnit.ThisTransform.position, targetUnits);

                if (!didFindAnyTarget) continue;

                subjectUnit.SetTarget(closestUnit);

                if (closestUnitDistance <= subjectUnit.AttackRange)
                {
                    subjectUnit.AttackTo(closestUnit);
                }
            }
        }

        private (Unit, float, bool) FindClosestUnitAndDistance(Vector3 requestedPosition, Unit[] targets)
        {
            var closestDistance = float.MaxValue;
            var resultUnit = default(Unit);
            var didFindAnyTarget = false;

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].Health.IsDead)
                {
                    continue;
                }

                didFindAnyTarget = true;
                var distance = Vector3.Distance(targets[i].ThisTransform.position, requestedPosition);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    resultUnit = targets[i];
                }
            }

            return (resultUnit, closestDistance, didFindAnyTarget);
        }

        private void OnBattleResulted(BattleResult result)
        {
            isDirecting = false;
            for (int i = 0; i < armyA.Length; i++)
            {
                armyA[i].Stop();
            }

            for (int i = 0; i < armyB.Length; i++)
            {
                armyB[i].Stop();
            }
        }
    }
}