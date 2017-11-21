using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaAe : MonoBehaviour
{
    public GameObject objDestruido;
    public AudioSource[] SFX;
    public GameObject[] dialogo;
    public Collider2D acionador;
    public bool umavezporra = true;
    public bool pegueiAlago;
    public GameObject[] coletavel;
    public bool inventario;
    public bool documento;
    bool faznada = false;
    bool some =false;
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
            
            dialogo[0].SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.E)) 
            dialogo[0].SetActive(false);
    }
    void PodeIr()
    {
        if (Input.anyKey)
        {
            dialogo[0].SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        dialogo[0].SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && pegueiAlago == true)
        {
            dialogo[0].SetActive(false);
            if (documento == true)
            {
                for (int i = 0; i < SFX.Length; i++)
                {
                    SFX[i].Play();
                }
                    objDestruido.GetComponent<Collider2D>().enabled = false;
                    for (int t = 0; t < coletavel.Length; t++)
                        coletavel[t].SetActive(true);
                }
            
            if (inventario == true)
            {
                objDestruido.GetComponent<Collider2D>().enabled = false;
                for (int i = 0; i < coletavel.Length; i++)
                    coletavel[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }
    }

}
