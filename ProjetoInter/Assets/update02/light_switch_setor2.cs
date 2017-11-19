using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_switch_setor2 : MonoBehaviour
{
    public Animator anim;
    public GameObject luz;
    bool playerDentro = false;
    bool testeLogico = true;
    bool luzAcesa = false;
    bool ligouGerador = false;
    int luzBinario = 0;

    private void Update()
    {
        //passagem para ligar as luzes assim que ligar a maquina
        if (PlayerPrefs.GetInt("switch_especial01") == 1)
        {
            if (!ligouGerador)
            {
                luz.SetActive(true);
                anim.SetBool("ligado", true);
                luzAcesa = true;
                ligouGerador = true;
            }
        }


        if (Input.GetButtonDown("E") && playerDentro)
        {
            if (PlayerPrefs.GetInt("switch_especial01") == 1)
            {

                if (testeLogico && !luzAcesa)
                {
                    //luzBinario = 1;
                    anim.SetBool("ligado", true);
                    luzAcesa = true;
                    testeLogico = false;
                    Invoke("ligaLuz", 1);
                }

                if (testeLogico && luzAcesa)
                {
                    //luzBinario = 0;
                    anim.SetBool("ligado", false);
                    luzAcesa = false;
                    testeLogico = false;
                    Invoke("ligaLuz", 1);
                }
            }


        }

        if (Input.GetButtonDown("E") && playerDentro)
        {

            testeLogico = true;
        }






    }

    void ligaLuz()
    {
        if (luzAcesa)
        {
            luz.SetActive(true);
            //luzAcesa = true;
        }

        if (!luzAcesa)
        {
            luz.SetActive(false);
            //luzAcesa = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            playerDentro = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerDentro = false;
        }
    }
}
