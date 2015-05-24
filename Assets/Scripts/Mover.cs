using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public int damage = 20;
	public float speed = 5;
	public GameObject explosion;
	[HideInInspector] public string spawnedBy;

	private Rigidbody rb;
	private bool exploded;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
		spawnedBy = null;
	}

	void Update () {
		transform.rotation = Quaternion.LookRotation (rb.velocity) * Quaternion.Euler (0, 90, 90);
	}

	void OnTriggerEnter (Collider other) {
		if (other.name != spawnedBy) {
			if(other.tag == "Player"){
				Debug.Log (true);
				other.GetComponent<PlayerController>().TakeDamage (damage);
			}
			if(other.tag == "Enemy" && spawnedBy == "Player"){
				other.GetComponent<EnemyController>().TakeDamage (damage);
			}
			GameObject exp = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
			Destroy (exp, 0.1f);


			Destroy (gameObject);
			//exploded = true;
		}
	}

	public void Target (GameObject target) {
		transform.rotation = Quaternion.LookRotation (target.transform.position - transform.position) * Quaternion.Euler (0, 90, 90);
		rb.velocity = (target.transform.position - transform.position).normalized * speed;
	}

	public void Target (Vector3 targetPosition) {
		transform.rotation = Quaternion.LookRotation (targetPosition - transform.position) * Quaternion.Euler (0, 90, 90);
		rb.velocity = (targetPosition - transform.position).normalized * speed;
	}

}
