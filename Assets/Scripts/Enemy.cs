using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField]
    //private Transform initPosition;

    //[SerializeField]
    //private Transform endPosition;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    private Vector2 dir = Vector2.right;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);        
    }

    public void ChangeDir()
    {
        dir *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
