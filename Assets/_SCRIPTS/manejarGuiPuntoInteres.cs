using UnityEngine;
using System.Collections;

public class manejarGuiPuntoInteres : MonoBehaviour
{
	//GameObjects publicos
	public GUITexture _GUI_TITULO;
	public GUITexture _GUI_ENTRAR;
	public GUITexture _GUI_SALIR;
	public GUITexture _GUI_EVENTOS;
	[SerializeField]
	MouseLook mouseLookFirstPersonController;
	[SerializeField]
	MouseLook mouseLookMainCamera;
	[SerializeField]
	CharacterController characterController;
	public string id;
	private string info_dir = "localhost/ufps/php/buscarSitioUnity.php?id="; // Direccion del servidor que entregara la informacion del punto de interes.
	private string eventos_dir = "localhost/ufps/php/buscarEventoUnity.php?lugar=";// Direccion del servidor que entregara los eventos del punto de interes.


	private Vector2 barraDezplazamiento_info; // Esta variable permite dar posicion al la barra de desplazamiento.
	private Vector2 barraDezplazamiento_eventos; // Esta variable permite dar posicion al la barra de desplazamiento.
	string info;
	string eventos;


	// Variables publicas
	float  fadeInSpeed  = 1f;
	float  fadeOutSpeed = 0.5f;
	bool   show=false;
	bool   entro=false;

	void Start()
	{
		/* Este metodo se ejectuca cada vez se inicializa el collider, o cada vez este esta en uso.
		 * Muestro el cursor.
		 * Organizo todo los GUI layouts que tenga para utilizar.
		 * _GUI_TITULO -> es una textura que muestra el titulo del punto de interés, esta textura es unica para cada punto de interes.
		 * _GUI_ENTRAR -> es una textura de ayuda que muestra la opcion de teclado y controlador para acceder al menu de eventos del punto de interes.
		 * _GUI_SALIR  -> es una textura de ayuda que muestra la opcion de teclado y controlador para salir del menu de eventos del punto de interes.
		 * _GUI_EVENTOS-> es una textura utilizada como contenedor de los eventos e información de los puntos de interes.
		 * */
		 Screen.showCursor = false;// Escondo el cursor, lo mostrare cuando sea necesario.
		 _GUI_TITULO.pixelInset = new Rect(-Screen.width/2+15, -Screen.height/2+15 , 512, 128);// Seteo la posicion inicial de esta textura GUI.
		 _GUI_ENTRAR.pixelInset = new Rect(Screen.width/2-370, -Screen.height/2 , 256, 128);// Seteo la posicion inicial de esta textura GUI.
		 _GUI_SALIR.pixelInset = new Rect(Screen.width/2-370, -Screen.height/2 , 256, 128);// Seteo la posicion inicial de esta textura GUI.
		 _GUI_EVENTOS.pixelInset = new Rect(Screen.width/2, -(Screen.height/2 + 2048 - Screen.height) , 512, 2048);// Seteo la posicion inicial de esta textura GUI.
	}

