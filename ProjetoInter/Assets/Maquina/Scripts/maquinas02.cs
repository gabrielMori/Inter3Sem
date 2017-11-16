using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquinas02 : MonoBehaviour
{
    //public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    // Use this for initialization

    void Start()
    {
        //PlayerPrefs.SetInt("maquina01", 0);
        if (PlayerPrefs.GetInt("maquina02") == 0)
        {
            anim.SetBool("ativada", false);
            anim.SetBool("idleAtivo", false);
            maquinaLigada = false;
            //playerDentro = false;
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("maquina02") == 1)
        {
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
            if (!maquinaLigada)
            {
                maquinaLigada = true;
                //playerDentro = false; 
            }
        }

        if (maquinaLigada)
        {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("maquina02", 1);
            Invoke("idle", 1);
            maquinaLigada = false;
            //bloqueio.SetActive(true);
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
