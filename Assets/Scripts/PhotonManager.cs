using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject lobbyCamera;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");  
    }

    //Look for room "Room" if it exists execute OnJoinedRoom if it does not exists create a new "Room"
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 3 }, TypedLobby.Default);
    }

    //When Joined the room Execute this code
    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", player.transform.position, Quaternion.identity, 0);
        lobbyCamera.SetActive(false);
    }

}