	void OnGUI()
	{
		if (show) 
		{
			StartCoroutine (cargarEventos ());// Cargo la informacion que necesito del servidor.
			Font fuente = (Font)Resources.Load ("Myriad", typeof(Font)); // Aqui cargare la fuente que se utilizara.
		
			GUIStyle estilo = new GUIStyle (); // Creo un estilo al cual le aplicare diferentes valores para asi mostrar los textos en texto enriquecido.
			estilo.richText = true; // Activo la capacidad de texto enriquecido para este estilo.
			estilo.font = fuente; // Agrego la fuente cargada al estilo.
			estilo.fixedWidth = 430;// Doy un tamaño maximo para el texto a mostrar.
			estilo.wordWrap = true;// Activamos wordwarp el cual organiza el texto segun el tamaño en x dividiendo las palabras por su espacio.

			GUIStyle estilo_titulo = new GUIStyle (); // Creo un estilo al cual le aplicare diferentes valores para asi mostrar los textos en texto enriquecido.
			estilo_titulo.richText = true; // Activo la capacidad de texto enriquecido para este estilo.
			estilo_titulo.font = fuente; // Agrego la fuente cargada al estilo.
			estilo_titulo.fixedWidth = 430;// Doy un tamaño maximo para el texto a mostrar.
			estilo_titulo.wordWrap = true;// Activamos wordwarp el cual organiza el texto segun el tamaño en x dividiendo las palabras por su espacio.
			estilo_titulo.fontSize=25;



			//Creo el textarea para la info
			GUILayout.BeginArea (new Rect (Screen.width - 470, 170, 450, 250));// Para crear el TextArea en una posicion en concreto utilizamos BeginArea y le enviamos un nuevo Rect el cual tiene la informacion de posicion y tamaño.
			barraDezplazamiento_info = GUILayout.BeginScrollView (barraDezplazamiento_info, GUILayout.Width (450), GUILayout.Height (250)); // Creamos una zona con barras dezplazadoras.
			//GUILayout.Label (info, estilo); // Agregamos a la zona de barras dezplazadoras un label que contendar la informcion a mostrar.
			GUILayout.Label(info, estilo);
			float altoTitulo= estilo.CalcHeight(new GUIContent(info), 450);
            GUILayout.EndScrollView (); // Termino la zona de barras dezplazadoras.
			GUILayout.EndArea(); // termino la zona de dibujado.

			GUILayout.BeginArea (new Rect (Screen.width - 470, 190 + altoTitulo, 450, 20));// Para crear el TextArea en una posicion en concreto utilizamos BeginArea y le enviamos un nuevo Rect el cual tiene la informacion de posicion y tamaño.
			GUILayout.Label("Eventos", estilo_titulo);
			GUILayout.EndArea(); // termino la zona de dibujado.

			//Creo el textarea para los eventos
			GUILayout.BeginArea (new Rect (Screen.width - 470, 230 + altoTitulo, 450, Screen.height-(230+altoTitulo)));// Para crear el TextArea en una posicion en concreto utilizamos BeginArea y le enviamos un nuevo Rect el cual tiene la informacion de posicion y tamaño.
			barraDezplazamiento_eventos = GUILayout.BeginScrollView (barraDezplazamiento_eventos, GUILayout.Width (450), GUILayout.Height (Screen.height-(230+altoTitulo)-150)); // Creamos una zona con barras dezplazadoras.
			GUILayout.Label (eventos, estilo); // Agregamos a la zona de barras dezplazadoras un label que contendar la informcion a mostrar.
			GUILayout.EndScrollView (); // Termino la zona de barras dezplazadoras.
			GUILayout.EndArea (); // termino la zona de dibujado.
		}
	}

	
	IEnumerator cargarEventos()
	{
		WWW cargar = new WWW(info_dir+id);
		yield return cargar;
		
		if (cargar.error == null)
			info = cargar.text;	

		cargar = new WWW(eventos_dir+id);
		yield return cargar;
		
		if (cargar.error == null)
			eventos = cargar.text;	
		
	}

	void OnTriggerEnter(Collider other)
	{
		entro = true;
		StartCoroutine(fadeIn_GUI_ENTRAR());
		_GUI_ENTRAR.enabled = true;
		StartCoroutine(fadeIn_TITULO());
		_GUI_TITULO.enabled = true;

	}

	void OnTriggerExit(Collider other)
	{
		entro = false;
		StartCoroutine(fadeOut_TITULO());
		StartCoroutine(fadeOut_GUI_ENTRAR());

		if (show) {
			StartCoroutine (hideBySide());// Escondo la _GUI_EVENTOS de drecha a izquierda.
			show = false;// variable para saber si _GUI_EVENTOS esta mostrandose
			mouseLookFirstPersonController.enabled = true;// Libero los movimientos del mouse.
			mouseLookMainCamera.enabled = true;// Libero los movimientos del mouse.
			Screen.showCursor = false;// Escondo el cursor, lo mostrare cuando sea necesario.
			_GUI_SALIR.enabled = false;
			StartCoroutine (fadeOut_GUI_SALIR());
			StartCoroutine (fadeOut_GUI_ENTRAR());
		}
	}

