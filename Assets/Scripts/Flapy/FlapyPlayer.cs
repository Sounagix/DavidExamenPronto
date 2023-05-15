using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapyPlayer : MonoBehaviour
{
    [SerializeField]
    private KeyCode barra;

    [SerializeField]
    private float velocidadSalto;

    [SerializeField]
    private float velocidadMovimientoDerecha;

    private Rigidbody2D rb;

    private Vector3 initPosition;

    private Animator animator;

    private bool muriendo = false;

    private int puntos = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        initPosition = transform.position;
    }


    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(barra))
            {
                Vuela();
            }
        }
    }

    private void FixedUpdate()
    {
        MueveDerecha();
        animator.SetFloat("VelocidadVolar", rb.velocity.normalized.y);
    }

    private void MueveDerecha()
    {
        rb.AddForce(Vector2.right * velocidadMovimientoDerecha);
    }

    private void Vuela()
    {
        if (!muriendo) 
        {
            rb.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!muriendo && collision.gameObject.CompareTag("Suelo")) 
        {
            muriendo = true;
            animator.SetBool("Muerte", true);
            Time.timeScale = 0.1f;
            Invoke(nameof(ResetPlayer), 0.15f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puntos"))
        {
            puntos++;
            CanvasActions.ActualizaPuntos(puntos);
        }
    }

    private void ResetPlayer()
    {
        CanvasActions.ReseteaPuntos();
        puntos = 0;
        animator.SetBool("Muerte", false);
        muriendo = false;
        Time.timeScale = 1.0f;
        transform.position = initPosition;
        rb.velocity = Vector2.zero;
    }


    public void LlegaMeta()
    {
        rb.velocity = Vector2.zero;
        Time.timeScale = 0.1f;
    }
}
