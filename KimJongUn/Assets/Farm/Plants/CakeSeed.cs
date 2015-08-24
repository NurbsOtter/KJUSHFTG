using UnityEngine;
using System.Collections;

public class CakeSeed : MonoBehaviour {
	private float timeGrowing = 0.0f;
	public GameObject cake;
	public float growthTime=300.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeGrowing < growthTime) {
			timeGrowing += Time.deltaTime;
			this.transform.localScale = (0.25f + ((timeGrowing / growthTime) * .75f)) * new Vector3 (0.0f, 0.0f, 1.0f);
			Vector3 cakeTransform = new Vector3(.25f,.25f,1.0f);
			cakeTransform.z -= timeGrowing / growthTime;
			this.transform.localScale = cakeTransform;
		} else {
			GameObject newCake = (GameObject)Instantiate(cake,this.transform.position,this.transform.rotation);
			newCake.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f,Random.Range(30.0f,100.0f),0.0f));
			Physics.IgnoreCollision(this.GetComponent<Collider>(),newCake.GetComponent<Collider>());
			Destroy(this.gameObject);
		}
	}
}
