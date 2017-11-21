using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager1 : MonoBehaviour {

    public GameObject tela1;
    public GameObject tela2;

    // Use this for initialization
    void Start()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        logoGrupo();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void logoGrupo()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        tela1.SetActive(true);
        Invoke("transicao1", 3);

    }

    void transicao1()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        Invoke("LogoGame", 3);
    }
 
    void LogoGame()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
        tela1.SetActive(false);
        tela2.SetActive(true);
        Invoke("transicao3", 3);

    }

    void transicao3()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(1);
        Invoke("loadCena", 3);
    }

    void loadCena()
    {
        SceneManager.LoadScene("inicial");
    }


}
