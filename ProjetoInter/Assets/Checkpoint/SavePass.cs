using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePass : MonoBehaviour {
    //public Animator anim;
    //public AudioSource aud;
	[SerializeField]
	private Lanterna lanterna;

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            //anim.SetBool("save1", true);
            //aud.Play();

            Vector3 posplayer = col.gameObject.transform.position;
            PlayerPrefs.SetFloat("posPx", posplayer.x);
            PlayerPrefs.SetFloat("posPy", posplayer.y);
            PlayerPrefs.GetInt("switch_especial01");
            PlayerPrefs.GetInt("inimigo01");
            print (PlayerPrefs.GetInt("inimigo01"));
            PlayerPrefs.Save();
            print("salvei?");
            //PlayerPrefs.Save ();

			//Salva Itens Coletados
			for(int i = 0; i < col.GetComponent<Jogador>().itens.Length; i++){
				PlayerPrefs.SetInt ("item" + i, col.GetComponent<Jogador>().itens[i]);
			}

			for(int i = 0; i < col.GetComponent<Jogador>().documentos.Length; i++){
				PlayerPrefs.SetInt ("documento" + i, col.GetComponent<Jogador>().documentos[i]);
			}

			//recarrega lanterna
			lanterna.lightDentro.GetComponent<Light> ().intensity = 8;
			lanterna.lightFora.GetComponent<Light> ().intensity = 4;
        }


    }
}
