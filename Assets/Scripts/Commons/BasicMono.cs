using UnityEngine;

namespace Commons
{
    public class BasicMono : MonoBehaviour
    {
        [Header("BasicMono")] 
        [SerializeField] protected Transform thisTransform;
        [SerializeField] protected GameObject thisGameObject;

        public Transform ThisTransform => thisTransform;
        public GameObject ThisGameObject => thisGameObject;

        [ContextMenu("GetReferences")]
        protected void GetReferences()
        {
            thisTransform = transform;
            thisGameObject = gameObject;
        }
    }
}