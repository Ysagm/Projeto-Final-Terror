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
    public Camera myCamera;
    public CamMove myCamMove;
    public GameObject playerBody;
    public AudioListener myListener;

    bool puzzleIsClosed = false;
    //private PuzzleQuestion puzzle;
    /*GameObject myPlayer;

    Player[] twoPlayers;
    int id;*/
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
        myCamera.enabled = photonView.IsMine;
        myListener.enabled = photonView.IsMine;
        myCamMove.camMoving = photonView.IsMine;
        playerBody.SetActive(!photonView.IsMine);
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) 
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                photonView.RPC("ChangeColor", RpcTarget.All, Random.Range(0.0f, 1.0f));
            }

            //Vector3 forward = transform.TransformDirection(Vector3.forward);
            //Transform other = GameObject.Find("CadernoPuzzles2").transform.TransformDirection(Vector3.forward);
            //Vector3 toOther = other.position - transform.position;
            //Vector3 toOther = GameObject.Find("CadernoPuzzles2").transform.TransformDirection(Vector3.forward);;
            //if (Vector3.Dot(forward, toOther) < 0.2f && puzzleIsClosed == false)

/*             if((myCamera.transform.localEulerAngles.y > 45 ||
                (myCamera.transform.localEulerAngles.y > 300 && myCamera.transform.localEulerAngles.y < 364))
            
            && puzzleIsClosed == false)
            {
                puzzleIsClosed = true;
                FindObjectOfType<OpenPuzzle>().Close();
                //Debug.Log("Close " + Mathf.Abs(myCamera.transform.localEulerAngles.y));
            }
            else
            {
                puzzleIsClosed = false;
            } */
        }
    }

    [PunRPC]
    public void ChangeColor(float hue, PhotonMessageInfo info)
    {
        Color newColor = Color.HSVToRGB(hue, 1, 1);
        GetComponent<MeshRenderer>().material.color = newColor;
    }
}
