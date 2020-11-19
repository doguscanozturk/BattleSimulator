using Data;
using UnitSystem.Characteristics;
using UnityEngine;

namespace UnitSystem.GameDesign
{
    public static class GameDesignVariables
    {
        private static readonly CharacteristicsVariables CharacteristicsVariables;

        public static CharacteristicData BasicUnit;
        public static CharacteristicData Cube;
        public static CharacteristicData Sphere;
        public static CharacteristicData Big;
        public static CharacteristicData Small;
        public static CharacteristicData Blue;
        public static CharacteristicData Yellow;
        public static CharacteristicData Green;
        public static CharacteristicData Red;
    
        static GameDesignVariables()
        {
            CharacteristicsVariables = (CharacteristicsVariables) Resources.Load("Data/CharacteristicsVariables", typeof(ScriptableObject));
            BasicUnit = CharacteristicsVariables.basicUnit;
            Cube = CharacteristicsVariables.cube;
            Sphere = CharacteristicsVariables.sphere;
            Big = CharacteristicsVariables.big;
            Small = CharacteristicsVariables.small;
            Blue = CharacteristicsVariables.blue;
            Yellow = CharacteristicsVariables.yellow;
            Green = CharacteristicsVariables.green;
            Red = CharacteristicsVariables.red;
        }
    }
}