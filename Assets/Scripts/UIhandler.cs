using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public TMP_InputField playerName;

    public TMP_Text welcomePlayer;

    public TMP_Text bestPlayerScore;

    public void Start()
    {
        if (GameManager.Instance.playerName != "")
        {
            welcomePlayer.text = "Welcome, " + GameManager.Instance.playerName + "!";
        }
        else
        {
            welcomePlayer.text = "Welcome!";
        }

        GameManager.Instance.LoadBestScore();
        bestPlayerScore.text = "Best score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;
    }

    public void StartGame()
    {
        if (playerName.text != "")
        {
            GameManager.Instance.playerName = playerName.text;
        }

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
