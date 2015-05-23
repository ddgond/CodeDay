using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 5;

	private Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}

	void Start () {

	}

	public void Target (GameObject target) {
		transform.rotation = Quaternion.LookRotation (target.transform.position - transform.position) * Quaternion.Euler (0, 90, 90);
		rb.velocity = (target.transform.position - transform.position).normalized * speed;
	}

}
