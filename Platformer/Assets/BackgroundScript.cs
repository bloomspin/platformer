using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundScript : MonoBehaviour {
	public GameObject player;
	public List<Layer> Layers = new List<Layer>();
	public float progress = 0.0f;
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {	
	}
}

[System.Serializable]
public class Layer{
	public GameObject layerObject;
	public Transform startPos;
	public Transform endPos;
	public float Distance;
}
