using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Update () {
		if ((Input.GetButton("Fire1") || Input.GetKeyDown (KeyCode.Space)) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 mov = new Vector3 (h, 0.0f, v);
		rigidbody.velocity = mov * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f, 
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax) 
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
