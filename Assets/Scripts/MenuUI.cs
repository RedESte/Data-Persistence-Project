using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public InputField nameField;
    public Text bestScoreText;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.LoadRecord();
        string bestPlayer = GameData.Instance.bestPlayer;
        int bestScore = GameData.Instance.BestScore;
        if (bestScore != 0)
        {
            bestScoreText.text = $"Best Score: {bestPlayer}: {bestScore}";
        }
        else
        {
            bestScoreText.text = $"";
        }
    }

    public void SaveName()
    {
        playerName = nameField.text;
    }

    public void StartNewGame()
    {
        GameData.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
