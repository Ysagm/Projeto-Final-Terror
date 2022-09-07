using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject puzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
           if(GameIsPause){
               Resume();
           }else{
               Open();
           }
        }
    }

    public void Open()
    {
        Time.timeScale = 0f;
        puzzle.SetActive(true);
        GameIsPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        puzzle.SetActive(false);
    }
}
