using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager_pause : MonoBehaviour {

    public void menuInicial() {
		Time.timeScale = 1;
        SceneManager.LoadScene("inicial");
    }
}
