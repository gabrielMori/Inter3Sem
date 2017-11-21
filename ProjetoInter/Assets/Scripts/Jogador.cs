using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
	public int[] itens;
	public int[] documentos;
	bool personagemDesligado = false;
	bool efeito = false;
	bool efeitoTransicao = false;
	float cooldownEfeito = 0;

	bool efeito2 = false;
	bool efeitoTransicao2 = false;
	float cooldownEfeito2 = 0;

	public AudioSource movimentos;
	public AudioClip[] movimentosP;
	int curentMove;
	public float velocidade;
	public bool pulando, rastejando, escada, makingNoise;
	private Vector3 dutoPos;
	private BoxCollider2D colisorChao;
	private Collider2D dutoColisor;
	private List<GameObject> chaves = new List<GameObject>();
	public GameObject[] canvas;
	private Rigidbody2D meuRigidbody;
	private int switchIndex;

	private bool estaNoChao, subindo, onTrigger, duto, acido;

	private float subindoTimer;

	[SerializeField]
	private float distanciaChao, forcaPulo;

	[SerializeField]
	private Transform[] pontosChão;

	[SerializeField]
	private LayerMask chao;

	// Use this for initialization
	void Start()
	{
		meuRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (cooldownEfeito > 0)
		{
			cooldownEfeito -= Time.deltaTime;
		}
		float h = Input.GetAxis("Horizontal");
		if (h < 0)
		{
			if (!movimentos.isPlaying)
			{
				if (rastejando)
				{
					curentMove = 1;
					movimentos.clip = movimentosP[curentMove];
					movimentos.Play();
				}
				else
				{
					curentMove = 0;
					movimentos.clip = movimentosP[curentMove];
					movimentos.Play();
				}
			}
			GetComponent<Animator>().SetInteger("Direction", 1);
		}
		else if (h > 0)
		{
			if (!movimentos.isPlaying)
			{
				if (rastejando)
				{
					curentMove = 1;
					movimentos.clip = movimentosP[curentMove];
					movimentos.Play();
				}
				else
				{
					curentMove = 0;
					movimentos.clip = movimentosP[curentMove];
					movimentos.Play();
				}

			}
			GetComponent<Animator>().SetInteger("Direction", -1);
		}
		float v = Input.GetAxis("Correr");

		Movimento(h, v);

		estaNoChao = EstaNoChao();

		Botoes();

		if (!rastejando && !subindo)
		{
			GetComponent<BoxCollider2D>().size = new Vector3(1.36f, 2.7f, transform.position.z);
			meuRigidbody.gravityScale = 10;
		}
		else if (rastejando)
		{
			GetComponent<BoxCollider2D>().size = new Vector3(1.36f, 1.25f, transform.position.z);
			meuRigidbody.gravityScale = 10;
		}
	}

	private void Botoes()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			rastejando = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			rastejando = false;
		}
	}

	private void Movimento(float horizontal, float velo)
	{
		if (!personagemDesligado)
		{//condicao usada para fazer o efeito de fade in fade out
			if (velo > 0 && !rastejando)
			{
				velocidade = 8;
				curentMove = 0;
				makingNoise = true;
			}
			else if (rastejando)
			{
				makingNoise = false;
				velocidade = 1;
				curentMove = 1;
			}
			else
			{
				makingNoise = false;
				velocidade = 3;
			}

			if (!duto)
			{
				meuRigidbody.velocity = new Vector3(horizontal * velocidade, meuRigidbody.velocity.y, transform.position.z);
			}
		}
	}

	private bool EstaNoChao()
	{
		if (meuRigidbody.velocity.y <= 0)
		{
			foreach (Transform ponto in pontosChão)
			{
				Collider2D[] colisores = Physics2D.OverlapCircleAll(ponto.position, distanciaChao, chao);

				for (int i = 0; i < colisores.Length; i++)
				{
					if (colisores[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.tag == "Duto")
		{

			onTrigger = true;
			canvas[0].SetActive(true);
			GetComponent<Animator>().SetBool("DutoDireita", collider.GetComponent<Duto>().dir);
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (collider.GetComponent<Duto>().index == 0)
				{
                    print("dentro do tudo");
                    
					duto = true;
					transform.position = collider.transform.position;
				}
				else
				{
                    print("fora do tudo");
                    PlayerPrefs.SetInt("dentroTubo", 1);
                    duto = false;
				}
				TransicaoDuto(collider.GetComponent<Duto>().pos.transform.position, collider.GetComponent<Duto>().index);
				Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider.GetComponent<Duto>().dutoSuperficie.GetComponent<Collider2D>());
				dutoColisor = collider.GetComponent<Duto>().dutoSuperficie.GetComponent<Collider2D>();
			}
		}

		if (collider.tag == "Switch")
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if(switchIndex == collider.GetComponent<Switch> ().index){
					if (collider.GetComponent<Switch> ().aranhaObj) {
						collider.GetComponent<Switch> ().ModAranha ();

					} else {
						collider.GetComponent<Switch> ().aranha.inteligencia = Mathf.Clamp (collider.GetComponent<Switch> ().aranha.inteligencia + 1, 0, 3);
						collider.GetComponent<Switch> ().aranha.inteligencia2 = 0;
						Destroy (collider.GetComponent<Switch> ().box);

						if(collider.GetComponent<Switch> ().index == 3){
							collider.GetComponent<Switch> ().ChangeCamera ();
						}
					}

					switchIndex++;
				}
			}
		}
		if (collider.tag == "Chave" || collider.tag == "Acido")
		{
			onTrigger = true;
			if (Input.GetKeyDown(KeyCode.E))
			{

				if (collider.GetComponent<Chave>().portas.Length > 0)
				{
					for (int i = 0; i < collider.GetComponent<Chave>().portas.Length; i++)
					{
						chaves.Add(collider.GetComponent<Chave>().portas[i]);
					}
				}
				if (collider.GetComponent<Chave>().portas2.Length > 0)
				{
					for (int i = 0; i < collider.GetComponent<Chave>().portas2.Length; i++)
					{
						collider.GetComponent<Chave>().portas2[i].podeAbrir = true;
					}
				}
				if (collider.GetComponent<Chave>().tele)
					collider.GetComponent<Chave>().TeleportEnemies();
				if (collider.tag == "Acido")
				{
					acido = true;
				}

				Destroy(collider.gameObject);
			}
		}
		if (collider.tag == "lori")
		{
			onTrigger = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(collider.gameObject);
                canvas[1].SetActive(false);
            }
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		onTrigger = false;
		canvas[0].SetActive(false);
		canvas[1].SetActive(false);
	}

	private void TransicaoDuto(Vector3 p, int index)
	{
		pulando = true;
		dutoPos = p;
		if (index == 0)
		{
			meuRigidbody.velocity = Vector3.zero;
			meuRigidbody.velocity = new Vector3(0, 50, transform.position.z);
			pulando = true;
		}
	}

	private void AbrirPortas(GameObject porta)
	{
		for (int i = 0; i < chaves.Count; i++)
		{
			if (chaves[i] == porta)
			{
				if (porta.GetComponent<Acido>())
				{
					Destroy(porta);
				}
				else
				{
					porta.SetActive(false);
					StartCoroutine(WaitPorta(porta));
				}
			}
		}
	}
	private IEnumerator WaitPorta(GameObject p)
	{
		yield return new WaitForSeconds(3);
		p.SetActive(true);
	}
	private void SairAnimacaoSubindo()
	{
		gameObject.transform.position = dutoPos;
		meuRigidbody.gravityScale = 10;
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), dutoColisor, false);
		if (duto)
		{
			duto = false;
			rastejando = true;
			subindo = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "EntradaDuto")
		{
			if (duto)
			{
				pulando = false;
				meuRigidbody.gravityScale = 0;
				meuRigidbody.velocity = Vector3.zero;
				subindo = true;
				GetComponent<Animator>().SetTrigger("Subir");
			}
		}
		if (collider.tag == "Escada_1")
		{
 
			PlayerPrefs.SetInt("estado", 0);
			if (Input.GetButtonDown("Vertical") && !efeito)
			{

			}
		}

		if (collider.tag == "Escada_2")
		{
			PlayerPrefs.SetInt("estado", 1);
			if (Input.GetButtonDown("Vertical") && !efeito)
			{

			}
		}

        //copiar isso daqui pro proximo UPDATE
        if (collider.tag == "setor1_passagem_01")
       {            
            PlayerPrefs.SetInt("setor1_passagem01", 1);
        }

        if (collider.tag == "setor1_passagem_02")
        {
            PlayerPrefs.SetInt("setor1_passagem02", 1);
        }


        //copiar isso daqui pro proximo UPDATE
    }
}