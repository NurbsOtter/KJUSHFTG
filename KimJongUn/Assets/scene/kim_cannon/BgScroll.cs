using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

	public float speed = -0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        if (pos.x < -9.6f) {
            pos.x += 12.8f;
		}
        transform.position = pos;
	}
}
