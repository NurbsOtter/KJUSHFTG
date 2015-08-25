using UnityEngine;
using System.Collections;

public class FarmController : MonoBehaviour {
	public float rotSpeedX=1.0f;
	public float rotSpeedY=1.0f;
	public float groundedSpeed = .5f;
	private Rigidbody phys;
	// Use this for initialization
	void Start () {
		phys = GetComponent<Rigidbody> ();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newRot = transform.eulerAngles;
		newRot.y += Input.GetAxis ("Mouse X") * rotSpeedX * Time.deltaTime;
		this.transform.rotation = Quaternion.Euler (newRot);
		Vector3 camRot = new Vector3 (Input.GetAxis ("Mouse Y") * rotSpeedY * Time.deltaTime, 0.0f, 0.0f);
		Camera.main.transform.Rotate (camRot);
        float speedmul = !Input.GetKey(KeyCode.LeftShift) ? 1f : 2.3f;

        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

		if (Input.GetKey (KeyCode.W)) {
			phys.AddForce(transform.forward * groundedSpeed * speedmul);
		}
		if (Input.GetKey(KeyCode.S)){
            phys.AddForce(-transform.forward * groundedSpeed * speedmul);
		}
        if (Input.GetKey(KeyCode.A)) {
            phys.AddForce(-transform.right * groundedSpeed * speedmul);
        }
        if (Input.GetKey(KeyCode.D)) {
            phys.AddForce(transform.right * groundedSpeed * speedmul);
        }
	}
}
