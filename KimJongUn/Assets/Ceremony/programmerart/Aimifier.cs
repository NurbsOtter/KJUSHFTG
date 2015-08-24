using UnityEngine;
using System.Collections;

public class Aimifier : MonoBehaviour {
	RectTransform rect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rect = GetComponent<RectTransform> ();
		Vector3 newPos = rect.position;
		newPos.x = Input.mousePosition.x;
		newPos.y = Input.mousePosition.y;
		rect.position = newPos;
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if (hit.collider != null){
				Debug.Log (hit.collider.gameObject);
				hit.collider.gameObject.SendMessageUpwards("killDude",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
