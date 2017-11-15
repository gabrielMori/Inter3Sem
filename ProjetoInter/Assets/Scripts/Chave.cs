using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour {
	public GameObject[] portas;
	public GameObject tamandua, pos;
	public Porta[] portas2;
	public bool tele;

	public void TeleportEnemies(){
		tamandua.transform.position = pos.transform.position;
	}
}
