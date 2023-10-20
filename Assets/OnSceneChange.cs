using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// When the scene is changed, run some specific functionality
/// </summary>
public class OnSceneChange : MonoBehaviour
{
    // When scene is loaded and play begins
    public UnityEvent SceneChange = new UnityEvent();

    private void Awake()
    {
        SceneManager.activeSceneChanged += SceneChangedEvent;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SceneChangedEvent;
    }

    private void SceneChangedEvent(Scene scene1, Scene scene2)
    {
        SceneChange.Invoke();
    }
}
