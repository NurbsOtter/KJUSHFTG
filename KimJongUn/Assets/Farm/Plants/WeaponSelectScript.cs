using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSelectScript : MonoBehaviour {
	public Image cakeImg;
	public Image grassImg;
	// Use this for initialization
	void Start () {
		//cakeImg = GameObject.Find ("CakeIcon").GetComponent<Image>();
		//grassImg = GameObject.Find ("GrassIcon").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void setWeapon(int weapIn){
		if (weapIn == 0) {
			cakeImg.color = Color.green;
			grassImg.color = Color.white;
		}else if (weapIn == 1){
			cakeImg.color = Color.white;
			grassImg.color = Color.green;
		}
	}
}
