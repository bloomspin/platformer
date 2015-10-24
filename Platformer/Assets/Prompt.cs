using UnityEngine;
using System.Collections;

public class Prompt : MonoBehaviour {
    public bool Old = false;
    public bool IsOpen = false;
	public string Message = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Old) return;
        if (IsOpen)
        {
            Debug.Log(Message);
            GameObject.Find("Character").GetComponent<_Control>().Frozen = false;
            Old = true;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Old) return;
        var player = collision.gameObject;
        if (player.tag.ToLower() == "player")
        {
            player.GetComponent<_Control>().Frozen = true;
            IsOpen = true;
        }
    }
}
