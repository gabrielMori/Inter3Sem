using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_moreau : MonoBehaviour {

   public  bool playerDentro = false;
    public GameObject vao;
    public GameObject borda;
    //public GameObject efeito;
    public AudioSource porta;
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
        if (PlayerPrefs.GetInt("maquina03") == 1 && PlayerPrefs.GetInt("switch_especial02") == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {
                porta.Play();
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
        porta.Stop();
        anim.SetBool("abrindo", false);
        vao.SetActive(false);
        //efeito.SetActive(false);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (PlayerPrefs.GetInt("maquina03") == 1 && PlayerPrefs.GetInt("switch_especial02") == 1)
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
