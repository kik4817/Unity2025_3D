using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button ReStartButton;
    [SerializeField] Button QuitButton;

    private void OnEnable()
    {
        ReStartButton.onClick.AddListener(Restart);
        QuitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        //ReStartButton.onClick.RemoveListener(Quit); // ÇÑ°³¾¿
        ReStartButton.onClick.RemoveAllListeners();
        QuitButton.onClick.RemoveAllListeners();
    }

    public void Quit()
    {        
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}
