using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {
    public string cena; 
  // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (cena.Length > 1)//se nao escreveu nada nao executa
            Invoke("LevelLoad", 11);// chama a funcao com delay

    }
    //chama o level load usando a variavel global como padrao
    public void LevelLoad()
    {
        //NEW GAME
        if(PlayerPrefs.GetInt("Reset") == 0)
        //CONTINUE
        LevelLoad(cena);
    }

    public void NewGame()
    {
        //NEW GAME
        PlayerPrefs.SetInt("Reset", 1);
        LevelLoad(cena);
    }
    public void Continue()
    {
        //NEW GAME
        PlayerPrefs.SetInt("Reset", 0);
        LevelLoad(cena);
    }

    //funcao propria pra carregar o level
    public void LevelLoad(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("chave_azul", 0);
        PlayerPrefs.SetInt("chave_azul", 0);
        PlayerPrefs.SetInt("chave_azul", 3);
        PlayerPrefs.SetInt("chave_azul", 0);
    }

    public void Sair()
    {
        Application.Quit();
    }

}
