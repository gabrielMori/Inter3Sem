using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimaCoisa : MonoBehaviour {
    public GameObject dialogo;
    public GameObject folha;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player")){
            dialogo.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogo.SetActive(false);
            folha.SetActive(false);
        }
    }
}
