using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour {
	public GameObject lightDentro, lightFora;

	public float timer;
	// Update is called once per frame
	void Update () {
		lightDentro.GetComponent<Light> ().intensity = Mathf.Clamp (lightDentro.GetComponent<Light> ().intensity - Time.deltaTime/15, 0, 8);
		lightFora.GetComponent<Light> ().intensity = Mathf.Clamp (lightFora.GetComponent<Light> ().intensity - Time.deltaTime/30, 0, 4);
	}
}
