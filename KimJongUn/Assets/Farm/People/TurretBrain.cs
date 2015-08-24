using UnityEngine;
using System.Collections;

public class TurretBrain : MonoBehaviour {
	public Transform turretTrans;
	private GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target == null || target.Equals (null)) {
			turretTrans.Rotate (new Vector3 (0.0f, 1.0f, 0.0f));
			RaycastHit hit;
			Debug.DrawRay (turretTrans.position + new Vector3(0.0f,1.0f,0.0f), turretTrans.forward);
			if (Physics.Raycast (turretTrans.position + new Vector3(0.0f,1.0f,0.0f), turretTrans.forward, out hit, 30.0f)) {
				if (hit.collider.CompareTag ("baddude")) {
					target = hit.collider.gameObject;
				}				
			}
		} else {
			turretTrans.LookAt(target.transform.position);
		}

	}
}
