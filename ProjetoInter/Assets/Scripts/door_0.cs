using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_0 : MonoBehaviour

{
	public GameObject entrada;
	public GameObject saida;
	public GameObject player;

	float cooldownEfeito;

	bool disparaContador = false;
	bool estadoGenerico = false;
	bool estado0 = false;
	bool estado1 = false;

	bool botao = false;
	bool efeitoAtivo = false;
	bool playerDentro = false;

	void Start()
	{
		Vector3 entrada01 = entrada.transform.position;
		Vector3 player01 = player.transform.position;
		entrada.GetComponent<Transform>();

	}
	private void Update()
	{

		if (efeitoAtivo)
		{
			float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
			Invoke("Clarear", 2);
			efeitoAtivo = false;

		}
		if (disparaContador)
		{
			if (cooldownEfeito > 0)
			{
				cooldownEfeito -= Time.deltaTime;
			}
		}
		if (Input.GetButtonDown("Vertical") && playerDentro)
		{
			if (!botao)
			{
				botao = true;
				efeitoAtivo = true;
				estado1 = true;
			}
		}
		if (estado1)
		{
			cooldownEfeito = 1;
			disparaContador = true;
			estado1 = false;
			player.SetActive(false);
		}

		if (cooldownEfeito <= 0 && disparaContador)
		{
			disparaContador = false;
			estadoGenerico = true;
		}

		if (estadoGenerico)
		{
			if (PlayerPrefs.GetInt("estado") == 1)
			{
				player.SetActive(true);
				player.transform.position = new Vector3(entrada.transform.position.x, entrada.transform.position.y, -1.05f);
				estadoGenerico = false;
				botao = false;
			}

			if (PlayerPrefs.GetInt("estado") == 0)
			{
				player.SetActive(true);
				player.transform.position = new Vector3(saida.transform.position.x, saida.transform.position.y, -1.05f);
				estadoGenerico = false;

				botao = false;
			}
		}
	}

	void Clarear()
	{
		float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
		//playerDentro = false;
	}

	// Update is called once per frame

	public void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			playerDentro = true;
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			playerDentro = false;
		}
	}
}