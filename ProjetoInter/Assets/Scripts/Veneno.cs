using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Veneno : MonoBehaviour {

	private Animator anim;
	private bool playerInRange;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void DropVeneno(){
		anim.SetTrigger ("Veneno");
	}

	private void OnTriggerEnter2D(Collider2D colisor){
		if (colisor.tag == "Player")
			playerInRange = true;
	}

	private void OnTriggerExit2D(Collider2D colisor){
		if (colisor.tag == "Player")
			playerInRange = false;
	}

	private void KillPlayer(){
		if (playerInRange)
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
