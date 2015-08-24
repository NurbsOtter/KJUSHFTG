using UnityEngine;
using System.Collections;

public class GrassController : MonoBehaviour {
	private Collider myCol;
	private int stepped = 5;
	// Use this for initialization
	void Start () {
		myCol = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (stepped <= 0) {
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("baddude")){
			col.gameObject.SendMessage("hurt",5);
			stepped--;
			Physics.IgnoreCollision(myCol,col.gameObject.GetComponent<Collider>());
		}
		if (col.gameObject.CompareTag ("player")) {
			stepped--;
			Physics.IgnoreCollision(myCol,col.gameObject.GetComponent<Collider>());
		}
	}
}
