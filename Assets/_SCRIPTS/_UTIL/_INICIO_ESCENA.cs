using UnityEngine;
using System.Collections;

public class _INICIO_ESCENA : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.enabled = true;
		guiTexture.pixelInset = new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.01f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	

}