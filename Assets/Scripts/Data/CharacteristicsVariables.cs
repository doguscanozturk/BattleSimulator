using UnitSystem.Characteristics;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacteristicsVariables", menuName = "Game/CharacteristicsVariables")]
    public class CharacteristicsVariables : ScriptableObject
    {
        public CharacteristicData basicUnit;
        [Header("Shapes")]
        public CharacteristicData cube;
        public CharacteristicData sphere;
        [Header("Sizes")]
        public CharacteristicData big;
        public CharacteristicData small;
        [Header("Colors")]
        public CharacteristicData blue;
        public CharacteristicData yellow;
        public CharacteristicData green;
        public CharacteristicData red;
    }
}