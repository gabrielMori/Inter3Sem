using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AranhaAtaque : MonoBehaviour {
	[SerializeField]
	private Aranha aranha;

	[SerializeField]
	private int ataquePos;

	private void OnTriggerEnter2D (Collider2D colisor){
		if(colisor.tag == "Player"){
			aranha.playerInRange = true;
		}
	}

	private void OnTriggerStay2D(Collider2D colisor){
		if(colisor.tag == "Player"){
			if (aranha.ataqueTimer <= 2)
				aranha.ataqueTimer += Time.deltaTime;
			else {
				aranha.Ataque (ataquePos);
				aranha.ataqueTimer = 0;
			}
		}
	}

	private void OnTriggerExit2D (Collider2D colisor){
		if(colisor.tag == "Player"){
			aranha.ataqueTimer = 0;
			aranha.playerInRange = false;
		}
	}
}
