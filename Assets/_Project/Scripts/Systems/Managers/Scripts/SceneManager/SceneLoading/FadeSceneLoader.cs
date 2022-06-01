using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SoummySDK.Systems.SceneManagement.SceneLoading
{
    public class FadeSceneLoader : MonoBehaviour, ISceneLoader
    {
        [Header("Fading Properties")]
        [SerializeField] private Image sceneFadeImage;
        [SerializeField] private bool enableSceneFade = true;

        [Header("Fade In")]
        [SerializeField] private float timeToFadeIn = 1f;
        [SerializeField] private Ease fadeInEaseType = Ease.OutQuint;

        [Header("Fade Out")]
        [SerializeField] private bool initialSceneFadeOut = false;
        [SerializeField] private float timeToFadeOut = 1f;
        [SerializeField] private Ease fadeOutEaseType = Ease.InQuad;

        private Tween FadeIn;
        private Tween FadeOut;

        #region SETUP

        private void InitializeSceneFading()
        {
            if (!enableSceneFade) return;
            else if(sceneFadeImage == null)
            {
                Debug.LogError("FadeImage Missing!!, Add a FadeImage and run Play Mode again");
                return;
            }

            if (initialSceneFadeOut)
            {
                sceneFadeImage.gameObject.SetActive(true);
                SetFadeImageInstant(1f);
            }
            else
            {
                SetFadeImageInstant(0f);
                sceneFadeImage.gameObject.SetActive(false);
            }

        }
        private void SetFadeImageInstant(float alpha)
        {
            Color tempColor = sceneFadeImage.color;
            tempColor.a = alpha;
            sceneFadeImage.color = tempColor;
        }

        private void SetTweens()
        {
            FadeIn = sceneFadeImage.DOFade(1f, timeToFadeIn).SetEase(fadeInEaseType);
            FadeOut = sceneFadeImage.DOFade(0f, timeToFadeOut).SetEase(fadeOutEaseType).
                            OnComplete(() => sceneFadeImage.gameObject.SetActive(false));
        }

        #endregion

        private void Awake()
        {
            InitializeSceneFading();
            SetTweens();
        }

        public IEnumerator LoadScene(int sceneNo)
        {
            yield return StartCoroutine(SceneLoader.LoadScene(sceneNo));
            if (initialSceneFadeOut)
                yield return FadeOut.WaitForCompletion();
        }

        public IEnumerator LoadScene(string sceneName)
        {
            yield return StartCoroutine(SceneLoader.LoadScene(sceneName));
            if (initialSceneFadeOut) 
                yield return FadeOut.WaitForCompletion();
        }

        public IEnumerator UnloadLoadScene(int unloadSceneNo, int loadSceneNo)
        {
            sceneFadeImage.gameObject.SetActive(true);
            yield return FadeIn.WaitForCompletion();
            yield return StartCoroutine(SceneLoader.UnloadLoadScene(unloadSceneNo, loadSceneNo));
            yield return FadeOut.WaitForCompletion();
        }

        public IEnumerator UnloadLoadScene(string unloadSceneName, string loadSceneName)
        {
            sceneFadeImage.gameObject.SetActive(true);
            yield return FadeIn.WaitForCompletion();
            yield return StartCoroutine(SceneLoader.UnloadLoadScene(unloadSceneName, loadSceneName));
            yield return FadeOut.WaitForCompletion();
        }



    }
}
