using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {
    public string cena; 
  // Use this for initialization
    void Start()
    {
        float fadeTime = GameObject.Find("fadding").GetComponent<fadding>().BeginFade(-1);
    }

    void Update()
    {


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
        if (PlayerPrefs.GetInt("som") == 0) {
            PlayerPrefs.DeleteAll();
            Invoke("apagar1", 1);
        }

        if (PlayerPrefs.GetInt("som") == 1)
        {
            PlayerPrefs.DeleteAll();
            Invoke("apagar2", 1);
        }
        //PlayerPrefs.SetInt("chave_azul", 0);
        //PlayerPrefs.SetInt("chave_azul", 0);
        //PlayerPrefs.SetInt("chave_azul", 3);
        //PlayerPrefs.SetInt("chave_azul", 0);
    }

    public void apagar1() {
        PlayerPrefs.SetInt("som", 0);
    }

    public void apagar2()
    {
        PlayerPrefs.SetInt("som", 1);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void desligaSomON() {

        PlayerPrefs.SetInt("som", 1);

    }

    public void desligaSomOFF()
    {
        PlayerPrefs.SetInt("som", 0);


    }

}
