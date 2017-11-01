using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemAnimCtrl : MonoBehaviour {
	private Jogador jogador;
	private Animator animator;
	private Rigidbody2D meuRigidbody;
	// Use this for initialization
	void Start () {
		jogador = GetComponent<Jogador> ();
		animator = GetComponent<Animator> ();
		meuRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		animator.SetFloat ("Velocidade", Mathf.Abs(meuRigidbody.velocity.x));
		animator.SetBool ("Rastejando", jogador.rastejando);
		animator.SetBool ("Pulando", jogador.pulando);
	}
}
