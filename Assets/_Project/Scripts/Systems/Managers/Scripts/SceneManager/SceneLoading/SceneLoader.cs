using System.Collections;
using UnityEngine.SceneManagement;

namespace SoummySDK.Systems.SceneManagement.SceneLoading
{
    public static class SceneLoader
    {
        public static IEnumerator LoadScene(int sceneNo)
        {
            yield return SceneManager.LoadSceneAsync(sceneNo, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneNo));
        }

        public static IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        public static IEnumerator UnloadLoadScene(int unloadSceneNo, int loadSceneNo)
        {
            yield return SceneManager.UnloadSceneAsync(unloadSceneNo);
            yield return SceneManager.LoadSceneAsync(loadSceneNo, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadSceneNo));
        }

        public static IEnumerator UnloadLoadScene(string unloadSceneName, string loadSceneName)
        {
            yield return SceneManager.UnloadSceneAsync(unloadSceneName);
            yield return SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadSceneName));
        } 
    }
}
