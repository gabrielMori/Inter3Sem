using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour {
	private Transform alvo;

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;
	// Use this for initialization
	void Start () {
		alvo = GameObject.Find ("Jogador").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, new Vector3(alvo.position.x, alvo.position.y + 1.5f, transform.position.z), 8 * Time.deltaTime);
	}
}
