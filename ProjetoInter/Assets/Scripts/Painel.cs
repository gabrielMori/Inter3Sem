using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel : MonoBehaviour {
	public GameObject[] portasVerm, escadas;
	public GameObject[] inimigos, portasAutomaticas, javali;
    public GameObject[] musicas;
    public GameObject porta, tamandua, pos, webs;

	[SerializeField]
	private int index;
	// Use this for initialization
	public void SpawnInimigos(){
		GetComponent<BoxCollider2D> ().enabled = false;
		if (index == 0) {
			for (int i = 0; i < inimigos.Length; i++) {
				inimigos [i].SetActive (true);
				Destroy (porta);
			}
			for (int i = 0; i < portasAutomaticas.Length; i++) {
				portasAutomaticas [i].GetComponent<Porta> ().podeAbrir = true;
			}
		} else if (index == 1) {
			for (int i = 0; i < javali.Length; i++) {
				javali [i].gameObject.transform.position = new Vector2 (javali [i].gameObject.transform.position.x + 20, javali [i].gameObject.transform.position.y);
			}
		} else if (index == 2) {
			for (int i = 0; i < escadas.Length; i++)
				escadas [i].SetActive (true);
			if(webs){
				webs.SetActive (false);
				tamandua.transform.position = pos.transform.position;
			}

		} else if(index == 3){
			for (int i = 0; i < javali.Length; i++) {
				javali [i].gameObject.transform.position = new Vector2 (javali [i].gameObject.transform.position.x - 19, javali [i].gameObject.transform.position.y);
			}
		}
	}
}
