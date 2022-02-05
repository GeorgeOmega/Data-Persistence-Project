using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField inputField;

    public string playerName;

    public void Start()
    {
        bestScoreText.text = MenuMainManager.Instance.GetBestScore();
        inputField.text = MenuMainManager.Instance.playerName;
    }

    public void StartNew()
    {
        MenuMainManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public void SaveNameClicked()
    {
        MenuMainManager.Instance.SaveScoreAndName();
    }
}
