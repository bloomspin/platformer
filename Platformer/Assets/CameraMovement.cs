using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
public GameObject player;

	private Vector3 offset;
	private Vector3 position;
	private Rigidbody2D hitbox; 
	private _Control playerScript; 

	// Use this for initialization
	void Start () {

		//offset = transform.position - player.transform.position ;
		position.y = transform.position.y;
		hitbox = player.GetComponent<Rigidbody2D> ();
		playerScript = player.GetComponent<_Control> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		
		//Follow Player
		// float x = player.transform.position.x;
		// float y = player.transform.position.y;

		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10);

		//x += player.transform.position.x*hitbox.velocity.x;
	
		//y = Mathf.Clamp (y, 0, 900);

		
		//transform.position = new Vector3(x, y, -1);



	}
}
