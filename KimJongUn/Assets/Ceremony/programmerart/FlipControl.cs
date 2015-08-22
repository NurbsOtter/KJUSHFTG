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
	public Texture2D propaganda; 
	int flipX = 0;
	public float flipDelay = 0.25f;
	float sinceFlip = 0.0f;
	public bool flipping = false;
	public Texture2D loadImage(string inImage){
		Texture2D newImg = null;
		byte[] inBytes;
		if (File.Exists (inImage)) {
			inBytes = File.ReadAllBytes (inImage);
			newImg = new Texture2D (400, 400);
			newImg.LoadImage (inBytes);
		} else {
			Debug.Log("Not found!");
		}
		return newImg;
	}
	public Texture2D cutImage(int inX,int inY){
		Texture2D outTex = new Texture2D (40, 40);
		outTex.SetPixels(0,0,40,40,propaganda.GetPixels (inX * 40, inY * 40, 40, 40));
		return outTex;
	}
	public void changeImage(string inNewImage){
		propaganda = loadImage (inNewImage);
	}


	// Use this for initialization
	void Start () {
		propaganda = loadImage (Application.dataPath+ "/Ceremony/programmerart/gloriousleader.png");
		flippers = new GameObject[x,y];
		for (int i = 0; i < x; i++) {
			for (int i2 = 0; i2 < y; i2++){
				flippers[i,i2] = (GameObject)Instantiate(sign,new Vector3(i,i2,0.0f),Quaternion.identity);
				flippers[i,i2].GetComponent<SpriteRenderer>().sprite = Sprite.Create(cutImage(i,i2),new Rect(0,0,40,40),new Vector2(0.5f,0.5f));
				flippers[i,i2].transform.localScale = new Vector3(2.5f,2.5f,0.0f);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (flipping) {
			if (sinceFlip > flipDelay){
				if (flipX < 10){ //Do another one!
					for (int i = 0; i < 10;i++){
						flippers[flipX,i].SendMessage("FlipCard");
					}
					flipX++;
					sinceFlip = 0.0f;
				}else{
					flipping = false;
					sinceFlip = 0.0f;
				}
			}else{
				sinceFlip += Time.deltaTime;
			}
		}
	}
}
