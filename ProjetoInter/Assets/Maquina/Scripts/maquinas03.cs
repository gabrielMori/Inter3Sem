using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquinas03 : MonoBehaviour

{
    public AudioClip[] musicas;
    public AudioSource BG;
    public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    bool ligouMaquina = false;

    bool tocaMusica = false;
    // Use this for initialization

    void Start()
    {
        PlayerPrefs.SetInt("maquina03", 0);
        if (PlayerPrefs.GetInt("maquina03") == 0)
        {
            if (!tocaMusica)
            {
                BG.clip = musicas[0];
                BG.Play();
                tocaMusica = true;
            }

            anim.SetBool("ativada", false);
            anim.SetBool("idleAtivo", false);
            maquinaLigada = false;
            //playerDentro = false;
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("maquina03") == 1)
        {
            BG.clip = musicas[1];
            anim.SetBool("ativada", false);
            maquinaLigada = true;
        }
    }

    void idle()
    {
        anim.SetBool("ativada", false);
        anim.SetBool("idleAtivo", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("E") /*Input.GetKeyDown(KeyCode.E)*/ && playerDentro && !maquinaLigada)
        {
            if (!ligouMaquina)
            {

                //if (!maquinaLigada)

                BG.clip = musicas[1];
                BG.Play();
                maquinaLigada = true;
                //playerDentro = false; 
                ligouMaquina = true;

            }


        }

        if (maquinaLigada)
        {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("maquina01", 1);
            Invoke("idle", 1);
            maquinaLigada = false;
            bloqueio.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            if (!maquinaLigada)
            {
                playerDentro = true;

            }

            //maquinaLigada = true;
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
