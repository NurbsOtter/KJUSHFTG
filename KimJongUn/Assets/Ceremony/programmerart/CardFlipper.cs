using UnityEngine;
using System.Collections;
public interface ICardFlip: UnityEngine.EventSystems.IEventSystemHandler{
	void FlipCardNoSwap();
}

public class CardFlipper : MonoBehaviour, ICardFlip {
	SpriteRenderer mySprite;
	public float flipTime = 1.0f;
	public float timeSinceFlip = 0.0f;
	public bool flipping = true;
	public bool colorSwapped = false;
	Texture2D newFlip;
	public bool allowedFlip = true;
	public GameObject associatedDude;
	public Color newColor;
	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
	}
	// Update is called once per frame
	void Update () {
		if (flipping && allowedFlip) {
			if (timeSinceFlip <= flipTime) {
				Vector3 newRot = this.transform.rotation.eulerAngles;
				newRot.x = (timeSinceFlip/flipTime) * 180.0f;
				newRot.y = 0.0f;
				newRot.z = 0.0f;
				this.transform.rotation = Quaternion.Euler(newRot);
				//Debug.Log(timeSinceFlip / flipTime);
				if ((timeSinceFlip/flipTime) > .5f && !colorSwapped){
					if (newFlip != null){
						mySprite.sprite = Sprite.Create(newFlip,new Rect(0,0,40,40),new Vector2(0.5f,0.5f));
						newFlip = null;
					}
					colorSwapped = true;
				}
				timeSinceFlip += Time.deltaTime;

			}else{
				timeSinceFlip = 0.0f;
				flipping = false;
				colorSwapped = false;
				this.transform.rotation = Quaternion.Euler(Vector3.zero);//Shhh. Nobody will know.
			}
		}
	}
	public void FlipCardNoSwap(){
		flipping = true;
	}
	public void SwapImage(Texture2D flipTo){
		flipping = true;
		newFlip = flipTo;
	}
	public void stopFlip(){
		allowedFlip = false;
	}
	public void SetDude(GameObject dudeIn){
		associatedDude = dudeIn;
	}
}
