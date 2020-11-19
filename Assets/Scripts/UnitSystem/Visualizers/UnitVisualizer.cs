using System.IO;
using UnitSystem.Characteristics.Color;
using UnitSystem.Characteristics.Shape;
using UnitSystem.Characteristics.Size;
using UnityEngine;

namespace UnitSystem.Visualizers
{
    public class UnitVisualizer
    {
        private readonly IUnitVisualizerUser unitVisualizerUser;
        private readonly VisualizerAssets visualizerAssets;

        public UnitVisualizer(IUnitVisualizerUser unitVisualizerUser, VisualizerAssets visualizerAssets)
        {
            this.unitVisualizerUser = unitVisualizerUser;
            this.visualizerAssets = visualizerAssets;
        }

        public void UpdateVisuals(UnitInfo unitInfo)
        {
            unitVisualizerUser.MeshFilter.mesh = unitInfo.shape is Cube ? visualizerAssets.cube : visualizerAssets.sphere;
            unitVisualizerUser.MeshRenderer.material = GetMaterial(unitInfo.color);
            unitVisualizerUser.MeshRendererTransform.localScale = unitInfo.size is Big ? Vector3.one * 2 : Vector3.one;
            unitVisualizerUser.MeshRendererTransform.localPosition = unitInfo.size is Big ? Vector3.up : Vector3.up / 2;
        }

        private Material GetMaterial(UnitColor color)
        {
            switch (color)
            {
                case Blue b:
                    return visualizerAssets.blue;
                case Yellow y:
                    return visualizerAssets.yellow;
                case Green g:
                    return visualizerAssets.green;
                case Red r:
                    return visualizerAssets.red;
                default:
                    throw new InvalidDataException();
            }
        }
    }
}