using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaAe : MonoBehaviour
{
    public GameObject dialogo;
    public Collider2D acionador;
    public bool umavezporra = true;
    public bool pegueiAlago;
    public GameObject[] coletavel;
    public bool inventario;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (acionador.enabled == false && umavezporra == true)
        {
            dialogo.SetActive(true);
            umavezporra = false;
        }
        if (umavezporra == false)
        {
            Invoke("PodeIr", 1);
        }
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

        if (Input.GetKeyDown(KeyCode.E) && pegueiAlago == true)
        {
            if (inventario == false)
            {
                dialogo.SetActive(false);
                for (int i = 0; i < coletavel.Length; i++) 
                    coletavel[i].SetActive(true);
            }
            else
            {
                dialogo.SetActive(false);
                for (int i = 0; i < coletavel.Length; i++)
                    coletavel[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }
    }

}
