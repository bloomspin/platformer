using UnityEngine;
using System;
using System.Collections;




public class _Control : MonoBehaviour {
	public GameObject GameMaster;
	Controller MainScript;
	Rigidbody2D hitbox;
	float currentHeight;
	float maxSpeed = 8.0f;
	float jumpHeight = 700.0f;

	public bool jumping = false;
	public bool Frozen = false;
	public bool facingRight = true;

	// Use this for initialization
	void Start () {
		MainScript = GameMaster.GetComponent <Controller>();
		hitbox = this.GetComponent<Rigidbody2D> ();
	}

    // Update is called once per frame
    void Update()
    {

    }

	// Fixed Update is called once per physics frame
    void FixedUpdate()
    {
        if (Frozen) return;
        float move_h = Input.GetAxis("Horizontal");        

        if (MainScript.JUMP)
        {
            if (!jumping || hitbox.velocity.y == 0)
            {
                jumping = true;                
                var x = hitbox.velocity.x;
                //hitbox.velocity = new Vector2(x, move_v * jumpHeight);
                hitbox.AddForce(new Vector2 (0, jumpHeight));
            }
        }

        if (MainScript.RIGHT)
        {
            //Flip direction of player		
            Flip(true);
            if (!jumping || (jumping && facingRight))
            {
                if (hitbox.velocity.x < maxSpeed)
                {
                    hitbox.velocity = new Vector2(move_h * maxSpeed, hitbox.velocity.y);
                }
            }            
        }

        if (MainScript.LEFT)
        {
            //Flip direction of player
            Flip(false);

            if (!jumping || (jumping && !facingRight))
            {
                if (hitbox.velocity.x > -maxSpeed)
                {
                    hitbox.velocity = new Vector2((move_h * maxSpeed), hitbox.velocity.y);
                }
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
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
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
