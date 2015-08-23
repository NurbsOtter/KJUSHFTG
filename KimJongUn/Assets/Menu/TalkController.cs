using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TalkController : MonoBehaviour {
	public Text UIName;
	public Text UITalk;
	// Use this for initialization
	void Start () {
		UIName.text = "";
		UITalk.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PrintMessage(string inMessage){
		string[] messages = inMessage.Split (':');
		UIName.text = messages [0];
		UITalk.text = messages [1];
	}
}
