using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nameOfLevel;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Intro;
    [SerializeField] private GameObject Blackout;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Extra;
    [SerializeField] private GameObject Credits;
    

    public void Play(){
        SceneManager.LoadScene(nameOfLevel);
    } 
    public void OpenIntro(){
        Menu.SetActive(false);
        Intro.SetActive(true);
        Debug.Log("Abriu intro");
    }
    public void CloseIntro(){
        Intro.SetActive(false);
        Menu.SetActive(true);
    }
    public void OpenBlackout(){
        Menu.SetActive(false);
        Blackout.SetActive(true);
        Debug.Log("Abriu blackout");
   	}
    public void CloseBlackout(){
        Blackout.SetActive(false);
        Menu.SetActive(true);
    }

    //TENTATIVA EXTRA PARA SEGURAR ALGUNS SEGUNDOS NA TELA DE BLACKOUT
    /*
    void Start(){
    // set color of the panel transparent
    GameObject.Find("Canvas/Blackout").GetComponent<Image>().color = new Color(0,0,0,0);
 
    //call GoBlack function after random 1-5 seconds 
    Invoke("GoBlack",Random.Range(1,5));
    }
 
    void GoBlack()
    {
    // set color of the panel - black
    GameObject.Find("Canvas/Blackout").GetComponent<Image>().color = new Color(0,0,0,255);
    }
    */


    public void OpenOptions(){
        Menu.SetActive(false);
        Options.SetActive(true);
        Debug.Log("Abriu opção");
    }
    public void CloseOptions(){
        Options.SetActive(false);
        Menu.SetActive(true);
    }
    public void OpenExtra(){
        Menu.SetActive(false);
        Extra.SetActive(true);
        Debug.Log("Abriu extra");
    }
    public void CloseExtra(){
        Extra.SetActive(false);
        Menu.SetActive(true);
    }

    public void OpenCredits(){
        Menu.SetActive(false);
        Credits.SetActive(true);
        Debug.Log("Abriu credits");
    }
    public void CloseCredits(){
        Credits.SetActive(false);
        Menu.SetActive(true);
    }
}

