using System;
using BattleSystem;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameOverPanel : Panel
    {
        [SerializeField] private Text result;
        
        public void OnReturnHomeClicked()
        {
            UIEvents.TriggerReturnHomeClicked();
            Close();
        }

        public void PreparePanel(BattleResult battleResult)
        {
            switch (battleResult)
            {
                case BattleResult.ArmyAWon:
                    result.text = $"ARMY A WON!";
                    break;
                case BattleResult.ArmyBWon:
                    result.text = $"ARMY B WON!";
                    break;
                case BattleResult.Draw:
                    result.text = $"DRAW!";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(battleResult), battleResult, null);
            }
        }
    }
}