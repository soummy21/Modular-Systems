using UnityEngine;
using UnityEngine.SceneManagement;
using SoummySDK.Saving;
using SoummySDK.DesignPatterns;
using SoummySDK.Systems.SceneManagement.SceneLoading;


namespace SoummySDK.Systems.SceneManagement
{
    public class GameSceneManager : Singleton<GameSceneManager>
    {
        #region GameSceneManager Data
        [System.Serializable]
        private class Progression
        {
            //Default PlayerProgress
            public Progression() { }

            //Actual Data
            public int sceneToLoad = 1;
            public int currentLevel = 1;
        }

        private static Progression GameProgression;
        public static int CurrentLevel => GameProgression.currentLevel;
        #endregion

        [Header("Loading Data")]
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private bool enableLoadingScreen = true;
        [SerializeField] private float loadingTime = 3f;

        private int totalLevels = -1;
        private int loadedScene = -1;
        private int LoadedScene
        {
            get => loadedScene;
            set => loadedScene = value == 0 ? totalLevels : value;
        } //Set Logic for previousLoadedMap

        private ISceneLoader sceneLoader;

        #region Component Life Cycle

        class RuntimeLoader
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
            static void LoadSavedProgressionData()
            {
                var SavedPlayerProgress = SaveUtilities<Progression>.LoadDataClass();
                GameProgression = SavedPlayerProgress == null ? new Progression() : SavedPlayerProgress;

            }

        }

        private void Start()
        {
            totalLevels = SceneManager.sceneCountInBuildSettings - 1;
            sceneLoader = GetComponent<ISceneLoader>();
            if(sceneLoader == null)
            {
                Debug.LogError($"No ISceneLoader attached to GameSceneManager");
                return;
            }
        }

        private void OnEnable()
        {
            ManagerMessages.GameSceneManagerMessages.OnUpdateLevel.AddListener(UpdateCurrentLevel);
            ManagerMessages.GameSceneManagerMessages.OnLoadCurretLevel.AddListener(UnloadLoadScene);
        }

        private void OnDisable()
        {
            ManagerMessages.GameSceneManagerMessages.OnUpdateLevel.RemoveListener(UpdateCurrentLevel);
            ManagerMessages.GameSceneManagerMessages.OnLoadCurretLevel.RemoveListener(UnloadLoadScene);
        }
            
        #endregion

        private void LoadGameScene()
        {
            loadingScreen.SetActive(enableLoadingScreen);
            LoadScene();
            if (enableLoadingScreen) Invoke(nameof(OnCompleteLoading), loadingTime);
            
        }

        private void OnCompleteLoading()
        {
            loadingScreen.SetActive(enableLoadingScreen);
            //Run Any OnCompleteLoadingFunctionality
        }

        private void UpdateCurrentLevel()
        {
            IncrementCurrentLevel();
            SaveGameData();

        }
        //Increments currentLevel and updates previousMapLoaded and currentMapLoaded accordingly
        private void IncrementCurrentLevel()
        {
            GameProgression.currentLevel++;
            //currentLoadedMap 
            LoadedScene = GameProgression.sceneToLoad; //Store the previousScene to be unloaded
            GameProgression.sceneToLoad = GameProgression.currentLevel % totalLevels == 0
                ? totalLevels : GameProgression.currentLevel % totalLevels; //scene to be loaded
        }
        //Saves GameProgession
        private void SaveGameData() => SaveUtilities<Progression>.SaveDataClass(GameProgression);

        private void LoadScene() => StartCoroutine(sceneLoader.LoadScene(GameProgression.sceneToLoad));
        private void UnloadLoadScene() => StartCoroutine(sceneLoader.UnloadLoadScene(loadedScene, GameProgression.sceneToLoad));

    }
}
