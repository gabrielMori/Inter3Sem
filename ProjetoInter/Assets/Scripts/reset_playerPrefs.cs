using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_playerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("fornalhaligada", 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("H")) {
            print("player prefs resetados");
            PlayerPrefs.DeleteAll();
            //PlayerPrefs.SetInt("chave_azul", 0);
            //PlayerPrefs.SetInt("chave_amarela", 0);
            //PlayerPrefs.SetInt("chave_verde", 0);
            //PlayerPrefs.SetInt("chave_preta", 0);
            //PlayerPrefs.SetInt("chave_branca", 0);
            //PlayerPrefs.SetInt("chave_laranja", 0);
            //PlayerPrefs.SetInt("chave_roxa", 0);
            
            //PlayerPrefs.SetInt("switch_especial01", 0);
            //PlayerPrefs.SetInt("switch_especial02", 0);
            //PlayerPrefs.SetInt("switch_especial03", 0);
            //PlayerPrefs.SetInt("maquina01", 0);
            //PlayerPrefs.SetInt("maquina02", 0);
            //PlayerPrefs.SetInt("maquina03", 0);

        }
	}
}
