using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evento2_setor2 : MonoBehaviour {

    public GameObject inimigo1;
    public GameObject inimigo2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("chave_verde") == 0)
        {
            inimigo1.SetActive(true);
            inimigo2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("chave_verde") == 1)
        {
            inimigo1.SetActive(false);
            inimigo2.SetActive(true);
        }
    }
}
