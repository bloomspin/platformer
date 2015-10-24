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

	public bool facingRight = true;

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
	
			//Flip direction of player		
			Flip(true);

			hitbox.AddForce (new Vector2 (3, 0));
			hitbox.velocity = Vector3.ClampMagnitude(hitbox.velocity, maxSpeed);

		}

		if (MainScript.LEFT) {

			//Flip direction of player
			Flip(false);

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

	void Flip(bool direction)
	{
		if (direction == facingRight) {return;}
		facingRight = direction;
		// Switch the way the player is labelled as facing
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	
	}





}
