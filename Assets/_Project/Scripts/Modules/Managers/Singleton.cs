//SINGLETON PATTERN 
//An Inheritable Class that creates a private instance of the inherited class

using UnityEngine;

namespace SoummySDK.DesignPatterns
{
    [RequireComponent(typeof(Transform))]
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        [Header("Load Property")]
        [SerializeField] protected bool dontDestroyOnLoad = false;

        public virtual void Awake()
        {
            if (instance == null)
                instance = this as T;

            if(dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }

        public virtual void OnDestroy()
        {
            if (instance == this as T)
                instance = null;
        }
    }

}
