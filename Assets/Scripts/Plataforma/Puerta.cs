using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField]
    private Transform tr;

    [SerializeField]
    private float totalTime;

    [SerializeField]
    private float currentTime;

    private float initTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            initTime = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentTime = Time.time - initTime;
            if (currentTime >= totalTime)
            {
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.transform.position = tr.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentTime = 0.0f;
        }
    }
}
