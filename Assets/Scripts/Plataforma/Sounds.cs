using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SOUND : int
{
    COIN, JUMP, HURT , MOVE, WIN , LOSE
}

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip coinSound;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioClip hurtSound;

    [SerializeField]
    private AudioClip loseSound;

    [SerializeField]
    private AudioClip winSound;


    private void Start()
    {
        audioSource = Camera.main./*transform.GetChild(0).*/GetComponent<AudioSource>();
    }

    public void PlaySound(SOUND sOUND)
    {
        switch (sOUND)
        {
            case SOUND.COIN:
                audioSource.PlayOneShot(coinSound);
                break;
            case SOUND.JUMP:
                audioSource.PlayOneShot(jumpSound);
                break;
            case SOUND.HURT:
                audioSource.PlayOneShot(hurtSound);
                break;
            case SOUND.MOVE:
                break;
            case SOUND.WIN:
                audioSource.clip = winSound;
                audioSource.Play();
                break;
            case SOUND.LOSE:
                audioSource.clip = loseSound;
                audioSource.Play();
                break;
            default:
                break;
        }
    }
}