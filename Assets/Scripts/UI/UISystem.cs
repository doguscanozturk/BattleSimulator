using BattleSystem;
using Data;
using Events;
using UI.Panels;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public class UISystem
    {
        private readonly AssetData assetData;
        private readonly Canvas canvas;
        private readonly Transform canvasTransform;
        private readonly HomePanel homePanel;
        private readonly GameOverPanel gameOverPanel;

        public UISystem(AssetData assetData)
        {
            this.assetData = assetData;

            canvas = Object.Instantiate(assetData.canvasPrefab).GetComponent<Canvas>();
            canvasTransform = canvas.transform;

            homePanel = Object.Instantiate(assetData.homePanelPrefab, canvasTransform).GetComponent<HomePanel>();
            homePanel.Initialize();
            homePanel.Open();
            gameOverPanel = Object.Instantiate(assetData.gameOverPanelPrefab, canvasTransform).GetComponent<GameOverPanel>();
            gameOverPanel.Initialize();

            UIEvents.ReturnHomeClicked += OnReturnHomeClicked;
            GameEvents.BattleResulted += OnBattleResulted;
        }

        private void OnReturnHomeClicked()
        {
            homePanel.Open();
        }

        private void OnBattleResulted(BattleResult battleResult)
        {
            gameOverPanel.PreparePanel(battleResult);
            gameOverPanel.Open();
        }
    }
}