	void Update() 
	{
		if (entro) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (!show) {	
					_GUI_EVENTOS.enabled=true;// Pongo visible la _GUI_EVENTOS.
					StartCoroutine (showBySide());// Muestro la _GUI_EVENTOS de drecha a izquierda.

					mouseLookFirstPersonController.enabled = false;// Bloqueo los movimientos del mouse.
					mouseLookMainCamera.enabled = false;// Bloqueo los movimientos del mouse.
					Screen.showCursor = true;// Es necesario mostrar el cursor.

					StartCoroutine (fadeOut_TITULO());// Escondo la _GUI_TITULO.

					_GUI_SALIR.enabled = true;
				    _GUI_SALIR.transform.position = new Vector3(_GUI_SALIR.transform.position.x, _GUI_SALIR.transform.position.y, 1);
					StartCoroutine (fadeIn_GUI_SALIR());
				}
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (show) {
					StartCoroutine (hideBySide());// Escondo la _GUI_EVENTOS de drecha a izquierda.
					show = false;// variable para saber si _GUI_EVENTOS esta mostrandose
					mouseLookFirstPersonController.enabled = true;// Libero los movimientos del mouse.
					mouseLookMainCamera.enabled = true;// Libero los movimientos del mouse.
					Screen.showCursor = false;// Escondo el cursor, lo mostrare cuando sea necesario.
					StartCoroutine (fadeIn_TITULO());// Muestro la _GUI_TITULO.

					_GUI_SALIR.enabled = false;
					StartCoroutine (fadeIn_GUI_SALIR());
				}
			}
	    }
	}
	IEnumerator showBySide()
	{
		for (float t = 50f; t < _GUI_EVENTOS.pixelInset.width; t+=50) {
			_GUI_EVENTOS.pixelInset = new Rect(_GUI_EVENTOS.pixelInset.x-50, _GUI_EVENTOS.pixelInset.y , _GUI_EVENTOS.pixelInset.width, _GUI_EVENTOS.pixelInset.height);
			yield return _GUI_EVENTOS;
		}
		show = true;// variable para saber si _GUI_EVENTOS esta mostrandose
	}

	IEnumerator hideBySide()
	{
		for (float t = 50f; t < _GUI_EVENTOS.pixelInset.width; t+=50) {
			_GUI_EVENTOS.pixelInset = new Rect(_GUI_EVENTOS.pixelInset.x+50, _GUI_EVENTOS.pixelInset.y , _GUI_EVENTOS.pixelInset.width, _GUI_EVENTOS.pixelInset.height);
			yield return _GUI_EVENTOS;
		}	
	}

	IEnumerator fadeIn_TITULO()
	{
		_GUI_TITULO.enabled = true;
		float t;
		for (t = 0.0f; t < fadeInSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_TITULO.color;
			textureColor.a = Mathf.Lerp (0, 1, t / fadeInSpeed);
			_GUI_TITULO.color=textureColor;
			yield return _GUI_TITULO;
		}
	}

	IEnumerator fadeOut_TITULO()
	{
		float t;
		for (t = 0.0f; t < fadeOutSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_TITULO.color;
			textureColor.a = Mathf.Lerp (1, 0, t / fadeOutSpeed);
			_GUI_TITULO.color=textureColor;
			yield return _GUI_TITULO;
		}
		_GUI_TITULO.enabled = false;
	}

	IEnumerator fadeIn_GUI_ENTRAR()
	{
		float t;
		for (t = 0.0f; t < fadeInSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_ENTRAR.color;
			textureColor.a = Mathf.Lerp (0, 1, (t / fadeInSpeed)-0.5f);
			_GUI_ENTRAR.color = textureColor;
			yield return _GUI_ENTRAR;
		}
	}
	
	IEnumerator fadeOut_GUI_ENTRAR()
	{
		float t;
		for (t = 0.0f; t < fadeOutSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_ENTRAR.color;
			textureColor.a = Mathf.Lerp (1-0.5f, 0, (t / fadeOutSpeed));
			_GUI_ENTRAR.color=textureColor;
			yield return _GUI_ENTRAR;
		}
		_GUI_ENTRAR.enabled = false;
	}

	IEnumerator fadeIn_GUI_SALIR()
	{
		float t;
		for (t = 0.0f; t < fadeInSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_SALIR.color;
			textureColor.a = Mathf.Lerp (0, 1, (t / fadeInSpeed)-0.5f);
			_GUI_SALIR.color = textureColor;
			yield return _GUI_SALIR;
		}
			
	}
	
	IEnumerator fadeOut_GUI_SALIR()
	{
		float t;
		for (t = 0.0f; t < fadeOutSpeed; t+= Time.deltaTime) {
			Color textureColor = _GUI_SALIR.color;
			textureColor.a = Mathf.Lerp (1, 0, t / fadeOutSpeed);
			_GUI_SALIR.color=textureColor;
			yield return _GUI_SALIR;
		}
		_GUI_SALIR.enabled = false;
	}


}

