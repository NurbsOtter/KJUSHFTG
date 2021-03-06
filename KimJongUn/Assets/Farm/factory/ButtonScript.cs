﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public int buttonNo= 0;
	public GameObject factory;
	private float timeSelected;
	private MeshRenderer mesh;
	public Text selectText;
	public string selectTextOut ="";
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeSelected >= 0.25f) {
			mesh.material.color = Color.red;
		} else {
			timeSelected += Time.deltaTime;
		}
	}
	void isSelected(){
		mesh.material.color = Color.green;
		timeSelected = 0.0f;
		selectText.text = selectTextOut;
	}
	void pushButton(){
		factory.SendMessage ("buttonPush", buttonNo);
	}
}
