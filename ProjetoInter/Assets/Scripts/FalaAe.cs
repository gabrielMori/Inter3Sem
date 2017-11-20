using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaAe : MonoBehaviour
{
    public GameObject tecla;
    public GameObject objDestruido;
    public AudioSource[] SFX;
    public GameObject dialogo;
    public Collider2D acionador;
    public bool umavezporra = true;
    public bool pegueiAlago;
    public GameObject[] coletavel;
    public bool inventario;
    public bool documento;
    bool faznada = false;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("mapa", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (acionador.enabled == false && umavezporra == true)
        {
            //aqui seta o mapa pra verdade com isso o mapa aparece so se passar por esse if
            
            dialogo.SetActive(true);
            umavezporra = false;
        }
        if (umavezporra == false)
        {
            Invoke("PodeIr", 1);
        }
        if (objDestruido.activeSelf) {
            faznada = true;
        }
        else
            Invoke("PodeIr", 1);
    }
    void PodeIr()
    {
        if (Input.anyKey)
        {
            dialogo.SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        dialogo.SetActive(true);
        tecla.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && pegueiAlago == true)
        {
            
            if (documento == true)
            {
                for (int i = 0; i < coletavel.Length; i++)
                    SFX[i].Play();    
                objDestruido.GetComponent<Collider2D>().enabled=false;
                tecla.SetActive(false);
                dialogo.SetActive(false);
                for (int i = 0; i < coletavel.Length; i++) 
                    coletavel[i].SetActive(true);   
            }
            if (inventario == true)
            {
                dialogo.SetActive(false);
                tecla.SetActive(false);
                objDestruido.GetComponent<Collider2D>().enabled = false;
                for (int i = 0; i < coletavel.Length; i++)
                    coletavel[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }
    }

}
