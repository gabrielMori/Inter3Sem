using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esquema_duto : MonoBehaviour
{
    public GameObject Outside;
    public GameObject Inside;
    bool playerDentro = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {

            playerDentro = true;
            Inside.SetActive(true);
            Outside.SetActive(false);
            PlayerPrefs.SetInt("dentroTubo", 1);

            //maquinaLigada = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        PlayerPrefs.SetInt("dentroTubo", 0);
        playerDentro = false;
        Inside.SetActive(false);
        Outside.SetActive(true);

    }

}
