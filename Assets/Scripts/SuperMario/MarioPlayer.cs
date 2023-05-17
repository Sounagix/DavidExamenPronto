using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayer : MonoBehaviour
{
    [SerializeField]
    private KeyCode derecha;

    [SerializeField]
    private KeyCode izquierda;

    [SerializeField]
    private KeyCode salto;

    [SerializeField]
    private KeyCode abajo;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private float velocidadSalto;

    [SerializeField]
    private float maximaVelocidad;

    private Rigidbody2D rb;

    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(salto) && PuedeSaltar())
            {
                Salta();
            }
            else if (Input.GetKey(derecha))
            {
                Mueve(Vector2.right);
            }
            else if (Input.GetKey(izquierda))
            {
                Mueve(Vector2.left);
            }
        }
    }

    private void Mueve(Vector2 dir)
    {
        if (rb.velocity.magnitude < maximaVelocidad) 
            rb.AddForce(dir * velocidad, ForceMode2D.Impulse);
    }

    private void Salta()
    {
        rb.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
    }

    private bool PuedeSaltar()
    {
        int layer = (1 << 7);
        Debug.DrawLine(transform.position, transform.position + (1 * -transform.up), Color.red, 1.0f);
        float distance = GetComponent<CapsuleCollider2D>().size.y / 2 + 0.2f;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -transform.up, distance, layer);
        return hit2D.collider != null;
    }

    public void AgrandaMario()
    {
        animator.SetTrigger("Crecer");
    }

    public void AplicaEfectoDeCrecer()
    {
        CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
        capsule.size = new Vector2(capsule.size.x, 2);
        animator.SetBool("Grande", true);
    }
}
