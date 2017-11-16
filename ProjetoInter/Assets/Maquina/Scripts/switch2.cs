using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch2 : MonoBehaviour

{
    bool especial = false;
    //public GameObject bloqueio;
    public bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    // Use this for initialization

    void Start()
    {
        PlayerPrefs.SetInt("chave_azul", 0);
        PlayerPrefs.SetInt("chave_amarela", 0);
        PlayerPrefs.SetInt("chave_verde", 0);
        PlayerPrefs.SetInt("chave_preta", 0);
        PlayerPrefs.SetInt("chave_branca", 0);
        PlayerPrefs.SetInt("chave_laranja", 0);
        PlayerPrefs.SetInt("chave_roxa", 0);

        PlayerPrefs.SetInt("switch_especial01", 0);
        PlayerPrefs.SetInt("switch_especial02", 0);
        PlayerPrefs.SetInt("maquina01", 0);
        PlayerPrefs.SetInt("maquina02", 0);
        PlayerPrefs.SetInt("maquina03", 0);

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
