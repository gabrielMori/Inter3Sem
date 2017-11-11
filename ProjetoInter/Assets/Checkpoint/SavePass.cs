using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePass : MonoBehaviour {

    //public Animator anim;
    //public AudioSource aud;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            //anim.SetBool("save1", true);
            //aud.Play();

            Vector3 posplayer = col.gameObject.transform.position;
            PlayerPrefs.SetFloat("posPx", posplayer.x);
            PlayerPrefs.SetFloat("posPy", posplayer.y);

            PlayerPrefs.Save();
            print("salvei?");
            //PlayerPrefs.Save ();

        }


    }
}
