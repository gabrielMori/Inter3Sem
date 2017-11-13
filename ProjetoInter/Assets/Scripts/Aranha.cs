using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aranha : MonoBehaviour {
	private GameObject player;
	public int inteligencia, inteligencia2, direcao;
	private float idleTimer, venenoRandom, venenoTimer, ataque3Timer;
	private Animator anim;

	[SerializeField]
	private GameObject[] venenos;
	[SerializeField]
	private GameObject ataquePos;

	public float ataqueTimer;
	public bool playerInRange;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(inteligencia == 0){
			if (idleTimer <= 5)
				idleTimer += Time.deltaTime;
			else {
				idleTimer = 0;
				if (inteligencia2 == 0)
					inteligencia2 = 1;
				else if (inteligencia2 == 1)
					inteligencia2 = 0;
			}
		}

		if(inteligencia != 2 && inteligencia != 3){
			if (player.transform.position.x < transform.position.x)
				transform.localScale = new Vector2 (1, 1);
			else
				transform.localScale = new Vector2 (-1, 1);
		} else if(inteligencia == 3)
			transform.localScale = new Vector2 (1, 1);
		else {
			if (player.transform.position.x < transform.position.x)
				transform.localScale = new Vector2 (-1, 1);
			else
				transform.localScale = new Vector2 (1, 1);
		}
		
		AtualizaInteligencia ();
	}

	private void AtualizaInteligencia(){
		switch(inteligencia){
		case 0:
			//estagio 1
			switch (inteligencia2){
			case 0:
				//idle frente
				anim.SetTrigger("TransicaoFrente");
				break;
			case 1:
				//idle lado
				anim.SetTrigger("TransicaoLado");
				break;
			case 2:
				//ataque frente
				anim.SetTrigger("AtaqueFrente");
				break;
			case 3:
				//ataque lado
				anim.SetTrigger("AtaqueLado");
				break;
			}
			break;
		case 1:
			//estagio 2
			switch(inteligencia2){
			case 0:
				//transição
				anim.SetTrigger("Transicao1-2");
				break;
			case 1:
				//idle2
				venenoRandom = Random.Range (0, 3);

				if (!venenos [0].activeSelf) {
					for (int i = 0; i < venenos.Length; i++)
						venenos [i].SetActive (true);
				}
				if (venenoTimer <= 2)
					venenoTimer += Time.deltaTime;
				else {
					venenoTimer = 0;
					venenos [Mathf.RoundToInt(venenoRandom)].GetComponent<Veneno> ().DropVeneno ();
				}
				break;
			}
			break;
		case 2:
			//estagio3
			ataquePos.SetActive(false);

			switch(inteligencia2){
			case 0:
				//transição
				anim.SetTrigger("Transicao2-3");
				break;
			case 1:
				//idle
				if (ataque3Timer <= 2)
					ataque3Timer += Time.deltaTime;
				else {
					ataque3Timer = 0;
					inteligencia2 = 2;
				}
				break;
			case 2:
				//ataque3
				anim.SetTrigger ("Ataque3");
				Ataque (inteligencia2);
				break;
			}
			break;
		case 3:
			//morte
			anim.SetTrigger("Morte");
			break;
		}
	}

	public void Ataque(int i){
		if (inteligencia == 0) {
			if (i == inteligencia2) {
				if (i == 0)
					inteligencia2 = 2;
				else
					inteligencia2 = 3;
			}
		}
	}

	private void RetornaIdle(int i){
		inteligencia2 = i;
		if(playerInRange){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	private void TerminaTransicao(){
		inteligencia2 = 1;
	}
}
