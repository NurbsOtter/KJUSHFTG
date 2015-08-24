﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FactoryScript : MonoBehaviour {
	private int cakeDollars = 0;
	public GameObject dropPoint;
	public GameObject cakeSeed;
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
	void buttonPush(int butNo){
		if (butNo == 0){
			if (cakeDollars > 0){
				cakeDollars--;
				for (int i =0; i < 5;i++){
					Instantiate(cakeSeed,dropPoint.transform.position,Quaternion.identity);
				}
			}
		}
	}
}
