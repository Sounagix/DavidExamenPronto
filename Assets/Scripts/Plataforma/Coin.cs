using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Sounds>().PlaySound(SOUND.COIN);
            collision.GetComponent<Player>().AddCoin();
            Destroy(gameObject);
        }
    }
}
