using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPanel;


    private int numHeart;

    private int currHeart = 0;


    private void Start()
    {
        numHeart = heartPanel.transform.childCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Sounds>().PlaySound(SOUND.HURT);
            GetComponent<Animator>().SetTrigger("Hurt");
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 dir = ((Vector2)(transform.position - collision.transform.position) + Vector2.up).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce(dir * 5, ForceMode2D.Impulse);
            LostLife();
            Invoke(nameof(BackNormalColor), 1.5f);
        }
    }

    public void LostLife()
    {
        if (currHeart < numHeart)
        {
            var heart = heartPanel.transform.GetChild(currHeart);
            heart.gameObject.SetActive(false);
            currHeart++;
        }
        else
        {
            GetComponent<Sounds>().PlaySound(SOUND.LOSE);
            GameManager.instance.LosePanel();
        }
    }

    public void BackNormalColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
