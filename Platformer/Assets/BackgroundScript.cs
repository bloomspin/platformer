using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundScript : MonoBehaviour {
	public GameObject player;
	public List<Layer> Layers = new List<Layer>();
	public float progress = 0.0f;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		foreach (Layer x in Layers) {
			x.startPos = x.layerObject.transform;
			if (x.endPos != null) {
				x.Distance = Vector3.Distance(x.startPos.position, x.endPos.position);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Controller> ().RIGHT) {
			progress += 0.005f / 100.0f;
		}

		foreach (Layer x in Layers) {
			if (x.endPos != null){
				float distCovered = (Time.time - startTime) * progress;
				float fractJourney = distCovered / x.Distance;
				x.layerObject.transform.position = Vector3.Lerp(x.startPos.position, x.endPos.position, fractJourney);				
			}
		}
	}
}

[System.Serializable]
public class Layer{
	public GameObject layerObject;
	public Transform startPos;
	public Transform endPos;
	public float Distance;
}
