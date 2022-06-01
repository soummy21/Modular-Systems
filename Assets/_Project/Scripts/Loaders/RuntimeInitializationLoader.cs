//Loader executes methods during runtime according to the RuntimeInitializeLoadType. 
using UnityEngine;
using SoummySDK.Systems.Economy;

namespace SoummySDK
{
    class RuntimeInitializationLoader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void RunTimeLoad()
        {
            LoadManagersInGame();
        }

        static void LoadManagersInGame()
        {
            GameObject gameObject = new GameObject("Loaded Managers");
            CreateManager<EconomyManager>(gameObject.transform);
            Debug.Log("Loaded Managers....");
        }

        static void CreateManager<T>() where T : Component
        {
            GameObject manager = new GameObject(typeof(T).Name);
            manager.AddComponent<T>();
        }

        static void CreateManager<T>(Transform parent) where T : Component
        {
            GameObject manager = new GameObject(typeof(T).Name);
            manager.transform.parent = parent;
            manager.AddComponent<T>();
        }

    }
}
