using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
	public float velocidade;
	public bool pulando, rastejando, escada;
	private Vector2 dutoPos;
	private BoxCollider2D colisorChao;
	private Collider2D dutoColisor;
	private List<GameObject> chaves = new List<GameObject>();

	private Rigidbody2D meuRigidbody;

	private bool estaNoChao, subindo, onTrigger, duto;

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
		if (h < 0 && !subindo) 
			gameObject.transform.localScale = new Vector2 (1, gameObject.transform.localScale.y);
		else if (h > 0) 
			gameObject.transform.localScale = new Vector2 (-1, gameObject.transform.localScale.y);
		
		float p = Input.GetAxis ("Jump");
		float v = Input.GetAxis ("Correr");

		Movimento (h, v, p);

		estaNoChao = EstaNoChao ();

		Botoes ();
	}

	private void Botoes ()
	{
		if(Input.GetKeyDown(KeyCode.LeftControl))
			rastejando = true;
		else if(Input.GetKeyUp(KeyCode.LeftControl))
			rastejando = false;
		
	}

	private void Movimento (float horizontal, float velo, float pula)
	{
		if (velo > 0 && !rastejando) {
			velocidade = 8;
		} else if (rastejando) {
			velocidade = 1;
		} else {
			velocidade = 3;
		}

		if (pula > 0 && !estaNoChao) {
			pulando = true;
		} else {
			pulando = false;
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
		if(collider.tag == "Chave"){
			onTrigger = true;
			for(int i = 0; i < collider.GetComponent<Chave>().portas.Length; i++){
				chaves.Add (collider.GetComponent<Chave>().portas[i]);
			}
			Destroy (collider.gameObject);
		} else if(collider.tag == "EntradaDuto"){
			if(duto){
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
				AbrirPortas (collider.gameObject);
			}
		}
		if(collider.tag == "Painel"){
			for(int i = 0; i < collider.GetComponent<Painel>().portasVerm.Length; i++){
				chaves.Add (collider.GetComponent<Painel>().portasVerm[i]);
				collider.GetComponent<Painel>().SpawnInimigos();
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
			meuRigidbody.velocity = new Vector2 (0, 10);
		}
	}

	private void AbrirPortas(GameObject porta){
		for(int i = 0; i < chaves.Count; i++){
			if(chaves[i] == porta){
				porta.SetActive (false);
				StartCoroutine (WaitPorta(porta));
			}
		}
	}
	private IEnumerator WaitPorta(GameObject p){
		yield return new WaitForSeconds (3);
		p.SetActive (true);
	}
	private void SairAnimacaoSubindo(){
		gameObject.transform.position = dutoPos;
		meuRigidbody.gravityScale = 1;
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), dutoColisor, false);
		if(duto){
			duto = false;
			rastejando = true;
			subindo = false;
		}
	}
}