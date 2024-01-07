using UnityEngine;
using System.Collections;

public class rotar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,0,  5.8f), Space.Self);
	
	}
}
