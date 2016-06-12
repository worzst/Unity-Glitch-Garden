using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	public int starCost = 100;
	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	// Only being used as a tag for now!
	public void AddStars (int amount) {
		starDisplay.AddStars(amount);
	}
}
