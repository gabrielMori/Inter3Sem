using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventos_enemy : MonoBehaviour {

    public GameObject inimigo1;
    public GameObject inimigo2;
    public GameObject inimigo3;
    public GameObject inimigo4;
    //public GameObject inimigo3;
    //public GameObject inimigo4;
    //public GameObject inimigo5;
    //public GameObject inimigo6;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("inimigo01", 0);
        PlayerPrefs.Save();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("inimigo01") == 0)
        {
            inimigo1.SetActive(false);
            inimigo2.SetActive(true);
            //inimigo1.transform.position = new Vector3(-30f, -22.9f, 0);
        }

        if (PlayerPrefs.GetInt("inimigo01") == 1)
        {
            inimigo1.SetActive(true);
            inimigo2.SetActive(false);
            //inimigo1.transform.localPosition = inimigo1.GetComponent<destino>().estado02.transform.localPosition;
        }

        if (PlayerPrefs.GetInt("inimigo02") == 0)
        {
            inimigo3.SetActive(true);
            inimigo4.SetActive(false);
            //inimigo1.transform.position = new Vector3(-30f, -22.9f, 0);
        }

        if (PlayerPrefs.GetInt("inimigo02") == 1)
        {
            inimigo3.SetActive(false);
            inimigo4.SetActive(true);
            //inimigo1.transform.localPosition = inimigo1.GetComponent<destino>().estado02.transform.localPosition;
        }

    }
}
