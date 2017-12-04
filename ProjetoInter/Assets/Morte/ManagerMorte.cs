using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerMorte : MonoBehaviour {
    int PP;
    public string defLevel;
    public GameObject botoes;
    public GameObject AS;

	public GameObject loading;
	public Slider barra;

	private AsyncOperation async;
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
		StartCoroutine (LoadScreen("inicial"));
    }

    public void Continue()
    {
		StartCoroutine (LoadScreen("Level"));
    }
	IEnumerator LoadScreen(string level){
		loading.SetActive (true);
		async = SceneManager.LoadSceneAsync (level);
		async.allowSceneActivation = false;

		while(!async.isDone){
			barra.value = async.progress;
			if(async.progress == 0.9f){
				barra.value = 1;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}

}

