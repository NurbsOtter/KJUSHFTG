using UnityEngine;
using System.Collections;

public class GetSuit : MonoBehaviour {
    public baby_kim kim;
    private float time;
    private int state = 0;

	// Use this for initialization
	void Start () {
        time = Time.time + 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > time) {
            time = Time.time + 0.3f;
            if (state == 0) {
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                state++;
            } else {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                state--;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        kim.getSuit();
        Destroy(gameObject);
    }
}
