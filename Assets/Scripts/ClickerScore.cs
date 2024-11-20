using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ClickerScore : MonoBehaviourPunCallbacks
{

    public int myScore;

    public Text ScoreText;

    public Text DebugArea;

    public Dictionary<string, object> scoreDict = new();

    private string name;

    public static byte GameScoreEventCode = 80;

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }
    

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

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

        object[] customData = new object[]
            {
                    name,
                    myScore
            };

        PhotonNetwork.RaiseEvent(GameScoreEventCode, customData, new RaiseEventOptions() { Receivers = ReceiverGroup.Others }, SendOptions.SendReliable);
    }

    private void OnEvent(EventData data)
    {
        if(data.Code==GameScoreEventCode)
        {

        }
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
