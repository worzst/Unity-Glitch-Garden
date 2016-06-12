using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

		parent = GameObject.Find("Defenders");
		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		if (Button.selectedDefender) {
			int defenderCost = Button.selectedDefender.GetComponent<Defenders>().starCost;
			if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
				SpawnDefender();
			} else {
				Debug.Log ("Insufficient stars to spawn");
			}
		}
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX, newY);
	}

	void SpawnDefender() {
		GameObject newDef = Instantiate(Button.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
		newDef.transform.parent = parent.transform;
	}
}
