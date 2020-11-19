using ArmySystem;
using BattleSystem;
using Camera;
using Data;
using Events;
using UnitSystem.Generators;
using UnityEngine;

namespace Progression
{
    public class LevelManager
    {
        private readonly GameData gameData;
        private readonly AssetData assetData;
        private readonly UnitGenerator unitGenerator;
        private readonly ArmyGenerator armyGenerator;
        private readonly BattleReferee battleReferee;
        private readonly BattleDirector battleDirector;

        private GameObject playground;
        private Army armyA;
        private Army armyB;

        public LevelManager(GameData gameData, AssetData assetData)
        {
            this.gameData = gameData;
            this.assetData = assetData;

            unitGenerator = new UnitGenerator(gameData, assetData);
            armyGenerator = new ArmyGenerator(gameData.armyLineupCalculatorSettings, unitGenerator);
            battleReferee = new BattleReferee();
            battleDirector = new BattleDirector();

            playground = Object.Instantiate(assetData.playgroundPrefab);

            UIEvents.StartClicked += OnStartClicked;
            UIEvents.RandomizeClicked += OnRandomizeClicked;
            UIEvents.ReturnHomeClicked += OnReturnHomeClicked;
        }

        public void InitializeLevel()
        {
            armyA = armyGenerator.GenerateArmy(gameData.battleScenarioData.armyA);
            armyB = armyGenerator.GenerateArmy(gameData.battleScenarioData.armyB);
            battleReferee.Initialize(armyA.units, armyB.units);
            battleDirector.Initialize(armyA.units, armyB.units);
        }

        public void UninitializeLevel()
        {
            battleDirector.Uninitialize();
            battleReferee.Uninitialize();
            armyA.Clear();
            armyB.Clear();
        }

        public void UpdateFrame(float deltaTime)
        {
            battleReferee.UpdateFrame(deltaTime);
            battleDirector.UpdateFrame(deltaTime);
        }

        private void OnRandomizeClicked()
        {
            for (int i = 0; i < armyA.units.Length; i++)
            {
                armyA.units[i].PickRandomCharacteristic();
            }

            for (int i = 0; i < armyB.units.Length; i++)
            {
                armyB.units[i].PickRandomCharacteristic();
            }
        }

        private void OnStartClicked()
        {
            battleDirector.StartDirecting();
            battleReferee.StartWatching();
            CameraEvents.TriggerCameraStateUpdated(CameraDirector.State.Battle);
        }

        private void OnReturnHomeClicked()
        {
            UninitializeLevel();
            InitializeLevel();
            CameraEvents.TriggerCameraStateUpdated(CameraDirector.State.PreBattle);
        }
    }
}