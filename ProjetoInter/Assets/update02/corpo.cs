using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpo : MonoBehaviour
{
    bool desligaEfeito = false;
    public GameObject borda;
    bool playerDentro = false;
    bool umaVez;
    // Use this for initialization
    void Start()
    {
        umaVez = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(umaVez==true)
        if (Input.GetButtonDown("E") && playerDentro)
        {
            if (!desligaEfeito) {
                borda.SetActive(false);
                Destroy(borda);
                umaVez = false;
            }
                
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (umaVez==true)
        if (col.gameObject.tag.Equals("Player"))
        {           
                if (!desligaEfeito)
                {
                    playerDentro = true;
                    borda.SetActive(true);
                } 
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")&&playerDentro)
        {
            if (!desligaEfeito)
            {
                playerDentro = false;
                borda.SetActive(false);
            }
        }
    }
}
