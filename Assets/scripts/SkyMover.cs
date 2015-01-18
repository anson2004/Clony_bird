using UnityEngine;
using System.Collections;

public class SkyMover : MonoBehaviour {
	Rigidbody2D player;

	public float speed = 0.01f;

	void Start () {
		GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
		if (playerGo == null) {
			Debug.LogError ("Could not find tag Player");
			return;
		} 
		player = playerGo.rigidbody2D;

	}

	void FixedUpdate(){
		float vel = player.velocity.x * 0.9f;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
		/*
		Vector3 pos = transform.position;
		pos.x += speed *Time.deltaTime;
		transform.position = pos;*/
	}
}
