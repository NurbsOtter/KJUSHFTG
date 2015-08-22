using UnityEngine;
using System.Collections;
public interface ICardFlip: UnityEngine.EventSystems.IEventSystemHandler{
	void FlipCard(float r, float g, float b);
}

public class CardFlipper : MonoBehaviour, ICardFlip {
	SpriteRenderer mySprite;
	public float flipTime = 1.0f;
	public float timeSinceFlip = 0.0f;
	public bool flipping = true;
	public bool colorSwapped = false;
	public Color newColor;
	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
	}
	// Update is called once per frame
	void Update () {
		if (flipping) {
			if (timeSinceFlip <= flipTime) {
				Vector3 newRot = this.transform.rotation.eulerAngles;
				newRot.x = (timeSinceFlip/flipTime) * 180.0f;
				newRot.y = 0.0f;
				newRot.z = 0.0f;
				this.transform.rotation = Quaternion.Euler(newRot);
				//Debug.Log(timeSinceFlip / flipTime);
				if ((timeSinceFlip/flipTime) > .5f && !colorSwapped){
					mySprite.color = newColor;
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
	public void FlipCard(float r, float g, float b){
		newColor = new Color (r, g, b);
		flipping = true;
	}
}
