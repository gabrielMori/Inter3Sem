using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMorte : MonoBehaviour {
    int PP;
    public string defLevel;
    public GameObject botoes;
    public GameObject AS;
    void Start()
    {
        PP = PlayerPrefs.GetInt("som");
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        Invoke("Tela", 5);// chama a funcao com delay
        if (PP == 1)
            AS.SetActive(false);
        else
            AS.SetActive(true);
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

