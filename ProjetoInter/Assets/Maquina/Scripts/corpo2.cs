﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpo2 : MonoBehaviour

{
    bool desligaEfeito = false;
    public GameObject borda;
    bool playerDentro = false;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("switch_especial03", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("E") && playerDentro)
        {

            if (!desligaEfeito)
            {
                borda.SetActive(false);
                Destroy(borda);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            if (PlayerPrefs.GetInt("switch_especial03") == 1)
            {
                    playerDentro = true;
                    borda.SetActive(true);
                
            }


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            
                playerDentro = false;
                borda.SetActive(false);
            
        }
    }
}
