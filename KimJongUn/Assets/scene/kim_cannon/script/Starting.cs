using UnityEngine;
using System.Collections;

public class Starting : MonoBehaviour {

    public baby_kim kim;
    private float power = 800f;
    public GameObject arrow;
    private float rotate = 0f;
    private float scale = 1f;
    public AudioClip newsong;
    public GameObject sun;

    int state = 0;
    int other_state = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool trigger = Input.GetButtonDown("Fire1");
        switch (state) {
        case 0:
            Quaternion rot = arrow.transform.rotation;
            if (other_state == 0) {
                arrow.transform.Rotate(0f,0f,120f*Time.deltaTime);
                if (rot.z > (15f * Mathf.PI / 180f)) {
                    other_state = 1;
                }
            } else {
                arrow.transform.Rotate(0f, 0f, -120f * Time.deltaTime);
                if (rot.z < 0f) {
                    other_state = 0;
                }
            }
            if (trigger) {
                state++;
                rotate = rot.z;
            }
            break;

        case 1:
            if (other_state == 0) {
                scale -= 0.05f;
                if (scale < 0.5) {
                    other_state = 1;
                }
            } else {
                scale += 0.05f;
                if (scale > 1.5) {
                    other_state = 0;
                }
            }
            arrow.transform.localScale = new Vector3(scale, scale, scale);
            if (trigger) {
                state++;
            }
            break;

        case 2:
            print("go");
            launch();
            Destroy(this);
            break;
        }
	}

    private void launch() {
        kim.gameObject.SetActive(true);
        power *= scale;
        var rb = kim.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(Mathf.Cos(rotate)*power, Mathf.Sin(rotate)*power);
        rb.AddForce(force);
        Destroy(GameObject.Find("Plane"));
        Camera.main.backgroundColor = new Color(122f / 255f, 200f / 255f, 236f / 255f);
        Camera.main.GetComponent<AudioSource>().clip = newsong;
        Camera.main.GetComponent<AudioSource>().loop = true;
        Camera.main.GetComponent<AudioSource>().Play();
        sun.SetActive(true);
    }
}
