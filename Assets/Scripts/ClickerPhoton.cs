using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClickerPhoton : MonoBehaviourPunCallbacks
{

    public TypedLobby testLobby = new TypedLobby("TestLobby", LobbyType.Default);

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ShowDebug(string message)
    {
        Debug.Log("<<<<" + message);
    }


    //-----------------------------------------------------------------------------------------------

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby(testLobby);
        ShowDebug("OnConnectedToMaster");

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        ShowDebug("On Joined Lobby");

        RoomOptions myRoomOptions = new RoomOptions();
        myRoomOptions.MaxPlayers = 2;

        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions:myRoomOptions);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        ShowDebug("On Joined Room  " + PhotonNetwork.CurrentRoom.Name);
    }

}
