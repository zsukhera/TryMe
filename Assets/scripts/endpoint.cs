using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour
{
    public GameObject nextLevelScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            nextLevelScreen.SetActive(true);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
