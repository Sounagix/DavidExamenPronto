using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Vector2 dir;

    [SerializeField]
    private float velocidad;


    private void FixedUpdate()
    {
        transform.Translate(dir * velocidad * Time.deltaTime);
    }

    public void ChangeDir(Vector2 vector2)
    {
        dir = vector2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PacMan>().InitDieAnimation();
        }
    }


}
