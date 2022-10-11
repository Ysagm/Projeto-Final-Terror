using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dica : MonoBehaviour
{
    public GameObject modalDica;
    public bool chatActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && chatActive == false)
        {
            modalDica.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.W) && chatActive == false)
        {
            modalDica.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ChatIsActive(BaseEventData eventdata)
    {
        chatActive = true;
    }

    public void ChatIsNotActive(BaseEventData eventdata)
    {
        chatActive = false;
    }
}
