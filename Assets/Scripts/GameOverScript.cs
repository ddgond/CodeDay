using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOver;
	public GameObject win;
	[HideInInspector] public bool gameEnded = false;

	private bool restartable;
	private int enemyCount;

	void Awake () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		enemyCount = enemies.Length;
	}

	void Start () {
		restartable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (restartable && Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (enemyCount <= 0) {
			Win ();
		}
	}

	public void GameOver () {
		if (!gameEnded) {
			gameEnded = true;
			Instantiate (gameOver);
			restartable = true;
		}
	}

	public void enemyKilled () {
		enemyCount--;
	}

	void Win () {
		if (!gameEnded) {
			gameEnded = true;
			Instantiate (win);
			restartable = true;
		}
	}
}
