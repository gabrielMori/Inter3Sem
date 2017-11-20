using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch2 : MonoBehaviour

{
    public GameObject borda;
    bool especial = false;
    //public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    // Use this for initialization

    void Start()
    {
     

        if (PlayerPrefs.GetInt("switch_especial02") == 0)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("switch_especial02") == 1)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = true;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("maquina03") == 1) {
            if (Input.GetButtonDown("E") /*Input.GetKeyDown(KeyCode.E)*/ && playerDentro && !maquinaLigada && !especial)
            {
                if (!maquinaLigada)
                {
                    //Destroy(borda);
                    maquinaLigada = true;
                    //playerDentro = false; 
                }
            }
        }        

        if (maquinaLigada)
        {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("switch_especial02", 1);
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
                borda.SetActive(true);
                
            }
            playerDentro = true;
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
