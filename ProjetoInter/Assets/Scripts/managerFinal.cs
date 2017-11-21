﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerFinal : MonoBehaviour {

    public GameObject tela1;
    public GameObject tela2;
    public GameObject tela3;

    // Use this for initialization
    void Start () {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        Fim();
    }
	
	// Update is called once per frame
	void Update () {
        

    }
    void Fim() {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        tela1.SetActive(true);
        Invoke("transicao1", 3);

    }

    void transicao1() {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);        
        Invoke("Agradecimentos", 3);
    }
    void Agradecimentos() {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        tela1.SetActive(false);
        tela2.SetActive(true);
        Invoke("transicao2", 3);

    }
    void transicao2()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        Invoke("Creditos", 3);
    }

    void Creditos() {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        tela2.SetActive(false);
        tela3.SetActive(true);
        Invoke("transicao3", 3);
        
    }

    void transicao3()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        Invoke("loadCena", 3);
    }

    void loadCena() {
        SceneManager.LoadScene("inicial");
    }

    
}