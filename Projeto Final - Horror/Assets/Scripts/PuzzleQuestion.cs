using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleQuestion : MonoBehaviour
{   
    [SerializeField] private GameObject Enforcado;
    [SerializeField] private GameObject MonstroTeto;
    [SerializeField] private GameObject Eyes;

    public TextMeshProUGUI riddle;
    public TextMeshProUGUI respostaD;
    public TextMeshProUGUI respostaE;

    public string[] riddles; //Armazena pergunta
    public string[] answerD; //Armazena resposta
    public string[] answerE;
    public string[] certas; //Armazena resposta certa

    private int idRiddle;
    public MenuManager epilogue;

    //ideia: decisão de vitoria ou derrota (ending diferente dependendo da quantidade de acertos)
    private float acertos;
    private float quantRiddles;
    private float media;

    //Audio
    public AudioSource audioAcerto;
    public AudioSource audioErro;    
    
    IEnumerator Start()
    {
        //audioAcerto = GetComponent<AudioSource>();

        idRiddle = 0;
        quantRiddles = riddles.Length;
        //riddle.text = riddles[idRiddle];

        if(riddles.Length > 0)
            riddle.text = riddles[idRiddle];
        
        yield return new WaitForSeconds(5.0f);

        if(answerE.Length > 0)
            respostaE.text = answerE[idRiddle];
         if(answerD.Length > 0)
            respostaD.text = answerD[idRiddle];
    }

    public void Resposta(string answer)
    {
        respostaE.text = "";
        respostaD.text = "";

       if(answer == "E"){
            if(answerE[idRiddle] == certas[idRiddle])
            {
                acertos++;
                Debug.Log("Acertou E");
                FindObjectOfType<OpenPuzzle>().Closed();
                audioAcerto.Play();
            }
            else{
                FindObjectOfType<OpenPuzzle>().Closed();
                audioErro.Play();
            }
        }
        else if (answer == "D"){
            
            if(answerD[idRiddle] == certas[idRiddle])
            {
                acertos++;
                Debug.Log("Acertou D");
                FindObjectOfType<OpenPuzzle>().Closed();
                audioAcerto.Play();
            }
            else{
                FindObjectOfType<OpenPuzzle>().Closed();
                audioErro.Play();
            }                        
        }

        StartCoroutine(NextQuestion());

        //NextQuestion();
    }

    //void 
    IEnumerator NextQuestion()
    {        
        
        idRiddle += 1;
        riddle.text = riddles[idRiddle];
        yield return new WaitForSeconds(5.0f);
        respostaE.text = answerE[idRiddle];
        respostaD.text = answerD[idRiddle];  

        if (idRiddle == 6) {        
        Enforcado.SetActive(true);
        MonstroTeto.SetActive(false);
        Debug.Log("Enforcado ok");        
        }   
        else if (idRiddle == 3) { 
        MonstroTeto.SetActive(true); 
        Debug.Log("Monstro Teto ok");  
        }               
        else if (idRiddle == 2) { 
        Eyes.SetActive(true); 
        Enforcado.SetActive(false);         
        Debug.Log("Olhos ok");  
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (idRiddle == 8) {
            epilogue.GetComponent<MenuManager>().OpenEpilogue();
        }           
    }
}
