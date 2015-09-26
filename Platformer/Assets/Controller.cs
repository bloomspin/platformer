using UnityEngine;
using System.Collections;

[SerializePrivateVariables]
public class Controller : MonoBehaviour {
	public bool UP = false;
	public bool DOWN = false;
	public bool LEFT = false;
	public bool RIGHT = false;
	public bool JUMP = false;

	void Awake() {
		DontDestroyOnLoad (this);
	}

	void Update(){
		if (Input.GetKeyDown ("up")) {
			UP = true;
		}
		if (Input.GetKeyUp ("up")) {
			UP = false;
		}
		if (Input.GetKeyDown ("down")) {
			DOWN = true;
		}
		if (Input.GetKeyUp ("down")) {
			DOWN = false;
		}
		if (Input.GetKeyDown ("left")) {
			LEFT = true;
		}
		if (Input.GetKeyUp ("left")) {
			LEFT = false;
		}
		if (Input.GetKeyDown ("right")) {
			RIGHT = true;
		}
		if (Input.GetKeyUp ("right")) {
			RIGHT = false;
		}
		if (Input.GetKeyDown ("space")) {
			JUMP = true;
		}
		if (Input.GetKeyUp ("space")) {
			JUMP = false;
		}
	}
}
