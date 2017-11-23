using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPass : MonoBehaviour {
	public int[] itensColetados;
	public GameObject[] itensObj;

	public int[] documentosColetados;
	public GameObject[] documentosObj;
	// Use this for initialization
	void Start()
	{
		if (PlayerPrefs.GetInt("Reset") == 0) {
			if (PlayerPrefs.HasKey("posPx"))
			{
				Vector3 posplayer = new Vector3(PlayerPrefs.GetFloat("posPx"), PlayerPrefs.GetFloat("posPy"), gameObject.transform.position.z);
				gameObject.transform.position = posplayer;

				for(int i = 0; i < itensColetados.Length; i ++){
					itensColetados [i] = PlayerPrefs.GetInt ("item" + i);
				}
				for(int j = 0; j < itensObj.Length; j++){
					if(itensColetados[j] == 1){
						itensObj[j].GetComponent<Image>().color = new Color(1, 1, 1, 1);
					}
				}

				for(int i = 0; i < documentosColetados.Length; i ++){
					documentosColetados [i] = PlayerPrefs.GetInt ("documento" + i);
				}
				for(int j = 0; j < documentosObj.Length; j++){
					if(documentosColetados[j] == 1){
						documentosObj [j].SetActive (true);
					}
				}

				for(int i = 0; i < itensColetados.Length; i++){
					GetComponent<Jogador> ().itens [i] = itensColetados [i];
				}
				for(int i = 0; i < documentosColetados.Length; i++){
					GetComponent<Jogador> ().documentos [i] = documentosColetados [i];
				}
			}
		}
		if (PlayerPrefs.GetInt("Reset") == 1)
		{
			if (PlayerPrefs.HasKey("posPx"))
			{
				Vector3 posplayer = new Vector3(35f, 1.5f, gameObject.transform.position.z);
				gameObject.transform.position = posplayer;
			}
		}

	}
}
