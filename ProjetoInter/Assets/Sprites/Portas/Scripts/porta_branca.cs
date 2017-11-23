using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_branca : MonoBehaviour {

    bool playerDentro = false;
    public GameObject vao;
    public GameObject borda;
    //public GameObject efeito;
    public AudioSource abrePorta;
    public GameObject dialogo;
    public Animator anim;
    bool portaAberta = false;
    bool portaFechada = true;
    bool portaIdleAberta = false;
    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("chave_verde", 0);
        //PlayerPrefs.SetInt("chave_amarela", 0);
        //PlayerPrefs.SetInt("chave_roxa", 0);
        //PlayerPrefs.SetInt("chave_azul", 0);
        //PlayerPrefs.SetInt("chave_laranja", 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("chave_branca") == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {
                abrePorta.Play();
                if (playerDentro)
                {
                    
                    portaAberta = true;
                    //playerDentro = false;
                }

            }
        }


        if (portaAberta)
        {
            anim.SetBool("abrindo", true);

            Invoke("aberta", 2);
        }
    }
    void aberta()
    {
        //efeito.SetActive(true);
        vao.SetActive(true);
        Invoke("portaFechando", 4);
    }

    void portaFechando()
    {
        abrePorta.Stop();
        anim.SetBool("abrindo", false);
        vao.SetActive(false);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (PlayerPrefs.GetInt("chave_branca") == 1)
            {
                borda.SetActive(true);
            }else
                dialogo.SetActive(true);
            playerDentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        dialogo.SetActive(false);
        if (collision.tag == "Player")
        {
            borda.SetActive(false);
            playerDentro = false;
        }
    }
}

