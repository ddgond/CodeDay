using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject Gshot;
	public GameObject AGshot;
	public float fireRate;
	public int health = 100;
	public Sprite right;
	public Sprite left;
	public Sprite middle;
	private float nextFire;
	private bool playedSoundThingy = false;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	
	
	// Reference to the PlayerShooting script.
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	


	
	
	public void TakeDamage (int amount)
	{
		damaged = true;
		health -= amount;
		healthSlider.value = health;

	}
	
	
	void Death ()
	{
		isDead = true;
	}       


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();

	}



	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "spikes") {
			health = 0;
		}
	}

	void PlayTheSoundThingy () {
		if (!playedSoundThingy) {
			GetComponent<AudioSource> ().Play ();
			playedSoundThingy = true;
		}
	}

	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		damaged = false;
		if (health <=0){
			PlayTheSoundThingy ();
			Destroy(gameObject,4.0f);
			GameObject.Find ("GameController").GetComponent <GameOverScript> ().GameOver ();
			
		}
		if (Physics.gravity.x == 0) {
			GetComponent<SpriteRenderer> ().sprite = middle;
		}
		else if (Physics.gravity.x > 0f ) {
			GetComponent<SpriteRenderer> ().sprite = right; 
		} else if (Physics.gravity.x < 0f) { 
			GetComponent<SpriteRenderer> ().sprite = left;
		}

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject thisShot = Instantiate(AGshot, transform.position, transform.rotation) as GameObject;

			Vector3 target = Vector3.zero;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				target = hit.point;
				target = new Vector3 (target.x, target.y, 0);
				thisShot.GetComponent<Mover>().Target(target);
				thisShot.GetComponent<Mover>().spawnedBy = gameObject.name;
			}
		}
		if (Input.GetButton("Fire2") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject thisShot = Instantiate(Gshot, transform.position, transform.rotation) as GameObject;
			
			Vector3 target = Vector3.zero;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				target = hit.point;
				target = new Vector3 (target.x, target.y, 0);
				thisShot.GetComponent<Mover>().Target(target);
				thisShot.GetComponent<Mover>().spawnedBy = gameObject.name;
			}
		}
	}
	
	void FixedUpdate ()
	{

	}
}
