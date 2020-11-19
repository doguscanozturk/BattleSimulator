using UnityEngine;

namespace UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        private GameObject thisGameObject;

        public bool IsOpen { get; protected set; }

        public virtual void Initialize()
        {
            thisGameObject = gameObject;
            thisGameObject.SetActive(false);
            IsOpen = false;
        }

        public virtual void Uninitialize()
        {
            thisGameObject = null;
        }

        public virtual void Open()
        {
            IsOpen = true;
            thisGameObject.SetActive(true);
        }

        public virtual void Close()
        {
            IsOpen = false;
            thisGameObject.SetActive(false);
        }
    }
}