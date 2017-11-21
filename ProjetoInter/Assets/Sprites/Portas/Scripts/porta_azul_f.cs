using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_azul_f : MonoBehaviour {
    public AudioSource portaAbre;
    bool playerDentro = false;
    public GameObject vao;
    //public GameObject efeito;
    public GameObject tecla;
    public GameObject borda;
    bool mostraTecla=false;
    public Animator anim;
    bool portaAberta = false;
    bool portaFechada = true;
    bool portaIdleAberta = false;
    public GameObject dialogo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("chave_azul") == 1)
        {
            mostraTecla = true;
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {

                if (playerDentro)
                {
                    portaAbre.Play();
                    portaAberta = true;
                    //playerDentro = false;
                }

            }
        }


        if (portaAberta)
        {
            portaAbre.Play();
            anim.SetBool("abrindo", true);
            Invoke("aberta", 2);
        }
    }
    void aberta()
    {
        //efeito.SetActive(true);
        vao.SetActive(false);
        //efeito.SetActive(false);
        Invoke("portaFechando", 4);
    }

    void portaFechando()
    {
        portaAbre.Stop();
        anim.SetBool("abrindo", false);
        vao.SetActive(true);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && mostraTecla == true)
        {
            if (PlayerPrefs.GetInt("chave_azul") == 1)
            {
                borda.SetActive(true);
            }
            tecla.SetActive(true);
            playerDentro = true;
        }
        else
            dialogo.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        dialogo.SetActive(false);
        if (collision.tag == "Player"&&mostraTecla==true)
        {
            borda.SetActive(false);
            tecla.SetActive(false);
            playerDentro = false;
        }
            
    }
}

