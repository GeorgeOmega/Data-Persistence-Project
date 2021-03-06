using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class MenuMainManager : MonoBehaviour
{
    [SerializeField] public static MenuMainManager Instance;
    [SerializeField] public static TMP_InputField inputField;
    [SerializeField] public string playerName;
    [SerializeField] public int bestScore;
    [SerializeField] public string bestScorePlayer;

    [SerializeField] public bool isEmpty = false;
    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        bestScore = 0;
        DontDestroyOnLoad(gameObject);
    }
    public string GetBestScore()
    {
        return $"Best Score \n {bestScorePlayer} : {bestScore}";
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
        Debug.Log(Application.persistentDataPath);    
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
            isEmpty = false;
        }
        else
        {
            Debug.Log("No data");
            isEmpty = true;
        }
    }
    public void ResetData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path) && File.ReadAllText(path) != null)
            File.Delete(Application.persistentDataPath + "/savefile.json");
        else Debug.Log("File is empty");
    }
}
