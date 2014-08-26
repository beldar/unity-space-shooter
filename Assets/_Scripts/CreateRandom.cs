using UnityEngine;
using System.Collections;

public class CreateRandom : MonoBehaviour {
	public GameObject enemy;

	void Start () {
		InvokeRepeating("CreateRandomEnemy",0.01f,2.0f);
	}
	
	void CreateRandomEnemy(){
		Vector3 spawnPosition = new Vector3 (Random.Range (-6, 6), 0, 16);
		transform.rotation = Quaternion.Euler(180, 0, 0); 

		Instantiate(enemy,spawnPosition, transform.rotation);
	}
}
