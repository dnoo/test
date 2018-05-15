using UnityEngine;

public class Bullet : MonoBehaviour {

	public int speed = 10;
	public float lifeTime = 5;
	
	// Update is called once per frame
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}
}
