using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerScore : MonoBehaviour
{

    public int myScore;

    public Text ScoreText;

    public Text DebugArea;

    public Dictionary<string, object> scoreDict = new();

    private string name;

    private void Start()
    {
        name = "User_" + Random.Range(0, 100);
    }

    public void AddScore()
    {
        myScore++;
        ScoreText.text = myScore.ToString();
        UpdateDict(name, myScore.ToString());
    }

    public void UpdateDict(string username,string score)
    {
        scoreDict[username] = score;
    }

    public void SubmitScore()
    {

    }

    public void DisplayScore()
    {
        foreach (var item in scoreDict)
        {
            DebugArea.text = $"Key is {item.Key} and value is {item.Value}";
        }
    }

}
