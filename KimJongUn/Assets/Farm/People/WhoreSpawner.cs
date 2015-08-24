using UnityEngine;
using System.Collections;

public class WhoreSpawner : MonoBehaviour {
	private float timeSince = 0.0f;
	private int whoreWave = 0;
	public GameObject whore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeSince >= 120.0f) {
			whoreWave++;
			timeSince = 0.0f;
			int numWhores = Mathf.FloorToInt (Mathf.Pow ((float)whoreWave, 1.5f) / 2) + 1;
			for (int i = 0; i < numWhores; i++) {
				Instantiate (whore, new Vector3 (Random.Range (50.0f, 420.0f), 1.0f, Random.Range (50.0f, 420.0f)), Quaternion.Euler (0.0f, 0.0f, 0.0f));
			}
		} else {
			timeSince += Time.deltaTime;
		}
	}
}
