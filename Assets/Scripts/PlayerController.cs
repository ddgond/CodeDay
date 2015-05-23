using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject shot;
	public float fireRate;
	public int health = 100;
	private float nextFire;

	void Start ()
	{

	}

	public void TakeDamage (int damage){
		health -= damage;

	}

	void Update ()
	{
		if (health == 0) {
			Destroy(gameObject);
		}
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject thisShot = Instantiate(shot, transform.position, transform.rotation) as GameObject;

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
