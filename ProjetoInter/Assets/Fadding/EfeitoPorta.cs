using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPorta : MonoBehaviour
{
    bool playerDentro = false;
    // CODIDO PARA O EFEITO DE FADE IN E FADE OUT, ALIAS AQUI É ONDE ELE FAZ
    void Start()
    {

    }
    private void Update()
    {
        if (playerDentro) {
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerDentro)
        {
            float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
            Invoke("Clarear", 2);
            playerDentro = false;
        }

    }

    // Update is called once per frame
   
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerDentro = true;
        }        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDentro = false;
        }
    }

    void Clarear()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        //playerDentro = false;
    }

}
