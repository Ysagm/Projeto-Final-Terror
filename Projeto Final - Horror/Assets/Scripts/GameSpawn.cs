using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawn : MonoBehaviour
{
    public static GameSpawn instance;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
