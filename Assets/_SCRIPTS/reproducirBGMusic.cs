using UnityEngine;
using System.Collections;

public class reproducirBGMusic: MonoBehaviour {

	private static reproducirBGMusic instance = null;

	public static reproducirBGMusic Instance {
		get { return instance; }
	}


	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
