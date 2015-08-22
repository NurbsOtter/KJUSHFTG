using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

    public baby_kim kim;
    public float factor = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += kim.xvel * Time.deltaTime * factor;
        if (pos.x < -9.6f) {
            pos.x += 12.8f;
		}
        transform.position = pos;
	}
}
