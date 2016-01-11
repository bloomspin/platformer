using UnityEngine;
using System;
using System.Collections;

public class SubCollider : MonoBehaviour {
	public bool Colliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			Colliding = true;
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			Colliding = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "ground") {
			Colliding = false;
		}
	}
}
