using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSegue : MonoBehaviour {

	private Transform alvo;

	void Start () {
		alvo = GameObject.Find ("Lanterna").transform;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (alvo.position.x, alvo.position.y, transform.position.z);
	}
}
