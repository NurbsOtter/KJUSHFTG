using UnityEngine;
using System.Collections;

public class GrassSeed : MonoBehaviour {
	public GameObject grass;
	public int numGrasses = 5;
	public float grassTime = 5.0f;
	private float timeToGrass = 0.0f;
	private Collider myCol;
	// Use this for initialization
	void Start () {
		myCol = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToGrass >= grassTime) {
			GameObject newGrass = (GameObject)Instantiate (grass, this.transform.position, Quaternion.Euler(new Vector3(-90.0f,0.0f,0.0f)));
			Physics.IgnoreCollision (myCol, newGrass.GetComponent<Collider> ());
			newGrass.GetComponent<Rigidbody> ().AddForce (Vector3.up * Random.Range (150.0f, 300.0f));
			numGrasses -= 1;
			timeToGrass = 0.0f;
		} else {
			timeToGrass += Time.deltaTime;
		}
		if (numGrasses <= 0){
			Destroy(this.gameObject);
		}
	}
}
