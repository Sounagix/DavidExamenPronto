using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    [SerializeField]
    private KeyCode arriba;
    [SerializeField]
    private KeyCode abajo;
    [SerializeField]
    private KeyCode derecha;
    [SerializeField]
    private KeyCode izquierda;

    [SerializeField]
    private float velocidad;

    private Vector2 posicionInicial;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private bool muriendo = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Physics2D.gravity = Vector2.zero;
        posicionInicial = transform.position;
    }


    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(arriba))
            {
                animator.SetBool("Top", true);
                if (animator.GetBool("Down"))
                {
                    animator.SetBool("Down", false);
                }
                Muevete(Vector2.up);
               
            }
            else if (Input.GetKey(abajo))
            {
                animator.SetBool("Down", true);
                Muevete(Vector2.down);
                if (animator.GetBool("Top"))
                {
                    animator.SetBool("Top", false);
                }

            }
            else if (Input.GetKey(derecha))
            {
                Muevete(Vector2.right);
                spriteRenderer.flipX = false;
                if (animator.GetBool("Top"))
                {
                    animator.SetBool("Top", false);
                }
                if (animator.GetBool("Down"))
                {
                    animator.SetBool("Down", false);
                }
            }
            else if (Input.GetKey(izquierda))
            {
                Muevete(Vector2.left);
                spriteRenderer.flipX = true;
                if (animator.GetBool("Top"))
                {
                    animator.SetBool("Top", false);
                }
                if (animator.GetBool("Down"))
                {
                    animator.SetBool("Down", false);
                }
            }
        }
    }

    private void Muevete(Vector2 dir)
    {
        transform.Translate(dir * Time.deltaTime * velocidad);
    }

    public void ResetPacMan()
    {
        transform.position = posicionInicial;
        muriendo = false;
    }

    public void InitDieAnimation()
    {
        if (!muriendo)
        {
            animator.SetTrigger("Die");
            muriendo = true;
        }
    }
}
