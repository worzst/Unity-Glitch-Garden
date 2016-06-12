using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSrc;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		//Debug.Log("Don't destroy on load " + name);
	}

	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		//Debug.Log("Playing Clip " + thisLevelMusic);

		if (thisLevelMusic && audioSrc && audioSrc.clip != thisLevelMusic) {
			audioSrc.clip = thisLevelMusic;
			audioSrc.loop = true;
			audioSrc.Play();
		}
	}

	public void ChangeVolume(float volume) {
		audioSrc.volume = volume;
	}
}
