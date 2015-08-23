using UnityEngine;
using System.Collections;

public class CitizenBirther : MonoBehaviour {

	// Use this for initialization
	public GameObject citizen;
	private Vector3 citizenPosition(){
		Vector3 outVect = new Vector3 ();
		outVect.x = Random.Range (-5.0f, 5.0f);
		outVect.y = Random.Range (-1.0f, 3.0f);
		return outVect;
	}
	void Start () {
		int numCitizens = Random.Range (5, 30);
		for (int i = 0; i < numCitizens; i++) {
			Instantiate(citizen,citizenPosition(),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
