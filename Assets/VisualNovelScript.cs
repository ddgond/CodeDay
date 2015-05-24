using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VisualNovelScript : MonoBehaviour {

	public List<string> dialogLines;
	public float delay = 1f;

	private float timePassed;
	private int index;
	private Text dialog;

	void Awake () {
		dialog = GameObject.Find ("Dialog").GetComponent<Text>();
		index = 0;
	}

	void Start () {
		timePassed = 0f;
		dialog.text = dialogLines[index];
	}
	

	void Update () {
		timePassed += Time.deltaTime;
		if (timePassed > delay) {
			if (Input.GetKey (KeyCode.Space)) {
				timePassed = 0f;
				index++;
				if (index < dialogLines.Count)
					dialog.text = dialogLines [index];
			}
		}
	}
}
