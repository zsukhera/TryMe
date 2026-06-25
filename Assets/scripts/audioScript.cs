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
        audioSource.PlayOneShot(jumpSound);
    }
    
    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound, 0.5f);
    }

    public void PlayNextLevelSound()
    {
        audioSource.PlayOneShot(nextLevelSound);
    }
    /*
     * 
     * 
        audioSource.PlayOneShot(gameOverClip, 0.2f); // 20% volume
        audioSource.PlayOneShot(fallingClip, 0.5f);  // 50% volume
     */
    public void playFallingsound()
    {
        audioSource.PlayOneShot(playerFalling);
    }
}
