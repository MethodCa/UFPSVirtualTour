using UnityEngine;
using System.Collections;

public class _ORDERNAR_GUI : MonoBehaviour {

	public GUITexture _CARGANDO;
	public GUITexture _CREDITOS;
	public GUITexture _LOGOS;
	public GUITexture _PRESIONE_ENTER;

	// Use this for initialization
	void Start () {

		_CARGANDO.pixelInset = new Rect((Screen.width/2)-265, (Screen.height/2)-43 , 222, 35);// Seteo la posicion inicial de esta textura GUI.
		_CREDITOS.pixelInset = new Rect((-Screen.width/2)+20, (-Screen.height/2)+7 , 512, 34);// Seteo la posicion inicial de esta textura GUI.
		_LOGOS.pixelInset = new Rect((Screen.width/2)-520, (-Screen.height/2) , 512, 64);// Seteo la posicion inicial de esta textura GUI.
		_PRESIONE_ENTER.pixelInset = new Rect(Screen.width/2-430, Screen.height/2-43 , 383, 34);// Seteo la posicion inicial de esta textura GUI.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
