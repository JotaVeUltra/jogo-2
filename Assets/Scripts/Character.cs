
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    public AudioSource respostaCorreta;
    public AudioSource respostaIncorreta;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Food food = other.gameObject.GetComponent<Food>();
            if (food.boa) {
                GameManager.adicionaP();
                respostaCorreta.Play();
            } else {
                GameManager.removeP();
                respostaIncorreta.Play();
            }
            Destroy(other.gameObject);
        }
    }
}