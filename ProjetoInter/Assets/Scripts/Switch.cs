using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public Aranha aranha;
	public BoxCollider2D box;
	public GameObject aranhaObj;
	public CameraSegue camera;
	public int index;

	public void ModAranha(){
		aranhaObj.SetActive (true);
		ChangeCamera ();
	}
	public void ChangeCamera(){
		camera.focoBoss = !camera.focoBoss;
	}
}
