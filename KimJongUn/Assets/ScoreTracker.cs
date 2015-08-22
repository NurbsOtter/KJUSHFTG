using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
	public int[] scores;
	// Use this for initialization
	void Start () {
		scores = new int[5];
		for (int i = 0; i < scores.Length;i++){
			scores[i] = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
