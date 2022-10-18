using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Dica : MonoBehaviour
{
    public GameObject modalDica;
    public bool chatActive;

    public TextMeshProUGUI textField;
    //public int dica;
    public string[] dica;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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

    public void GetDica()
    {
        //dica++;
        count+=1;
        textField.text = dica[count];

        Debug.Log("agr vai" + count);
    }
}
