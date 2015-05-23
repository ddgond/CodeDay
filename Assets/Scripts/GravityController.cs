using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {

	public float maxGravity = 3f;
	public float gravityChangeMultiplier = 0.2f;
	public float smoothing = 1f;

	void Start () {
		Physics.gravity = Vector3.zero;
		Physics2D.gravity = Vector2.zero;
	}
	

	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 newGravity = Vector3.ClampMagnitude (Physics.gravity + new Vector3 (horizontal * gravityChangeMultiplier, vertical * gravityChangeMultiplier, 0f), maxGravity);

		Physics.gravity = Vector3.Lerp (Physics.gravity, newGravity, smoothing);
		Physics2D.gravity = Physics.gravity;
	}
}
