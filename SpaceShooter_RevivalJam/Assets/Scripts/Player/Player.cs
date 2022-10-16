using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string horizontalAxis;
    Vector2 moveInput;

    Rigidbody2D rb2d;
    Animator anim;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw(horizontalAxis);
        moveInput = new Vector2(moveX,0).normalized;

    }
	
	private void FixedUpdate()
	{
        rb2d.MovePosition(transform.position - (transform.up * moveInput.x) * speed * Time.fixedDeltaTime);
    }
}
