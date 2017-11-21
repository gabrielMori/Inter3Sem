using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desbloqueio : MonoBehaviour
{
    public GameObject barreira;
    public GameObject enemy01;
    public GameObject enemy02;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("setor1_passagem01", 0);
        PlayerPrefs.SetInt("setor1_passagem01", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (PlayerPrefs.GetInt("setor1_passagem01") == 1)
            {
                enemy01.SetActive(true);
                barreira.SetActive(false);
            }

            if (PlayerPrefs.GetInt("setor1_passagem02") == 1)
            {
                enemy02.SetActive(true);
                barreira.SetActive(false);
            }

        }
    }
}
