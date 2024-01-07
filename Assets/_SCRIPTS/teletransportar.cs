using UnityEngine;
using System.Collections;

public class teletransportar : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			GameObject personaje=GameObject.Find("First Person Controller");
			print (personaje.transform.position);
			personaje.transform.position=(new Vector3 (-145F,11.7F, -62.8F));
			
		}


	}
}
