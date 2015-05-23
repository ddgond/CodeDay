using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody rb;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal * speed, rb.velocity.y, 0.0f);
		
		rb.velocity = movement;
	}
}
