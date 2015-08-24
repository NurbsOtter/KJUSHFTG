using UnityEngine;
using System.Collections;

public class baby_kim : MonoBehaviour {

    public float xvel = 0f;
    public Sprite clothes;
    private float rotate;
    public float score = 0;
    public GameObject canvas;
    private float spawnTime;
    private float spawnDelay = 1f;
    public GameObject target_prefab;
    private bool canControl = false;
    private bool done = false;

	// Use this for initialization
	void Start () {
        rotate = Random.Range(2f, 6f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 80f));
        spawnTime = Time.time + spawnDelay;
	}
	
	// Update is called once per frame
    void Update() {
        if (done) return;
        if (xvel <= 0) {
            score += -xvel / 10f;
            canvas.SendMessage("SetScore", score);
            Vector3 pos = transform.position;
            if (!canControl && pos.x > 0) {
                canControl = true;
                pos.x = 0;
                Vector2 vel = GetComponent<Rigidbody2D>().velocity;
                xvel = -vel.x;
                vel.x = 0f;
                GetComponent<Rigidbody2D>().velocity = vel;
            }
            if (canControl) {
                float input = Input.GetAxis("Horizontal");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(input*100F * Time.deltaTime, 0));
            }

            transform.position = pos;
            GetComponent<Transform>().Rotate(0f, 0f, -rotate);
            if (spawnTime < Time.time) {
                spawnTime = Time.time + spawnDelay;
                spawnDelay += 0.1f;
                Instantiate(target_prefab).SendMessage("setBaby", this);
            }
        }

        if (xvel > -1f && canControl) {
            print("factory");
            xvel = 0f;
            GameObject.Find("factory").BroadcastMessage("FactoryAnimate");
            done = true;
        }

	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag.Equals("ground")) {
            rotate *= 0.95f;
            float slowFactor;
            if (xvel > -3f) {
                slowFactor = 0.5f;
            } else {
                slowFactor = 0.2f;
            }
            xvel *= 1f - (slowFactor);
            GetComponent<AudioSource>().Play();
        }
    }

    public void getSuit() {
        GetComponent<SpriteRenderer>().sprite = clothes;
    }
}
