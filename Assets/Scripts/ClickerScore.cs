using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerScore : MonoBehaviour
{

    public int myScore;

    public Text ScoreText;

    public Text DebugArea;

    public void AddScore()
    {
        myScore++;

        ScoreText.text = myScore.ToString();
    }
}
