using UnityEngine;
using System.Collections;

public class WeaponizedTomato : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		col.gameObject.SendMessage ("hurt", 5,SendMessageOptions.DontRequireReceiver);
		Destroy (this.gameObject);
	}
}
