using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class GamePlayer : MonoBehaviour
{
    Rigidbody rbody;
    PhotonView photonView;
    private PuzzleQuestion puzzle;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) 
        {
            //puzzle.Resposta("");

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
