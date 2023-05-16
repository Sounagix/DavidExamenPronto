using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDir : MonoBehaviour
{
    [SerializeField]
    private Vector2[] direcciones;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int choice = Random.Range(0, direcciones.Length);
        collision.GetComponent<Ghost>().ChangeDir(direcciones[choice]);
    }
}
