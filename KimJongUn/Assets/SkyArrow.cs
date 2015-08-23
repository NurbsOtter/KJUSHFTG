using UnityEngine;
using System.Collections;

public class SkyArrow : MonoBehaviour {

    public Transform track;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = track.position.x;
        transform.position = pos;
        if (track.position.y > transform.position.y) {
            GetComponent<SpriteRenderer>().enabled = true;
        } else {
            GetComponent<SpriteRenderer>().enabled = false;
        }
	}
}
