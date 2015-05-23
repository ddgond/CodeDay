using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float fireRate = 2f;
	public GameObject shot;

	private float timeSinceFire = 0f;
	private GameObject player;

	void Start () {
		player = GameObject.Find ("Player");
	}

	void Update () {
		timeSinceFire += Time.deltaTime;
		if (timeSinceFire > fireRate) {
			timeSinceFire = 0f;
			GameObject thisShot = Instantiate(shot, transform.position, transform.rotation) as GameObject;
			thisShot.GetComponent<Mover>().Target(player);
		}
	}
}
