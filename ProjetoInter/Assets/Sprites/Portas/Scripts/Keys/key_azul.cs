using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_azul : MonoBehaviour {
    bool playerDentro = false;
    //public GameObject chave;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDentro)
        {
            if (playerDentro)
            {
                PlayerPrefs.SetInt("chave_azul", 1);
                //Destroy(chave);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerDentro = true;
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
