using UnitSystem.Visualizers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AssetData", menuName = "Game/AssetData")]
    public class AssetData : ScriptableObject
    {
        public VisualizerAssets visualizerAssets;

        [Header("Gameplay Prefabs")] 
        public GameObject unitPrefab;
        public GameObject playgroundPrefab;
        [Header("UI Prefabs")] 
        public GameObject canvasPrefab;
        public GameObject homePanelPrefab;
        public GameObject gameOverPanelPrefab;
    }
}