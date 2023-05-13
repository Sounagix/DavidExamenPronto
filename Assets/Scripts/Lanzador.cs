using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBallPrefab;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minY;

    [SerializeField]
    private float bulletSpeedMax;

    [SerializeField]
    private float bulletSpeedMin;


    [SerializeField]
    private Vector2 dir;

    [SerializeField]
    private float lanzamientoTiempo;

    [SerializeField]
    private bool initFlip;


    private void Start()
    {
        InvokeRepeating(nameof(LanzaBolaFuego), 0, lanzamientoTiempo);
    }

    private void LanzaBolaFuego()
    {
        GameObject actualBolaDefuego = Instantiate(fireBallPrefab);
        Vector2 position = new Vector2(transform.position.x, Random.Range(minY, maxY));
        actualBolaDefuego.transform.position = position;
        actualBolaDefuego.GetComponent<SpriteRenderer>().flipX = initFlip;
        float speed = Random.Range(bulletSpeedMin,bulletSpeedMax);
        actualBolaDefuego.GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
