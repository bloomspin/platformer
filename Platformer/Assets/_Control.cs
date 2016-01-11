using UnityEngine;
using System;
using System.Collections;

public class _Control : MonoBehaviour {
	public GameObject GameMaster;
	public GameObject back;
	public GameObject front;

	SubCollider leftCollider;
	SubCollider frontCollider;

	Controller MainScript;
	Rigidbody2D hitbox;
	float currentHeight;
	float maxSpeed = 8.0f;
	float jumpHeight = 700.0f;

	public bool jumping = false;
	public bool Frozen = false;
	public bool facingRight = true;
	public bool feetCollide = false;

	// Use this for initialization
	void Start () {
		MainScript = GameMaster.GetComponent <Controller>();
		hitbox = this.GetComponent<Rigidbody2D> ();

		leftCollider = back.GetComponent<SubCollider> ();
		frontCollider = front.GetComponent<SubCollider> ();
	}

    // Update is called once per frame
    void Update()
    {

    }

	// Fixed Update is called once per physics frame
    void FixedUpdate()
    {
		if (Frozen)
			return;
		float move_h = Input.GetAxis ("Horizontal");
		if (hitbox.velocity.normalized.y == 0) {
			jumping = false;
		}


		if (MainScript.JUMP) {
			if (!jumping) {
				jumping = true;                
				var x = hitbox.velocity.x;
				//hitbox.velocity = new Vector2(x, move_v * jumpHeight);
				hitbox.AddForce (new Vector2 (0, jumpHeight));
				Debug.Log("FIRED");
			}
		}

		if (MainScript.RIGHT) {
			//Flip direction of player		
			Flip (true);
			if (!frontCollider.Colliding){
				if (!jumping || (jumping && facingRight)) {
					if (hitbox.velocity.x < maxSpeed) {
						hitbox.velocity = new Vector2 (move_h * maxSpeed, hitbox.velocity.y);
					}
				}            
			}
		}

		if (MainScript.LEFT) {
			//Flip direction of player
			Flip (false);

			if (!frontCollider.Colliding){
				if (!jumping || (jumping && !facingRight)) {
					if (hitbox.velocity.x > -maxSpeed) {
						hitbox.velocity = new Vector2 ((move_h * maxSpeed), hitbox.velocity.y);
					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			feetCollide = true;
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			feetCollide = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			feetCollide = false;
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
