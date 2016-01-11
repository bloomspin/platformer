using UnityEngine;
using System.Collections;

public class SanguineAI : MonoBehaviour {
	public bool isCharacterNear = false;
	Transform playerLocation = null;
	public Transform myTransform;
	Rigidbody2D hitbox;
	public float rotationSpeed = 8f;
	public float movementSpeed = 1f;
	public float maxDefaultDistance = 20f;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
		myTransform = this.gameObject.transform;
		startPos = this.gameObject.transform.position;
		this.hitbox = this.gameObject.GetComponent<Rigidbody2D> ();
		Debug.Log (startPos.y); 
		this.hitbox.AddForce (transform.right * movementSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	} 

	void FixedUpdate(){
		if (!isCharacterNear) {
			// try to return home

		} else {
			Debug.Log ("near");
			if (playerLocation == null){
				playerLocation = GameObject.FindGameObjectWithTag ("Player").transform;
				movementSpeed = 5f;
			}
		
			Vector3 dir = playerLocation.position - myTransform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), rotationSpeed * Time.deltaTime);
		}

		Mathf.Clamp (transform.rotation.z, 0, 180);

		// Debug.Log ("blah: " + startPos.y);
		if (myTransform.position.y < startPos.y){
			this.hitbox.AddForce(transform.up * 50);
		}

	}

	void OnTriggerEnter2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "player") {
			isCharacterNear = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "player") {
			isCharacterNear = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision) {
		string tag = collision.gameObject.tag;
		if (tag.ToLower () == "player") {

		}
	}
}
