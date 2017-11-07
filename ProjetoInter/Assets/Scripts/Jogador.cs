﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
	public float velocidade;
	public bool pulando, rastejando, escada, makingNoise;
	private Vector2 dutoPos;
	private BoxCollider2D colisorChao;
	private Collider2D dutoColisor;
	private List<GameObject> chaves = new List<GameObject>();

	private Rigidbody2D meuRigidbody;

	private bool estaNoChao, subindo, onTrigger, duto, acido;

	private float subindoTimer;

	[SerializeField]
	private float distanciaChao, forcaPulo;

	[SerializeField]
	private Transform[] pontosChão;

	[SerializeField]
	private LayerMask chao;

	// Use this for initialization
	void Start ()
	{
		meuRigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		if (h < 0)
			GetComponent<Animator> ().SetInteger ("Direction", 1);
		else if (h > 0) 
			GetComponent<Animator> ().SetInteger ("Direction", -1);
		
		float v = Input.GetAxis ("Correr");

		Movimento (h, v);

		estaNoChao = EstaNoChao ();

		Botoes ();

		if (!rastejando && !subindo) {
			GetComponent<BoxCollider2D>().size = new Vector2(1.36f, 2.7f);
			meuRigidbody.gravityScale = 10;
		} else if(rastejando) {
			GetComponent<BoxCollider2D> ().size = new Vector2 (1.36f, 1.25f);
			meuRigidbody.gravityScale = 10;
		}
	}

	private void Botoes ()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			rastejando = true;
		} else if (Input.GetKeyUp (KeyCode.LeftControl)) {
			rastejando = false;
		}
	}

	private void Movimento (float horizontal, float velo)
	{
		if (velo > 0 && !rastejando) {
			velocidade = 8;
			makingNoise = true;
		} else if (rastejando) {
			makingNoise = false;
			velocidade = 1;
		} else {
			makingNoise = false;
			velocidade = 3;
		}

		if(!duto){
			meuRigidbody.velocity = new Vector2 (horizontal * velocidade, meuRigidbody.velocity.y);
		}
	}

	private bool EstaNoChao ()
	{
		if (meuRigidbody.velocity.y <= 0) {
			foreach (Transform ponto in pontosChão) {
				Collider2D[] colisores = Physics2D.OverlapCircleAll (ponto.position, distanciaChao, chao);

				for (int i = 0; i < colisores.Length; i++) {
					if (colisores [i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;
	}
	private void OnTriggerEnter2D (Collider2D collider){
		if(collider.tag == "Chave" || collider.tag == "Acido"){
			onTrigger = true;
			if(collider.GetComponent<Chave>().portas.Length > 0){
				for(int i = 0; i < collider.GetComponent<Chave>().portas.Length; i++){
					chaves.Add (collider.GetComponent<Chave>().portas[i]);
				}
			}
			if(collider.GetComponent<Chave>().portas2.Length > 0){
				for(int i = 0; i < collider.GetComponent<Chave>().portas2.Length; i++){
					collider.GetComponent<Chave> ().portas2 [i].podeAbrir = true;
				}
			}
			if(collider.GetComponent<Chave>().tele)
				collider.GetComponent<Chave>().TeleportEnemies();
			if(collider.tag == "Acido"){
				acido = true;
			}
				
			Destroy (collider.gameObject);
		} else if(collider.tag == "EntradaDuto"){
			if(duto){
				pulando = false;
				meuRigidbody.gravityScale = 0;
				meuRigidbody.velocity = Vector2.zero;
				subindo = true;
				GetComponent<Animator> ().SetTrigger("Subir");
			}
		}
	}
	private void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag == "Duto") {
			onTrigger = true;
			GetComponent<Animator> ().SetBool ("DutoDireita", collider.GetComponent<Duto>().dir);
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (collider.GetComponent<Duto> ().index == 0) {
					duto = true;
					transform.position = collider.transform.position;
				} else {
					duto = false;
				}
				TransicaoDuto (collider.GetComponent<Duto> ().pos.transform.position, collider.GetComponent<Duto> ().index);
				Physics2D.IgnoreCollision (GetComponent<Collider2D>(), collider.GetComponent<Duto>().dutoSuperficie.GetComponent<Collider2D>());
				dutoColisor = collider.GetComponent<Duto> ().dutoSuperficie.GetComponent<Collider2D> ();
			}
		} 

		if(collider.tag == "Escada"){
			onTrigger = true;
			if(Input.GetKeyDown (KeyCode.Space)){
				gameObject.transform.localPosition = collider.GetComponent<Escada> ().colisor.transform.localPosition;
			}
		} 

		if (collider.tag == "Porta"){
			onTrigger = true;
			if(Input.GetKeyDown (KeyCode.Space)){
				if (collider.GetComponent<Acido> ()) {
					if (acido) {
						AbrirPortas (collider.gameObject);
						acido = false;
					}
				} else 
					AbrirPortas (collider.gameObject);
			}
		}
		if(collider.tag == "Painel"){
			if(Input.GetKeyDown (KeyCode.Space)){
				collider.GetComponent<Painel>().SpawnInimigos();
				for(int i = 0; i < collider.GetComponent<Painel>().portasVerm.Length; i++){
					chaves.Add (collider.GetComponent<Painel>().portasVerm[i]);
				}
			}
		}
		if(collider.tag == "Porta2"){
			if (Input.GetKeyDown (KeyCode.Space)) {
				if(collider.GetComponent<Porta>().podeAbrir)
					transform.position = new Vector2 (collider.GetComponent<Porta> ().pos.transform.position.x, collider.GetComponent<Porta> ().pos.transform.position.y);
			}
		}
	}

	private void OnTriggerExit2D (Collider2D collider)
	{
		onTrigger = false;
	}

	private void TransicaoDuto (Vector2 p, int index)
	{
		pulando = true;
		dutoPos = p;
		if(index == 0){
			meuRigidbody.velocity = Vector2.zero;
			meuRigidbody.velocity = new Vector2 (0, 50);
			pulando = true;
		}
	}

	private void AbrirPortas(GameObject porta){
		for(int i = 0; i < chaves.Count; i++){
			if(chaves[i] == porta){
				if (porta.GetComponent<Acido> ()) {
					Destroy (porta);
				} else {
					porta.SetActive (false);
					StartCoroutine (WaitPorta(porta));
				}
			}
		}
	}
	private IEnumerator WaitPorta(GameObject p){
		yield return new WaitForSeconds (3);
		p.SetActive (true);
	}
	private void SairAnimacaoSubindo(){
		gameObject.transform.position = dutoPos;
		meuRigidbody.gravityScale = 10;
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), dutoColisor, false);
		if(duto){
			duto = false;
			rastejando = true;
			subindo = false;
		}
	}
}