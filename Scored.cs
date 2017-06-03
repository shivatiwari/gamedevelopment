using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scored : MonoBehaviour {

	static int scored = 0;
	static int highScore = 0;
	public Text scorePoints;

	static Scored instance;
	static public void AddPoint(){
		if (instance.bird.dead) {
			return;
		}

		scored++;
		if (scored > highScore) {

			highScore = scored;
		}

	}

	Birdmovement bird;

	void Start()
	{
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.LogError ("no object with tag 'Player'");
		}
		bird = player_go.GetComponent<Birdmovement>();
		scored = 0;
		highScore = PlayerPrefs.GetInt ("highScore", 0);

	}

	void OnDestroy()
	{
		instance = null;
		PlayerPrefs.SetInt ("highScore", highScore);
	}

	void Update () {

		GetComponent<Text>().text = " Score: " + scored + "\n High Score:" + highScore;

	}
}﻿