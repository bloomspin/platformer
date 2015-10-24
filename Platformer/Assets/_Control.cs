using UnityEngine;
using System;
using System.Collections;




public class _Control : MonoBehaviour {
	public GameObject GameMaster;
	Controller MainScript;
	Rigidbody2D hitbox;
	float currentHeight;
	float maxSpeed = 8.0f;
	float jumpHeight = 8.0f;

	public bool jumping = false;
	public bool Frozen = false;
	public bool facingRight = true;

	// Use this for initialization
	void Start () {
		MainScript = GameMaster.GetComponent <Controller>();
		hitbox = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Frozen) {

			if (MainScript.JUMP) {
				if (!jumping) {
					jumping = true;

					jumpHeight = 12.0f;

					var x = hitbox.velocity.x;
					hitbox.velocity = new Vector2(x, jumpHeight);
				}			
			}

			if (MainScript.RIGHT) {
				//Flip direction of player		
				Flip (true);

				//hitbox.AddForce (new Vector2 (12, 0));

				if (!jumping || (jumping && facingRight)){
					if(hitbox.velocity.x< maxSpeed){
						hitbox.velocity = new Vector2(10f, hitbox.velocity.y);
					}
				}
				//hitbox.velocity = Vector3.ClampMagnitude(hitbox.velocity, maxSpeed);				
			}

			if (MainScript.LEFT) {
				//Flip direction of player
				Flip (false);

				if (!jumping || (jumping && !facingRight)){
					if(hitbox.velocity.x> -maxSpeed){
						hitbox.velocity = new Vector2(-10f, hitbox.velocity.y);
					}
				}
				//hitbox.velocity = Vector3.ClampMagnitude (hitbox.velocity, maxSpeed);				
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		string tag = collision.collider.gameObject.tag;
		if (tag.ToLower () == "") {
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			jumping = false;
			maxSpeed = 8.0f;
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			jumping = false;
			maxSpeed = 8.0f;
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
