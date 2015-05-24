using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOver;
	[HideInInspector] public bool gameEnded = false;

	private bool restartable;

	// Use this for initialization
	void Start () {
		restartable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (restartable && Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void GameOver () {
		gameEnded = true;
		Instantiate (gameOver);
		restartable = true;
	}
}
