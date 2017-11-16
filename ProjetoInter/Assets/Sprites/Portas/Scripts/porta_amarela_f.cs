using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_amarela_f : MonoBehaviour {

    bool playerDentro = false;
    public GameObject vao;

    public Animator anim;
    bool portaAberta = false;
    bool portaFechada = true;
    bool portaIdleAberta = false;
    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("maquina01", 0);
        //PlayerPrefs.SetInt("chave_verde", 0);
        //PlayerPrefs.SetInt("chave_amarela", 0);
        //PlayerPrefs.SetInt("chave_roxa", 0);
        //PlayerPrefs.SetInt("chave_azul", 0);
        //PlayerPrefs.SetInt("chave_laranja", 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("chave_amarela") == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerDentro)
            {
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
        vao.SetActive(false);
        Invoke("portaFechando", 4);
    }

    void portaFechando()
    {
        anim.SetBool("abrindo", false);
        vao.SetActive(true);
        portaAberta = false;
    }

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
}

