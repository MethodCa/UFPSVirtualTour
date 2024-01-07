using UnityEngine;
using System.Collections;

public class manejarGuiAyuda : MonoBehaviour {

	public GUITexture gui;
	public GUITexture ayudaIcon;
	private bool mostrarAyuda=false;

	// Use this for initialization
	void Start () {
		ayudaIcon.pixelInset = new Rect(-Screen.width/2+15, Screen.height/2-15-64 ,64, 64);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			if (!mostrarAyuda)
			{
				StartCoroutine (fadeIn());
				mostrarAyuda=true;
			}
			else
			{
				StartCoroutine (fadeOut());
				mostrarAyuda=false;
			}
		}
	}
	IEnumerator fadeIn()
	{
		gui.enabled = true;
		float t;
		for (t = 0.0f; t < 0.4F; t+= Time.deltaTime) {
			Color textureColor = gui.color;
			textureColor.a = Mathf.Lerp (0, 1, t / 1F);
			gui.color=textureColor;
			yield return gui;
		}
	}

	IEnumerator fadeOut()
	{
		float t;
		for (t = 0.0f; t < 0.5F; t+= Time.deltaTime) {
			Color textureColor = gui.color;
			textureColor.a = Mathf.Lerp (0.4F, 0, t / 0.5F);
			gui.color=textureColor;
			yield return gui;
		}
		gui.enabled = false;
	}
}
	
	

