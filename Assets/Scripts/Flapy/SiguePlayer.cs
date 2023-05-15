using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguePlayer : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;


    private void FixedUpdate()
    {
        Vector2 position = playerTransform.position;
        position.y = transform.position.y;
        transform.position = position;
    }
}
