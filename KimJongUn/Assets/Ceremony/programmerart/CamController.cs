using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	public float camSpeed = 1.0f;
	public float camSpeedZoomed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newMove = new Vector3 ();
		newMove.x += Input.GetAxis ("Mouse X") * camSpeed * Time.deltaTime;
		newMove.y += Input.GetAxis ("Mouse Y") * camSpeed * Time.deltaTime;
		newMove += this.transform.position;
		this.transform.position = newMove;
	}
}
