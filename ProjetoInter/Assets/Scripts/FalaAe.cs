using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaAe : MonoBehaviour
{
	public GameObject tecla;
	public GameObject escrito, chave, folha, invent;
	public bool esc, cha, fo, dica;
	public AudioSource[] SFX;
	public GameObject[] dialogo;
	public bool pegueiAlago;
	public GameObject[] coletavel;
	public bool inventario;
	public bool documento;
	bool ok = false;
	bool okey = false;
	bool umaVez;
	bool umaVezagain;
	public int[] itemIndex;
	public int[] documentosIndex;

	private void OnTriggerStay2D (Collider2D col)
	{
        if (dica == true)
        {
            if (escrito)
                escrito.SetActive(true);
            Invoke("DeuTempo", 3);
        }
        if (col.CompareTag ("Player") && ((ok || okey) == false)) {
			dialogo [0].SetActive (true);
			if (tecla)
				tecla.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E) && pegueiAlago == true) {
				umaVez = true;
				umaVezagain = true;
				dialogo [0].SetActive (false);
                for (int i = 0; i < SFX.Length; i++)
                {
                    SFX[i].Play();
                }
                if (tecla)
					tecla.SetActive (false);
				if (documento == true) {
					for (int i = 0; i < SFX.Length; i++) {
						SFX [i].Play ();
					}
					for (int t = 0; t < coletavel.Length; t++) {
						coletavel [t].SetActive (true);
						print (coletavel [t].activeSelf);
					}
					ok = true;
				}

				if (inventario == true) {
					
					for (int i = 0; i < coletavel.Length; i++)
						coletavel [i].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
					okey = true;
				}

				for (int i = 0; i < itemIndex.Length; i++) {
					col.GetComponent<Jogador> ().itens [itemIndex [i]] = 1;
				}
				for (int i = 0; i < documentosIndex.Length; i++) {
					col.GetComponent<Jogador> ().documentos [documentosIndex [i]] = 1;
				}
			}
			Invoke ("SomeComIsso", 5);
		}
		if (Input.GetKeyUp (KeyCode.E) && (umaVez == true)) {
			if (esc == true) {
				if (escrito)
					escrito.SetActive (true);
			}  
			if (inventario == true) {
				if (chave)
					chave.SetActive (true);
			}  
			if (documento == true) {
				if (folha)
					folha.SetActive (true);
			}  				
			umaVez = false;
			Invoke ("DeuTempo", 4);
		}
		if (Input.GetKeyDown (KeyCode.I) && (umaVezagain == true)) {
			if (invent)
				invent.SetActive (true);

			if (esc == true) {
				if (escrito)
					escrito.SetActive (false);
			}
			if (inventario == true) {
				if (chave)
					chave.SetActive (false);
			}
			if (documento == true) {
				if (folha)
					folha.SetActive (false);
			}
			umaVezagain = false;
		}
		if (Input.GetKeyDown (KeyCode.M) && (umaVezagain == true)) {
			if (esc == true)
				coletavel [0].SetActive (false);
		}
	}

	void DeuTempo ()
	{
		if (esc == true) {
			if (escrito)
				escrito.SetActive (false);
		}
		if (inventario == true) {
			if (chave)
				chave.SetActive (false);
		}
		if (documento == true) {
			if (folha)
				folha.SetActive (false);
		}
		dialogo [0].SetActive (false);
		umaVezagain = false;
	}

	void SomeComIsso ()
	{
		dialogo [0].SetActive (false);
	}
}
