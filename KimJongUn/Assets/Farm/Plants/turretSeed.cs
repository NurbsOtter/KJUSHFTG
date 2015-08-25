using UnityEngine;
using System.Collections;

public class turretSeed : MonoBehaviour {
	public GameObject turret;
	public bool allowedGrow = false;
	public float timeLeft = 250.0f;
	public Vector3 scaleFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (allowedGrow) {
			if (timeLeft <= 0.0f){
				Instantiate(turret,this.transform.position,Quaternion.Euler(0.0f,0.0f,0.0f));
				Destroy(this.gameObject);
			}else{
				timeLeft -= Time.deltaTime;
				this.transform.localScale += scaleFactor * Time.deltaTime;
			}
		}	
	}
	void activateSeed(){
		allowedGrow = true;
	}
	void deactivateSeed(){
		allowedGrow = false;
	}
	void nomnom(){
		Destroy (this.gameObject);
	}
}
