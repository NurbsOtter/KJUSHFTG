using UnityEngine;
using System.Collections;

public class CakeStealingWhore : MonoBehaviour {
	private NavMeshAgent nav;
	public GameObject testCake;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		GameObject[] cakes = GameObject.FindGameObjectsWithTag ("cake");
		if (cakes.Length > 0) {
			testCake = cakes[Random.Range(0,cakes.Length)];
			nav.SetDestination(testCake.transform.position);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (testCake == null || testCake.Equals(null) || this.transform.position.Equals(testCake.transform.position)|| nav.pathStatus == NavMeshPathStatus.PathComplete || nav.pathStatus == NavMeshPathStatus.PathPartial){
		GameObject[] cakes = GameObject.FindGameObjectsWithTag ("cake");
		if (cakes.Length > 0) {
			testCake = cakes[Random.Range(0,cakes.Length)];
			nav.SetDestination(testCake.transform.position);
		}
	}
	
	}
	void OnCollisionEnter(Collision col){
		if (col.collider.gameObject.CompareTag("cake")) {
			col.collider.gameObject.SendMessage("nomnom");
		}

	}
}
