using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGen : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] GameObject bullets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConstantShooting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ConstantShooting()
	{
        Instantiate(bullets, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(ConstantShooting());
	}
}
