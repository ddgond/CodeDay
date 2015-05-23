using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float fireRate = 3f;
	public GameObject shot;

	private float timeSinceFire = 0f;

	void Start () {

	}

	void Update () {
		timeSinceFire += Time.deltaTime;
		if (timeSinceFire > fireRate) {
			timeSinceFire = 0f;
			Instantiate(shot, transform.position, transform.rotation);
		}
	}
}
