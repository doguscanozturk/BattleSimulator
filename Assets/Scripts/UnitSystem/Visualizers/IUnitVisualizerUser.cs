using UnityEngine;

namespace UnitSystem.Visualizers
{
    public interface IUnitVisualizerUser
    {
        MeshFilter MeshFilter { get; }
        MeshRenderer MeshRenderer { get; }
        Transform MeshRendererTransform { get; }
    }
}