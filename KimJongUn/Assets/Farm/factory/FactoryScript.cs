using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FactoryScript : MonoBehaviour {
	private int cakeDollars = 0;
	public Text sign;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ateCake(){
		cakeDollars++;
		sign.text = "" + cakeDollars;
	}
}
