using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel : MonoBehaviour {
	public GameObject[] portasVerm;
	public GameObject[] inimigos;
	public GameObject porta;
	// Use this for initialization
	public void SpawnInimigos(){
		for(int i = 0; i < inimigos.Length; i++){
			inimigos [i].SetActive (true);
			Destroy (porta);
		}
	}
}
