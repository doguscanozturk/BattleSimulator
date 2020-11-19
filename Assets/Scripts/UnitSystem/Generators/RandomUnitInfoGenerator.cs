using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Extensions;
using UnitSystem.Characteristics.Color;
using UnitSystem.Characteristics.Shape;
using UnitSystem.Characteristics.Size;

namespace UnitSystem.Generators
{
    public static class RandomUnitInfoGenerator
    {
        private static readonly Type[] availableTypesInAssembly;
        private static readonly List<Type> availableShapes;
        private static readonly List<Type> availableSizes;
        private static readonly List<Type> availableColors;

        static RandomUnitInfoGenerator()
        {
            var assembly = Assembly.GetAssembly(typeof(RandomUnitInfoGenerator));
            availableTypesInAssembly = assembly.GetTypes();

            availableShapes = availableTypesInAssembly.Where(t => t.IsSubclassOf(typeof(UnitShape))).ToList();
            availableSizes = availableTypesInAssembly.Where(t => t.IsSubclassOf(typeof(UnitSize))).ToList();
            availableColors = availableTypesInAssembly.Where(t => t.IsSubclassOf(typeof(UnitColor))).ToList();
        }

        public static UnitInfo Generate()
        {
            UnitInfo newUnitInfo;

            newUnitInfo.shape = (UnitShape) Activator.CreateInstance(availableShapes.GetRandomElement());
            newUnitInfo.size = (UnitSize) Activator.CreateInstance(availableSizes.GetRandomElement());
            newUnitInfo.color = (UnitColor) Activator.CreateInstance(availableColors.GetRandomElement(), newUnitInfo.shape);

            return newUnitInfo;
        }
    }
}