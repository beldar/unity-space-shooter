using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour {

	protected Vector3 velocity;
	public Transform _transform;
	public Transform shotSpawn;
	public GameObject bolt;

	public virtual void Start () {
		_transform = GetComponent<Transform>();
		velocity = new Vector3(0,0, -Random.Range(0.5f,1.5f));
		InvokeRepeating("Shoot",0.01f,2.0f);
	}

	public virtual void Update(){
		_transform.Translate ( -velocity.x*Time.deltaTime,0,velocity.z*Time.deltaTime,Space.World);
	}

	public void Shoot() {
		Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
		audio.Play ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bolt")
			Destroy(gameObject);
	}
}
