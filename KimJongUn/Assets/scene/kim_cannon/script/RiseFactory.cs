using UnityEngine;
using System.Collections;

public class RiseFactory : MonoBehaviour {
    public Transform target;
    bool animating = false;
    public GameObject canvas;
    public GameObject cont;
    private float time;
    private float time2;

    void FactoryAnimate() {
        animating = true;
        time = Time.time + 4f;
        time2 = Time.time + 6f;
    }

    void Update() {
        if (animating) {
            transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime);
            if (Time.time > time) {
                canvas.SetActive(true);
                time = float.MaxValue;
            }
            if (Time.time > time2) {
                cont.SetActive(true);
                time2 = float.MaxValue;
            }
        }
    }
}
