using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desbloqueio : MonoBehaviour {
    public GameObject barreira;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            barreira.SetActive(false);
        }
    }
}
