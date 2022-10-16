using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float damage;
	[SerializeField] float timeToDestroy;
	Rigidbody2D rb2d;
	Animator anim;
	// Start is called before the first frame update
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Destroy(this.gameObject, timeToDestroy);
	}
	private void FixedUpdate()
	{
		rb2d.velocity = transform.position + transform.right * speed * Time.fixedDeltaTime;
	} //new Vector2(1,0)
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(this.gameObject);
		

		if (collision.tag == "Shleter")
		{
			Debug.Log("I hit a shelter");
			Destroy(this.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(this.gameObject);
		Debug.Log("I hit a shelter");
	}
	
}
