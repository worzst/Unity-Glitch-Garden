using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (!levelManager) {
			Debug.LogError("No LevelManager found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.GetComponent<Attacker>()) {
			levelManager.LoadLevel("03b Lose");
		}
	}
}
