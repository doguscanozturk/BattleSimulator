using System;
using UnityEngine;

namespace ArmySystem
{
    [Serializable]
    public struct ArmyLineupData
    {
        public int unitCount;
        public Vector3 startPosition;
        public Vector3 startDirection;
    }
}