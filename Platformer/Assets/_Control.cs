using UnityEngine;
using System;
using System.Collections;

public class _Control : MonoBehaviour {
	public GameObject GameMaster;
	Controller MainScript;
	Rigidbody2D hitbox;
	DateTime jumpStart = DateTime.Now;
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
				hitbox.AddForce (new Vector2 (7, 30));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		string tag = collision.collider.gameObject.tag;
		if (tag.ToLower () == "ground") {
			jumping = false;
		}
	}
}
