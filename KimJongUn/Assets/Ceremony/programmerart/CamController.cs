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
		if (newMove.x > 6.5f) {
			newMove.x = 6.5f;
		}
		if (newMove.x < 1.5f) {
			newMove.x = 1.5f;
		}
		if (newMove.y > 8.5f){
			newMove.y = 8.5f;
		}
		if (newMove.y < 1.0f) {
			newMove.y = 1.0f;
		}
		this.transform.position = newMove;
	}
}
