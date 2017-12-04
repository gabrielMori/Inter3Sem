using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadinManager : MonoBehaviour {
	public GameObject loading;
	public GameObject[] coisasDaCena;
	public Slider progressBar;

	private AsyncOperation async;

	public void Chama(string level){
		StartCoroutine (LoadingScreen (level));
	}
	IEnumerator LoadingScreen(string level){
		loading.SetActive (true);
		for(int i = 0; i < coisasDaCena.Length; i++){
			coisasDaCena [i].SetActive (false);
		}
		async = SceneManager.LoadSceneAsync (level);
		async.allowSceneActivation = false;

		while(!async.isDone){
			progressBar.value = async.progress;
			if(async.progress == 0.9f){
				progressBar.value = 1;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
