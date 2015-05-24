using UnityEngine;
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


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	//	GetComponent<SpriteRenderer> ().sprite = right; 

	}

	public void TakeDamage (int damage){
		health -= damage;

	}
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "spikes") {
			health = 0;
		}
	}
	void Update ()
	{
		if (health <= 0) {
			GameObject.Find ("GameController").GetComponent <GameOverScript> ().GameOver ();
			Destroy(gameObject);
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
