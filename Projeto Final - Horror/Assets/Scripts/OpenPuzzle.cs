using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class OpenPuzzle : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject puzzle, papelPuzzle1, papelPuzzle2;
    PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameIsPause)
            {
                Close();
            }
            else
            {
                StartCoroutine(Open());
            }
        }
        

    }

    IEnumerator Open()
    {
        //Quando subir
        GameIsPause = true;

        //papelPuzzle.transform.position = new Vector3(0f, 0.0f, 0.0f);
        if (PhotonNetwork.IsMasterClient)
        {
            papelPuzzle1.transform.Rotate(45.0f, 0.0f, 0.0f, Space.Self);
        }
        else
        {
            papelPuzzle2.transform.Rotate(-45.0f, 0.0f, 0.0f, Space.Self);
        }
            
        
        Debug.Log("Papel sobe");

        yield return new WaitForSeconds(1f);
        puzzle.SetActive(true);
        Debug.Log("Papel aparece");

        //Fecha
        /*GameIsPause = false;
        puzzle.SetActive(false);
        Debug.Log("Papel fecha");*/

    }

    public void Close()
    {
        GameIsPause = false;
        puzzle.SetActive(false);

        if (PhotonNetwork.IsMasterClient)
        {
            papelPuzzle1.transform.Rotate(-45.0f, 0.0f, 0.0f, Space.Self);
        }
        else
        {
            papelPuzzle2.transform.Rotate(45.0f, 0.0f, 0.0f, Space.Self);
        }
    }


}
