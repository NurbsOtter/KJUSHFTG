using UnityEngine;
using System.Collections;

public class baby_kim : MonoBehaviour {

    public float xvel = 0f;
    public Sprite clothes;
    private float rotate;

	// Use this for initialization
	void Start () {
        rotate = Random.Range(2f, 6f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 80f));
	}
	
	// Update is called once per frame
    void Update() {
        xvel *= 1f - (0.18f * Time.deltaTime);
        Vector3 pos = transform.position;
        if (pos.x > 0) {
            pos.x = 0;
            Vector2 vel = GetComponent<Rigidbody2D>().velocity;
            xvel = -vel.x;
            vel.x = 0f;
            GetComponent<Rigidbody2D>().velocity = vel;
        }
        transform.position = pos;
        GetComponent<Transform>().Rotate(0f, 0f, -rotate);
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag.Equals("ground")) {
            rotate *= 0.95f;
        }
    }

    public void getSuit() {
        GetComponent<SpriteRenderer>().sprite = clothes;
    }
}
