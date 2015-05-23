using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {

	public float gravityMultiplier = 3f;

	void Start () {
		Physics.gravity = Vector3.zero;
		Physics2D.gravity = Vector2.zero;
	}
	

	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 newGravity = new Vector3 (horizontal, vertical, 0f).normalized * gravityMultiplier;

		Physics.gravity = newGravity;
		Physics2D.gravity = Physics.gravity;
	}
	 
}
