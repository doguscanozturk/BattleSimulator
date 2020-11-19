using UnityEngine;

namespace UnitSystem.Generators
{
    public interface IUnitGenerator
    {
        Unit GenerateUnit(Vector3 position, Quaternion rotation, Transform parent);
    }
}