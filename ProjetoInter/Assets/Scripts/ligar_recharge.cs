using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligar_recharge : MonoBehaviour {

    bool playerDentro;
    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("E") && playerDentro) {
            anim.SetBool("ativado", true);
        }
        
	}

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerDentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDentro = false;
        }
    }
}
