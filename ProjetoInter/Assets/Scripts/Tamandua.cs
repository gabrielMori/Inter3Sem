using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tamandua : MonoBehaviour
{
	[SerializeField]
	private Jogador jogador;
    private int inteligencia;

    void FixedUpdate()
    {
        InteligenceCtrl();
    }

    private void OnTriggerStay2D(Collider2D colisor)
    {
        if (colisor.tag == "Player")
        {
            if (colisor.transform.position.x < transform.position.x)
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

            if (colisor.GetComponent<Jogador>().makingNoise || Vector3.Distance(transform.position, colisor.transform.position) < 3)
                inteligencia = 2;
            else
                inteligencia = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.tag == "Player")
        {
            inteligencia = 0;
        }
    }
    private void InteligenceCtrl()
    {
        switch (inteligencia)
        {
            case 0:
                //idle
                GetComponent<Animator>().SetBool("PlayerInRange", false);
                break;
            case 1:
                //observa
                GetComponent<Animator>().SetBool("PlayerInRange", true);
                break;
            case 2:
                //attack
                GetComponent<Animator>().SetTrigger("Attack");
                break;
        }
    }

    private void Death()
    {
		if (!jogador.invencivel) {
			if (GetComponent<Animator> ().GetBool ("PlayerInRange"))
				SceneManager.LoadScene ("dead");
			else
				GetComponent<Animator> ().ResetTrigger ("Attack");
		} else
			GetComponent<Animator> ().ResetTrigger ("Attack");
    }
}
