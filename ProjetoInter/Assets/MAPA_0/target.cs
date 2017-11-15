using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
    public GameObject personagem;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //acessandoMovement = gameObject.GetComponent<Movement>();
        //playerVivoREF = acessandoMovement.playerVivo;

        //if (playerVivoREF == true) {
        if (!personagem)
            return;
        Vector3 newpos = new Vector3(personagem.transform.position.x, personagem.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime);

        //}

    }
}
