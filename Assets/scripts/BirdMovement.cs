using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	Animator animator;

	bool didFlap= false;
	float deathCooldown = 1f;
	public bool dead = false;

	public bool godModd = true;

	public float forwardSpeed = 10f;
	public float flapSpeed = 90f;


	//public Vector3 gravity;
	//public Vector3 flapVelocity;
	//public float maxSpeed = 2f;
	//public float forwardSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator> ();
		if (animator == null) {
			Debug.LogError("can not find a animator");		
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (godModd)
			return;
		animator.SetTrigger("Death");
		dead = true;
	}

	// Do Graphic & Input
	void Update() {
		if (dead) {
			deathCooldown -= Time.deltaTime;
			if( deathCooldown <0) {
				if (Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		} else {
			// get space button, tabSpace
			if (Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown (0) ||  Input.touchCount >0) {
				didFlap = true;
				animator.SetTrigger("DoFlap");
			}
		}
	}

	void FixedUpdate () {
		if (dead) {
			return;		
		}
		rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		if (didFlap) {
			didFlap = false;
			rigidbody2D.AddForce (Vector2.up * flapSpeed);
		}
		//rotoate down
		float angle = 0;
		if (rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);

		} else {
			angle = Mathf.Lerp (0, -90, -rigidbody2D.velocity.y / 3f);	
			transform.rotation = Quaternion.Euler (0, 0, angle);

		}
	}
	// Dp physics engine
	/*
	void FixedUpdate () {
		velocity.x = forwardSpeed;
		//velocity += gravity * Time.deltaTime;
		if (didFlap == true) {
			didFlap = false;
			if(velocity.y <= 0){
				velocity.y = 0;
			}
			velocity += flapVelocity;
		}
		//velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		transform.position += velocity;

		// rotoate, down
		float angle = 0;
		if (velocity.y < 0) {
			angle = Mathf.Lerp (0, -90, -velocity.y / maxSpeed);	
		}
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}*/
}
