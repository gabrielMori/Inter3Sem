using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPass : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Reset") == 0) {
            if (PlayerPrefs.HasKey("posPx"))
            {
                Vector3 posplayer = new Vector3(PlayerPrefs.GetFloat("posPx"), PlayerPrefs.GetFloat("posPy"), gameObject.transform.position.z);
                gameObject.transform.position = posplayer;
            }
        }
        if (PlayerPrefs.GetInt("Reset") == 1)
        {
            if (PlayerPrefs.HasKey("posPx"))
            {
                Vector3 posplayer = new Vector3(35f, 1.5f, gameObject.transform.position.z);
                gameObject.transform.position = posplayer;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
