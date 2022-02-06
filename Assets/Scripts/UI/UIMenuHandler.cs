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
    [SerializeField] public TextMeshProUGUI bestScoreText;
    [SerializeField] public TMP_InputField inputField;

    [SerializeField] public string playerName;

    public void StartNew()
    {
        MenuMainManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public virtual void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    
    public void SaveClicked()
    {
        playerName = inputField.text;
        MenuMainManager.Instance.SaveScoreAndName();
        bestScoreText.text = "Name was saved";
    }

    public void ResetClicked()
    {
        MenuMainManager.Instance.ResetData();
        bestScoreText.text = "Data were reset!";


    }
    public void LoadClicked()
    {
        MenuMainManager.Instance.LoadScoreAndName();
        if(MenuMainManager.Instance.isEmpty)
            bestScoreText.text = "File is empty";
        else
            bestScoreText.text = MenuMainManager.Instance.GetBestScore();
    }
}
