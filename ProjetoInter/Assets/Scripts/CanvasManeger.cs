using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManeger : MonoBehaviour {
    public GameObject pause;
    public GameObject mapa;
    public GameObject inicio;
    bool ativado=false;
    bool quale = true;
	// Use this for initialization
	void Start () {
        inicio.SetActive(true);
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (inicio.active == false)
        {
            if (quale==true)
            {
                Time.timeScale = 1;
                quale = false;
            }
        }

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 0;
            mapa.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            Time.timeScale = 1;
            mapa.SetActive(false);
        }
    }
}
