using UnityEngine;
using System.Collections;
using System.IO;
/// <summary>
/// GLORIOUS FLIPPER OF THE PEOPLE
/// </summary>
public class FlipControl : MonoBehaviour {
	GameObject[,] flippers;
	public GameObject sign;
	public int x, y;
	public Texture2D loadImage(string inImage){
		Texture2D newImg = null;
		byte[] inBytes;
		if (File.Exists (inImage)) {
			inBytes = File.ReadAllBytes (inImage);
			newImg = new Texture2D (640, 480);
			newImg.LoadImage (inBytes);
		} else {
			Debug.Log("Not found!");
		}
		return newImg;
	}

	// Use this for initialization
	void Start () {
		flippers = new GameObject[x,y];
		for (int i = 0; i < x; i++) {
			for (int i2 = 0; i2 < y; i2++){
				flippers[i,i2] = (GameObject)Instantiate(sign,new Vector3(i,i2,0.0f),Quaternion.identity);
			}
		}
		//loadImage (Application.dataPath+ "/Ceremony/programmerart/gloriousleader.png");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
