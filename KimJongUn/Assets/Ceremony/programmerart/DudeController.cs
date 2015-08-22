using UnityEngine;
using System.Collections;
public interface IKillDude: UnityEngine.EventSystems.IEventSystemHandler{
	void killDude();
}
public class DudeController : MonoBehaviour, IKillDude {
	bool alive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void killDude(){
		Destroy (this.gameObject);
	}
}
