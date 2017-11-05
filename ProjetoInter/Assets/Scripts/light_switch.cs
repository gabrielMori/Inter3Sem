using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_switch : MonoBehaviour {

    public GameObject luz;
    bool playerDentro = false;
    bool testeLogico = true;
    bool luzAcesa = false;
    int luzBinario = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerDentro)
        {
            if (testeLogico && !luzAcesa) {
                //luzBinario = 1;
                luzAcesa = true;
                testeLogico = false;
            }

            if (testeLogico && luzAcesa)
            {
                //luzBinario = 0;
                luzAcesa = false;
                testeLogico = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.X) && playerDentro) {

            testeLogico = true;
        }




            if (luzAcesa) {
            luz.SetActive(true);
            //luzAcesa = true;
        }

        if (!luzAcesa)
        {
            luz.SetActive(false);
            //luzAcesa = false;
        }
        //if (Input.GetKeyDown(KeyCode.X) && playerDentro && luzAcesa)
        // {
        //    print("ligou?");
        //    luz.SetActive(false);
        //    luzAcesa = false;
        // }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            playerDentro = true;
        }        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerDentro = false;
        }
    }
}
