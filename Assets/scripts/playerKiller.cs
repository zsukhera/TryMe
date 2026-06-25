using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for a trigger that shall kill the player and play it's animation
public class playerKiller : MonoBehaviour
{
    public GameObject player;
    public GameObject audioManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        audioManager = GameObject.Find("audioManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<player>().isDead = true;
        audioManager.GetComponent<audioScript>().PlayGameOverSound();
        audioManager.GetComponent <audioScript>().playFallingsound();
    }
}
