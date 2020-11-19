using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var randomResult = new UnitInfo();

            var randomShape = availableShapes[UnityEngine.Random.Range(0, availableShapes.Count())];
            randomResult.shape = (UnitShape) Activator.CreateInstance(randomShape);
            var randomSize = availableSizes[UnityEngine.Random.Range(0, availableSizes.Count())];
            randomResult.size = (UnitSize) Activator.CreateInstance(randomSize);
            var randomColor = availableColors[UnityEngine.Random.Range(0, availableColors.Count())];
            randomResult.color = (UnitColor) Activator.CreateInstance(randomColor, randomResult.shape);

            return randomResult;
        }
    }
}