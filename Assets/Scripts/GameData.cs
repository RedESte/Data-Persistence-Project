using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public string playerName;
    public string bestPlayer;
    int bestScore;

    public int BestScore { get => bestScore; private set => bestScore = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName = "";
        public int bestScore = 0;
    }

    public void SaveRecord(int score)
    {
        BestScore = score;
        SaveData saveData = new SaveData();
        saveData.playerName = playerName;
        saveData.bestScore = BestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScore = data.bestScore;
            bestPlayer = data.playerName;
        }
    }

}
