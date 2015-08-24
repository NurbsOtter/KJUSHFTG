using UnityEngine;
using System.Collections;

public class CakeScript : MonoBehaviour {
	public GameObject crumps;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void nomnom(){
		Instantiate (crumps, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);

	}
}
