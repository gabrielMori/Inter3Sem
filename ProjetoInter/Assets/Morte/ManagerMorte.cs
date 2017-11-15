using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMorte : MonoBehaviour {

    public string defLevel;
    public GameObject botoes;

    void Start()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        Invoke("Tela", 5);// chama a funcao com delay

    }

    void Tela() {
        botoes.SetActive(true);
    }

    // Update is called once per frame
    public void MenuInicial()
    {
        SceneManager.LoadScene("inicial");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level");
    }
}

