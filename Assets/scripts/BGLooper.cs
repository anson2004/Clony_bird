using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 6;

	public float pipeMax = 0.84f;
	public float pipeMin = -0.9f;

	void Start(){
		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

		foreach (GameObject pipe in pipes) {
			Vector3 pos = pipe.transform.position;
			pos.y =	Random.Range(pipeMin,pipeMax);
			pipe.transform.position = pos;

		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log ("Trigger " + collider.name);
		float widthOfGBObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x += widthOfGBObject * numBGPanels - widthOfGBObject / 2;
		if (collider.tag == "Pipe") {
			pos.y =	Random.Range(pipeMin,pipeMax);
		}
		collider.transform.position = pos;


	}
}
