using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public float speed = 1.0f;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length){
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform Enemy in this.transform) 
        {
            if (!Enemy.gameObject.activeInHierarchy){
                continue;
            }

            if (_direction == Vector3.right && Enemy.position.x >= (rightEdge.x - 1.0f)){
                AdvanceRow();
                break;
            } else if (_direction == Vector3.left && Enemy.position.x < (leftEdge.x + 1.0f)){
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

        // Flip the direction the invaders are moving
        _direction = new Vector3(-_direction.x, 0f, 0f);
    }
}
