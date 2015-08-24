using UnityEngine;
using System.Collections;

public class TurretBrain : MonoBehaviour {
	public GameObject rotPoint;
	public Transform turretTrans;
	private GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target == null || target.Equals (null)) {
			turretTrans.Rotate (new Vector3 (0.0f, 0.0f, 1.0f));
			RaycastHit hit;
			Debug.DrawRay (turretTrans.position, turretTrans.up);
			if (Physics.Raycast (turretTrans.position, turretTrans.up, out hit, 30.0f)) {
				if (hit.collider.CompareTag ("baddude")) {
					target = hit.collider.gameObject;
				}
				
			}
		}

	}
}
