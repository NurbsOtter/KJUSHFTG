using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	void SetScore(float score) {
        GetComponent<Text>().text = "" + Mathf.FloorToInt(score);
    }
}
