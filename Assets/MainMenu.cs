using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string startButtonSceneName;
    
    public Button startButton;
    public GameObject mainMenu;
    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
    }
    private void StartGame()
    {
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync(startButtonSceneName);
    }
}