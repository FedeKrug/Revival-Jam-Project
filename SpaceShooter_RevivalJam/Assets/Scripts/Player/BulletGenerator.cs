using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] GameObject bulletToShoot;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
		{
            Shoot();
		}
    }

    public void Shoot()
	{
        Instantiate(bulletToShoot, transform.position, transform.rotation);
	}

}
