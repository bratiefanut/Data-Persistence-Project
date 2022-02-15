using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;

    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void UpdateBestScore(int score)
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            if (score > data.bestScore)
            {
                SaveBestScore(playerName, score);
            }

            //LoadBestScore();

        }
    }

    public void SaveBestScore(string name, int score)
    {
        SaveData data = new SaveData();

        LoadBestScore();

        if (score > bestScore)
        {
            data.bestPlayerName = name;
            data.bestScore = score;
        }
        else
        {
            data.bestPlayerName = bestPlayerName;
            data.bestScore = bestScore;
        }

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
