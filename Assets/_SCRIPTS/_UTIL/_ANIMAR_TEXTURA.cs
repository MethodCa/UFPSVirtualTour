using UnityEngine;
using System.Collections;

public class _ANIMAR_TEXTURA : MonoBehaviour {
	
	public float  fadeInSpeed  = 1f;
	public float  fadeOutSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		StartCoroutine (animar());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator animar()
	{

		float t;
		while (true) {
						for (t = 0.0f; t < fadeOutSpeed; t+= Time.deltaTime) {
								Color textureColor = guiTexture.color;
								textureColor.a = Mathf.Lerp (0.7F, 0, t / fadeOutSpeed);
								guiTexture.color = textureColor;
								yield return guiTexture;
						}
						for (t = 0.0f; t < fadeInSpeed; t+= Time.deltaTime) {
								Color textureColor = guiTexture.color;
								textureColor.a = Mathf.Lerp (0, 1, (t / fadeInSpeed) - 0.3f);
								guiTexture.color = textureColor;
								yield return guiTexture;
						}
				}

	}

}
