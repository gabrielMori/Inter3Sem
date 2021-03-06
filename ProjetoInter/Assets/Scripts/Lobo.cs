﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobo: MonoBehaviour
{
	public GameObject[] waypoints, inimigos;
	[SerializeField]
	private BoxCollider2D collider;
	private Animator animator;
	private GameObject player, alvo;
	private Rigidbody2D meuRigidbody;
	private int inteligencia, velocidade, alvoIndex;
	private bool idle;
	private float idleTimer;
	// Use this for initialization
	void Start ()
	{
		inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		for(int i = 0; i < inimigos.Length; i++){
			Physics2D.IgnoreCollision (GetComponent<BoxCollider2D>(), inimigos[i].GetComponent<BoxCollider2D>());
		}

		player = GameObject.Find ("Jogador");
		velocidade = 3;
		alvo = waypoints [0];
		meuRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (meuRigidbody.velocity.x > 0)
			collider.offset = new Vector2(2.5f, 0);
		else if (meuRigidbody.velocity.x < 0)
			collider.offset = new Vector2(-2.5f, 0);

		ChangeState ();

		animator.SetFloat ("Direction", meuRigidbody.velocity.x);

		if(Vector2.Distance(gameObject.transform.localPosition, player.transform.localPosition) < 5 && player.GetComponent<Jogador>().velocidade > 5){
			inteligencia = 1;
		}
	}

	void ChangeState ()
	{
		switch (inteligencia) {
		case 0:
			//patrulha/idle
			if(waypoints[0]){
				animator.SetBool("Run", false);
				if (alvo == player)
					alvo = waypoints [alvoIndex];
				if (Vector2.Distance (gameObject.transform.position, alvo.transform.position) > 1f) {
					if (!idle) {
						animator.SetBool ("Idle", false);
						animator.SetBool ("Walk", true);
						if (transform.position.x > alvo.transform.position.x)
							meuRigidbody.velocity = new Vector2 (velocidade * -1, meuRigidbody.velocity.y);
						else
							meuRigidbody.velocity = new Vector2 (velocidade, meuRigidbody.velocity.y);
					} else {
						animator.SetBool ("Idle", true);
						animator.SetBool ("Walk", false);
						if (idleTimer < 2)
							idleTimer += Time.deltaTime;
						else {
							idleTimer = 0;
							idle = false;
							meuRigidbody.bodyType = RigidbodyType2D.Dynamic;
						}
					}
				} else {
					idle = true;
					meuRigidbody.bodyType = RigidbodyType2D.Static;
					if (alvoIndex < waypoints.Length - 1) {
						alvoIndex++;
						alvo = waypoints [alvoIndex];
					} else {
						alvoIndex = 0;
						alvo = waypoints [alvoIndex];
					}
				}
			}
			break;

		case 1:
			//persegue
			animator.SetBool ("Idle", false);
			animator.SetBool ("Walk", false);
			animator.SetBool ("Run", true);
			alvo = player;
			velocidade = 8;
			meuRigidbody.bodyType = RigidbodyType2D.Dynamic; 
			if (Vector2.Distance (gameObject.transform.position, alvo.transform.position) > 1.5f) {
				if (transform.position.x > alvo.transform.position.x)
					meuRigidbody.velocity = new Vector2 (velocidade * -1, meuRigidbody.velocity.y);
				else
					meuRigidbody.velocity = new Vector2 (velocidade, meuRigidbody.velocity.y);
			} else
				inteligencia = 2;
			break;
		case 2:
			//ataca
			if(!player.GetComponent<Jogador>().invencivel)
				SceneManager.LoadScene ("dead");
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D colisor)
	{
		RaycastHit2D hit;
		if (colisor.tag == "Player") {
			hit = Physics2D.Raycast (new Vector2 (transform.position.x, colisor.transform.position.y), new Vector2 (colisor.transform.position.x - transform.position.x, 0)); 
			if (hit.collider.tag == "Player") {
				inteligencia = 1;
				print ("y");
			} else
				print (hit.collider.tag);
		}
	}

	void OnTriggerExit2D (Collider2D colisor)
	{
		if (colisor.tag == "Player")
			inteligencia = 0;
	}
}
