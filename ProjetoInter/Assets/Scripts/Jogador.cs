using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public AudioSource musicas, SFX, movimentos;
    public AudioClip[] BG;
    public AudioClip[] movimentosP;
    public AudioClip[] SoundEffects;
    int curentSong;
    int curentSFX;
    int curentMove;
    public float velocidade;
    public bool pulando, rastejando, escada, makingNoise;
    private Vector2 dutoPos;
    private BoxCollider2D colisorChao;
    private Collider2D dutoColisor;
    private List<GameObject> chaves = new List<GameObject>();
    public GameObject[] canvas;
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
    void Start()
    {
        meuRigidbody = GetComponent<Rigidbody2D>();
        curentSong = 0;
        musicas.clip = BG[curentSong];
        musicas.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!musicas.isPlaying)
        {
            musicas.clip = BG[curentSong];
            musicas.Play();
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
            GetComponent<BoxCollider2D>().size = new Vector2(1.36f, 2.7f);
            meuRigidbody.gravityScale = 10;
        }
        else if (rastejando)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1.36f, 1.25f);
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
            meuRigidbody.velocity = new Vector2(horizontal * velocidade, meuRigidbody.velocity.y);
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
                    duto = true;
                    transform.position = collider.transform.position;
                }
                else
                {
                    duto = false;
                }
                TransicaoDuto(collider.GetComponent<Duto>().pos.transform.position, collider.GetComponent<Duto>().index);
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider.GetComponent<Duto>().dutoSuperficie.GetComponent<Collider2D>());
                dutoColisor = collider.GetComponent<Duto>().dutoSuperficie.GetComponent<Collider2D>();
            }
        }

        if (collider.tag == "Escada")
        {
            onTrigger = true;
            canvas[0].SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.localPosition = collider.GetComponent<Escada>().colisor.transform.localPosition;
            }
        }

        if (collider.tag == "Porta")
        {
            onTrigger = true;
            canvas[1].SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                curentSFX = 0;
                SFX.clip = SoundEffects[curentSFX];
                SFX.Play();
                if (collider.GetComponent<Acido>())
                {
                    if (acido)
                    {
                        AbrirPortas(collider.gameObject);
                        acido = false;
                    }
                }
                else
                    AbrirPortas(collider.gameObject);
            }
        }
        if (collider.tag == "Painel")
        {
            canvas[1].SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                curentSong = 1;
                musicas.clip = SoundEffects[curentSong];
                musicas.Play();
                collider.GetComponent<Painel>().SpawnInimigos();
                for (int i = 0; i < collider.GetComponent<Painel>().portasVerm.Length; i++)
                {
                    chaves.Add(collider.GetComponent<Painel>().portasVerm[i]);
                }
            }
        }
        if (collider.tag == "Porta2")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (collider.GetComponent<Porta>().podeAbrir)
                {
                    canvas[0].SetActive(true);
                    curentSFX = 0;
                    SFX.clip = SoundEffects[curentSFX];
                    SFX.Play();
                    transform.position = new Vector2(collider.GetComponent<Porta>().pos.transform.position.x, collider.GetComponent<Porta>().pos.transform.position.y);
                }
            }
        }

        if (collider.tag == "Switch")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                collider.GetComponent<Switch>().aranha.inteligencia = Mathf.Clamp(collider.GetComponent<Switch>().aranha.inteligencia + 1, 0, 3);
                collider.GetComponent<Switch>().aranha.inteligencia2 = 0;
                Destroy(collider.GetComponent<Switch>().box);
            }
        }
        if (collider.tag == "Chave" || collider.tag == "Acido")
        {
            canvas[1].SetActive(true);
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
        else if (collider.tag == "EntradaDuto")
        {
            if (duto)
            {
                pulando = false;
                meuRigidbody.gravityScale = 0;
                meuRigidbody.velocity = Vector2.zero;
                subindo = true;
                GetComponent<Animator>().SetTrigger("Subir");
            }
        }
        if (collider.tag == "lori")
        {
            canvas[1].SetActive(true);
            onTrigger = true;
            if (Input.GetKeyDown(KeyCode.E))
                Destroy(collider.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        onTrigger = false;
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
    }

    private void TransicaoDuto(Vector2 p, int index)
    {
        pulando = true;
        dutoPos = p;
        if (index == 0)
        {
            meuRigidbody.velocity = Vector2.zero;
            meuRigidbody.velocity = new Vector2(0, 50);
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
}