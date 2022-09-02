using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nameOfLevel;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Extra;
    public void Play(){
        SceneManager.LoadScene(nameOfLevel);
    }
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
}

