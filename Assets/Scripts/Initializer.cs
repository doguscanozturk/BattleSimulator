using Data;
using Progression;
using UI;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private UISystem uiSystem;
    private GameData gameData;
    private AssetData assetData;
    private LevelManager levelManager;

    void Start()
    {
        gameData = (GameData) Resources.Load("Data/GameData", typeof(ScriptableObject));
        assetData = (AssetData) Resources.Load("Data/AssetData", typeof(ScriptableObject));
        
        uiSystem = new UISystem(assetData);

        levelManager = new LevelManager(gameData, assetData);
        levelManager.InitializeLevel();
    }

    void Update()
    {
        var deltaTime = Time.deltaTime;
        levelManager.UpdateFrame(deltaTime);
    }
}