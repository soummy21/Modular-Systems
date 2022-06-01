using SoummySDK.DesignPatterns;
using SoummySDK.Saving;
using UnityEngine;

namespace SoummySDK.Systems.Economy
{
    public class EconomyManager : Singleton<EconomyManager>
    { 
        #region EconomyData

        //Saved Economy Data
        [System.Serializable]
        private class Economy
        {
            //Default Economy
            public Economy() { }

            //Actual Data
            public int inGameCurrency = 0;
        }
        //Runtime Economy Data
        private static Economy GameEconomy;

        public static int InGameCurrency => GameEconomy.inGameCurrency;
        #endregion

        #region Component Life Cycle 
        class LoadEconomyOnRuntime
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
            static void LoadEconomySaveData()
            {
                var SavedGameEconomy = SaveUtilities<Economy>.LoadDataClass();
                GameEconomy = SavedGameEconomy == null ? new Economy() : SavedGameEconomy;
            }

        }

        private void OnEnable() => ManagerMessages.OnEconomyUpdate.AddListener(UpdateEconomy);
        private void OnDisable() => ManagerMessages.OnEconomyUpdate.RemoveListner(UpdateEconomy);
        private void OnApplicationQuit() => SaveEconomyData();
        #endregion

        #region Behaviours
        private void SaveEconomyData() => SaveUtilities<Economy>.SaveDataClass(GameEconomy);

        //Don't access this function through any scripts, only public for the editor
        private void UpdateEconomy(int value)
        {
            GameEconomy.inGameCurrency += value;
            SaveEconomyData();
        }        

        //Can be accessed without Monobehaviours (To remove dependencies)
        #region Accesable Methods
        public static bool CheckEconomyBalance(int value) => GameEconomy.inGameCurrency >= value;
        #endregion

        #endregion

    }
}
