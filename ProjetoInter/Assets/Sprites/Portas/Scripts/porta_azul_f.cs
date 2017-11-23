using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class porta_azul_f : MonoBehaviour
{
    public AudioSource portaAbre;
    bool playerDentro = false;
    public GameObject vao;
    public GameObject tecla;
    public GameObject borda;
    bool mostraTecla = false;
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
        portaAbre.Stop();
        anim.SetBool("abrindo", false);
        vao.SetActive(true);
        portaAberta = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && mostraTecla == true)
        {
            if (PlayerPrefs.GetInt("chave_amarela") == 1)
            {
                borda.SetActive(true);
            }
            tecla.SetActive(true);
            playerDentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && mostraTecla == true)
        {
            tecla.SetActive(false);
            borda.SetActive(false);
            playerDentro = false;
        }
    }
}


