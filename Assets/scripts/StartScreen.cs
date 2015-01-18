using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	static bool sawOnce = false;
	// Use this for initialization
	void Start () {
		if (!sawOnce) {
			GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 00 && (Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			Time.timeScale = 1;
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
