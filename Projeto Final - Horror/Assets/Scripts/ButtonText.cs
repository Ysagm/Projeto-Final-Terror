using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonText : MonoBehaviour
{
    public TextMeshProUGUI textField;
    //public int dica;
    public string[] dica;
    public int count = 0;

    /*public void SetText(string text)
    {
        textField.text = text;
    }*/

    public void GetDica()
    {
        //dica++;
        textField.text = dica[count];
        count++;
        Debug.Log("agr vai" + count);
    }

}
