using UnityEngine;
using System.Collections;

public class RadiationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		col.gameObject.SendMessage ("deactivateSeed",SendMessageOptions.DontRequireReceiver);
	}
}
