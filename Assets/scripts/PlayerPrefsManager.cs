using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";


	#region Master Volume
	public static void SetMasterVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Set master volume out of range!");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	#endregion


	#region Level Unlock
	public static void SetLevelUnlock (int level) {
		if (level <= (LevelManager.GetLevelCount() - 1)) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level) {
		if (level <= (LevelManager.GetLevelCount() - 1)) {
			int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level);
			bool isLevelUnlocked = (levelValue == 1);
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to ask for unlocked level not in build order");
			return false;
		}
	}
	#endregion


	#region Difficulty
	public static void SetDifficulty(float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Set difficulty out of range!");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
	#endregion
}
