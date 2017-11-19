using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour {
	public bool focoBoss;

	private Transform alvo;

	[SerializeField]
	private Transform alvoAranha;

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;
	// Use this for initialization
	float posXInicial;
	float posYInicial;

	void Start () {

		if (PlayerPrefs.GetInt("checkpoint") == 0)
		{
			posXInicial = -34f;
			posYInicial = 1.3f;
			transform.position = new Vector3(posXInicial, posYInicial, gameObject.transform.position.z);
			//alvo = GameObject.Find("Jogador").transform;
		}

		if (PlayerPrefs.GetInt("checkpoint") == 1)
		{
			posXInicial = -13f;
			posYInicial = 1.8f;
			transform.position = new Vector3(posXInicial, posYInicial, gameObject.transform.position.z);

		}
		alvo = GameObject.Find("Jogador").transform;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (!focoBoss) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (alvo.position.x, alvo.position.y + 1.5f, transform.position.z), 8 * Time.deltaTime);
			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, 3.17f, Time.deltaTime);
		}
		else{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (alvoAranha.position.x, alvoAranha.position.y, transform.position.z), Time.deltaTime);
			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, 10, Time.deltaTime);
		}
	}
}
