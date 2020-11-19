using Events;

namespace UI.Panels
{
    public class HomePanel : Panel
    {
        public void OnStartClicked()
        {
            UIEvents.TriggerStartClicked();
            Close();
        }

        public void OnRandomizeClicked()
        {
            UIEvents.TriggerRandomizeClicked();
        }
    }
}