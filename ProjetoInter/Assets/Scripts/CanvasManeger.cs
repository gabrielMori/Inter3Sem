using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManeger : MonoBehaviour
{
	public GameObject[] multSons;
	public GameObject inventario;
	public GameObject pause;
	public GameObject mapa;
	bool peguei = false;
	bool ativado = false;
	int veAi;
	private void Start()
	{
		veAi = PlayerPrefs.GetInt("som");
		if (veAi == 1)
			Tira_som();
		else
			Toca_som();
	}

	// Update is called once per frame
	void Update()
	{
		if(pause){
			if (Input.GetKeyDown(KeyCode.P))
			{
				if(!inventario.activeSelf && !mapa.activeSelf){
					if (ativado == false)
					{
						Time.timeScale = 0;
						pause.SetActive(true);
						ativado = true;
					}
					else
					{
						Time.timeScale = 1;
						pause.SetActive(false);
						ativado = false;
					}
				}
		
			}
			if (Input.GetKeyDown(KeyCode.I))
			{
				if(!pause.activeSelf && !mapa.activeSelf){
					if (ativado == false)
					{
						Time.timeScale = 0;
						inventario.SetActive(true);
						ativado = true;
					}
					else
					{
						Time.timeScale = 1;
						inventario.SetActive(false);
						ativado = false;
					}
				}
			}
			if (peguei == false)
			{
				if (Input.GetKeyUp(KeyCode.M))
				{
					Time.timeScale = 1;
					mapa.SetActive(false);
					peguei = true;
				}
			}
			if(!pause.activeSelf && !inventario.activeSelf){
				if (Input.GetKeyDown(KeyCode.M) && peguei == true)
				{
					Time.timeScale = 0;
					mapa.SetActive(true);
				}
				if (Input.GetKeyUp(KeyCode.M) && peguei == true)
				{
					Time.timeScale = 1;
					mapa.SetActive(false);
				}
			}
		}
	}

	public void Continue() {
		Time.timeScale = 1;
		pause.SetActive(false);
		ativado = false;

	}

	public void Continue_inventario()
	{
		Time.timeScale = 1;
		inventario.SetActive(false);
		ativado = false;

	}
	public void Tira_som()
	{
		PlayerPrefs.SetInt("som",1);
		for (int i = 0; i < multSons.Length; i++)
		{
			multSons[i].SetActive(false);
		}
	}
	public void Toca_som()
	{
		PlayerPrefs.SetInt("som", 0);
		for (int i = 0; i < multSons.Length; i++)
		{
			multSons[i].SetActive(true);
		}
	}
}
