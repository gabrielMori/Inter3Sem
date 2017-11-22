﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManeger : MonoBehaviour
{
    public GameObject inventario;
    public GameObject pause;
    public GameObject mapa;
    bool peguei = false;
    bool ativado = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
                if (ativado == false)
                {
                    Time.timeScale = 0;
                    pause.SetActive(true);
                    ativado = true;
                }
                else
                {
                    Time.timeScale = 1;
                    pause.SetActive(false);
                    ativado = false;
                }
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
                if (ativado == false)
                {
                    Time.timeScale = 0;
                    inventario.SetActive(true);
                    ativado = true;
                }
                else
                {
                    Time.timeScale = 1;
                    inventario.SetActive(false);
                    ativado = false;
                }
            
        }
        if (peguei == false)
        {
            if (Input.GetKeyUp(KeyCode.M))
            {
                Time.timeScale = 1;
                mapa.SetActive(false);
                peguei = true;
            }
        }
            if (Input.GetKeyDown(KeyCode.M) && peguei == true)
            {
                Time.timeScale = 0;
                mapa.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.M) && peguei == true)
            {
                Time.timeScale = 1;
                mapa.SetActive(false);
            }
    }

    public void Continue() {
        Time.timeScale = 1;
        pause.SetActive(false);
        ativado = false;

    }

    public void Continue_inventario()
    {
        Time.timeScale = 1;
        inventario.SetActive(false);
        ativado = false;

    }
}
