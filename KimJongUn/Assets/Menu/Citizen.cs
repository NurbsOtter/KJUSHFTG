using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Citizen : MonoBehaviour {

	// Use this for initialization
	public GameObject head;
	public GameObject arms;
	public GameObject legs;
	private Rigidbody2D phys;
	public string[] places;
	public string[] actions;
	public string[] objects;
	public GameObject talkCanv;
	public string name;
	public float timeToTalk = 0.0f;
	public string[] names;
	private string genSentance(){
		int sentanceToGen = Random.Range (0, 6);
		switch (sentanceToGen) {
		case 0:
			return "Let's go to the " + randomPlace() + "!";
			break;
		case 1:
			return "The Supreme Leader has blessed us with " + randomObject() + "!";
			break;
		case 2:
			return "Finally! The workers have made a " + randomObject() + " for my " + randomObject() + "!";
			break;
		case 3:
			return "Help me I'm trapped in a North Korean game studio in " + randomPlace();
			break;
		case 4:
			return "After I meet my manufacturing quota I hope the eternal president allows me to " + randomAction();
			break;
		case 5:
			return "I hear Americans are dogs who use " + randomObject() + " to " + randomAction();
			break;
		case 6:
			return "My cousin got caught " + randomAction() + " at the " + randomPlace() + " and they forced three generations of his family to eat " + randomObject() + " it was delicious!";
			break;
		default:
			return "";
		}
	}
	private Color genRandomColor(){
		Color colorOut = new Color ();
		colorOut.a = 1.0f;
		colorOut.g = Random.Range (0.0f, 1.0f);
		colorOut.b = Random.Range (0.0f, 1.0f);
		colorOut.r = Random.Range (0.0f, 1.0f);
		return colorOut;
	}
	private string randomPlace(){
		return places [Random.Range (0, places.Length)];
	}
	private string randomAction(){
		return actions [Random.Range (0, actions.Length)];
	}
	private string randomObject(){
		return objects [Random.Range (0, objects.Length)];
	}
	void Start () {
		this.GetComponent<SpriteRenderer> ().color = genRandomColor ();
		head.GetComponent<SpriteRenderer> ().color = genRandomColor ();
		arms.GetComponent<SpriteRenderer> ().color = genRandomColor ();
		legs.GetComponent<SpriteRenderer> ().color = genRandomColor ();
		phys = GetComponent<Rigidbody2D> ();
		timeToTalk = Random.Range (0.0f, 60.0f);
		name = names [Random.Range (0, names.Length)];
		talkCanv = GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		if (phys.velocity == Vector2.zero) {
			Vector2 newForce = new Vector2(Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f));
			phys.AddForce(newForce);
		}
		if (timeToTalk <= 0.0f) {
			string messageString = name + ":" + genSentance ();
			talkCanv.SendMessage ("PrintMessage", messageString);
			timeToTalk = Random.Range (10.0f, 60.0f);
		} else {
			timeToTalk -= Time.deltaTime;
		}
	}
}
