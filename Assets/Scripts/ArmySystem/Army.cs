using UnitSystem;
using UnityEngine;

namespace ArmySystem
{
    public struct Army
    {
        public Transform sceneRoot;
        public Unit[] units;

        public void Clear()
        {
            for (int i = units.Length - 1; i >= 0; i--)
            {
                units[i].Uninitialize();
                Object.Destroy(units[i].ThisGameObject);
            }

            units = null;
            Object.Destroy(sceneRoot.gameObject);
        }
    }
}