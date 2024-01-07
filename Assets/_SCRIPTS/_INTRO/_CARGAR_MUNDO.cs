using UnityEngine;
using System.Collections;

public class _CARGAR_MUNDO : MonoBehaviour 
{ 
	
   //public Texture2D imgLoad; //la imagen de para la animacion 
	private AsyncOperation LoadLevelAsync=null;
	private Vector2 pivotPoint; //Pto de refencia para la animacion de la imagen(depende del tamaño de la imagen) 
	private float rotAngle = 0;
	private bool cargar=false;

	public float fadeSpeed = 1.5f; 
	public GUITexture _CARGANDO;
	public GUITexture _PRESIONE_ENTER;



	void Start() 
	{ 
		_CARGANDO.enabled = true;
		StartCoroutine(LoadLevel(2));
	}


	void Update ()
	{
			
		if (LoadLevelAsync != null) 
		{
			if (LoadLevelAsync.progress>=0.9F) 
			{
				_CARGANDO.enabled=false;
				_PRESIONE_ENTER.enabled=true;
			}

		}



		if (Input.GetKeyDown (KeyCode.Return)) 
			cargar=true;

		if(cargar)
			EndScene();
	
		if (cargar && guiTexture.color.a >= 0.95f)
			LoadLevelAsync.allowSceneActivation = true;

		print (guiTexture.color.a);

	}

	IEnumerator LoadLevel(int level) 
	{ 
	  LoadLevelAsync = Application.LoadLevelAsync(level); 
	  LoadLevelAsync.allowSceneActivation =false;
		yield return LoadLevelAsync; 
	} 
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
	}
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
}