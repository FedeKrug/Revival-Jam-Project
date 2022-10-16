using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
	[SerializeField] GameObject bulletToShoot;
	[SerializeField] private float cooldown;
	[SerializeField] float timeRemaining;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			Shoot();
		}
		if (Input.GetKey(KeyCode.C))
		{
			ContantShooting();

		}

	}

	public void Shoot()
	{
		Instantiate(bulletToShoot, transform.position, transform.rotation);
	}

	public void ContantShooting()
	{
		if (timeRemaining <=0)
		{
			timeRemaining = cooldown;
			Shoot();
		}
	}

}
