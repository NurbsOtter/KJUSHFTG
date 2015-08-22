using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public baby_kim follow;
    private bool go = false;
    private float time;
    private float time2 = -1f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (go) {
            Vector3 oldpos = transform.position;
            oldpos.z = 0f;
            Vector3 newpos = Vector3.Slerp(oldpos, follow.transform.position, 0.1f);
            if (newpos.y > oldpos.y) {
                newpos.y = oldpos.y;
            }
            if (newpos.y < 0f) {
                newpos.y = 0f;
            }
            newpos.z = -10f;
            newpos.x = 0f;
            transform.position = newpos;
        } else {
            if (follow.gameObject.activeSelf) {
                time = Time.time;
                if (time2 <= 0f) {
                    time2 = time + 0.2f;
                }
                if (time > time2) {
                    go = true;
                }
            }
        }
    }
}
