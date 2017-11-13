using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalaAe : MonoBehaviour {
    public GameObject objDestruido;
    public GameObject dialogo;
    public Collider2D acionador;
    bool umavezporra = true;
    bool umavezdenovoporra = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (acionador.enabled == false&&umavezporra==true)
        {
            dialogo.SetActive(true);
            umavezporra = false;
        }
        if (umavezporra == false)
        {
            
            Invoke("podeIr", 1);
        }
        if (objDestruido.activeSelf){
            return;
        } else
            Invoke("podeIr", 1);
    }
    void podeIr()
    {
        if (Input.anyKey)
        {
            dialogo.SetActive(false);
        }
            
    }
}
