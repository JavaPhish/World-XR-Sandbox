using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class playerList : MonoBehaviourPunCallbacks
{
    public Text playerText;

    void Start()
    {
        playerText = GetComponent<Text>();
        playerText.text = "Waiting for players...";
    }

    void Awake()
    {
        string display = "Players:";
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++) 
        {
            display = display + "\n" + PhotonNetwork.CurrentRoom.Players[i];
        }
        playerText.text = display;
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        string display = "Players:";
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++) 
        {
            display = display + "\n" + PhotonNetwork.CurrentRoom.Players[i];
        }
        playerText.text = display;
    }
}
