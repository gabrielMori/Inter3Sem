﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esquemaPorta : MonoBehaviour {

    bool playerDentro = false;
    public GameObject vao;
    public AudioSource somPorta;
    public Animator anim;
    bool portaAberta= false;
    bool portaFechada = true;
    bool portaIdleAberta = false;
    public GameObject borda;
    public GameObject dialogo;
   
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("maquina01") == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {
                if (playerDentro)
                {
                    somPorta.Play();
                    portaAberta = true;
                    //playerDentro = false;
                }

            }
        }


        if (portaAberta) {
            anim.SetBool("abrindo", true);
            
            Invoke("aberta", 2);
        }
    }
    void aberta() {
        vao.SetActive(false);
        Invoke("portaFechando", 4);
    }

    void portaFechando() {
        somPorta.Stop();
        anim.SetBool("abrindo", false);
        vao.SetActive(true);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {

            if (PlayerPrefs.GetInt("maquina01") == 1)
            {
                borda.SetActive(true);
            }
            else
                dialogo.SetActive(true);
            playerDentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        dialogo.SetActive(false);
        if (collision.tag == "Player")
        {
            playerDentro = false;
            borda.SetActive(false);
        }
           
    }
}
