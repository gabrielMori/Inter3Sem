using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat : MonoBehaviour
{

    bool playerDentro = false;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("plataforma01") == 1)
        {
            if (playerDentro)
            {
                Invoke("EnableRagdoll", 1);
            }
        }
    }



    void EnableRagdoll()
    {
        rb.isKinematic = false;
        //rb.detectCollisions = true;
    }
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        //rb.detectCollisions = false;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            playerDentro = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerDentro = false;
        }
    }
}


