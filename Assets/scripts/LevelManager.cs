using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() {
		if (autoLoadNextLevelAfter <= 0) {
			//Debug.Log("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		//Debug.Log("Loading Level " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		//Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static int GetCurrentLevel() {
		return SceneManager.GetActiveScene().buildIndex;
	}

	public static int GetLevelCount() {
		//Debug.Log ("SceneCount: " + SceneManager.sceneCountInBuildSettings);
		return SceneManager.sceneCountInBuildSettings;
	}
}
