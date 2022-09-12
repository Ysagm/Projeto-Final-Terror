using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class GameSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    public int count = 0;
    public List<Vector3> spawnPosition = new List<Vector3>();
    void Start()
    {
        spawnPosition.Add(new Vector3(-1,0,3));
        spawnPosition.Add(new Vector3(-1,0,-2));

        for(int i = 0; i < 1; i++)
        {
            count++;

            if(PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(player.name, new Vector3(-1,0,3), transform.rotation, 0);
                Debug.Log("Player 01 created");
            }
            else
            {
                PhotonNetwork.Instantiate(player.name, new Vector3(-1,0,-2), transform.rotation, 0);
                Debug.Log("Player 02 created");
            }
        }

    }
}
