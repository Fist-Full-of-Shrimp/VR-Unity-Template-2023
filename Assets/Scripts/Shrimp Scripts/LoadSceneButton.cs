using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    public string sceneName;

    private Button _loadSceneButton;
    private void Awake()
    {
        _loadSceneButton = GetComponent<Button>();
    }
    private void Start()
    {
        _loadSceneButton.onClick.AddListener(StartGame);
    }
    private void OnDestroy()
    {
        _loadSceneButton.onClick.RemoveListener(StartGame);
    }
    private void StartGame()
    {
        LevelManager.Instance.LoadSceneAsync(sceneName);
    }
}
