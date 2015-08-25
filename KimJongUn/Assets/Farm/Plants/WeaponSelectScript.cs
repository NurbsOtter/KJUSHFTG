using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSelectScript : MonoBehaviour {
	public Image cakeImg;
	public Image grassImg;
	public Image turretImg;
	// Use this for initialization
	void Start () {
		//cakeImg = GameObject.Find ("CakeIcon").GetComponent<Image>();
		//grassImg = GameObject.Find ("GrassIcon").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void setWeapon(int weapIn){
		grassImg.color = Color.white;
		cakeImg.color = Color.white;
		turretImg.color = Color.white;
		if (weapIn == 0) {
			cakeImg.color = Color.green;
		} else if (weapIn == 1) {
			grassImg.color = Color.green;
		} else if (weapIn == 2) {
			turretImg.color = Color.green;
		}
	}
}
