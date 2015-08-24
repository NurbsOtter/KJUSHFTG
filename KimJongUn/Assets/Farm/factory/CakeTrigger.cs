using UnityEngine;
using System.Collections;

public class CakeTrigger : MonoBehaviour {
	public GameObject factory;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("cake")) {
			col.gameObject.SendMessage("nomnom");
			factory.SendMessage("ateCake");
		}
	}
}
