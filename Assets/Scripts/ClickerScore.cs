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

    private string myName;

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
        myName = "User_" + Random.Range(0, 100);
    }

    public void AddScore()
    {
        myScore++;
        ScoreText.text = myScore.ToString();
        UpdateDict(myName, myScore.ToString());
    }

    public void UpdateDict(string username,string score)
    {
        if (username == myName)
        {
            object[] customData = new object[]
                {
                    myName,
                    myScore
                };

            PhotonNetwork.RaiseEvent(GameScoreEventCode, customData, new RaiseEventOptions() { Receivers = ReceiverGroup.Others }, SendOptions.SendReliable);
        }
        else
        {
          scoreDict[username] = score;
        }
    }

    private void OnEvent(EventData data)
    {
        if(data.Code==GameScoreEventCode)
        {
            object[] receivedData = (object[])data.CustomData;
            string username = (string)receivedData[0];
            string score = (string)receivedData[1];
            UpdateDict(username, score);
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
