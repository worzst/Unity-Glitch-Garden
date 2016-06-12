﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start() {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		//secondsLeft = levelSeconds;

		FindYouWin();
		winLabel.SetActive(false);
	}

	void FindYouWin() {
		winLabel = GameObject.Find("You Win");
		if (!winLabel) {
			Debug.LogWarning("Please create You Win");
		}
	}



	// Update is called once per frame
	void Update() {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}
