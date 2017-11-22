using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaAe : MonoBehaviour
{
    public GameObject escrito, chave, folha, invent;
    public bool esc, cha, fo;
    public AudioSource[] SFX;
    public GameObject[] dialogo;
    public bool pegueiAlago;
    public GameObject[] coletavel;
    public bool inventario;
    public bool documento;
    bool ok=false;
    bool okey=false;
    bool umaVez;
    bool umaVezagain;
	public int[] itemIndex;
	public int[] documentosIndex;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && ((ok || okey) == false))
        {
            dialogo[0].SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && pegueiAlago == true)
            {
                umaVez = true;
                umaVezagain = true;
                dialogo[0].SetActive(false);
                if (documento == true)
                {
                    for (int i = 0; i < SFX.Length; i++)
                    {
                        SFX[i].Play();
                    }
                    for (int t = 0; t < coletavel.Length; t++)
                        coletavel[t].SetActive(true);
                    ok = true;
                }

                if (inventario == true)
                {
                    for (int i = 0; i < SFX.Length; i++)
                    {
                        SFX[i].Play();
                    }
                    for (int i = 0; i < coletavel.Length; i++)
                        coletavel[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    okey = true;
                }

                for (int i = 0; i < itemIndex.Length; i++)
                {
                    col.GetComponent<Jogador>().itens[itemIndex[i]] = 1;
                }
                for (int i = 0; i < documentosIndex.Length; i++)
                {
                    col.GetComponent<Jogador>().documentos[documentosIndex[i]] = 1;
                }
            }
        }
            if (Input.GetKeyUp(KeyCode.E) && (umaVez == true))
            {

                if (esc == true)
                    escrito.SetActive(true);
                if (inventario == true)
                    chave.SetActive(true);
                if (documento == true)
                    folha.SetActive(true);
                umaVez = false;
            Invoke("DeuTempo", 2);
            }
            if (Input.GetKeyDown(KeyCode.I) && (umaVezagain == true))
            {

                invent.SetActive(true);
                if (esc == true)
                    escrito.SetActive(false);
                if (inventario == true)
                    chave.SetActive(false);
                if (documento == true)
                    folha.SetActive(false);
                umaVezagain = false;
            }
        if (Input.GetKeyDown(KeyCode.M) && (umaVezagain == true))
        {
            if (esc == true)
                coletavel[0].SetActive(false);
        }
    }
    void DeuTempo()
    {
        if (esc == true)
            escrito.SetActive(false);
        if (inventario == true)
            chave.SetActive(false);
        if (documento == true)
            folha.SetActive(false);
        dialogo[0].SetActive(false);
        umaVezagain = false;
    }
    
}
