using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int pontos = 0;
    public static float tempo = 60;
    public Text tPontos;
    public Text tTempo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo >= 0) {
            print(""+tempo);
            tempo -= 1 * Time.deltaTime;
            tPontos.text = "Pontuação: " + pontos;
            tTempo.text = "" + (int)tempo;
        }
        else 
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        
    }

    public static void adicionaP()
    {
        pontos += 50;
    }

    public static void removeP()
    {
        pontos -= 50;
    }
}
