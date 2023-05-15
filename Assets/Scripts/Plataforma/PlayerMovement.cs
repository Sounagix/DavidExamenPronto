using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode movimientoDerecha;   // tecla D

    public KeyCode movemientoIzquierda; // tecla A

    public KeyCode teclaSalto;          //  Space

    public Rigidbody2D rigidbody2D;

    public float velocidad;

    public float velocidadSalto;


    // Se llama muchas veces x segundo
    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(movimientoDerecha))    // D
            {
                print("Tecla D");
                MueveJugador(Vector2.right);
            }
            else if (Input.GetKey(movemientoIzquierda)) //A
            {
                print("Tecla A");
                MueveJugador(Vector2.left);
            }

            if (Input.GetKey(teclaSalto))
            {
                print("SALTO");
                SaltaJugador();
            }
        }
    }

    private void MueveJugador(Vector2 direccion)
    {
        rigidbody2D.AddForce(direccion * velocidad);
    }

    private void SaltaJugador()
    {
        rigidbody2D.AddForce(Vector2.up * velocidadSalto);
    }
}
