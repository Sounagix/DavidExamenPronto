using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    [SerializeField]
    private Color colorEnter;

    [SerializeField]
    private Color colorStay;

    [SerializeField]
    private Color colorExit;

    [SerializeField]
    private TextMeshProUGUI text;

    private SpriteRenderer spR;

    private int contador = 0;


    private void Awake()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contador++;
            text.text = contador.ToString();
            spR.color = colorEnter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spR.color = colorExit;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spR.color = colorStay;
        }
    }
}
