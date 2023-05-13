using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.GetComponent<Player>().JugadorEnEscalera(true);
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().JugadorEnEscalera(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().JugadorEnEscalera(true);
        }
    }
}
