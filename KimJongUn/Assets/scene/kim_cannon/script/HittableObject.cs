using UnityEngine;
using System.Collections;

public class HittableObject : MonoBehaviour {

    public Sprite[] pics;
    public baby_kim kim;
    private int spindex;

	// Use this for initialization
	void Start () {
        spindex = Random.Range(0, pics.Length / 2);
        Vector3 pos = transform.position;
        pos.x = Random.Range(5f, 12f);
        pos.y = Random.Range(-1.12f, -0.7f);
        transform.position = pos;
	}

    void setBaby(baby_kim k) {
        kim = k;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += kim.xvel * Time.deltaTime;
        transform.position = pos;
        if (transform.position.x < -5) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        
        if (coll.gameObject == kim.gameObject) {
            spindex++;
            GetComponent<SpriteRenderer>().sprite = pics[spindex];
            Vector2 vel = kim.GetComponent<Rigidbody2D>().velocity;
            if (vel.y > 0) {
                vel.y = vel.y * 1.8f + 2f;
            } else {
                vel.y = -vel.y * 1.8f + 2f;
            }
            kim.xvel -= 5f;
            kim.GetComponent<Rigidbody2D>().velocity = vel;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
