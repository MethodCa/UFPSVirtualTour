using UnityEngine;
using System.Collections;

public class reproducirHimno : MonoBehaviour {

	public AudioSource bgMusic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		StartCoroutine(musica_fadeOut (bgMusic));
		audio.Play ();
	}
	void OnTriggerExit(Collider other)
	{
		StartCoroutine(musica_fadeOut (audio));
		StartCoroutine(musica_fadeIn (bgMusic));
	}

	IEnumerator musica_fadeOut(AudioSource musica)
	{

		float t;
		for (t = 1; t >= 0; t-= Time.deltaTime) {
			yield return musica.volume=t;
		}
		musica.Stop();
		musica.volume=1;
	}
	IEnumerator musica_fadeIn(AudioSource musica)
	{
		musica.enabled = false;
		musica.enabled = true;
		float t;
		musica.Play();
		musica.volume=0;
		for (t = 0; t <= 1; t+= Time.deltaTime) {
			yield return musica.volume=t;
		}

	}

}
