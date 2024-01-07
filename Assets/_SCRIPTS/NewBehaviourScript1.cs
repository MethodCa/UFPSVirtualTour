using UnityEngine;
using System.Collections;
public class ProgressBar : MonoBehaviour 
{ 
	public Texture2D imgLoad; //la imagen de para la animacion 
	private AsyncOperation LoadLevelAsync; 
	private Vector2 pivotPoint; //Pto de refencia para la animacion de la imagen(depende del tamaño de la imagen)
	private float rotAngle = 0; 

	void Start() 
	{ 
		if (!imgLoad) imgLoad = Resources.Load("name_img") as Texture2D; //para asegurarme que cargue en el inspector. 
	} 

	void OnGUI() 
	{ 
		pivotPoint = new Vector2(Screen.width - 42, Screen.height - 42); 
		if(GUI.Button(new Rect(Screen.width * 0.5f,Screen.height * 0.5f,100,25),"Empezar Nivel")) 
			StartCoroutine(LoadLevel("Big_Level")); //Big_Level, Nombre de la escena a cargar. 
		if (!LoadLevelAsync.isDone) 
		{ 
			GUI.Label(new Rect(Screen.width - 150, Screen.height - 50,200,50), "Cargando " + Mathf.RoundToInt(LoadLevelAsync.progress * 100) + "..."); 
			GUIUtility.RotateAroundPivot(rotAngle,pivotPoint); GUI.DrawTexture(new Rect((Screen.width - 50), (Screen.height - 50), 16, 16), imgLoad); rotAngle += 200 * Time.deltaTime; 
		} 
	} 

	IEnumerator LoadLevel(string level) 
	{ 
		this.camera.backgroundColor = Color.black; 
		LoadLevelAsync = Application.LoadLevelAsync(level);
		yield return LoadLevelAsync; 
	} 
} 
	
