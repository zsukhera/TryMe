using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{

    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip nextLevelSound;
    public AudioClip playerFalling;
    public AudioClip playerDeath;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource exists, add one automatically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound, 0.5f);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound, 0.5f);
    }

    public void PlayNextLevelSound()
    {
        audioSource.PlayOneShot(nextLevelSound);
    }
    public void playFallingsound()
    {
        audioSource.PlayOneShot(playerFalling);
    }

    public void playDeathSound()
    {
        audioSource.PlayOneShot(playerDeath);
    }
}
