using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_especial : MonoBehaviour {
    public AudioSource portaAbre;
    bool playerDentro = false;
    public GameObject vao;
    //public GameObject barreira;
    public GameObject tecla;
    bool mostraTecla = false;
    public Animator anim;
    bool portaAberta = false;
    bool portaFechada = true;
    bool portaIdleAberta = false;
    public GameObject dialogo;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("inicioSetor2") == 1) {
            anim.SetBool("abrindo",false);
        }
    }

    // Update is called once per frame
    void Update()
    {

       // if (PlayerPrefs.GetInt("inicioSetor2") == 1)
       // {
        //    anim.SetBool("abrindo", false);
       // }

        if (PlayerPrefs.GetInt("maquina01") == 1)
        {
            mostraTecla = true;
            if (!portaAberta) {
                anim.SetBool("abrindo", true);
                vao.SetActive(false);
                portaAberta = true;
                portaIdleAberta = true;
            }
            
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {
                
                if (playerDentro)
                {
                    portaAberta = true;
                    vao.SetActive(false);
                    portaAbre.Play();
                    //playerDentro = false;
                }

            }
        }


        //desativa collider que segura os monstros
        if (portaIdleAberta)
            {
            anim.SetBool("abrindo", true);


            //Invoke("aberta", 2);
        }
    }
    void aberta()
    {
        vao.SetActive(false);
        Invoke("portaFechando", 4);
    }

    void portaFechando()
    {
        
        vao.SetActive(true);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && mostraTecla == true)
        {
            tecla.SetActive(true);
            anim.SetBool("abrindo", false);
            portaIdleAberta = false;
            vao.SetActive(true);
            //PlayerPrefs.SetInt("inicioSetor2", 1);
            PlayerPrefs.SetInt("maquina01", 0);
        }
        else
        {
            dialogo.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player" && mostraTecla == true) 
            tecla.SetActive(false);
        if (collision.tag == "Player" && mostraTecla == false)
            dialogo.SetActive(false);
    }


}