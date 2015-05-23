using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float smoothing = 0.2f;
	
	private GameObject player;
	private Rigidbody rb;
	private Vector3 velocity;
	private float z;
	
	void Awake () {
		player = GameObject.Find ("Player");
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	void Start () {
		velocity = Vector3.zero;
		z = transform.position.z;
	}
	
	void LateUpdate () {
		velocity = rb.velocity;
		Follow ();
	}
	
	void Follow () {
		transform.position = Vector3.SmoothDamp (transform.position, player.transform.position, ref velocity, smoothing);
		transform.position = new Vector3 (transform.position.x, transform.position.y, z);
	}
}
