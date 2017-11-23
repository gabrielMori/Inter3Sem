using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour {
	[SerializeField]
	private Transform[] spawnPositions;
	[SerializeField]
	private GameObject jogador;
	[SerializeField]
	private Image[] imagens;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			jogador.transform.position = spawnPositions [0].position;
		} else if(Input.GetKeyDown(KeyCode.Alpha2)){
			jogador.transform.position = spawnPositions [1].position;
		} else if(Input.GetKeyDown(KeyCode.Alpha3)){
			jogador.transform.position = spawnPositions [2].position;
		} else if(Input.GetKeyDown(KeyCode.Alpha4)){
			jogador.transform.position = spawnPositions [3].position;
		} else if(Input.GetKeyDown(KeyCode.Alpha5)){
			jogador.GetComponent<Jogador> ().invencivel = true;
			PlayerPrefs.SetInt("chave_amarela", 1);
			PlayerPrefs.SetInt("chave_azul", 1);
			PlayerPrefs.SetInt("chave_branca", 1);
			PlayerPrefs.SetInt("chave_laranja", 1);
			PlayerPrefs.SetInt("chave_preta", 1);
			PlayerPrefs.SetInt("chave_roxa", 1);
			PlayerPrefs.SetInt("chave_verde", 1);
			PlayerPrefs.SetInt("inimigo02", 1);
			PlayerPrefs.SetInt("chave_vermelha", 1);

			for (int i = 0; i < imagens.Length; i++)
				imagens [i].color = new Color (1,1,1,1);
		}
	}
}
