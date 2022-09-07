using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dica : MonoBehaviour
{
    public GameObject modalDica;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            modalDica.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            modalDica.SetActive(false);
        }
    }
}
