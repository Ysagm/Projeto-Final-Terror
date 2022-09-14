using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class GameSpawn : MonoBehaviour
{
    [SerializeField]
    //private GameObject player = null;
    public int count = 0;
    public List<Transform> spawnPosition = new List<Transform>();

    void Start()
    {
        //spawnPosition.Add(new Vector3(-1,0,3));
        //spawnPosition.Add(new Vector3(-1,0,-2));

        for(int i = 0; i < 1; i++)
        {
            count++;

            /*if(PhotonNetwork.IsMasterClient)
            //if(true)
            {
                Instantiate(player, spawnPosition[0].position, spawnPosition[0].rotation);
                //PhotonNetwork.Instantiate(player.name, spawnPosition[0].position, spawnPosition[0].rotation, 0);
                Debug.Log("Player 01 created");
            }
            else
            {
                Instantiate(player, spawnPosition[1].position, spawnPosition[1].rotation);
                //PhotonNetwork.Instantiate(player.name, spawnPosition[1].position, spawnPosition[1].rotation, 0);
                Debug.Log("Player 02 created");
            }*/
        }

    }

    public void OnSpawn()
    {
        if(PhotonNetwork.IsMasterClient)
            //if(true)
            {
                //Instantiate(player, spawnPosition[0].position, spawnPosition[0].rotation);
                PhotonNetwork.Instantiate("Player", spawnPosition[0].position, spawnPosition[0].rotation, 0);

                Debug.Log("Player 01 created");
            }
            else
            {
                //Instantiate(player, spawnPosition[1].position, spawnPosition[1].rotation);
                PhotonNetwork.Instantiate("Player", spawnPosition[1].position, spawnPosition[1].rotation, 0);
                Debug.Log("Player 02 created");
            }
    }
}
