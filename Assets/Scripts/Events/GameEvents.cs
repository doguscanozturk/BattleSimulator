using System;
using BattleSystem;

namespace Events
{
    public static class GameEvents
    {
        public static event Action<BattleResult> BattleResulted;

        public static void TriggerBattleResulted(BattleResult battleResult)
        {
            BattleResulted?.Invoke(battleResult);
        }
    }
}