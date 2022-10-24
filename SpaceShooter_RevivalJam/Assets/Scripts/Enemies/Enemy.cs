using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite[] animationSprites;
    [SerializeField] float animationTime = 1.0f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] bool onLimit; 
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //private void Start()
    //{
    //    InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    //}

    //private void AnimateSprite()
    //{
    //    _animationFrame++;

    //    if (_animationFrame >= animationSprites.Length)
    //    {
    //        _animationFrame = 0;
    //    }

    //    _spriteRenderer.sprite = animationSprites[_animationFrame];
    //}

    private void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;

        //Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        //Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        //foreach (Transform Enemy in transform) 
        //{
        //    if (!Enemy.gameObject.activeInHierarchy){
        //        continue;
        //    }

        //    if (_direction == Vector3.right && Enemy.position.x >= (rightEdge.x - 1.0f)){
        //        AdvanceRow();
        //        break;
        //    } else if (_direction == Vector3.left && Enemy.position.x < (leftEdge.x + 1.0f)){
        //        AdvanceRow();
        //        break;
        //    }
        //}
        if (onLimit)
		{
            speed = -1;

		}
        else if (!onLimit)
		{
            speed = 1;
		}
    }

    //private void AdvanceRow()
    //{
    //    _direction.x *= -1.0f;

    //    Vector3 position = this.transform.position;
    //    position.y -= 1.0f;
    //    this.transform.position = position;

    //    // Flip the direction the invaders are moving
    //    _direction = new Vector3(-_direction.x, 0f, 0f);
    //}
    private void GoDownARow()
	{
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
    }
	//   private void MoveRight()
	//{

	//}
	//   private void MoveLeft()
	//{
	//       // Flip the direction the invaders are moving
	//           _direction = new Vector3(-_direction.x, 0f, 0f);
	//   }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        onLimit = !onLimit;
	}
}
