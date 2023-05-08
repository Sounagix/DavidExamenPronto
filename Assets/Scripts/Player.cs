using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private KeyCode movDer;

    [SerializeField]
    private KeyCode movIzq;

    [SerializeField]
    private KeyCode salto;

    [SerializeField]
    private KeyCode movAbajo;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float jumpSpeed;

    private Rigidbody2D rb2D;

    private bool eNELSuelo = false;



    // Awake -> getcmp, poner x valor a una variable
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start ->
    private void Start()
    {
        
    }


    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(movDer))
            {
                MovePlayer(Vector2.right);
            }
            else if (Input.GetKey(movIzq))
            {
                MovePlayer(Vector2.left);
            }
            else if (Input.GetKeyDown(salto))
            {
                MovePlayer(Vector2.up);
            }
            else if (Input.GetKey(movAbajo))
            {
                MovePlayer(Vector2.down);
            }
        }
    }


    private void MovePlayer(Vector2 dir)
    {
        if (eNELSuelo && dir.Equals(Vector2.up))
        {
            rb2D.AddForce(dir * jumpSpeed, ForceMode2D.Impulse);
        }
        else if (rb2D.velocity.magnitude < maxSpeed && !dir.Equals(Vector2.up))
        {
            if (dir.Equals(Vector2.up))
            {
                rb2D.AddForce(dir * jumpSpeed, ForceMode2D.Impulse);
            }
            else
            {
                rb2D.AddForce(dir * moveSpeed, ForceMode2D.Impulse);
            }
        }
    }


    //private bool CanJump()
    //{
    //    // donde guardo la informacion de lo que alcanza el rayo
        
    //    Vector2 dir = -transform.up;
    //    float distance = 3.0f;
    //    int layer = (1 << 7);

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance, layer);

    //    if (hit != null && hit.collider.CompareTag("Suelo"))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            eNELSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            eNELSuelo = false;
        }
    }



    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }
}
