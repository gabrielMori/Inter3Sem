using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGchange : MonoBehaviour {
    public AudioClip musica1;
    public AudioSource BG;
    public AudioSource ambiencia;
    bool umaVez;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (BG.clip != musica1)
            {
                BG.clip = musica1;
                BG.Play();
                ambiencia.Play();
            }
        }
    }
}
