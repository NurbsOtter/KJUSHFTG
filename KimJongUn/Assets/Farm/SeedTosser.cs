using UnityEngine;
using System.Collections;

public class SeedTosser : MonoBehaviour {
	public GameObject[] seeds;
	private int curSeed = 0;
	public Quaternion cakeRot;
	public Collider player;
	public GameObject canvas;
	// Use this for initialization
	void Start () {
		cakeRot = Quaternion.Euler (new Vector3 (-90.0f, 0.0f, 0.0f));
		canvas = GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			curSeed = 0;
			canvas.SendMessage("setWeapon",0,SendMessageOptions.RequireReceiver);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			curSeed = 1;
			canvas.SendMessage("setWeapon",1,SendMessageOptions.RequireReceiver);
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Vector3 newPos = transform.position + transform.forward * 1.5f;
			GameObject newSeed = (GameObject)Instantiate(seeds[curSeed],newPos,cakeRot);
			Rigidbody seedPhys = newSeed.GetComponent<Rigidbody>();
			seedPhys.AddForce(transform.forward * 50.0f);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,5.0f)){
				hit.collider.SendMessage("nomnom",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
