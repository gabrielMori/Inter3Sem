using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJS : MonoBehaviour {
    // Use this for initialization
    public AudioSource AS;
    public Collider2D hue;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AS.Play();
        hue.enabled = !enabled;
    }
}
