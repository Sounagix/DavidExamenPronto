using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private Vector2 direccion;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private float velocidadMaxima;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.x < velocidadMaxima)
            rb.AddForce(direccion * velocidad * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void CambiaDireccion()
    {
        direccion *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Plataforma"))
            CambiaDireccion();
    }
}
