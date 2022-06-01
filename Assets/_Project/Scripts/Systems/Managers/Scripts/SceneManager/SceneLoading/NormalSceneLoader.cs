using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoummySDK.Systems.SceneManagement.SceneLoading
{
    public class NormalSceneLoader : MonoBehaviour, ISceneLoader
    {
        public IEnumerator LoadScene(int sceneNo)
        {
            yield return StartCoroutine(SceneLoader.LoadScene(sceneNo));
        }

        public IEnumerator LoadScene(string sceneName)
        {
            yield return StartCoroutine(SceneLoader.LoadScene(sceneName));
        }

        public IEnumerator UnloadLoadScene(int unloadSceneNo, int loadSceneNo)
        {
            yield return StartCoroutine(SceneLoader.UnloadLoadScene(unloadSceneNo, loadSceneNo));
        }

        public IEnumerator UnloadLoadScene(string unloadSceneName, string loadSceneName)
        {
            yield return StartCoroutine(SceneLoader.UnloadLoadScene(unloadSceneName, loadSceneName));
        }
    }

}