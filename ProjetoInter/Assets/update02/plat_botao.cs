using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat_botao : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject plataforma;
    bool playerDentro = false;
    bool apertei = false;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("plataforma01", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("E") && playerDentro)
        {
            if (PlayerPrefs.GetInt("plataforma01") == 0)
            {
                PlayerPrefs.SetInt("plataforma01", 1);
                Invoke("destroi", 1.65f);
            }
        }


    }

    void destroi()
    {
        plataforma.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            dialogo.SetActive(true);
            playerDentro = true;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            dialogo.SetActive(false);
            playerDentro = false;
        }
    }
}
