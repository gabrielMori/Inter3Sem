using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine : MonoBehaviour
{
    bool playerDentro = false;
    bool maquinaLigada = false;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("maquina01", 0);
        if (PlayerPrefs.GetInt("maquina01") == 0)
        {
            anim.SetBool("ativada", false);
            anim.SetBool("idleAtivo", false);
            maquinaLigada = false;
            playerDentro = false;
            maquinaLigada = false;
        }

        if (PlayerPrefs.GetInt("maquina01") == 1)
        {
            anim.SetBool("ativada", false);
            maquinaLigada = true;
        }
    }

    void idle() {
        anim.SetBool("ativada", false);
        anim.SetBool("idleAtivo", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDentro)
        {
            if (!maquinaLigada) {
                maquinaLigada = true;
                playerDentro = false;
            }
           
        }

        if (maquinaLigada) {
            anim.SetBool("ativada", true);
            PlayerPrefs.SetInt("maquina01", 1);
            Invoke("idle", 1);
            maquinaLigada = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player" && !maquinaLigada)
        {
            playerDentro = true;
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
