using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	static  int score = 0;
	static 	int highScore ;
	public Text scoreText;
	// Use this for initialization
	static Score instance;
	BirdMovement bird;

	void Start () {
		instance = this;
		GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
		if (playerGo == null) {
			Debug.LogError("Can not find a bird");		
		}
		bird = playerGo.GetComponent<BirdMovement> ();
		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	static public void AddPoint(int point){
		if (instance.bird.dead)
			return;
		score += point;
		if (score > highScore) {
			highScore = score;		
		}
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt ("highScore", highScore);
	}
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
