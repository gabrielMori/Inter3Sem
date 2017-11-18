using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapa : MonoBehaviour {
    public GameObject setor1;
    //public GameObject setor2;
    //public GameObject setor3;

    // Use this for initialization
    int mapaAtivo = 0;
    bool map = false;
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (PlayerPrefs.GetInt("mapa") == 1) {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (map == false)
                {
                    //Time.timeScale = 0;
                    setor1.SetActive(true);
                    map = true;
                }
                else
                {
                    //Time.timeScale = 1;
                    setor1.SetActive(false);
                    map = false;
                }
            }
        }


        //if (Input.GetKeyUp(KeyCode.M))
        //{
        //    map = false;
        //
        //}
        if (map) {
            
        }

        if (!map)
        {
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
        }
    }
}
