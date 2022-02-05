using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class MenuMainManager : MonoBehaviour
{
    public static MenuMainManager Instance;
    public static TMP_InputField inputField;
    public string playerName;
    public int bestScore;
    public string bestScorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        bestScore = 0;
        DontDestroyOnLoad(gameObject);
        LoadScoreAndName();

    }
    public string GetBestScore()
    {
        return $"Best Score : {bestScorePlayer} : {bestScore}";
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int bestScore;
        public string bestScorePlayer;
    }

    public void SaveScoreAndName()
    {
        SaveData data = new SaveData();
        data.PlayerName = playerName;
        data.bestScore = bestScore;
        data.bestScorePlayer = bestScorePlayer;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(data.PlayerName);
    }

    public void LoadScoreAndName()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.PlayerName;
            bestScore = data.bestScore;
            bestScorePlayer = data.bestScorePlayer;
        }
    }
}
