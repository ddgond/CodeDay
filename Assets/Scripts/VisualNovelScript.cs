using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VisualNovelScript : MonoBehaviour {

	public List<string> dialogLines;
	public string speaker;
	public GameObject nextDialog;
	public float delay = 0.4f;
	public bool autoAdvance = false;
	public Sprite speakerSprite;
	public GameObject card;
	public float cardDisplayTime;

	private float timePassed;
	private int index;
	private Text dialog;
	private Text speak;
	private Image character;
	private float cardTimePassed;
	private bool cardDisplaying = false;
	private bool fading = false;
	private float startTime;

	void Awake () {
		dialog = GameObject.Find ("Dialog").GetComponent<Text> ();
		speak = GameObject.Find ("Speaker").GetComponent<Text> ();
		character = GameObject.Find ("Character").GetComponent<Image> ();
		index = 0;
	}

	void Start () {
		timePassed = 0f;
		cardTimePassed = 0f;
		dialog.text = dialogLines[index];
		speak.text = speaker;
		character.sprite = speakerSprite;
	}
	

	void Update () {
		timePassed += Time.deltaTime;
		if (fading) {
			if (Time.time - startTime >= 1) {
				Application.LoadLevel("Stage 01");
			}
		}
		if (card != null) {
			if (cardDisplaying) {
				cardTimePassed += Time.deltaTime;
			}
			if (cardTimePassed > cardDisplayTime) {
				Advance ();
			}
			if (timePassed > delay) {
				if (autoAdvance) {
					timePassed = -20f;
					Advance ();
				}
			}
		} else {
			if (timePassed > delay) {
				if (autoAdvance) {
					timePassed = 0f;
					Advance ();
				}
				if (Input.GetKey (KeyCode.Space)) {
					timePassed = 0f;
					index++;
					if (index < dialogLines.Count)
						dialog.text = dialogLines [index];
					else {
						Advance ();
					}
				}
			}
		}

	}

	void Advance () {
		if (dialog.text == "*LOADING: CLOVE_DATA*" && !cardDisplaying) {
			GameObject newCard = Instantiate(card);
			newCard.transform.SetParent(GameObject.Find ("Canvas").transform);
			newCard.transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
			newCard.name = "ID Card";
			cardDisplaying = true;
		} else {
			if (nextDialog != null) {
				VisualNovelScript next = nextDialog.GetComponent<VisualNovelScript> ();
				index = 0;
				card = next.card;
				dialogLines = next.dialogLines;
				dialog.text = dialogLines [index];
				speak.text = next.speaker;
				nextDialog = next.nextDialog;
				autoAdvance = next.autoAdvance;
				speakerSprite = next.speakerSprite;
				character.sprite = next.speakerSprite;
				delay = next.delay;
				timePassed = 0f;
				cardTimePassed = 0f;
				cardDisplayTime = next.cardDisplayTime;
				if (speak.text == "Clove" && cardDisplaying) {
					cardDisplaying = false;
					Destroy(GameObject.Find ("ID Card"));
				}
			} else {
				Destroy (GameObject.Find ("Panel"));
				FadeOut ();
			}
		}
	}

	void FadeOut () {
		Image characterSprite = GameObject.Find ("Character").GetComponent<Image> ();
		characterSprite.CrossFadeAlpha (0, 1, false);
		fading = true;
		startTime = Time.time;
	}
}
