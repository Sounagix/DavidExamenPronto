using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CanvasActions
{
    public static Action<int> ActualizaPuntos;
    public static Action ReseteaPuntos;
}

public class PuntosControl : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numeros;

    [SerializeField]
    private Image numIzq;

    [SerializeField]
    private Image numDer;

    private void OnEnable()
    {
        CanvasActions.ActualizaPuntos += MuestraPuntos;
        CanvasActions.ReseteaPuntos += ReseteaPuntos;
    }

    private void OnDisable()
    {
        CanvasActions.ActualizaPuntos -= MuestraPuntos;
        CanvasActions.ReseteaPuntos -= ReseteaPuntos;
    }

    public void MuestraPuntos(int puntos)
    {
        string p = puntos.ToString();
        if (p.Length > 1)  
        {
            int der = (int)p[1];
            int izq = (int)p[0];
            numDer.sprite = numeros[der];
            numIzq.sprite = numeros[izq];
        }
        else // "0"
        {
            numDer.sprite = numeros[puntos];
        }
    }

    public void ReseteaPuntos()
    {
        numDer.sprite = numeros[0];
        numIzq.sprite = numeros[0];
    }
}
