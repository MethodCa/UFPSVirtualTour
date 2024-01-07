using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUITexture))]
[RequireComponent (typeof (AudioSource))]

public class _VIDEO : MonoBehaviour 
{
	private GUITexture videoGUItex; 						    // Esta es la textura en la que se va a reproducir el video.
	private MovieTexture mTex; 									// Creo una nueva textura de pelicula.
	private AudioSource movieAS; 								// Aqui almacenare el audio del video.
	private System.DateTime seg_inicio= System.DateTime.Now; 	// Almaceno la hora de inicio del video para desplegar la cortinilla negra de carga.
	private string movieName="_VIDEO"; 							// Aqui almaceno el nombre del video, el video debe estar en la carpeta Resources.


	void Awake() 												// Al despertar
	{
		videoGUItex = this.GetComponent<GUITexture>(); 			// Obtengo la GUITexture adjuntada al GameObject.
		movieAS = this.GetComponent<AudioSource>(); 			// Obtengo el AudioSource adjuntado al GameObject.
		mTex = (MovieTexture)Resources.Load(movieName); 		// Cargo la MovieTexture de la carpera Resources por su nombre
		movieAS.clip = mTex.audioClip; 							// Hago dque el AdioSource clip del GameObject sea el mismo audio del Video.
		videoGUItex.pixelInset = new Rect(Screen.width/2, -Screen.height/2,0,0); // Escalo la textura en la que se cargo el video para que ocupe toda la pantalla.
	}
	
	void Start() 												// Al comenzar
	{
		videoGUItex.texture = mTex;								//Cargo la textura del video en la textura del GameObject.
		mTex.Play(); 											// Reproduzco el video.
		movieAS.Play(); 										// Reproduzco el audio.
	}

	void Update () // En cada frame.
	{
		if ((System.DateTime.Now - seg_inicio).Seconds >= 30) 	// Cuando el tiempo visible del video se acabe.
			videoGUItex.color = Color.black; 					// Despliego la cortinilla negra.

		if (!movieAS.isPlaying) 								// Cuando se acabe el video por completo. 
			Application.LoadLevel (1);							// Cargo el nuevo nivel.
	}
}
