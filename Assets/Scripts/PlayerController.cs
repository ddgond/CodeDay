using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	void Start ()
	{

	}
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			/*GameObject */thisShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) /*as GameObject*/;
			/*thisShot.GetComponent<Mover>().Target(Input.mouse);
			thisShot.GetComponent<Mover>().spawnedBy = gameObject.name;*/
		}
	}
	
	void FixedUpdate ()
	{

	}
}
