using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using Photon.Pun;
using Photon.Realtime;

public class GamePlayer : MonoBehaviour
{
    Rigidbody rbody;
    PhotonView photonView;
    //private PuzzleQuestion puzzle;
    /*GameObject myPlayer;

    Player[] twoPlayers;
    int id;*/
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();

        /*twoPlayers = PhotonNetwork.PlayerList;

        foreach(Player p in twoPlayers)
        {
            if(p != PhotonNetwork.LocalPlayer)
            {
                id++;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) 
        {
            //puzzle.Resposta("");
            //myPlayer = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), GameSpawn.instance.spawnPoints[id].position, Quaternion.identity);

            if (Input.GetKeyDown(KeyCode.C))
            {
                photonView.RPC("ChangeColor", RpcTarget.All, Random.Range(0.0f, 1.0f));
            }
        }
    }

    [PunRPC]
    public void ChangeColor(float hue, PhotonMessageInfo info)
    {
        Color newColor = Color.HSVToRGB(hue, 1, 1);
        GetComponent<MeshRenderer>().material.color = newColor;
    }
}
