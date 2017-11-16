using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_especial_01 : MonoBehaviour
{
    bool especial = false;
    //public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    // Use this for initialization

    void Start()
    {
        
        PlayerPrefs.SetInt("switch_especial01", 0);
        //PlayerPrefs.SetInt("maquina01", 0);
        if (PlayerPrefs.GetInt("switch_especial01") == 0)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("switch_especial01") == 1)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = true;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("E") /*Input.GetKeyDown(KeyCode.E)*/ && playerDentro && !maquinaLigada && !especial)
        {
            if (!maquinaLigada)
            {
                maquinaLigada = true;
                //playerDentro = false; 
            }

        }

        if (maquinaLigada)
        {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("switch_especial01", 1);
            PlayerPrefs.SetInt("inimigo01", 1);
            //PlayerPrefs.SetInt("inimigo02", 0);
            maquinaLigada = false;
            especial = false;
            //eventos
            //ligar as luzes do corredor

            
            //colocar o porco na porta

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
