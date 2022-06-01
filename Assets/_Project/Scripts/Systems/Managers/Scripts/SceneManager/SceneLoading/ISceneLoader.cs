using System.Collections;

namespace SoummySDK.Systems.SceneManagement.SceneLoading
{
    public interface ISceneLoader
    {
        public IEnumerator LoadScene(int sceneNo);
        public IEnumerator LoadScene(string sceneName);
        public IEnumerator UnloadLoadScene(int unloadSceneNo, int loadSceneNo);
        public IEnumerator UnloadLoadScene(string unloadSceneName, string loadSceneName);
    } 
}
