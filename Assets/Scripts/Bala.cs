using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().ResetPlayer();
            GetComponent<Animator>().SetTrigger("Explosion");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,1.0f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
