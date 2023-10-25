using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static event Action<float> FadeIn;
    public static event Action<float> FadeOut;
    public static LevelManager Instance;

    public float fadeDuration = 1.0f;

    private bool _isLoading = false;
   // [Header("Loading Slider")]
   // [SerializeField] private Slider loadingSlider;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void LoadSceneAsync(string sceneName)
    {
        if (!_isLoading)
        {
            StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
        }
    }
    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        _isLoading = true;

        FadeIn?.Invoke(fadeDuration);
        yield return new WaitForSeconds(fadeDuration);


        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!loadOperation.isDone)
        {
            if (loadOperation.progress >= 0.9f)
            {
                float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
              //  loadingSlider.value = progressValue;
            }
            yield return null;
        }
        _isLoading = false;


    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FadeOut?.Invoke(fadeDuration);
    }
}
