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
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newRot = transform.eulerAngles;
		newRot.y += Input.GetAxis ("Mouse X") * rotSpeedX * Time.deltaTime;
		this.transform.rotation = Quaternion.Euler (newRot);
		Vector3 camRot = new Vector3 (Input.GetAxis ("Mouse Y") * rotSpeedY * Time.deltaTime, 0.0f, 0.0f);
		Camera.main.transform.Rotate (camRot);
		if (Input.GetKey (KeyCode.W)) {
			phys.AddForce(transform.forward * groundedSpeed);
		}
		if (Input.GetKey(KeyCode.S)){
			phys.AddForce(-transform.forward * groundedSpeed);
		}
	}
}
