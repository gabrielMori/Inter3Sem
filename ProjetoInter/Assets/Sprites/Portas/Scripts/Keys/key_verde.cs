﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_verde : MonoBehaviour {
    bool playerDentro = false;
    //public GameObject chave;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDentro)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                print("oi");
                PlayerPrefs.SetInt("chave_verde", 1);
                PlayerPrefs.SetInt("inimigo02", 1);
                print(PlayerPrefs.GetInt("inimigo02"));
                //Destroy(chave);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerDentro = true;
            print(playerDentro);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDentro = false;
            print(playerDentro);
        }
    }
}
