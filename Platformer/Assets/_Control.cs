using UnityEngine;
using System;
using System.Collections;

public class _Control : MonoBehaviour {
	public GameObject GameMaster;
	Controller MainScript;
	Rigidbody2D hitbox;
	DateTime jumpStart = DateTime.Now;
	float maxSpeed = 4.0f;
	public bool jumping = false;

	// Use this for initialization
	void Start () {
		MainScript = GameMaster.GetComponent <Controller>();
		hitbox = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (MainScript.JUMP) {
			if (!jumping) {
				jumpStart = DateTime.Now;
				jumping = true;
			}

			DateTime now = DateTime.Now;
			TimeSpan diff = now - jumpStart;

			if (diff.TotalMilliseconds < 100) {
				hitbox.AddForce (new Vector2 (0, 30));
			}
		}

		if (MainScript.RIGHT) {
	
			hitbox.AddForce (new Vector2 (3, 0));
			if (this.gameObject.transform.rotation.y != 0){
			this.gameObject.transform.Rotate(new Vector3(0,180,0));
			}

			hitbox.velocity = Vector3.ClampMagnitude(hitbox.velocity, maxSpeed);

		}

		if (MainScript.LEFT) {
			if (this.gameObject.transform.rotation.y != 180){
			this.gameObject.transform.Rotate(new Vector3(0,180,0));
			}
			hitbox.AddForce (new Vector2 (-3, 0));
			
			hitbox.velocity = Vector3.ClampMagnitude(hitbox.velocity, maxSpeed);
			
		}



	}

	void OnCollisionEnter2D(Collision2D collision) {
		string tag = collision.collider.gameObject.tag;
		if (tag.ToLower () == "ground") {
			jumping = false;
		}
	}
}
