using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameControllerObject == null) {
			Debug.Log ("Cannot find GameController Object");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary"
		    || (other.tag == "Enemy" && gameObject.tag == "Enemy")
		    || (other.tag == "Asteroid" && gameObject.tag == "Enemy")
		    || (other.tag == "Enemy" && gameObject.tag == "Asteroid")
		    || (other.tag == "Enemy" && gameObject.tag == "EnemyBolt")
		    || (other.tag == "EnemyBolt" && gameObject.tag == "Enemy")
		    || (other.tag == "EnemyBolt" && gameObject.tag == "Asteroid")
		    || (other.tag == "Asteroid" && gameObject.tag == "EnemyBolt")
		   )
		{
			return;
		}

		Instantiate(explosion, transform.position, transform.rotation);
		Debug.Log (gameObject.tag + " collided with " + other.tag);	
		if (other.tag == "Player" || (gameObject.tag == "Player" && other.tag == "EnemyBolt"))
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			if (!gameController.Die()) {
				Destroy(gameObject);
				return;
			}
		}
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	} 
}
