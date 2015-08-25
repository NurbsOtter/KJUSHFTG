using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeedTosser : MonoBehaviour
{
	public GameObject[] seeds;
	private int curSeed = 0;
	private int numCakeSeeds = 5;
	private int numGrassSeeds = 2;
	private int numTurretSeeds = 1;
	public Quaternion cakeRot;
	public Collider player;
	public GameObject canvas;
	public Transform holdPoint;
	public GameObject holdVictim;
	public Text cakeUI;
	public float hunger=0.0f;
	public Text grassUI;
	public Text turretUI;
	public Text hungerText;
	// Use this for initialization
	void Start ()
	{
		cakeRot = Quaternion.Euler (new Vector3 (-90.0f, 0.0f, 0.0f));
		canvas = GameObject.Find ("HUD Canvas");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hunger < 100.0f) {
			hunger += .1f * Time.deltaTime;
			hungerText.text = "Kim Jong Unger: " + Mathf.RoundToInt (hunger) + "%";
		} else {
			//TODO:DIE
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			curSeed = 0;
			canvas.SendMessage ("setWeapon", 0, SendMessageOptions.RequireReceiver);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			curSeed = 1;
			canvas.SendMessage ("setWeapon", 1, SendMessageOptions.RequireReceiver);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			curSeed = 2;
			canvas.SendMessage("setWeapon",2,SendMessageOptions.RequireReceiver);
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Vector3 newPos = transform.position + transform.forward * 1.5f;
			if (curSeed == 0 && numCakeSeeds >0){
				numCakeSeeds--;
				cakeUI.text = numCakeSeeds.ToString();
				GameObject newSeed = (GameObject)Instantiate (seeds [curSeed], newPos, cakeRot);
				newSeed.SendMessage("activateSeed");
				Rigidbody seedPhys = newSeed.GetComponent<Rigidbody> ();
				seedPhys.AddForce (transform.forward * 50.0f);
                GetComponent<AudioSource>().Play();
			}
			if (curSeed == 1 && numGrassSeeds >0){
				numGrassSeeds--;
				grassUI.text = numGrassSeeds.ToString();
				GameObject newSeed = (GameObject)Instantiate (seeds [curSeed], newPos, cakeRot);
				newSeed.SendMessage("activateSeed");
				Rigidbody seedPhys = newSeed.GetComponent<Rigidbody> ();
                seedPhys.AddForce(transform.forward * 50.0f);
                GetComponent<AudioSource>().Play();
			}
			if (curSeed == 2 && numTurretSeeds >0){
				numTurretSeeds--;
				turretUI.text = numTurretSeeds.ToString();
				GameObject newSeed = (GameObject)Instantiate (seeds [curSeed], newPos, cakeRot);
				newSeed.SendMessage("activateSeed");
				Rigidbody seedPhys = newSeed.GetComponent<Rigidbody> ();
                seedPhys.AddForce(transform.forward * 50.0f);
                GetComponent<AudioSource>().Play();
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f)) {
				if (hit.collider.CompareTag("cakeSeed")){
					numCakeSeeds++;	
					cakeUI.text = numCakeSeeds.ToString();
				}
				if (hit.collider.CompareTag("grassSeed")){
					numGrassSeeds++;
					grassUI.text = numGrassSeeds.ToString();
				}
				if (hit.collider.CompareTag("turretSeed")){
					numTurretSeeds++;
					turretUI.text = numTurretSeeds.ToString();
				}
				if (hit.collider.CompareTag("cake")){
					hunger -= 25.0f;
					if (hunger < 0.0f){
						hunger = 0.0f;
					}
					hungerText.text = "Kim Jong Unger: " + Mathf.RoundToInt (hunger) + "%";
				}
				hit.collider.SendMessage ("nomnom", SendMessageOptions.DontRequireReceiver);
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (holdVictim == null || holdVictim.Equals(null)) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f)) {
					if (hit.collider.gameObject.CompareTag ("cake")) {
						holdVictim = hit.collider.gameObject;
					}
					if (hit.collider.gameObject.CompareTag("button")){
						hit.collider.gameObject.SendMessage("pushButton");
					}
				}
			}else{
				holdVictim = null;
			}
		}
		if (holdVictim != null || !holdVictim.Equals (null)) {
			holdVictim.transform.position = holdPoint.position;
		}
		RaycastHit butHit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out butHit,15.0f)) {
			if (butHit.collider.gameObject.CompareTag("button")){
				butHit.collider.gameObject.SendMessage("isSelected");
			}
		}
	}
}
