using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOver;

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
		Instantiate (gameOver);
		restartable = true;
	}
}
