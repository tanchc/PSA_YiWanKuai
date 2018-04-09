﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

    private AudioSource[] audioSources;
    private AudioSource BGM;
    private AudioSource clearClip;
    private AudioSource loseClip;

    public AudioMixer mixer;

	// Use this for initialization
	void Start () {
        audioSources = GetComponents<AudioSource>();
        if (Statics.stageNumber % 5 == 0) {
            BGM = audioSources[3];
        }
        else {
            BGM = audioSources[0];
        }
        if (audioSources.Length > 1) {
            loseClip = audioSources[1];
        }
        if (audioSources.Length > 2) {
            clearClip = audioSources[2];
        }
        BGM.Play();
        mixer.SetFloat("BGMVol", PlayerPrefs.GetFloat("BGMVol"));
        mixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
	}
	
	public IEnumerator playLose () {
        BGM.volume = 0f;
        loseClip.Play();
        yield return new WaitWhile(() => loseClip.isPlaying);
        while (BGM.volume < 1.0f) {
            BGM.volume += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator playClear() {
		BGM.volume = 0f;
        clearClip.Play();
        yield return new WaitWhile(() => clearClip.isPlaying);
        while (BGM.volume < 1.0f) {
            BGM.volume += Time.deltaTime;
            yield return null;
        }
    }
}
