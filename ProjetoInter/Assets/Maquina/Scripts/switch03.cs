using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch03 : MonoBehaviour

{
    public GameObject borda;
    bool especial = false;
    //public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;
    public GameObject luz4;
    public GameObject papel;

    // Use this for initialization

    void Start()
    {
       
        if (PlayerPrefs.GetInt("switch_especial03") == 0)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("switch_especial03") == 1)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = true;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("fornalhaligada") == 1)
        {
            if (Input.GetButtonDown("E") /*Input.GetKeyDown(KeyCode.E)*/ && playerDentro && !maquinaLigada && !especial)
            {
                if (!maquinaLigada)
                {
                    maquinaLigada = true;
                    //luz1.SetActive(true);
                    //luz2.SetActive(true);
                    luz3.SetActive(true);
                    luz4.SetActive(true);
                    //playerDentro = false; 
                }
            }
        }

        if (maquinaLigada)
        {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("switch_especial03", 1);
            maquinaLigada = false;
            especial = false;
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            if (!maquinaLigada)
            {
                if (PlayerPrefs.GetInt("fornalhaligada") == 1)
                {
                    borda.SetActive(true);
                }
                playerDentro = true;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            borda.SetActive(false);
            playerDentro = false;
        }
    }

}
