using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float fireRate = 2f;
	public int health = 40;
	public GameObject shot;

	private float timeSinceFire = 0f;
	private GameObject player;

	void Start () {
		player = GameObject.Find ("Player");
	}

	void Update () {
		if (GameObject.Find ("GameController").GetComponent<GameOverScript> ().gameEnded)
			gameObject.SetActive (false);
		timeSinceFire += Time.deltaTime;
		if (timeSinceFire > fireRate) {
			timeSinceFire = 0f;
			GameObject thisShot = Instantiate(shot, transform.position, transform.rotation) as GameObject;
			player = GameObject.Find ("Player");
			if(player != null){
				thisShot.GetComponent<Mover>().Target(player);
				thisShot.GetComponent<Mover>().spawnedBy = gameObject.name;
			}
		}
	}

	public void TakeDamage (int damage) {
		health -= damage;
		if (health <= 0) {
			GameObject.Find ("GameController").GetComponent<GameOverScript> ().enemyKilled();
			Destroy (gameObject);
		}
	}
}
