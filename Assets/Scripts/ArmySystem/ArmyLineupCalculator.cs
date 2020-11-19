using System;
using UnityEngine;

namespace ArmySystem
{
    public class ArmyLineupCalculator
    {
        private readonly Settings settings;

        public ArmyLineupCalculator(Settings settings)
        {
            this.settings = settings;
        }

        public Vector3[] CalculateStartLineup(ArmyLineupData armyLineupData)
        {
            var unitCount = armyLineupData.unitCount;
            var firstHalfOfUnits = unitCount % 2 == 0 ? unitCount / 2 : (unitCount / 2) + 1;
            var secondHalfOfUnits = unitCount - firstHalfOfUnits;
            
            var forwardDirection = armyLineupData.startDirection;
            var backwardDirection = forwardDirection * -1;
            var center = armyLineupData.startPosition;
            var localLeftDirection = Vector3.Cross(forwardDirection, Vector3.up);
            var localRightDirection = localLeftDirection * -1;

            var startPosition = center + localLeftDirection * 
                ((firstHalfOfUnits / 2 * settings.horizontalDistanceBetweenUnits) - (settings.horizontalDistanceBetweenUnits/2));

            var result = new Vector3[unitCount];
            
            for (int i = 0; i < firstHalfOfUnits; i++)
            {
                result[i] = startPosition + (forwardDirection * settings.verticalDistanceBetweenUnits / 2) +
                            (i * settings.horizontalDistanceBetweenUnits * localRightDirection);
            }

            for (int i = 0; i < secondHalfOfUnits; i++)
            {
                var index = firstHalfOfUnits + i;
                result[index] = startPosition + (backwardDirection * settings.verticalDistanceBetweenUnits / 2) +
                                (i * settings.horizontalDistanceBetweenUnits * localRightDirection);
            }

            return result;
        }

        [Serializable]
        public struct Settings
        {
            public float verticalDistanceBetweenUnits;
            public float horizontalDistanceBetweenUnits;
        }
    }
}