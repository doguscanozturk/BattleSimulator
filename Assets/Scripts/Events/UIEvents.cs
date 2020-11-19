using System;

namespace Events
{
    public static class UIEvents
    {
        public static event Action StartClicked;
        public static event Action RandomizeClicked;
        public static event Action ReturnHomeClicked;

        public static void TriggerRandomizeClicked()
        {
            RandomizeClicked?.Invoke();
        }
        
        public static void TriggerStartClicked()
        {
            StartClicked?.Invoke();
        }

        public static void TriggerReturnHomeClicked()
        {
            ReturnHomeClicked?.Invoke();
        }
    }
}