using UnityEngine;
using System.Collections;

public class GoLeft : MonoBehaviour {
    public baby_kim kim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (kim.gameObject.activeSelf) {
            Vector3 pos = transform.position;
            pos.x += kim.xvel * Time.deltaTime;
            transform.position = pos;
            if (transform.position.x < -5) {
                Destroy(gameObject);
            }
        }
	}
}
