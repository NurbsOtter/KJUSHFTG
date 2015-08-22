using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject follow;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 newpos = Vector3.Slerp(transform.position, follow.transform.position, 8f);
        if (newpos.y < 0) newpos.y = 0;
        newpos.z = -10;
        transform.position = newpos;
    }
}
