﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpdatableText : MonoBehaviour {

    public string textToSet;
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        switch (textToSet) {
            case "Timer":
                text.text = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().timeLeft.ToString("F0");
                break;
			case "Goal":
				text.text = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().scoreToClear.ToString ();
				break;
            case "StageNumber":
                text.text = Statics.stageNumber.ToString();
                break;
			case "Score": 
				text.text = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().getCurrScore ().ToString ();
				break;
            case "FreezeLevel":
                text.text = Statics.freezeLevel.ToString();
                break;
			case "StandardizeLevel":
				text.text = Statics.standardizeLevel.ToString ();
				break;
            default:
                text.text = textToSet;
                break;
        }
    }
}
